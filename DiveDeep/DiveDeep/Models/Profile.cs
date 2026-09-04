namespace DiveDeep.Models
{
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string Email { get; set; }
        public int ActiveRents { get; set; }
        public int CompletedRents { get; set; }
        public int Rents
        {
            get
            {
                return ActiveRents + CompletedRents;
            }
        }
        public Package? Packages { get; set; }
        public Equipment? Equipments { get; set; }
    }
}
