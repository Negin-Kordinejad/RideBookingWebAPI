
namespace RideBooking.Infrastructure.GateWay.Config
{
    public class ApiConfig
    {
        /// <summary>
        /// This url valuse should transfer to a config file 
        /// </summary>
        public string ListingUrl { get; set; } = $"https://jayridechallengeapi.azurewebsites.net/api/";

        public string ListingQuoteRequest { get; set; } = $"QuoteRequest";

        public string IpStackUrl { get; set; } = $"http://api.ipstack.com/";

        public string IpStackCridential { get; set; } = $"?access_key=6250bd112317e8e0044c75bdc8c838af&fields=city";

    }
}

