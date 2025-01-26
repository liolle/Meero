using meero.entity;
namespace meero.bll.Service;


public interface IAuthService {

    public void Register(UserModel user);
    public string Login(UserModel user);
    public ApplicationUser Auth(string token);
}