using Newtonsoft.Json;
using PremiumCalculationMicroservice.Common;
using PremiumCalculationMicroservice.Interface;
using System.Net.Http;
using System.Threading.Tasks;

namespace PremiumCalculationMicroservice.Service
{
    public class OccupationService : IOccupationService
    {
        private const string RatingFactorPath = "occupation/{0}/rating-factor";
        private readonly HttpClient _websiteHttpClientFactory;

        public OccupationService(IHttpClientFactory httpClientFactory)
        {
            _websiteHttpClientFactory = httpClientFactory.CreateClient(Constants.API_ENDPOINT);
        }

        public async Task<decimal> GetRatingFactor(int occupationId)
        {
            string path = string.Format(RatingFactorPath, occupationId);

            var ratingFactorResponse = await _websiteHttpClientFactory.GetAsync(path); 

            return JsonConvert.DeserializeObject<decimal>(await ratingFactorResponse.Content.ReadAsStringAsync()); 
        }
    }
}
