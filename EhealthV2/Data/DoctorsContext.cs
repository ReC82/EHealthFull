using EhealthV2.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EhealthV2.Data
{
    public class DoctorsContext: DbContext
    {
        public DoctorsContext(DbContextOptions<DoctorsContext> options) : base(options)
        { 
        
        }

        public DbSet<Doctors> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctors>().HasData(
                    new Doctors
                    {
                        DocId = 1,
                        FirstName = "LoDY",
                        LastName = "La fusée",
                        Email="lody@hotmail.com",
                        Address="Rue de la fusée",
                        City="Bruxelles",
                        PostCode="1000",
                        Inami="12345678910",
                        Speciality="Cardiologue",
                        Organisation="Sans"
                    },
                    new Doctors
                    {
                        DocId = 2,
                        FirstName = "Toto",
                        LastName = "La Grippe",
                        Email = "toto@gmail.com",
                        Address="Rue de la tortilla",
                        City="Bruxelles",
                        PostCode="1050",
                        Inami="12345678911",
                        Speciality="Généraliste",
                        Organisation="Sans"
                    },
                    new Doctors
                    {
                        DocId = 3,
                        FirstName = "Muharem",
                        LastName = "Le Hacker",
                        Email = "muharen@hotmail.com",
                        Address="Rue Bara",
                        City="Bruxelles",
                        PostCode="1000",
                        Inami="12345678912",
                        Speciality="kinésithérapie",
                        Organisation="Sans"
                    },
                    new Doctors
                    {
                        DocId = 4,
                        FirstName = "JP",
                        LastName = "La Tortue",
                        Email = "jp@hotmail.com",
                        Address="Rue Lente",
                        City="Laeken",
                        PostCode="1020",
                        Inami="12345678913",
                        Speciality="Dentiste",
                        Organisation="Sans"
                    }
                );
        }
    }
}
