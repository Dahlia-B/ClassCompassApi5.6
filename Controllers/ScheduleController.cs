using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ClassCompass.Shared.Models;
using ClassCompass.Shared.Services;

namespace ClassCompassApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleApi _scheduleApi;

        public ScheduleController(ScheduleApi scheduleApi)
        {
            _scheduleApi = scheduleApi;
        }

        // POST: api/schedule/generate
        [HttpPost("generate")]
        public async Task<IActionResult> GenerateSchedule([FromBody] ScheduleEntry request)
        {
            if (request == null)
                return BadRequest("Invalid schedule request.");

            try
            {
                var schedule = await _scheduleApi.GenerateWeeklySchedule(request);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating schedule: {ex.Message}");
            }
        }

        // POST: api/schedule/update
        [HttpPost("update")]
        public async Task<IActionResult> UpdateSchedule([FromBody] ScheduleTemplate update)
        {
            if (update == null)
                return BadRequest("Invalid schedule update.");

            try
            {
                await _scheduleApi.UpdateClassSchedule(update);
                return Ok(new { message = "Schedule updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating schedule: {ex.Message}");
            }
        }

        // GET: api/schedule/class/{classId}
        [HttpGet("class/{classId}")]
        public async Task<IActionResult> GetClassSchedule(string classId)
        {
            if (string.IsNullOrWhiteSpace(classId))
                return BadRequest("Class ID is required.");

            try
            {
                var schedule = await _scheduleApi.GetClassSchedule(classId);
                return schedule != null ? Ok(schedule) : NotFound("Schedule not found for the class.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving class schedule: {ex.Message}");
            }
        }

        // GET: api/schedule/teacher/{teacherId}
        [HttpGet("teacher/{teacherId}")]
        public async Task<IActionResult> GetTeacherSchedule(string teacherId)
        {
            if (string.IsNullOrWhiteSpace(teacherId))
                return BadRequest("Teacher ID is required.");

            try
            {
                var schedule = await _scheduleApi.GetTeacherSchedule(teacherId);
                return schedule != null ? Ok(schedule) : NotFound("Schedule not found for the teacher.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving teacher schedule: {ex.Message}");
            }
        }
    }
}
