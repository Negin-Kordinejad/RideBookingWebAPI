using Microsoft.Extensions.Configuration;
using RideBooking.Infrastructure.Utility;

namespace RideBooking.Infrastructure.GateWay.Config
{
    /// <summary>
    /// ToDo : Seprate ApiConfig files for every services when they grown.
    /// </summary>
    public class ApiConfig
    {
        private readonly IConfiguration _config;
        private const string Listing = "Listing";
        private const string IpStack = "IpStack";
        private const string Security = "Security";

        private const string Key = "EncryptionKey";
        private const string Ivector = "EncryptionIVector";

        private const string ListingUrlForPassengers = "Listing_Url";
        private const string ListingQuoteRequestAction = "Quote_Request";

        private const string IpStackUrlForLocation = "IpStack_Url";
        private const string IpStackCridentialForLocation = "Cridential";


        public ApiConfig(IConfiguration config, IIdentityServiceUtility ids)
        {
            _config = config;

            var securitySection = _config.GetSection(Security).AsEnumerable(true).ToDictionary(d => d.Key, d => d.Value);
            securitySection.TryGetValue(Key, out string key);
            securitySection.TryGetValue(Ivector, out string iVector);

            var listingSection = _config.GetSection(Listing).AsEnumerable(true).ToDictionary(d => d.Key, d => d.Value);
            ListingUrl = listingSection[ListingUrlForPassengers]!;
            ListingQuoteRequest = listingSection[ListingQuoteRequestAction]!;

            var IpStackSection = _config.GetSection(IpStack).AsEnumerable(true).ToDictionary(d => d.Key, d => d.Value);
            IpStackUrl = IpStackSection[IpStackUrlForLocation]!;
            var ipStackCridentialDecrypted = IpStackSection[IpStackCridentialForLocation]!;
            IpStackCridential = ids.DeserializeData(ipStackCridentialDecrypted, key, iVector);
        }


        public string ListingUrl { get; private set; }

        public string ListingQuoteRequest { get; private set; }

        public string IpStackCridential { get; private set; }

        public string IpStackUrl { get; private set; }
    }
}
