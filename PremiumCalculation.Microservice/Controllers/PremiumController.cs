using Microsoft.AspNetCore.Mvc;
using PremiumCalculationMicroservice.Interface;
using PremiumCalculationMicroservice.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PremiumCalculationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IPremiumCalculationService _premiumCalculationService;

        public PremiumController(IPremiumCalculationService premiumCalculationService)
        { _premiumCalculationService = premiumCalculationService; }

        [HttpPost]
        [Route("death/yearly")]
        public async Task<IActionResult> CalculateDeathPremium([FromBody] PremiumByOccupationInput input)
        {
            try
            {
                if (input == null || !ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }
                var premium = await _premiumCalculationService.CalculateYearlyDeathPremium(input);

                return new OkObjectResult(premium);
            }
            catch (InvalidOperationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
