using Microsoft.AspNetCore.Mvc;
using RideBooking.Infrastructure.Models;
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
            var response = await _bookingService.GetListingAsync(passengers, name);

            if (response.IsSuccessful == false)
            {
                string errorCode = response.ErrorMessages[0].ErrorCode;

                if (errorCode == ResponseCode.NotFound.ToString())
                {
                    return NotFound(response.ErrorMessages);
                }
            }

            return Ok(response.Data);

        }
    }
}
