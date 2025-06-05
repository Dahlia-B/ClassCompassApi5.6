using ClassCompass.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using ClassCompass.Shared.Models;

namespace ClassCompassApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolApi _schoolService;

        public SchoolController(SchoolApi schoolService)
        {
            _schoolService = schoolService;
        }

        // POST: api/school
        [HttpPost]
        public async Task<IActionResult> AddSchool([FromBody] School school)
        {
            if (school == null)
                return BadRequest("Invalid grade data.");

            var addedSchool = await _schoolService.AddSchool(school);
            if (addedSchool == null)
                return StatusCode(500, "Failed to add school.");

            return Ok(new { Message = "School added successfully!", School = addedSchool });
        }



    }
}
