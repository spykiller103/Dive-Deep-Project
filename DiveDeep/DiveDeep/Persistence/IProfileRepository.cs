using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public interface IProfileRepository
    {

        List<Profile> GetAll();
        Profile? GetById(int id);

    }
}
