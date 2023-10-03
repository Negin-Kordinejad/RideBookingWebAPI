
using Microsoft.Extensions.Configuration;

namespace RideBooking.Infrastructure.GateWay.Config
{
    /// <summary>
    /// ToDo : Seprate ApiConfig files for every services when they grown.
    /// </summary>
    public class ApiConfig
    {
        private readonly IConfiguration _config;
        private const string ListingUrlForPassengers = "Listing_Url";
        private const string ListingQuoteRequestAction = "Quote_Request";
        private const string IpStackUrlForLocation = "IpStack_Url";
        private const string IpStackCridentialForLocation = "IpStack_Cridential";

        public ApiConfig(IConfiguration config)
        {
            _config = config;
            ListingUrl = _config.GetSection(ListingUrlForPassengers).Value!;
            ListingQuoteRequest = _config.GetSection(ListingQuoteRequestAction).Value!;
            IpStackUrl = _config.GetSection(IpStackUrlForLocation).Value!;
            IpStackCridential = _config.GetSection(IpStackCridentialForLocation).Value!;
        }


        public string ListingUrl { get; private set; }

        public string ListingQuoteRequest { get; private set; }

        public string IpStackUrl { get; private set; }

        public string IpStackCridential { get; private set; }

    }
}

