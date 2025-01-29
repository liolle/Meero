using meero.Database;
using meero.entity;

namespace meero.bll.Service;

public class LocationService  (IDataContext context) : ILocationService
{
    public string Insert(LocationEntity location)
    {
        try
        {
            context.Locations.Add(location);
            context.SaveChanges();
            return "";
        }
        catch (Exception )
        {
            throw new DatabaseException();
        }
    }

    public LocationEntity? GetById(int id){
        return context.Locations.SingleOrDefault(p=>p.Id == id);
    }

    public ICollection<LocationEntity> GetAll()
    {
        return context.Locations.ToList();
    }
}