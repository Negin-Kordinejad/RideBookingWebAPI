using RideBooking.Model;

namespace RideBooking.Service.Services
{
    public interface ILocationService
    {
        Task<Location> IpLocator(string ipAddress);
    }
}