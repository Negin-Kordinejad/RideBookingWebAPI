using Microsoft.Extensions.Logging;

namespace RideBooking.Infrastructure.GateWay.ClientAgent.Web
{
    public class HttpService : IHttpService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _client;

        public HttpService(ILogger<HttpService> logger)
        {
            _logger = logger;
            _client = new HttpClient();
        }

        public async Task<string> Get(string url)
        {
            _logger.LogInformation($"HttpService::Get({url})");

            var httpResponse = await _client.GetAsync(url);

            _logger.LogInformation($"Respnose.StatusCode: {httpResponse.StatusCode}");

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadAsStringAsync();
        }
    }
}
