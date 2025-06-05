using ClassCompass.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using ClassCompass.Shared.Models;

namespace ClassCompassApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly GradesApi _gradesService;

        public GradesController(GradesApi gradesService)
        {
            _gradesService = gradesService;
        }

        // POST: api/grades
        [HttpPost]
        public async Task<IActionResult> AssignGrade([FromBody] Grade grade)
        {
            if (grade == null)
                return BadRequest("Invalid grade data.");

            var assignedGrade = await _gradesService.AssignGrade(grade);
            if (assignedGrade == null)
                return StatusCode(500, "Failed to assign grade.");

            return Ok(new { Message = "Grade assigned successfully!", Grade = assignedGrade });
        }

        // GET: api/grades/{studentId}
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetGrades(string studentId)
        {
            var grades = await _gradesService.GetGrades(studentId);
            return grades != null && grades.Any()
                ? Ok(grades)
                : NotFound("No grades found for this student.");
        }
    }
}
