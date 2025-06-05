using ClassCompass.Shared.Models;
using ClassCompass.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClassCompassApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceApi _attendanceService;

        public AttendanceController(AttendanceApi attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost("{studentId}")]
        public async Task<IActionResult> MarkAttendance(string studentId, [FromBody] Attendance record)
        {
            if (record == null)
                return BadRequest("Attendance record is required.");

            var result = await _attendanceService.MarkAttendance(studentId, record);

            if (!result)
                return StatusCode(500, "Failed to record attendance.");

            return Ok(new { Message = "Attendance recorded successfully!" });
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetAttendanceHistory(string studentId)
        {
            var records = await _attendanceService.GetAttendanceRecords(studentId);

            if (records == null || records.Count == 0)
                return NotFound(new { Message = "No attendance records found." });

            return Ok(records);
        }
    }
}
