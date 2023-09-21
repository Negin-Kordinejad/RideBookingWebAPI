namespace RideBooking.Service.Dto
{
    public class JournyDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public List<ListingDto> Result { get; set; } = new List<ListingDto>();
    }

}
