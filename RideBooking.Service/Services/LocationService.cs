using Microsoft.Extensions.Logging;
using RideBooking.Infrastructure.GateWay.ApiAgents.IpLocation;
using RideBooking.Model;
using System.Text.RegularExpressions;

namespace RideBooking.Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILogger<LocationService> _logger;
        private readonly ILocationApiAgent _bookingApiAgent;
        private const string Pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
        public LocationService(ILogger<LocationService> logger, ILocationApiAgent bookingApiAgent)
        {
            _logger = logger;
            _bookingApiAgent = bookingApiAgent;
        }
        
        public async Task<Location> IpLocator(string ipAddress)
        {
            var logPreFix = "LocationService::IpLocator";
            Location location;

            if (IsValidateIP(ipAddress))
            {
                location = await _bookingApiAgent.IpLocatorAsync(ipAddress);
            }
            else
            {
                _logger.LogError($"{logPreFix} Wrong Ip address provided.");
                throw new ArgumentException($"Ip:{ipAddress.Replace('.','_')} is invalid:");
            }

            return location;
        }

        private bool IsValidateIP(string Address)
        {
            Regex check = new(Pattern,RegexOptions.None, TimeSpan.FromMilliseconds(100));

            if (string.IsNullOrEmpty(Address))
            {
                return false;
            }
            else
            {
                return check.IsMatch(Address, 0);
            }
        }

    }
}
