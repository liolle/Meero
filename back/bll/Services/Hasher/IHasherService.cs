using meero.entity;
namespace meero.bll.Service;


public interface IHashService {
    public string HashPassword(ApplicationUser user, string password);
    public bool VerifyPassword(ApplicationUser user, string hashedPassword, string password);
}
