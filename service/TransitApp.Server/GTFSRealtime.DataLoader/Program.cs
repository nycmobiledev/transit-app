using System;
using System.Threading.Tasks;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.GTFSRealtime.Core.Services;
using TransitApp.Server.GTFSRealtime.Infrastructure.MTA;

namespace GTFSRealtime.DataLoader
{
    internal class Program
    {
        protected const string ApiKey = "80730fbe1b42c61fc060da055cb33334";
        protected const string Url = "http://datamine.mta.info/mta_esi.php?key={0}&feed_id=";

        private static void Main(string[] args)
        {
            AsyncMain().Wait();
        }

        private static async Task AsyncMain()
        {
            // Load Feed Message
            var combinedUrl = string.Format(Url, ApiKey);
            var service = new FeedMessageService(combinedUrl);
            var msgL = await service.GetCurrentRealtimeFeedMessage(SubwayLines.L);
            var msgIrt = await service.GetCurrentRealtimeFeedMessage(SubwayLines.RED_GREEN_S);

            var alertFactory = new AlertFactory();
            var alertsIrt = alertFactory.CreateItemsFromFeedMessage(msgIrt);
            var alertsL = alertFactory.CreateItemsFromFeedMessage(msgL);

            foreach (var alertIrt in alertsIrt)
            {
                Console.WriteLine("{0}: {1}", alertIrt.TripId, alertIrt.Message);
            }

            foreach (var alertL in alertsL)
            {
                Console.WriteLine("{0}: {1}", alertL.TripId, alertL.Message);
            }

            // Clear Tables

            // Load Tables
        }
    }
}