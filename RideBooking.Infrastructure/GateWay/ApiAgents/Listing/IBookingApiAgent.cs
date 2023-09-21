using RideBooking.Model;

namespace RideBooking.Infrastructure.GateWay.ApiAgents.Listing
{
    public interface IBookingApiAgent
    {
      Task<Journy> GetListingByPassengersAsync();
    }
}
