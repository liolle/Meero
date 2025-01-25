using meero.Database;
using meero.entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace meero.bll.Service;

public class UserService (IDataContext context) : IUserService
{
    public string Insert(UserEntity user)
    {
        try
        {
            context.Users.Add(user);
            context.SaveChanges();
            return "";
        }
        catch (DbUpdateException dbEx)
        {
            // Check for specific SQL exception (e.g., duplicate index on email)
            if (dbEx.InnerException is SqlException sqlEx && sqlEx.Number == 2601)
            {
                throw new DuplicateEmailException();
            }

            throw new DatabaseException();
        }
        catch (Exception )
        {
            throw new DatabaseException();
        }
    }

    public UserEntity? GetById(int id){
        return context.Users.SingleOrDefault(u=>u.Id == id);
    }

    public UserEntity? GetByEmail(string email){
        return context.Users.SingleOrDefault(u=>u.Email == email);
    }
}