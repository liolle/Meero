using meero.entity;
namespace meero.bll.Service;

public interface IPowerService {
    public string Insert(PowerEntity user);
    public PowerEntity? GetById(int id,bool includeHeroes);
    public ICollection<PowerEntity> GetAll();
}