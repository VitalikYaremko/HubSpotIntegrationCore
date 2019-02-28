using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Domain.Utils
{
    public class ConvertUtils
    {
        public static long DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            try
            {
                long unixTime = ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds();
                return unixTime;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
