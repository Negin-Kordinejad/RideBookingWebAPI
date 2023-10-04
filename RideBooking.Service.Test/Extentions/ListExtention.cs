namespace RideBooking.Service.Test.Extentions
{
    internal static class ListExtention
    {
        internal static List<T> AsList<T>(this T instance)
        {
            return new List<T>
            {
                instance
            };
        }
    }
}
