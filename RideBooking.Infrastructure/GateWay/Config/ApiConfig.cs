
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

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

        public ApiConfig(IConfiguration config, IDataProtectionProvider idp)
        {
            _config = config;
            ListingUrl = _config.GetSection(ListingUrlForPassengers).Value!;
            ListingQuoteRequest = _config.GetSection(ListingQuoteRequestAction).Value!;
            IpStackUrl = _config.GetSection(IpStackUrlForLocation).Value!;
            IpStackCridential = _config.GetSection(IpStackCridentialForLocation).Value!;
            //Add a comment to for testing.
            var ctd = idp.CreateProtector(IpStackCridential);
            var protect = ctd.Protect(IpStackCridential);
            IpStackCridential = ctd.Unprotect(protect);
        }


        public string ListingUrl { get; private set; }

        public string ListingQuoteRequest { get; private set; }


        public string IpStackCridential { get; private set; }

        public string IpStackUrl { get; private set; }
    }
}
