using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public static class EquipmentRepository
    {
        private static List<Equipment> _equipment = new List<Equipment>
        {

            new Equipment
            {
                Id = 1,
                ImageID = "/Content/Images/Equipment/BCD/NavigatorLite.png",
                Category = "BCD",
                Title = "Scubapro Navigator Lite BCD",
                Description = "TEMP",
                Price = 95
            },

            new Equipment
            {
                Id = 2,
                ImageID = "/Content/Images/Equipment/BCD/GlideBCD.png",
                Category = "BCD",
                Title = "Scubapro BCD Glide",
                Description = "TEMP",
                Price = 95
            },
            new Equipment
            {
                Id = 3,
                ImageID = "/Content/Images/Equipment/BCD/HydrosPro.png",
                Category = "BCD",
                Title = "Scubapro BCD Hydros Pro",
                Description = "TEMP",
                Price = 95
            },
            new Equipment
            {
                Id = 4,
                ImageID = "/Content/Images/Equipment/BCD/Modular.png",
                Category = "BCD",
                Title = "Seac BCD Modular",
                Description = "TEMP",
                Price = 95
            },

            new Equipment
            {
                Id = 5,
                ImageID = "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Definition",
                Description = "Våddragt, 3 mm",
                Price = 95
            },


            new Equipment
            {
                Id = 6,
                ImageID = "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Definition",
                Description = "Våddragt, 5 mm",
                Price = 95
            },
             new Equipment
            {
                Id = 7,
                ImageID = "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Definition",
                Description = "Våddragt, 7 mm",
                Price = 95
            },

              new Equipment
            {
                Id = 8,
                ImageID = "/Content/Images/Equipment/Divingsuits/Wetsuits/W5.png",
                Category = "Dykkerdragt",
                Title = "Waterproof W5",
                Description = "Våddragt, 3.5 mm",
                Price = 95
            },

               new Equipment
            {
                Id = 9,
                ImageID = "/Content/Images/Equipment/Divingsuits/Wetsuits/ProteusF.png",
                Category = "Dykkerdragt",
                Title = "Fourth Element Proteus",
                Description = "Våddragt, 5 mm",
                Price = 95
            },

            new Equipment
            {
                Id = 10,
                ImageID = "/Content/Images/Equipment/Divingsuits/Drysuits/Exodry4.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Exodry 4.0",
                Description = "Tørdragt",
                Price = 95
            },
             new Equipment
            {
                Id = 11,
                ImageID = "/Content/Images/Equipment/Divingsuits/Drysuits/D7Evo.png",
                Category = "Dykkerdragt",
                Title = "Waterproof D7 Evo",
                Description = "Tørdragt",
                Price = 95
            },

              new Equipment
            {
                Id = 12,
                ImageID = "/Content/Images/Equipment/Divingsuits/Drysuits/ELitePlus.png",
                Category = "Dykkerdragt",
                Title = "Santi E.Lite Plus",
                Description = "Tørdragt",
                Price = 95
            },

             new Equipment
            {
                Id = 13,
                ImageID = "/Content/Images/Equipment/Tanks/Tank.png",
                Category = "Tanke",
                Title = "Scubapro 5 liter",
                Description = "N/A",
                Price = 150
            },
              new Equipment
            {
                Id = 14,
                ImageID = "/Content/Images/Equipment/Tanks/Tank.png",
                Category = "Tanke",
                Title = "Scubapro 10 liter",
                Description = "N/A",
                Price = 160
            },
             new Equipment
            {
                Id = 15,
                ImageID = "/Content/Images/Equipment/Tanks/Tank.png",
                Category = "Tanke",
                Title = "Scubapro 12 liter",
                Description = "N/A",
                Price = 170
            },
            new Equipment
            {
                Id = 16,
                ImageID = "/Content/Images/Equipment/Tanks/Tank.png",
                Category = "Tanke",
                Title = "Scubapro 15 liter",
                Description = "N/A",
                Price = 180
            },

            new Equipment
            {
                Id = 17,
                ImageID = "/Content/Images/Equipment/Regulator/MK25EVO.png",
                Category = "Regulatorsæt",
                Title = "Scubapro Octopus R105/MK25EVO/S600",
                Description = "N/A",
                Price = 125
            },
               new Equipment
            {
                Id = 18,
                ImageID = "/Content/Images/Equipment/Regulator/MK17.png",
                Category = "Regulatorsæt",
                Title = "Scubapro Octopus R095/MK17EVO/C370",
                Description = "N/A",
                Price = 100
            },
            new Equipment
            {
                Id = 19,
                ImageID = "/Content/Images/Equipment/Regulator/MK25EVObt.png",
                Category = "Regulatorsæt",
                Title = "Scubapro Octopus S270/MK25EVO BT/A700 Carbon BT",
                Description = "N/A",
                Price = 150
            },

             new Equipment
            {
                Id = 20,
                ImageID = "/Content/Images/Equipment/Masks/Ghost.png",
                Category = "Maske/Snorkel",
                Title = "Scubapro Ghost",
                Description = "N/A",
                Price = 50
            },
                new Equipment
            {
                Id = 21,
                ImageID = "/Content/Images/Equipment/Masks/DMask.png",
                Category = "Maske/Snorkel",
                Title = "Scubapro D-Mask",
                Description = "N/A",
                Price = 60
            },
            new Equipment
            {
                Id = 22,
                ImageID = "/Content/Images/Equipment/Masks/SpectraMini.png",
                Category = "Maske/Snorkel",
                Title = "Scubapro Spectra Mini",
                Description = "N/A",
                Price = 50
            },
             new Equipment
            {
                Id = 23,
                ImageID = "/Content/Images/Equipment/Masks/CrystalVu.png",
                Category = "Maske/Snorkel",
                Title = "Scubapro Crystal VU",
                Description = "N/A",
                Price = 75
            },
            new Equipment
            {
                Id = 24,
                ImageID = "/Content/Images/Equipment/Masks/Scout.png",
                Category = "Maske/Snorkel",
                Title = "Fourth Element Scout Kontrast",
                Description = "N/A",
                Price = 75
            },
              new Equipment
            {
                Id = 25,
                ImageID = "/Content/Images/Equipment/Masks/ScoutEnchance.png",
                Category = "Maske/Snorkel",
                Title = "Fourth Element Scout Enchance",
                Description = "N/A",
                Price = 75
            },
            new Equipment
            {
                Id = 26,
                ImageID = "/Content/Images/Equipment/Masks/Element.png",
                Category = "Maske/Snorkel",
                Title = "Tusa Element",
                Description = "N/A",
                Price = 75
            },

              new Equipment
            {
                Id = 27,
                ImageID = "/Content/Images/Equipment/Fins/JetFin.png",
                Category = "Finner",
                Title = "Scubapro Jet Fin",
                Description = "N/A",
                Price = 50
            },
                 new Equipment
            {
                Id = 28,
                ImageID = "/Content/Images/Equipment/Fins/TravelFins.png",
                Category = "Finner",
                Title = "Scubapro GO travel",
                Description = "N/A",
                Price = 50
            },
               new Equipment
            {
                Id = 29,
                ImageID = "/Content/Images/Equipment/Fins/SeawingSupernova.png",
                Category = "Finner",
                Title = "Scubapro Seawing Supernova",
                Description = "N/A",
                Price = 60
            },
            new Equipment
            {
                Id = 30,
                ImageID = "/Content/Images/Equipment/Fins/Propulsion.png",
                Category = "Finner",
                Title = "Seac Propulsion",
                Description = "N/A",
                Price = 50
            },
               new Equipment
            {
                ImageID = "/Content/Images/Equipment/Fins/ALA.png",
                Category = "Finner",
                Title = "Seac ALA",
                Description = "N/A",
                Price = 50
            },
            new Equipment
            {
                Id = 31,
                ImageID = "/Content/Images/Equipment/Fins/TechFins.png",
                Category = "Finner",
                Title = "Fourth Element Tech",
                Description = "N/A",
                Price = 75
            },
            new Equipment
            {
                Id = 32,
                ImageID = "/Content/Images/Equipment/Fins/RecFins.png",
                Category = "Finner",
                Title = "Fourth Element Rec Fin",
                Description = "N/A",
                Price = 80
            },



        };

        public static List<Equipment> GetAll()
        {
            return _equipment;
        }

    }



}
