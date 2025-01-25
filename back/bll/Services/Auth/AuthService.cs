using meero.entity;
namespace meero.bll.Service;


public class AuthService(IUserService us, IHashService hashService, IJWTService jwt): IAuthService {
    public string Login(UserModel user)
    {
        UserEntity? entity = us.GetByEmail(user.Email);
        
        if (entity == null){
            throw new UserNotFountException();
        }

        ApplicationUser applicationUser = new(){Name=entity.Name,Id=entity.Id,Role=entity.Role};

        if (!hashService.VerifyPassword(applicationUser,entity.Password,user.Password)){
            throw new InvalidCredentialException();
        }

        return jwt.generate(applicationUser);
    }

    public void Register(UserModel user){
        ApplicationUser idUser = new (){Name=user.Name, Role=ERole.User};
        string hashedPassword = hashService.HashPassword(idUser,user.Password);
        UserEntity userEntity = new(){Name=user.Name,Email=user.Email,Password=hashedPassword,Role=idUser.Role};
     
        us.Insert(userEntity);
    }
}