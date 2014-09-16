using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.GTFSRealtime.Core.Services;
using TransitApp.Server.GTFSRealtime.Infrastructure.Data;
using TransitApp.Server.GTFSRealtime.Infrastructure.MTA;

namespace TransitApp.Server.GTFSRealtime.DataLoader
{
    internal class Program
    {
        protected const string ApiKey = "<INSERT API KEY>";
        protected const string Url = "http://datamine.mta.info/mta_esi.php?key={0}&feed_id=";

        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            var t = AsyncMain();
            t.Wait();
            watch.Stop();
            Console.WriteLine("Finished in {0} milliseconds.", watch.ElapsedMilliseconds);
        }

        private static async Task AsyncMain()
        {
            // Load Feed Message
            var dbConnStr = ConfigurationManager.ConnectionStrings["DbConnStr"].ConnectionString;

            var combinedUrl = string.Format(Url, ApiKey);
            var service = new FeedMessageService(combinedUrl);
            var msgIrt = await service.GetCurrentRealtimeFeedMessage(SubwayLines.RED_GREEN_S);
            var msgL = await service.GetCurrentRealtimeFeedMessage(SubwayLines.L);

            var alertFactory = new AlertFactory();
            var stopTimeFactory = new StopTimeUpdateFactory();
            var tripFactory = new TripFactory();
            var vehicleFactory = new VehiclePositionFactory();

            var alertsIrt = alertFactory.CreateItemsFromFeedMessage(msgIrt);
            var alertsL = alertFactory.CreateItemsFromFeedMessage(msgL);

            using (SqlConnection conn = new SqlConnection(dbConnStr))
            {

                using (var alertRepos = new AlertRepository() {Connection = conn})
                {
                    // Clear Tables
                    alertRepos.ClearAll();

                    // Load Tables
                    alertRepos.AddRange(alertsIrt);
                    alertRepos.AddRange(alertsL);
                }

                var stopsIrt = stopTimeFactory.CreateItemsFromFeedMessage(msgIrt);
                var stopsL = stopTimeFactory.CreateItemsFromFeedMessage(msgL);

                using (var stopsRepos = new StopTimeUpdateRepository() { Connection = conn })
                {
                    // Clear Tables
                    stopsRepos.ClearAll();

                    // Load Tables
                    stopsRepos.AddRange(stopsIrt);
                    stopsRepos.AddRange(stopsL);
                }

                var tripsIrt = tripFactory.CreateItemsFromFeedMessage(msgIrt);
                var tripsL = tripFactory.CreateItemsFromFeedMessage(msgL);

                using (var tripsRepos = new TripRepository() { Connection = conn })
                {
                    // Clear Tables
                    tripsRepos.ClearAll();

                    // Load Tables
                    tripsRepos.AddRange(tripsIrt);
                    tripsRepos.AddRange(tripsL);
                }

                var vehiclesIrt = vehicleFactory.CreateItemsFromFeedMessage(msgIrt);
                var vehiclesL = vehicleFactory.CreateItemsFromFeedMessage(msgL);

                using (var vehiclesRepos = new VehiclePositionRepository() { Connection = conn })
                {
                    // Clear Tables
                    vehiclesRepos.ClearAll();

                    // Load Tables
                    vehiclesRepos.AddRange(vehiclesIrt);
                    vehiclesRepos.AddRange(vehiclesL);
                }
            }
        }
    }
}