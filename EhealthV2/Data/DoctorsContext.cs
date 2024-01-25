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
                        LastName = "rue de lody",
                        Email="email lody"
                    },
                    new Doctors
                    {
                        DocId = 2,
                        FirstName = "Lloyd",
                        LastName = "rue de lloyd",
                        Email = "email lloyd"
                    }
                );
        }
    }
}
