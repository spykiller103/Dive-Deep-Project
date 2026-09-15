using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public interface IPackageRepository
    {
        List<Package> GetAll();
        Package? GetById(int id);
     
    }
}
