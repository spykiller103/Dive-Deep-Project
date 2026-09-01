using DiveDeep.Models;
using System.Reflection;

namespace DiveDeep.Persistence
{
    public class PackageRepository
    {
        private static List<Package> _packages = new List<Package>
        {
            new Package
            {
                Id=1,
                Price = 90,
                Image = "/Content/Images/Packages/Package1.png",
                Title = "Komplet dykkersæt",
                Equipment = new List<string>
                {
                    "BCD",
                    "Dykkerdragt",
                    "Regulatorsæt",
                    "Tank",
                    "Finner",
                    "Maske",
                    "Snorkel"
                }
            },

            new Package
            {
                Id=1,
                Price = 90,
                Image = "/Content/Images/Packages/Package2.png",
                Title = "Komplet snorkelsæt",
                Equipment = new List<string>
                {
                    "Finner",
                    "Maske",
                    "Snorkel"
                }
            }
        };
        public static List<Package> GetAll()
        {
            return _packages;
        }

        public static Package? GetById(int id)
        {
            return _packages.FirstOrDefault(x => x.Id == id);
        }
        public static void Add(Package package)
        {
            if (package == null) return;

            package.Id = _packages.Any() ? _packages.Max(x => x.Id) + 1 : 1;

            _packages.Add(package);
        }

        public static void Delete(int packageId)
        {
            _packages.RemoveAll(x => x.Id == packageId);
        }

        /*
        public static void Update(int packageId, Package package)
        {
            var packageToUpdate = GetById(packageId);
            if (packageToUpdate != null)
            {
                packageToUpdate.Title = package.Title;
            }
        }
        */
    }
}
