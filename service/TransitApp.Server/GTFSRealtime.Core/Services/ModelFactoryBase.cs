using System;

namespace TransitApp.Server.GTFSRealtime.Core.Services
{
    public abstract class ModelFactoryBase
    {
        protected static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var utcTime = dtDateTime.AddSeconds(unixTimeStamp);

            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTimeNow = TimeZoneInfo.ConvertTime(utcTime, TimeZoneInfo.Utc,
                                                            easternZone);
   
            return easternTimeNow;
        }
    }
}