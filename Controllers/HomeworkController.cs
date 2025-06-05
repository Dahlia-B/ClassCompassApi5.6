using ClassCompassApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ClassCompass.Shared.Data;
using ClassCompass.Shared.Models;
using ClassCompass.Shared;
using ClassCompass.Shared.Services;

namespace ClassCompassApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;

        public HomeworkController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> Assignment([FromBody] Assignment assignment)
        {
            if (assignment == null)
                return BadRequest("Invalid assignment data.");

            await _homeworkService.AssignHomework(assignment);
            return Ok(new { Message = "Homework assigned successfully!" });
        }

        [HttpPost("grade")]
        public async Task<IActionResult> GradeHomework([FromBody] Grade grade)
        {
            if (grade == null)
                return BadRequest("Invalid grade data.");

            await _homeworkService.GradeHomework(grade);
            return Ok(new { Message = "Homework graded successfully!" });
        }
    }
}