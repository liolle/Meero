using meero.entity;
namespace meero.bll.Service;

public interface IJWTService {
    public string generate(ApplicationUser applicationUser);
}