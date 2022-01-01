

using Microsoft.EntityFrameworkCore;
using OccupationMicroservice.Interface;
using OccupationMicroservice.Persistence;

namespace OccupationMicroservice.DBContext
{
    public class OccupationContext : DbContext, IOccupationContext
    {
        public OccupationContext(DbContextOptions<OccupationContext> options) : base(options)
        { }

        public DbSet<Occupation> Occupations { get; set; }

        public DbSet<OccupationRating> OccupationRatings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<OccupationRating>().HasData( 
                          new OccupationRating { OccupationRatingId = 1, Factor = 1.00m, OccupationRatingName = "Professional" },
                          new OccupationRating { OccupationRatingId = 2, Factor = 1.25m, OccupationRatingName = "White Collar" },
                          new OccupationRating { OccupationRatingId = 3, Factor = 1.50m, OccupationRatingName = "Light Manual" },
                          new OccupationRating { OccupationRatingId = 4, Factor = 1.75m, OccupationRatingName = "Heavy Manual" });

            modelBuilder.Entity<Occupation>().HasData(
                                new Occupation { OccupationId = 1, OccupationName = "Cleaner", OccupationRatingId = 3 },
                                new Occupation { OccupationId = 2, OccupationName = "Doctor", OccupationRatingId = 1 },
                                new Occupation { OccupationId = 3, OccupationName = "Author", OccupationRatingId = 2 },
                                new Occupation { OccupationId = 4, OccupationName = "Farmer", OccupationRatingId = 4 },
                                new Occupation { OccupationId = 5, OccupationName = "Mechanic", OccupationRatingId = 4 },
                                new Occupation { OccupationId = 6, OccupationName = "Florist", OccupationRatingId = 3 });

       
        }
    }
}
