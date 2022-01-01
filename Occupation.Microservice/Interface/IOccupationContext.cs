using Microsoft.EntityFrameworkCore; 
using OccupationMicroservice.Persistence;

namespace OccupationMicroservice.Interface
{
    public interface IOccupationContext
    {
        DbSet<Occupation> Occupations { get; set; }
        DbSet<OccupationRating> OccupationRatings { get; set; }
    }
}
