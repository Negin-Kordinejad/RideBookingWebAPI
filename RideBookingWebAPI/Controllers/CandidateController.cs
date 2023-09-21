using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RideBookingWebAPI.Controllers
{
    [Route("candidate")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new { name = "test", phone = "test" });
    }
}
