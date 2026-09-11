using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public class ProfileRepository
    {
        private static List<Profile> _profile = new List<Profile>
        {
            new Profile
            {
                ProfileId = 0,
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
            return _profile.FirstOrDefault(x => x.ProfileId == id);
        }
        public static void Add(Profile profile)
        {
            if (profile == null) return;

            profile.ProfileId = _profile.Any() ? _profile.Max(x => x.ProfileId) + 1 : 0;

            _profile.Add(profile);
        }

        public static void Delete(int packageId)
        {
            _profile.RemoveAll(x => x.ProfileId == packageId);
        }
    }
}
