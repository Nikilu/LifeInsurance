using System;

namespace PremiumCalculationMicroservice.Models
{
    public class PremiumByOccupationInput
    {
        public decimal CoverAmount { set; get; }
        public decimal RatingFactor { set; get; }
        public int OccupationId { set; get; }
        public DateTime DateOfBirth { get; set; }
    }
}
