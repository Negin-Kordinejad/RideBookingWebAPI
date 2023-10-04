﻿using Microsoft.Extensions.Logging;
using RideBooking.Infrastructure.GateWay.ApiAgents.Listing;
using RideBooking.Model;
using RideBooking.Service.Dto;

namespace RideBooking.Service.Services
{
    public class BookingService : IBookingService
    {
        private readonly ILogger<BookingService> _logger;
        private readonly IBookingApiAgent _bookingApiAgent;

        public BookingService(ILogger<BookingService> logger, IBookingApiAgent bookingApiAgent)
        {
            _logger = logger;
            _bookingApiAgent = bookingApiAgent;
        }

        public async Task<JournyDto> GetListingAsync(int passengers, string? name)
        {
            var logPriFix = $"BookingService::GetListingAsync:No listing found";
            var listing = await _bookingApiAgent.GetListingByPassengersAsync();

            //  var filteredListing =new IGrouping
            //ToDo: In refactoring will make a response wrapper and middleware error handling to avoid try-cache
            if (listing == null)
            {
                _logger.LogError($"{logPriFix} for GetListingByPassengersAsync");
                throw new ArgumentException($"No listing found.");
            }

            //Get all listing with specific the number of passenger. 
            var filteredListing = listing.listings.Where(s => s.vehicleType.maxPassengers == passengers &&
                                                                     (name == null ||
                                                                     s.vehicleType.name.ToLower() == name.ToLower()
                                                        )).ToList();

            if (filteredListing.Count == 0)
            {
                _logger.LogError($"{logPriFix} for {passengers} passengers numbers");
                throw new ArgumentException($"No listing found for {passengers} passengers numbers.");
            }

            return GetCalculatedTotalPriceListing(filteredListing, listing.from, listing.to);
        }

        private JournyDto GetCalculatedTotalPriceListing(List<Listing> filteredList, string source, string destination)
        {
            var TtResult = filteredList.Select(s =>
                                               new
                                               {
                                                   Name = s.name,
                                                   Total = s.pricePerPassenger * s.vehicleType.maxPassengers
                                               }
                                               )
                                        .OrderByDescending(o => o.Total)
                                        .ToList();

            //ToDo: Need AutoMapper to convert.
            return new JournyDto()
            {
                From = source,
                To = destination,
                Result = TtResult.ConvertAll(x => new ListingDto
                {
                    Name = x.Name,
                    Total = x.Total
                })
            };

        }
    }
}
