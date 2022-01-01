using OccupationMicroservice.Model; 
using System.Collections.Generic;

namespace OccupationMicroservice.Interface
{
   public interface IOccupationService
    {
        List<Occupation> GetOccupations();

        decimal GetOccupationRatingFactor(int id);
    }
}
