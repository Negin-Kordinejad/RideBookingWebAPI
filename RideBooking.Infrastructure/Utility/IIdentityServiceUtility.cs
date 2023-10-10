using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideBooking.Infrastructure.Utility
{
    public interface IIdentityServiceUtility
    {
        string EncryptData(string data, string key, string iVector);
        string DeserializeData(string encodedData, string key, string iVector);
    }
}
