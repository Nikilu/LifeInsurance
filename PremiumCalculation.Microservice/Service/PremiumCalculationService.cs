using Microsoft.AspNetCore.Mvc;
using PremiumCalculationMicroservice.Common;
using PremiumCalculationMicroservice.Interface;
using PremiumCalculationMicroservice.Models;
using System;
using System.Threading.Tasks;

namespace PremiumCalculationMicroservice.Service
{
    public class PremiumCalculationService : IPremiumCalculationService
    {
        private readonly IOccupationService _occupationService;

        public PremiumCalculationService(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        } 

        public async Task<decimal> CalculateYearlyDeathPremium(PremiumByOccupationInput input)
        {
            var age = Utility.GetAge(input.DateOfBirth);

            if (age <= Constants.MINIMUM_AGE)
                throw new InvalidOperationException(nameof(CalculateYearlyDeathPremium));

            var ratingFactor = await _occupationService.GetRatingFactor(input.OccupationId);

            if (ratingFactor <= 0)
                throw new InvalidOperationException(nameof(CalculateYearlyDeathPremium));

            var deathCover = input.CoverAmount * ratingFactor * age;

            return deathCover / Constants.DIVIDING_FACTOR * Constants.YEARLY;
        }
    }
}
