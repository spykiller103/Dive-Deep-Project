using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public static class EquipmentRepository
    {
        private static List<Equipment> _equipments = new List<Equipment>
        {

            new Equipment
            {
                EquipmentId=0,
                Image = "/Content/Images/Equipment/BCD/NavigatorLite.png",
                Category = "BCD",
                Title = "Scubapro Navigator Lite BCD",
                Description = "TEMP",
                Price = 125
            },

            new Equipment
            {
                EquipmentId=1,
                Image = "/Content/Images/Equipment/BCD/GlideBCD.png",
                Category = "BCD",
                Title = "Scubapro BCD Glide",
                Description = "TEMP",
                Price = 140
            },
            new Equipment
            {
                EquipmentId=2,
                Image = "/Content/Images/Equipment/BCD/HydrosPro.png",
                Category = "BCD",
                Title = "Scubapro BCD Hydros Pro",
                Description = "TEMP",
                Price = 200
            },
            new Equipment
            {
                EquipmentId=3,
                Image = "/Content/Images/Equipment/BCD/Modular.png",
                Category = "BCD",
                Title = "Seac BCD Modular",
                Description = "TEMP",
                Price = 145
            },

            new Equipment
            {
                EquipmentId=4,
                Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Definition",
                Description = "Våddragt, 3 mm",
                Price = 100
            },


            new Equipment
            {
                EquipmentId=5,
                Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Definition",
                Description = "Våddragt, 5 mm",
                Price = 100
            },
             new Equipment
            {
                EquipmentId=6,
                Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Definition",
                Description = "Våddragt, 7 mm",
                Price = 100
            },

              new Equipment
            {
                EquipmentId=7,
                Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/W5.png",
                Category = "Dykkerdragt",
                Title = "Waterproof W5",
                Description = "Våddragt, 3.5 mm",
                Price = 100
            },

               new Equipment
            {
                EquipmentId=8,
                Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/ProteusF.png",
                Category = "Dykkerdragt",
                Title = "Fourth Element Proteus",
                Description = "Våddragt, 5 mm",
                Price = 120
            },

            new Equipment
            {
                EquipmentId=9,
                Image = "/Content/Images/Equipment/Divingsuits/Drysuits/Exodry4.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Exodry 4.0",
                Description = "Tørdragt",
                Price = 300
            },
            new Equipment
            {
                EquipmentId = 10,
                Image = "/Content/Images/Equipment/Divingsuits/Drysuits/D7Evo.png",
                Category = "Dykkerdragt",
                Title = "Waterproof D7 Evo",
                Description = "Tørdragt",
                Price = 320
            },

              new Equipment
            {
                EquipmentId = 11,
                Image = "/Content/Images/Equipment/Divingsuits/Drysuits/ELitePlus.png",
                Category = "Dykkerdragt",
                Title = "Santi E.Lite Plus",
                Description = "Tørdragt",
                Price = 350
            },

             new Equipment
             {
                 EquipmentId = 12,
                Image = "/Content/Images/Equipment/Tanks/Tank.png",
                Category = "Tanke",
                Title = "Scubapro 5 liter",
                Description = "N/A",
                Price = 150
            },
              new Equipment
            {
                EquipmentId = 13,
                Image = "/Content/Images/Equipment/Tanks/Tank.png",
                Category = "Tanke",
                Title = "Scubapro 10 liter",
                Description = "N/A",
                Price = 160
            },
             new Equipment
             {
                 EquipmentId = 14,
                Image = "/Content/Images/Equipment/Tanks/Tank.png",
                Category = "Tanke",
                Title = "Scubapro 12 liter",
                Description = "N/A",
                Price = 170
            },
            new Equipment
            {
                EquipmentId = 15,
                Image = "/Content/Images/Equipment/Tanks/Tank.png",
                Category = "Tanke",
                Title = "Scubapro 15 liter",
                Description = "N/A",
                Price = 180
            },

            new Equipment
            {
                EquipmentId = 16,
                Image = "/Content/Images/Equipment/Regulator/MK25EVO.png",
                Category = "Regulatorsæt",
                Title = "Scubapro Octopus R105/MK25EVO/S600",
                Description = "N/A",
                Price = 125
            },
               new Equipment
            {
                EquipmentId = 17,
                Image = "/Content/Images/Equipment/Regulator/MK17.png",
                Category = "Regulatorsæt",
                Title = "Scubapro Octopus R095/MK17EVO/C370",
                Description = "N/A",
                Price = 100
            },
            new Equipment
            {
                EquipmentId = 18,
                Image = "/Content/Images/Equipment/Regulator/MK25EVObt.png",
                Category = "Regulatorsæt",
                Title = "Scubapro Octopus S270/MK25EVO BT/A700 Carbon BT",
                Description = "N/A",
                Price = 150
            },

             new Equipment
            {
                EquipmentId = 19,
                Image = "/Content/Images/Equipment/Masks/Ghost.png",
                Category = "Maske/Snorkel",
                Title = "Scubapro Ghost",
                Description = "N/A",
                Price = 50
            },
                new Equipment
            {
                EquipmentId = 20,
                Image = "/Content/Images/Equipment/Masks/DMask.png",
                Category = "Maske/Snorkel",
                Title = "Scubapro D-Mask",
                Description = "N/A",
                Price = 60
            },
            new Equipment
            {
                EquipmentId = 22,
                Image = "/Content/Images/Equipment/Masks/SpectraMini.png",
                Category = "Maske/Snorkel",
                Title = "Scubapro Spectra Mini",
                Description = "N/A",
                Price = 50
            },
             new Equipment
            {
                EquipmentId = 23,
                Image = "/Content/Images/Equipment/Masks/CrystalVu.png",
                Category = "Maske/Snorkel",
                Title = "Scubapro Crystal VU",
                Description = "N/A",
                Price = 75
            },
            new Equipment
            {
                EquipmentId = 24,
                Image = "/Content/Images/Equipment/Masks/Scout.png",
                Category = "Maske/Snorkel",
                Title = "Fourth Element Scout Kontrast",
                Description = "N/A",
                Price = 75
            },
              new Equipment
            {
                EquipmentId = 25,
                Image = "/Content/Images/Equipment/Masks/ScoutEnchance.png",
                Category = "Maske/Snorkel",
                Title = "Fourth Element Scout Enchance",
                Description = "N/A",
                Price = 75
            },
            new Equipment
            {
                EquipmentId = 26,
                Image = "/Content/Images/Equipment/Masks/Element.png",
                Category = "Maske/Snorkel",
                Title = "Tusa Element",
                Description = "N/A",
                Price = 75
            },

              new Equipment
            {
                EquipmentId = 27,
                Image = "/Content/Images/Equipment/Fins/JetFin.png",
                Category = "Finner",
                Title = "Scubapro Jet Fin",
                Description = "N/A",
                Price = 50
            },
                 new Equipment
            {
                EquipmentId = 28,
                Image = "/Content/Images/Equipment/Fins/TravelFins.png",
                Category = "Finner",
                Title = "Scubapro GO travel",
                Description = "N/A",
                Price = 50
            },
               new Equipment
            {
                EquipmentId = 29,
                Image = "/Content/Images/Equipment/Fins/SeawingSupernova.png",
                Category = "Finner",
                Title = "Scubapro Seawing Supernova",
                Description = "N/A",
                Price = 60
            },
            new Equipment
            {
                EquipmentId = 30,
                Image = "/Content/Images/Equipment/Fins/Propulsion.png",
                Category = "Finner",
                Title = "Seac Propulsion",
                Description = "N/A",
                Price = 50
            },
               new Equipment
            {
                EquipmentId = 31,
                Image = "/Content/Images/Equipment/Fins/ALA.png",
                Category = "Finner",
                Title = "Seac ALA",
                Description = "N/A",
                Price = 50
            },
            new Equipment
            {
                EquipmentId = 32,
                Image = "/Content/Images/Equipment/Fins/TechFins.png",
                Category = "Finner",
                Title = "Fourth Element Tech",
                Description = "N/A",
                Price = 75
            },
            new Equipment
            {
                EquipmentId = 33,
                Image = "/Content/Images/Equipment/Fins/RecFins.png",
                Category = "Finner",
                Title = "Fourth Element Rec Fin",
                Description = "N/A",
                Price = 80
            },
        };

        public static List<Equipment> GetAll()
        {
            return _equipments;
        }

        public static Equipment? GetById(int id)
        {
            return _equipments.FirstOrDefault(x => x.EquipmentId == id);
        }
    }
}
