namespace RideBooking.Infrastructure.Models
{
    public class Response<T> : Response
    {
        /// <summary>
        ///  response data payload
        /// </summary>
        public T Data { get; set; }
    }
}
