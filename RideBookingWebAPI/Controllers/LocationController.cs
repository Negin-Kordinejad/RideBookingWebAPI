using Microsoft.AspNetCore.Mvc;
using RideBooking.Model;
using RideBooking.Service.Services;

namespace RideBookingWebAPI.Controllers
{
    [Route("Location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;
        public LocationController(ILogger<LocationController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        [HttpGet("{ipAddress}")]
        public async Task<IActionResult> GetIpLocation(string ipAddress)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(ipAddress))
                {
                    return BadRequest("Ip is not provided.");
                }
                
                Location City = await _locationService.IpLocator(ipAddress);
                if (City != null)
                {
                    return Ok(City.city);
                }

                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}