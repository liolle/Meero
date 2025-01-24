using meero.Database;
using meero.entity;

namespace meero.bll.Service;

public class UserService (IDataContext context) : IUserService
{
    public bool Insert(UserEntity user)
    {
        try
        {
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public UserEntity? GetById(int id){
        return context.Users.SingleOrDefault(u=>u.Id == id);
    }

    public UserEntity? GetByEmail(string email){
        return context.Users.SingleOrDefault(u=>u.Email == email);
    }
}