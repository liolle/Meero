using meero.entity;
namespace meero.bll.Service;

public interface IHeroService {
    public string Insert(HeroEntity user,ICollection<int> power_id);
    public HeroEntity? GetById(int id, bool includePowers);
    public ICollection<HeroEntity> GetAll(bool includePowers);
    public ICollection<PowerEntity> GetPowers(int id);
}