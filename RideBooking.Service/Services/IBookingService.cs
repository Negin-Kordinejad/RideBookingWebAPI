using RideBooking.Infrastructure.Models;
using RideBooking.Service.Dto;

namespace RideBooking.Service.Services
{
    public interface IBookingService
    {
        Task<Response<JournyDto>> GetListingAsync(int passengers, string? name);
    }
}
