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
                PackageId=0,
                Category = "Pakke",
                Price = 750,
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
                PackageId=1,
                Category = "Pakke",
                Price = 100,
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
            return _packages.FirstOrDefault(x => x.PackageId == id);
        }
        public static void Add(Package package)
        {
            _packages.Add(package);
        }

        public static void Delete(int packageId)
        {
            _packages.RemoveAll(x => x.PackageId == packageId);
        }
    }
}
