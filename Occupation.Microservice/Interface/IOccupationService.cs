using OccupationMicroservice.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OccupationMicroservice.Interface
{
    public interface IOccupationService
    {
        Task<List<Occupation>> GetOccupations();

        Task<decimal> GetOccupationRatingFactor(int id);
    }
}
