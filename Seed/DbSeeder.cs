using CQRSMediaTr.Domain;
using CQRSMediaTr.Infrastructure.Persistance;

namespace CQRSMediaTr.Seed
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext appDbContext)
        {
            if (!appDbContext.Brands.Any())
            {
                appDbContext.Brands.AddRange
                    (
                    new Brand { Name = "Polar" },
                    new Brand { Name = "Mahou" },
                    new Brand { Name = "Alhambra" },
                    new Brand { Name = "Corona" },
                    new Brand { Name = "Heineken" },
                    new Brand { Name = "Budweiser" },
                    new Brand { Name = "Guinness" },
                    new Brand { Name = "Amstel" },
                    new Brand { Name = "Estrella Damm" },
                    new Brand { Name = "San Miguel" },
                    new Brand { Name = "Paulaner" },
                    new Brand { Name = "Beck’s" },
                    new Brand { Name = "Carlsberg" },
                    new Brand { Name = "Coors" },
                    new Brand { Name = "Stella Artois" },
                    new Brand { Name = "Modelo" },
                    new Brand { Name = "Quilmes" },
                    new Brand { Name = "Pilsner Urquell" },
                    new Brand { Name = "Dos Equis" },
                    new Brand { Name = "Leffe" },
                    new Brand { Name = "Tiger" },
                    new Brand { Name = "Peroni" },
                    new Brand { Name = "Kirin" },
                    new Brand { Name = "Asahi" },
                    new Brand { Name = "Tsingtao" },
                    new Brand { Name = "Sapporo" },
                    new Brand { Name = "Grolsch" },
                    new Brand { Name = "Hoegaarden" },
                    new Brand { Name = "Blue Moon" },
                    new Brand { Name = "Samuel Adams" },
                    new Brand { Name = "Brooklyn Brewery" },
                    new Brand { Name = "Sierra Nevada" },
                    new Brand { Name = "Lagunitas" },
                    new Brand { Name = "Anchor Steam" },
                    new Brand { Name = "Goose Island" },
                    new Brand { Name = "Molson" },
                    new Brand { Name = "Labatt" },
                    new Brand { Name = "Foster’s" },
                    new Brand { Name = "Victoria Bitter" },
                    new Brand { Name = "Montejo" },
                    new Brand { Name = "Cusqueña" },
                    new Brand { Name = "Brahma" },
                    new Brand { Name = "Skol" },
                    new Brand { Name = "Itaipava" },
                    new Brand { Name = "Antarctica" },
                    new Brand { Name = "Patagonia" },
                    new Brand { Name = "Andes Origen" },
                    new Brand { Name = "Schneider" },
                    new Brand { Name = "Warsteiner" },
                    new Brand { Name = "Zulia" },
                    new Brand { Name = "Tovar" },
                    new Brand { Name = "Presidente" },
                    new Brand { Name = "Erdinger" }
                    );
                appDbContext.SaveChanges();
            }
        }
    }
}
