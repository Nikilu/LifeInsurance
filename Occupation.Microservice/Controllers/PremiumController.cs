using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OccupationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    { 
        // POST api/<PremiumController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PremiumController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PremiumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
