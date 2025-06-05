using ClassCompassApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ClassCompass.Shared.Models;

namespace ClassCompassApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;

        public AuthController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost("homework/assign")]
        public async Task<IActionResult> AssignHomework([FromBody] Assignment assignment)
        {
            if (assignment == null)
                return BadRequest("Invalid assignment data.");

            await _homeworkService.AssignHomework(assignment);
            return Ok(new { Message = "Homework assigned successfully!" });
        }
    }
}
