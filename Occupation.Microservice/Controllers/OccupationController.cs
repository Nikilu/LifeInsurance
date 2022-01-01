using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OccupationMicroservice.Interface;
using OccupationMicroservice.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OccupationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationService _occupationService;

        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }


        [HttpGet]
        public async Task<List<Occupation>> GetAll()
        {
            return await _occupationService.GetOccupations();
        }

        [HttpGet]
        [Route("{occupationId}/rating-factor")]
        public async Task<IActionResult> GetOccupationRatting(int occupationId)
        {
            try
            {
                var result = await _occupationService.GetOccupationRatingFactor(occupationId);
                return new OkObjectResult(result);
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
