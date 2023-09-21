using RideBooking.Service.Dto;

namespace RideBooking.Service.Services
{
    public interface IBookingService
    {
        Task<JournyDto> GetListingAsync(int passengers);
    }
}
