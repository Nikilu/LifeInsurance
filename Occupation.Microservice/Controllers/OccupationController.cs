using System.Collections.Generic;
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
        public List<Occupation> GetAll()
        {
            return _occupationService.GetOccupations();
        }

        [HttpGet]
        [Route("{occupationId}/rating-factor")]
        public decimal GetOccupationRatting(int occupationId)
        {
            return _occupationService.GetOccupationRatingFactor(occupationId);
        }
    }
}
