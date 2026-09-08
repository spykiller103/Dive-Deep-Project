using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public class ProfileRepository
    {
        private static List<Profile> _profile = new List<Profile>
        {
            new Profile
            {
                Id = 1,
                FirstName = "Nicklas",
                LastName = "Jensen",
                Email = "Test@mail.com",
                ActiveRents = 2,
                CompletedRents = 4
            }
        };

        public static List<Profile> GetAll()
        {
            return _profile;
        }

        public static Profile? GetById(int id)
        {
            return _profile.FirstOrDefault(x => x.Id == id);
        }
        public static void Add(Profile profile)
        {
            if (profile == null) return;

            profile.Id = _profile.Any() ? _profile.Max(x => x.Id) + 1 : 1;

            _profile.Add(profile);
        }

        public static void Delete(int packageId)
        {
            _profile.RemoveAll(x => x.Id == packageId);
        }
    }
}
