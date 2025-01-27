using meero.Database;
using meero.entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace meero.bll.Service;

public class HeroService (IDataContext context): IHeroService
{
    public HeroEntity? GetById(int id,bool includePowers)
    {
        var query = context.Heroes.AsQueryable();

        if (includePowers)
        {
            query = query.Include(h => h.Powers);
        }

        return query.SingleOrDefault(p => p.Id == id);
    }

    public ICollection<HeroEntity> GetAll(bool includePowers)
    {
        IQueryable<HeroEntity>? query = context.Heroes.AsQueryable();
        if (includePowers)
        {
            query = query.Include(h => h.Powers);
        }
        return query.ToList();
    }

    public ICollection<PowerEntity> GetPowers(int id)
    {
        HeroEntity? power = context.Heroes
        .Include(h=>h.Powers) 
        .FirstOrDefault(p => p.Id == id);
        
        if (power == null)
        {
            return new List<PowerEntity>();
        }

        return power.Powers.ToList();
    }

    public string Insert(HeroEntity hero, ICollection<int> powerIds)
    {
        try
        {
            var powers = context.Powers.Where(p => powerIds.Contains(p.Id)).ToList();
            hero.Powers = powers;
            context.Heroes.Add(hero);
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