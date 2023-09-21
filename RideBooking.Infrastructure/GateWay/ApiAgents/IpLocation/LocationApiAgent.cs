using RideBooking.Infrastructure.GateWay.ApiAgents.Base;
using RideBooking.Infrastructure.GateWay.ClientAgent.Web;
using RideBooking.Infrastructure.GateWay.Config;
using RideBooking.Model;

namespace RideBooking.Infrastructure.GateWay.ApiAgents.IpLocation
{
    public class LocationApiAgent : ApiAgent, ILocationApiAgent
    {
        private readonly ApiConfig _apiConfig;

        public LocationApiAgent(ApiConfig apiConfig, IHttpService httpService)
            : base(apiConfig.IpStackUrl, httpService)
        {
            _apiConfig = apiConfig;
        }

        public async Task<Location> IpLocatorAsync(string ipAddress)
        {
            var response = await GetApiAsync($"{ipAddress}{_apiConfig.IpStackCridential}");

            return ToObject<Location>(response);
        }

    }
}
