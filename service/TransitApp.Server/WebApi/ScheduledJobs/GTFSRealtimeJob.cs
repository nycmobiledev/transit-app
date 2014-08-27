using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.GTFSRealtime.Core.Services;
using TransitApp.Server.GTFSRealtime.Infrastructure.Data;
using TransitApp.Server.GTFSRealtime.Infrastructure.MTA;

namespace TransitApp.Server.WebApi.ScheduledJobs
{
    public class GTFSRealtimeJob : ScheduledJob
    {
        //protected const string ApiKey = "<INSERT API KEY>";
        private const string ApiKey = "80730fbe1b42c61fc060da055cb33334";
        private const string Url = "http://datamine.mta.info/mta_esi.php?key={0}&feed_id=";

        /// <summary>
        /// When implemented in a derived class, executes the scheduled job asynchronously. Implementations that want to know whether
        ///             the scheduled job is being cancelled can get a <see cref="P:Microsoft.WindowsAzure.Mobile.Service.ScheduledJob.CancellationToken"/> from the <see cref="M:CancellationToken"/> property.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task"/> representing the asynchronous operation.
        /// </returns>
        public override async Task ExecuteAsync()
        {
            // Load Feed Message
            var dbConnStr = ConfigurationManager.ConnectionStrings["MTA_DB"].ConnectionString;

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

            using (var alertRepos = new AlertRepository(dbConnStr)) {
                // Clear Tables
                alertRepos.ClearAll();

                // Load Tables
                alertRepos.AddRange(alertsIrt);
                alertRepos.AddRange(alertsL);
            }

            var stopsIrt = stopTimeFactory.CreateItemsFromFeedMessage(msgIrt);
            var stopsL = stopTimeFactory.CreateItemsFromFeedMessage(msgL);

            using (var stopsRepos = new StopTimeUpdateRepository(dbConnStr)) {
                // Clear Tables
                stopsRepos.ClearAll();

                // Load Tables
                stopsRepos.AddRange(stopsIrt);
                stopsRepos.AddRange(stopsL);
            }

            var tripsIrt = tripFactory.CreateItemsFromFeedMessage(msgIrt);
            var tripsL = tripFactory.CreateItemsFromFeedMessage(msgL);

            using (var tripsRepos = new TripRepository(dbConnStr)) {
                // Clear Tables
                tripsRepos.ClearAll();

                // Load Tables
                tripsRepos.AddRange(tripsIrt);
                tripsRepos.AddRange(tripsL);
            }

            var vehiclesIrt = vehicleFactory.CreateItemsFromFeedMessage(msgIrt);
            var vehiclesL = vehicleFactory.CreateItemsFromFeedMessage(msgL);

            using (var vehiclesRepos = new VehiclePositionRepository(dbConnStr)) {
                // Clear Tables
                vehiclesRepos.ClearAll();

                // Load Tables
                vehiclesRepos.AddRange(vehiclesIrt);
                vehiclesRepos.AddRange(vehiclesL);
            }

            //return Task.FromResult(true);
        }
        
    }
}