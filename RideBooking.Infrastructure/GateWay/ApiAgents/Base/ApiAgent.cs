using Newtonsoft.Json;
using RideBooking.Infrastructure.GateWay.ClientAgent.Web;

namespace RideBooking.Infrastructure.GateWay.ApiAgents.Base
{
    public class ApiAgent
    {
        private readonly string _endpoint;
        private readonly IHttpService _httpService;

        public ApiAgent(string endpoint, IHttpService httpService)
        {
            _endpoint = endpoint;
            _httpService = httpService;
        }

        public virtual async Task<string> GetApiAsync(string function)
        {
            var url = $"{_endpoint}/{function}";
            return await _httpService.Get(url);
        }

        public virtual T ToObject<T>(string jsonResponse)
        {
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
