using meero.entity;
namespace meero.bll.Service;


public interface IAuthService {

    public int Register(UserModel user);
    public string Login(UserModel user);
}