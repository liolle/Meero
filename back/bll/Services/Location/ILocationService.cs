using meero.entity;

namespace meero.bll.Service;

public interface ILocationService {
    public string Insert(LocationEntity user);
    public LocationEntity? GetById(int id);
    public ICollection<LocationEntity> GetAll();
}