using System;
using NUnit.Framework;
using TransitApp.Server.GTFSRealtime;
using TransitApp.Server.GTFSRealtime.DTO;

namespace TransitApp.Server.IntegrationTests
{
    [TestFixture]
    public abstract class FeedMessageServiceTestsBase
    {
        protected string CombinedUrl;
        protected FeedMessageService Service;
        protected const string ApiKey = "80730fbe1b42c61fc060da055cb33334";
        protected const string Url = "http://datamine.mta.info/mta_esi.php?key={0}&feed_id=";

        protected static void DumpHeader(FeedHeader header)
        {
            Console.WriteLine("Header Info");
            Console.WriteLine("=========================================");
            Console.WriteLine("Gtfs Realtime Version: {0}", header.GtfsRealtimeVersion);
            Console.WriteLine("Data Incrementality: {0}", header.DataIncrementality.ToString());
            Console.WriteLine((string) "Timestamp: {0:F}", (object) UnixTimeStampToDateTime(header.Timestamp));
            Console.WriteLine("Nyct Subway Version: {0}", header.NyctFeedHeader.NyctSubwayVersion);
            Console.WriteLine("Trip Replacement Periods:");
            foreach (var replacementPeriod in header.NyctFeedHeader.TripReplacementPeriod) {
                Console.WriteLine("\tRoute: {0}\tStart: {1}\tEnd: {2}", replacementPeriod.RouteId,
                    replacementPeriod.ReplacementPeriod.Start,
                    UnixTimeStampToDateTime(replacementPeriod.ReplacementPeriod.End));
            }
        }

        protected static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            CombinedUrl = string.Format(Url, ApiKey);
            Service = new FeedMessageService(CombinedUrl);
        }
    }
}