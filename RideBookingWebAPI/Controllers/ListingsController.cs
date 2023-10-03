using Microsoft.AspNetCore.Mvc;
using RideBooking.Service.Dto;
using RideBooking.Service.Services;

namespace RideBookingWebAPI.Controllers
{
    [Route("Listings")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly ILogger<ListingsController> _logger;
        private readonly IBookingService _bookingService;

        public ListingsController(ILogger<ListingsController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpGet("{passengers:int}")]
        public async Task<IActionResult> GetListing(int passengers, string? name)
        {
            var logPreFix = $"ListingsController::GetListing";
            JournyDto response;

            if (passengers <= 0)
            {
                _logger.LogError($"{logPreFix} Incorrect parameter applied.");

                return BadRequest("Number of passengers is incorrect.");
            }
            //ToDo:An error handler in middleware needs to add.
            try
            {
                response = await _bookingService.GetListingAsync(passengers, name);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(response);

        }
    }
}
