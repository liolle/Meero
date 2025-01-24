using meero.Database;
using meero.entity;
namespace meero.bll.Service;


public class AuthService(IDataContext context, IHashService hashService): IAuthService {

    public int Register(UserModel user){
        ApplicationUser idUser = new (){Name=user.Name, Role=ERole.User};
        string hashedPassword = hashService.HashPassword(idUser,user.Password);

        UserEntity userEntity = new(){Name=user.Name,Email=user.Email,Password=hashedPassword,Role=idUser.Role};

        context.Users.Add(userEntity);
        context.SaveChanges();

        return userEntity.Id;
    }
}