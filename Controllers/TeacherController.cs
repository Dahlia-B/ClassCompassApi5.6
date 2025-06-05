using ClassCompass.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using ClassCompass.Shared.Models;

namespace ClassCompassApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherApi _teacherService;

        public TeacherController(TeacherApi teacherService)
        {
            _teacherService = teacherService;
        }

        // POST: api/school
        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            if (teacher == null)
                return BadRequest("Invalid grade data.");

            var addedTeacher = await _teacherService.AddTeacher(teacher);
            if (addedTeacher == null)
                return StatusCode(500, "Failed to add teacher.");

            return Ok(new { Message = "Teacher added successfully!", Teacher = addedTeacher });
        }



    }
}
