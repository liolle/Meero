using meero.entity;
namespace meero.bll.Service;


public class AuthService(IUserService us, IHashService hashService, IJWTService jwt): IAuthService {
    public string Login(UserModel user)
    {
        UserEntity? entity = us.GetByEmail(user.Email);
        if (entity == null){
            return "";
        }

        ApplicationUser applicationUser = new(){Name=entity.Name,Id=entity.Id,Role=entity.Role};

        if (!hashService.VerifyPassword(applicationUser,entity.Password,user.Password)){
            return "";
        }

        return jwt.generate(applicationUser);
    }

    public int Register(UserModel user){
        ApplicationUser idUser = new (){Name=user.Name, Role=ERole.User};
        string hashedPassword = hashService.HashPassword(idUser,user.Password);
        UserEntity userEntity = new(){Name=user.Name,Email=user.Email,Password=hashedPassword,Role=idUser.Role};
     
        if (!us.Insert(userEntity)){
            return -1;
        }

        return userEntity.Id;
    }
}