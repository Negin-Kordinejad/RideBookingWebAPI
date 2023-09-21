
using RideBooking.Model;

namespace RideBooking.Infrastructure.GateWay.ApiAgents.IpLocation
{
    public interface ILocationApiAgent
    {
        Task<Location> IpLocatorAsync(string ipAddress);
    }
}
