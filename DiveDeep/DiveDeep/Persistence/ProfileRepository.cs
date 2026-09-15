using DiveDeep.Models;
using DiveDeep.Data;
using Microsoft.EntityFrameworkCore;

namespace DiveDeep.Persistence
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DiveDeepContext _context;

        public ProfileRepository(DiveDeepContext context)
        {
            _context = context;
        }

        public List<Profile> GetAll()
        {
            return _context.Profiles
                .ToList();
        }

        public Profile? GetById(int id)
        {
            return _context.Profiles
                .FirstOrDefault(p => p.ProfileId == id);
        }

       
    }
}
