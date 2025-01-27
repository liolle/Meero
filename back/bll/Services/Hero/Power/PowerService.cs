using meero.Database;
using meero.entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace meero.bll.Service;

public class PowerService (IDataContext context): IPowerService
{
    public PowerEntity? GetById(int id, bool includeHeroes)
    {
        return context.Powers.SingleOrDefault(p => p.Id == id);
    }

    public ICollection<PowerEntity> GetAll()
    {
        IQueryable<PowerEntity>? power = context.Powers;
        return power.ToList();
    }

    public string Insert(PowerEntity power)
    {
        try
        {
            context.Powers.Add(power);
            context.SaveChanges();
            return "";
        }
        catch (DbUpdateException dbEx)
        {
            // Check for specific SQL exception (e.g., duplicate index on email)
            if (dbEx.InnerException is SqlException sqlEx && sqlEx.Number == 2601)
            {
                throw new DuplicatePowerException();
            }

            throw new DatabaseException();
        }
        catch (Exception )
        {
            throw new DatabaseException();
        }
    }
}