using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SedmiProjekt.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Zanr> Zanr { get; set; }

        public DbSet<Albumi> Albumi { get; set; }
   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Albumi>().Property(f => f.Cijena).HasPrecision(10, 2);

            builder.Entity<Zanr>().HasData(
                new Zanr() { Id = 1, Naziv = "Heavy Metal" },
                new Zanr() { Id = 2, Naziv = "Hard Rock" },
                new Zanr() { Id = 3, Naziv = "Alternative Rock" },
                new Zanr() { Id = 4, Naziv = "Alt-Pop" },
                new Zanr() { Id = 5, Naziv = "Rock" }
                );

            builder.Entity<Albumi>().HasData(
                new Albumi() { Id = 1, Izvodac = "Black Sabbath", Album = "Paranoid", Cijena = 10.99m, Datum = DateTime.Parse("1970-10-14"), SlikaUrl = "https://upload.wikimedia.org/wikipedia/en/6/64/Black_Sabbath_-_Paranoid.jpg", ZanrId = 1 },
                new Albumi() { Id = 2, Izvodac = "Rammstein", Album = "Mutter", Cijena = 13, Datum = DateTime.Parse("2001-03-24"), SlikaUrl = "https://upload.wikimedia.org/wikipedia/hr/4/45/Mutter_%282001%29.jpg", ZanrId = 2 },
                new Albumi() { Id = 3, Izvodac = "Joy Division", Album = "Unknown Pleasures", Cijena = 11.99m, Datum = DateTime.Parse("1979-12-18"), SlikaUrl = "https://upload.wikimedia.org/wikipedia/en/5/5a/UnknownPleasuresVinyl.jpg", ZanrId = 3 },
                new Albumi() { Id = 4, Izvodac = "Lana Del Rey", Album = "Born to Die", Cijena = 12.99m, Datum = DateTime.Parse("2012-07-18"), SlikaUrl = "https://muzikercdn.com/uploads/products/7847/784753/417f055a.JPG", ZanrId = 4 },
                new Albumi() { Id = 5, Izvodac = "Fleetwood Mac", Album = "Rumours", Cijena = 10.50m, Datum = DateTime.Parse("1977-04-10"), SlikaUrl = "https://upload.wikimedia.org/wikipedia/en/f/fb/FMacRumours.PNG", ZanrId = 5 }
                );




        }
    }

}
