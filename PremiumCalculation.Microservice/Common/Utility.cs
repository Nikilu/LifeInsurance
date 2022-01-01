using System;

namespace PremiumCalculationMicroservice.Common
{
    public static class Utility
    {
        public static int GetAge(DateTime dob)
        {
            var today = DateTime.Today;

            var age = today.Year - dob.Year;

            if (today.Month < dob.Month || (today.Month == dob.Month && today.Day < dob.Day))
                age--;

            return age;
        }
    }
}
