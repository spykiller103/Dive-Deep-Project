using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public interface IPackageRepository
    {
        Task<List<Package>> GetAllAsync();
        Task<Package?> GetByIdAsync(int id);

    }
}
