namespace RideBooking.Infrastructure.GateWay.ClientAgent.Web
{
    public interface IHttpService
    {
        Task<string> Get(string url);
    }
}
