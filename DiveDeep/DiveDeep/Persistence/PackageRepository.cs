using DiveDeep.Models;
using DiveDeep.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DiveDeep.Persistence
{
    public class PackageRepository : IPackageRepository
    {
        private readonly DiveDeepContext _context;

        public PackageRepository(DiveDeepContext context)
        {
            _context = context;
        }

        public async Task<List<Package>> GetAllAsync()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package?> GetByIdAsync(int id)
        {
            return await _context.Packages
                .FirstOrDefaultAsync(p => p.PackageId == id);
        }

    }
}
