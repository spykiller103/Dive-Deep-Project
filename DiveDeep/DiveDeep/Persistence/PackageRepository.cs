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

        public List<Package> GetAll()
        {
            return _context.Packages
                .ToList();
        }

        public Package? GetById(int id)
        {
            return _context.Packages
                .FirstOrDefault(p => p.PackageId == id);
        }

    }
}
