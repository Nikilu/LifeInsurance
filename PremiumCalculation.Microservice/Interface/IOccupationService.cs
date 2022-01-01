
using System.Threading.Tasks;

namespace PremiumCalculationMicroservice.Interface
{
    public interface IOccupationService
    {
        Task<decimal> GetRatingFactor(int occupationId);
    }
}
