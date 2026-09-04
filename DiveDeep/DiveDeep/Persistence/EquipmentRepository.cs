using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public static class EquipmentRepository
    {
        private static List<Equipment> _equipment = new List<Equipment>
        {

            new Equipment
            {
                Image = "Test",
                Category = "Beklædning",
                Title = "Dykkermaske",
                Description = "Silikone-maske med enkelt eller dobbelt linse. S/M/L",
                Price = 95
            },

            new Equipment
            {
                Image = "Test",
                Category = "Beklædning",
                Title = "Finner",
                Description = "Åbenhæls og lukkethæls finner. Størrelse 38-47",
                Price = 75
            }
        };

        public static List<Equipment> GetAll()
        {
            return _equipment;
        }

    }



}
