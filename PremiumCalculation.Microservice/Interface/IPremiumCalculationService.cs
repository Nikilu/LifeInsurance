
using PremiumCalculationMicroservice.Models;
using System.Threading.Tasks;

namespace PremiumCalculationMicroservice.Interface
{
    public interface IPremiumCalculationService
    {
        Task<decimal> CalculateYearlyDeathPremium(PremiumByOccupationInput input);
    }
}
