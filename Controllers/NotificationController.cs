using ClassCompass.Shared.Models;
using ClassCompass.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClassCompassApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] Notifications request)
        {
            if (string.IsNullOrWhiteSpace(request?.UserId.ToString()))
                return BadRequest("User ID is required.");

            // Convert UserId to string, since your NotificationService expects string
            var userIdString = request.UserId.ToString();

            await _notificationService.SendClassReminder(userIdString);

            return Ok(new { Message = "Notification sent successfully!" });
        }
    }
}
