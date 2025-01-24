using meero.entity;

namespace meero.bll.Service;

public interface IUserService {
    public bool Insert(UserEntity user);
    public UserEntity? GetById(int id);
    public UserEntity? GetByEmail(string email);
}