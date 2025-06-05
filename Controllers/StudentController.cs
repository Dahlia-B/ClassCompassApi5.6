using ClassCompass.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using ClassCompass.Shared.Models;

namespace ClassCompassApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentApi _studentService;

        public StudentController(StudentApi studentService)
        {
            _studentService = studentService;
        }

        // POST: api/school
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (student== null)
                return BadRequest("Invalid grade data.");

            var addedStudent = await _studentService.AddStudent(student);
            if (addedStudent == null)
                return StatusCode(500, "Failed to add student.");

            return Ok(new { Message = "Student added successfully!", Student = addedStudent });
        }



    }
}
