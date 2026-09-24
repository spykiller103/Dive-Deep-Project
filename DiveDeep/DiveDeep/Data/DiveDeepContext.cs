using DiveDeep.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DiveDeep.Data
{
    public class DiveDeepContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<PackageEquipmentSizeRequirement> PackageEquipmentSizeRequirements { get; set; }
        public DbSet<CartItemEquipmentSize> CartItemEquipmentSizes { get; set; }

        public DiveDeepContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasMany(b => b.CartItems)
                .WithOne(c => c.Booking)
                .HasForeignKey(c => c.BookingId)
                .IsRequired(false);

            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Package)
                .WithMany(p => p.CartItems)
                .HasForeignKey(c => c.PackageId)
                .IsRequired(false);

            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Equipment)
                .WithMany(e => e.CartItems)
                .HasForeignKey(c => c.EquipmentId)
                .IsRequired(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Bookings)
                .WithOne(b => b.ApplicationUser)
                .HasForeignKey(b => b.ApplicationUserId)
                .IsRequired();

            modelBuilder.Entity<PackageEquipmentSizeRequirement>()
                .HasOne(r => r.Package)
                .WithMany(p => p.EquipmentSizeRequirements)
                .HasForeignKey(r => r.PackageId)
                .IsRequired();

            modelBuilder.Entity<CartItemEquipmentSize>()
                .HasOne(s => s.CartItem)
                .WithMany(c => c.EquipmentSizes)
                .HasForeignKey(s => s.CartItemId)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.CartItems)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey(c => c.ApplicationUserId)
                .IsRequired();

            modelBuilder.Entity<Equipment>().HasData
            (
                new Equipment
                {
                    EquipmentId = 1,
                    Image = "/Content/Images/Equipment/BCD/NavigatorLite.png",
                    Category = "BCD",
                    Title = "Scubapro Navigator Lite BCD",
                    Description = "Let og komfortabel BCD med god pasform og stabilitet, velegnet til både begyndere og erfarne dykkere.",
                    Price = 125,

                },

            new Equipment
            {
                EquipmentId = 2,
                Image = "/Content/Images/Equipment/BCD/GlideBCD.png",
                Category = "BCD",
                Title = "Scubapro BCD Glide",
                Description = "En SCUBAPRO Glide BCD kombinerer komfort, stabilitet og nem opdriftskontrol. Det frontjusterbare design, Y-Fit-skuldre og integrerede vægtsystem sikrer en stabil og behagelig pasform under hele dykket.",
                Price = 140,

            },
            new Equipment
            {
                EquipmentId = 3,
                Image = "/Content/Images/Equipment/BCD/HydrosPro.png",
                Category = "BCD",
                Title = "Scubapro BCD Hydros Pro",
                Description = "SCUBAPRO Hydros Pro er en avanceret BCD med et fleksibelt og modulært design, der giver høj komfort, stabilitet og præcis opdriftskontrol under dykket.",
                Price = 200,

            },
            new Equipment
            {
                EquipmentId = 4,
                Image = "/Content/Images/Equipment/BCD/Modular.png",
                Category = "BCD",
                Title = "Seac BCD Modular",
                Description = "SEAC Modular BCD er designet med fokus på fleksibilitet, komfort og stabilitet. Det modulære design giver en god pasform og gør den velegnet til både rekreativ dykning og forskellige dykkersituationer.",
                Price = 145,

            },

            new Equipment
            {
                EquipmentId = 5,
                Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Definition",
                Description = "SCUBAPRO Definition er en 3 mm våddragt designet til høj komfort og bevægelsesfrihed. Det fleksible neoprenmateriale giver god pasform og hjælper med at holde kroppen varm under dykket.",
                Price = 100,

            },


            new Equipment
            {
                EquipmentId = 6,
                Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Definition",
                Description = "SCUBAPRO Definition er en 5 mm våddragt, der kombinerer varmeisolering, komfort og bevægelsesfrihed. Det fleksible neoprenmateriale sikrer en behagelig pasform og god beskyttelse mod koldt vand.",
                Price = 100,

            },
             new Equipment
             {
                 EquipmentId = 7,
                 Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png",
                 Category = "Dykkerdragt",
                 Title = "Scubapro Definition",
                 Description = "SCUBAPRO Definition er en 7 mm våddragt designet til dykning i koldere vand. Det tykkere neopren giver effektiv varmeisolering, mens den fleksible konstruktion sikrer god komfort og bevægelsesfrihed under dykket.",
                 Price = 100,

             },

              new Equipment
              {
                  EquipmentId = 8,
                  Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/W5.png",
                  Category = "Dykkerdragt",
                  Title = "Waterproof W5",
                  Description = "Waterproof W5 er en 3,5 mm våddragt, der kombinerer god varmeisolering med fleksibilitet og komfort. Det elastiske neoprenmateriale giver en behagelig pasform og god bevægelsesfrihed under dykket.",
                  Price = 100,

              },

               new Equipment
               {
                   EquipmentId = 9,
                   Image = "/Content/Images/Equipment/Divingsuits/Wetsuits/ProteusF.png",
                   Category = "Dykkerdragt",
                   Title = "Fourth Element Proteus",
                   Description = "Fourth Element Proteus er en 5 mm våddragt designet til effektiv varmeisolering og høj komfort. Det fleksible neoprenmateriale giver god bevægelsesfrihed og en tæt, behagelig pasform under dykket.",
                   Price = 120,

               },

            new Equipment
            {
                EquipmentId = 10,
                Image = "/Content/Images/Equipment/Divingsuits/Drysuits/Exodry4.png",
                Category = "Dykkerdragt",
                Title = "Scubapro Exodry 4.0",
                Description = "SCUBAPRO Exodry 4.0 er en robust tørdragt designet til dykning i koldt vand. Den vandtætte konstruktion hjælper med at holde dig tør og varm, mens den komfortable pasform giver god bevægelsesfrihed under dykket.",
                Price = 300,

            },
            new Equipment
            {
                EquipmentId = 11,
                Image = "/Content/Images/Equipment/Divingsuits/Drysuits/D7Evo.png",
                Category = "Dykkerdragt",
                Title = "Waterproof D7 Evo",
                Description = "Waterproof D7 Evo er en slidstærk tørdragt designet til krævende dykning i koldt vand. Den vandtætte konstruktion giver effektiv beskyttelse mod vand, mens det fleksible design sikrer god komfort og bevægelsesfrihed under dykket.",
                Price = 320,

            },

              new Equipment
              {
                  EquipmentId = 12,
                  Image = "/Content/Images/Equipment/Divingsuits/Drysuits/ELitePlus.png",
                  Category = "Dykkerdragt",
                  Title = "Santi E.Lite Plus",
                  Description = "SANTI E.Lite Plus er en let og slidstærk tørdragt designet til komfortabel dykning under forskellige forhold. Den robuste konstruktion beskytter mod vand, mens det fleksible materiale giver god bevægelsesfrihed og komfort under dykket.",
                  Price = 350,

              },

             new Equipment
             {
                 EquipmentId = 13,
                 Image = "/Content/Images/Equipment/Tanks/Tank.png",
                 Category = "Tanke",
                 Title = "Scubapro 5 liter",
                 Description = "SCUBAPRO 5 liters dykkertank er en kompakt og robust flaske, der er velegnet til kortere dyk og som ekstra luftforsyning. Den er nem at håndtere og transportere.",
                 Price = 150,

             },
              new Equipment
              {
                  EquipmentId = 14,
                  Image = "/Content/Images/Equipment/Tanks/Tank.png",
                  Category = "Tanke",
                  Title = "Scubapro 10 liter",
                  Description = "SCUBAPRO 10 liters dykkertank er en robust og alsidig flaske med god luftkapacitet til både rekreative og længere dyk. Det kompakte design gør den nem at håndtere og transportere.",
                  Price = 160,

              },
             new Equipment
             {
                 EquipmentId = 15,
                 Image = "/Content/Images/Equipment/Tanks/Tank.png",
                 Category = "Tanke",
                 Title = "Scubapro 12 liter",
                 Description = "SCUBAPRO 12 liters dykkertank er en robust flaske med høj luftkapacitet, velegnet til længere rekreative dyk. Den solide konstruktion sikrer pålidelig ydeevne og gør tanken velegnet til forskellige dykkeforhold.",
                 Price = 170,
                 Sizes = "S,M,L,XL"
             },
            new Equipment
            {
                EquipmentId = 16,
                Image = "/Content/Images/Equipment/Tanks/Tank.png",
                Category = "Tanke",
                Title = "Scubapro 15 liter",
                Description = "SCUBAPRO 15 liters dykkertank er en robust flaske med stor luftkapacitet, ideel til længere dyk og dykkere med et højt luftforbrug. Den solide konstruktion sikrer pålidelighed og stabilitet under dykket.",
                Price = 180,
                Sizes = "S,M,L,XL"
            },

            new Equipment
            {
                EquipmentId = 17,
                Image = "/Content/Images/Equipment/Regulator/MK25EVO.png",
                Category = "Regulatorsæt",
                Title = "Scubapro Octopus R105/MK25EVO/S600",
                Description = "SCUBAPRO Octopus R105/MK25EVO/S600 er et komplet regulatorsæt med høj ydeevne og pålidelig luftlevering. Sættet er designet til komfortabel vejrtrækning og stabil funktion under forskellige dykkeforhold.",
                Price = 125,
                Sizes = "S,M,L,XL"
            },
               new Equipment
               {
                   EquipmentId = 18,
                   Image = "/Content/Images/Equipment/Regulator/MK17.png",
                   Category = "Regulatorsæt",
                   Title = "Scubapro Octopus R095/MK17EVO/C370",
                   Description = "SCUBAPRO Octopus R095/MK17EVO/C370 er et pålideligt regulatorsæt, der giver en jævn og komfortabel luftlevering under dykket. Det robuste design sikrer stabil ydeevne og gør sættet velegnet til rekreativ dykning.",
                   Price = 100,
                   Sizes = "S,M,L,XL"
               },
            new Equipment
            {
                EquipmentId = 19,
                Image = "/Content/Images/Equipment/Regulator/MK25EVObt.png",
                Category = "Regulatorsæt",
                Title = "Scubapro Octopus S270/MK25EVO BT/A700 Carbon BT",
                Description = "SCUBAPRO Octopus S270/MK25EVO BT/A700 Carbon BT er et avanceret regulatorsæt med høj ydeevne og jævn luftlevering. Det robuste design og materialer i høj kvalitet sikrer komfortabel vejrtrækning og pålidelig funktion under dykket.",
                Price = 150,
                Sizes = "S,M,L,XL"
            },

             new Equipment
             {
                 EquipmentId = 20,
                 Image = "/Content/Images/Equipment/Masks/Ghost.png",
                 Category = "Maske/Snorkel",
                 Title = "Scubapro Ghost",
                 Description = "SCUBAPRO Ghost er en komfortabel dykkermaske med lav volumen og et bredt synsfelt. Den tætsluttende silikonefacial giver en behagelig pasform og sikrer klart udsyn under vandet.",
                 Price = 50,
                 Sizes = "S,M,L,XL"
             },
                new Equipment
                {
                    EquipmentId = 21,
                    Image = "/Content/Images/Equipment/Masks/DMask.png",
                    Category = "Maske/Snorkel",
                    Title = "Scubapro D-Mask",
                    Description = "SCUBAPRO D-Mask er en komfortabel dykkermaske med et moderne design og bredt synsfelt. Den bløde silikonefacial sikrer en tæt og behagelig pasform, mens det hærdede glas giver klart udsyn under vandet.",
                    Price = 60,
                    Sizes = "S,M,L,XL"
                },
            new Equipment
            {
                EquipmentId = 22,
                Image = "/Content/Images/Equipment/Masks/SpectraMini.png",
                Category = "Maske/Snorkel",
                Title = "Scubapro Spectra Mini",
                Description = "SCUBAPRO Spectra Mini er en kompakt og komfortabel dykkermaske designet til mindre ansigter. Det brede synsfelt og den bløde silikonefacial sikrer klart udsyn og en tæt, behagelig pasform under vandet.",
                Price = 50,
                Sizes = "S,M,L,XL"
            },
             new Equipment
             {
                 EquipmentId = 23,
                 Image = "/Content/Images/Equipment/Masks/CrystalVu.png",
                 Category = "Maske/Snorkel",
                 Title = "Scubapro Crystal VU",
                 Description = "SCUBAPRO Crystal VU er en komfortabel dykkermaske med stort synsfelt og fremragende udsyn under vandet. Den bløde silikonefacial sikrer en tæt og behagelig pasform, mens det robuste glas giver et klart og naturligt udsyn.",
                 Price = 75,
                 Sizes = "S,M,L,XL"
             },
            new Equipment
            {
                EquipmentId = 24,
                Image = "/Content/Images/Equipment/Masks/Scout.png",
                Category = "Maske/Snorkel",
                Title = "Fourth Element Scout Kontrast",
                Description = "Fourth Element Scout Kontrast er en komfortabel dykkermaske designet til klart og præcist udsyn under vandet. Det kontrastfremhævende design og den tætsluttende silikonefacial giver god pasform og komfort under dykket.",
                Price = 75,
                Sizes = "S,M,L,XL"
            },
              new Equipment
              {
                  EquipmentId = 25,
                  Image = "/Content/Images/Equipment/Masks/ScoutEnchance.png",
                  Category = "Maske/Snorkel",
                  Title = "Fourth Element Scout Enchance",
                  Description = "N/A",
                  Price = 75,
                  Sizes = "S,M,L,XL"
              },
            new Equipment
            {
                EquipmentId = 26,
                Image = "/Content/Images/Equipment/Masks/Element.png",
                Category = "Maske/Snorkel",
                Title = "Tusa Element",
                Description = "TUSA Element er en komfortabel dykkermaske med et enkelt og funktionelt design. Den bløde silikonefacial sikrer en tæt pasform, mens det klare glas giver et godt og naturligt udsyn under vandet.",
                Price = 75,
                Sizes = "S,M,L,XL"
            },

              new Equipment
              {
                  EquipmentId = 27,
                  Image = "/Content/Images/Equipment/Fins/JetFin.png",
                  Category = "Finner",
                  Title = "Scubapro Jet Fin",
                  Description = "SCUBAPRO Jet Fin er en robust og klassisk dykkerfinne med et kraftfuldt design, der giver effektiv fremdrift og god kontrol i vandet. Den solide konstruktion gør den velegnet til både rekreativ og krævende dykning.",
                  Price = 50,
                  Sizes = "S,M,L,XL"
              },
                 new Equipment
                 {
                     EquipmentId = 28,
                     Image = "/Content/Images/Equipment/Fins/TravelFins.png",
                     Category = "Finner",
                     Title = "Scubapro GO travel",
                     Description = "SCUBAPRO GO Travel er en let og kompakt dykkerfinne designet til rejser og nem transport. Det fleksible design giver god fremdrift og komfort, samtidig med at finnerne er nemme at pakke og tage med på farten.",
                     Price = 50
                 },
               new Equipment
               {
                   EquipmentId = 29,
                   Image = "/Content/Images/Equipment/Fins/SeawingSupernova.png",
                   Category = "Finner",
                   Title = "Scubapro Seawing Supernova",
                   Description = "SCUBAPRO Seawing Supernova er en kraftfuld dykkerfinne med innovativt design, der giver effektiv fremdrift og god kontrol i vandet. Den fleksible konstruktion sikrer en behagelig og energieffektiv svømning under dykket.",
                   Price = 60,
                   Sizes = "S,M,L,XL"
               },
            new Equipment
            {
                EquipmentId = 30,
                Image = "/Content/Images/Equipment/Fins/Propulsion.png",
                Category = "Finner",
                Title = "Seac Propulsion",
                Description = "SEAC Propulsion er en kraftfuld dykkerfinne designet til effektiv fremdrift og god kontrol i vandet. Den robuste og fleksible konstruktion giver komfortabel svømning og stabil ydeevne under dykket.",
                Price = 50,
                Sizes = "S,M,L,XL"
            },
               new Equipment
               {
                   EquipmentId = 31,
                   Image = "/Content/Images/Equipment/Fins/ALA.png",
                   Category = "Finner",
                   Title = "Seac ALA",
                   Description = "SEAC ALA er en let og komfortabel dykkerfinne designet til effektiv fremdrift og god manøvredygtighed. Den fleksible konstruktion giver en behagelig svømmeoplevelse og stabil kontrol under dykket.",
                   Price = 50,

               },
            new Equipment
            {
                EquipmentId = 32,
                Image = "/Content/Images/Equipment/Fins/TechFins.png",
                Category = "Finner",
                Title = "Fourth Element Tech",
                Description = "Fourth Element Tech er en robust dykkerfinne designet til teknisk dykning og krævende forhold. Den stive konstruktion giver kraftfuld fremdrift, præcis kontrol og effektiv svømning under vandet.",
                Price = 75,

            },
            new Equipment
            {
                EquipmentId = 33,
                Image = "/Content/Images/Equipment/Fins/RecFins.png",
                Category = "Finner",
                Title = "Fourth Element Rec Fin",
                Description = "Fourth Element Rec Fin er en alsidig og komfortabel dykkerfinne designet til rekreativ dykning. Den fleksible konstruktion giver effektiv fremdrift, god kontrol og en behagelig svømmeoplevelse under vandet.",
                Price = 80,

            });

            modelBuilder.Entity<Package>().HasData
                (
                new Package
                {
                    PackageId = 1,
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
                    ,
                    Sizes = "S,M,L,XL"
                },

            new Package
            {
                PackageId = 2,
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
                ,
                Sizes = "S,M,L,XL"
            });

            // Seed package equipment size requirements
            modelBuilder.Entity<PackageEquipmentSizeRequirement>().HasData(
                new PackageEquipmentSizeRequirement
                {
                    Id = 1,
                    EquipmentName = "BCD",
                    AvailableSizes = "S,M,L,XL",
                    RequiresSize = true,
                    PackageId = 1
                },
                new PackageEquipmentSizeRequirement
                {
                    Id = 2,
                    EquipmentName = "Dykkerdragt",
                    AvailableSizes = "S,M,L,XL",
                    RequiresSize = true,
                    PackageId = 1
                },
                new PackageEquipmentSizeRequirement
                {
                    Id = 3,
                    EquipmentName = "Regulatorsæt",
                    AvailableSizes = "",
                    RequiresSize = false,
                    PackageId = 1
                },
                new PackageEquipmentSizeRequirement
                {
                    Id = 4,
                    EquipmentName = "Tank",
                    AvailableSizes = "",
                    RequiresSize = false,
                    PackageId = 1
                },
                new PackageEquipmentSizeRequirement
                {
                    Id = 5,
                    EquipmentName = "Finner",
                    AvailableSizes = "S,M,L,XL",
                    RequiresSize = true,
                    PackageId = 1
                },
                new PackageEquipmentSizeRequirement
                {
                    Id = 6,
                    EquipmentName = "Maske",
                    AvailableSizes = "",
                    RequiresSize = false,
                    PackageId = 1
                },
                new PackageEquipmentSizeRequirement
                {
                    Id = 7,
                    EquipmentName = "Snorkel",
                    AvailableSizes = "",
                    RequiresSize = false,
                    PackageId = 1
                },
                new PackageEquipmentSizeRequirement
                {
                    Id = 8,
                    EquipmentName = "Finner",
                    AvailableSizes = "S,M,L,XL",
                    RequiresSize = true,
                    PackageId = 2
                },
                new PackageEquipmentSizeRequirement
                {
                    Id = 9,
                    EquipmentName = "Maske",
                    AvailableSizes = "",
                    RequiresSize = false,
                    PackageId = 2
                },
                new PackageEquipmentSizeRequirement
                {
                    Id = 10,
                    EquipmentName = "Snorkel",
                    AvailableSizes = "",
                    RequiresSize = false,
                    PackageId = 2
                });
        }
    }
}
