using RideBooking.Infrastructure.GateWay.ApiAgents.Base;
using RideBooking.Infrastructure.GateWay.ClientAgent.Web;
using RideBooking.Infrastructure.GateWay.Config;
using RideBooking.Model;

namespace RideBooking.Infrastructure.GateWay.ApiAgents.Listing
{
    public class BookingApiAgent : ApiAgent, IBookingApiAgent
    {
        private readonly ApiConfig _apiConfig;

        public BookingApiAgent(ApiConfig apiConfig, IHttpService httpService)
            : base(apiConfig.ListingUrl, httpService)
        {
            _apiConfig = apiConfig;
        }

        public async Task<Journy> GetListingByPassengersAsync()
        {
            var response = await GetApiAsync($"{_apiConfig.ListingQuoteRequest}");

            return ToObject<Journy>(response);
        }
    }
}
