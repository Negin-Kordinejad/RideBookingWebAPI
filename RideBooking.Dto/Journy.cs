using System.Reflection;

namespace RideBooking.Model
{
    public class Journy
    {
        public string from { get; set; }
        public string to { get; set; }
        public Listing[] listings { get; set; }
    }

}
