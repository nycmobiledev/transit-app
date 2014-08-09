using System;
using System.Linq;
using NUnit.Framework;
using TransitApp.Server.GTFSRealtime.Core.DTO;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.GTFSRealtime.Infrastructure.MTA;

namespace TransitApp.Server.GTFSRealtime.IntegrationTests.MTA
{
    [TestFixture]
    internal abstract class FeedMessageServiceTestsBase
    {
        protected string CombinedUrl;
        protected FeedMessageService MtaFeedService;
        protected const string ApiKey = "80730fbe1b42c61fc060da055cb33334";
        protected const string Url = "http://datamine.mta.info/mta_esi.php?key={0}&feed_id=";

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            CombinedUrl = string.Format(Url, ApiKey);
            MtaFeedService = new FeedMessageService(CombinedUrl);
        }

        protected static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }

        protected static void PrintHeader(FeedHeader header)
        {
            Console.WriteLine("Header Info");
            Console.WriteLine("=========================================");
            Console.WriteLine("GTFS Realtime Version: {0}", header.GtfsRealtimeVersion);
            Console.WriteLine("Data Incrementality: {0}", header.DataIncrementality.ToString());
            Console.WriteLine("Timestamp: {0:F}", UnixTimeStampToDateTime(header.Timestamp));
            Console.WriteLine("NYCT Subway Version: {0}", header.NyctFeedHeader.NyctSubwayVersion);
            Console.WriteLine("Trip Replacement Periods:");
            foreach (var replacementPeriod in header.NyctFeedHeader.TripReplacementPeriod) {
                Console.WriteLine("\tRoute: {0}\tStart: {1}\tEnd: {2:F}", replacementPeriod.RouteId,
                    replacementPeriod.ReplacementPeriod.Start,
                    UnixTimeStampToDateTime(replacementPeriod.ReplacementPeriod.End));
            }
        }

        protected static void PrintAlert(FeedEntity feedEntity)
        {
            if (feedEntity.Alert == null) {
                return;
            }
            Console.WriteLine("Cause: {0}", feedEntity.Alert.Cause.ToString());
            Console.WriteLine("Effect: {0}", feedEntity.Alert.Effect.ToString());
            Console.WriteLine("Url: {0}", feedEntity.Alert.Url);
            Console.WriteLine("=========================================");
            Console.WriteLine("Trips Affected");
            Console.WriteLine("=========================================");
            foreach (var selector in feedEntity.Alert.InformedEntity) {
                PrintTripDescriptor(selector.Trip);
            }

            Console.WriteLine("=========================================");
            Console.WriteLine("Alert Text");
            Console.WriteLine("=========================================");
            foreach (var text in feedEntity.Alert.HeaderText.Translations) {
                Console.WriteLine("Message: {0}", text.Text);
            }
        }

        protected static void PrintVehiclePosition(FeedEntity feedEntity)
        {
            if (feedEntity.Vehicle == null) {
                return;
            }

            PrintTripDescriptor(feedEntity.Vehicle.Trip);
            Console.WriteLine("Congestion Level: {0}", feedEntity.Vehicle.CongestionLevelValue);
            Console.WriteLine("Current Status: {0}", feedEntity.Vehicle.CurrentStatus);
            Console.WriteLine("Curent Stop Sequence: {0}", feedEntity.Vehicle.CurrentStopSequence);
            //Console.WriteLine(feedEntity.vehicle.position.ToString() ?? "");
            Console.WriteLine("Stop ID: {0}", feedEntity.Vehicle.StopId);
            Console.WriteLine("Timestamp: {0:F}", UnixTimeStampToDateTime(feedEntity.Vehicle.Timestamp));
        }

        protected static void PrintTripUpdate(FeedEntity feedEntity)
        {
            if (feedEntity.TripUpdate == null) {
                return;
            }

            PrintTripDescriptor(feedEntity.TripUpdate.Trip);
            foreach (var stopTimeUpdate in feedEntity.TripUpdate.StopTimeUpdates) {
                if (stopTimeUpdate.Arrival != null) {
                    Console.WriteLine("Arrival: {0}\tDelay: {1}\tUncertainty: {2}",
                        UnixTimeStampToDateTime((ulong) stopTimeUpdate.Arrival.Time), stopTimeUpdate.Arrival.Delay,
                        stopTimeUpdate.Arrival.Uncertainty);
                }
                if (stopTimeUpdate.Departure != null) {
                    Console.WriteLine("Departure: {0}\tDelay: {1}\tUncertainty: {2}",
                        UnixTimeStampToDateTime((ulong) stopTimeUpdate.Departure.Time), stopTimeUpdate.Departure.Delay,
                        stopTimeUpdate.Departure.Uncertainty);
                }
                Console.WriteLine("Schedule Relationship: {0}", stopTimeUpdate.ScheduleRelationship);
                Console.WriteLine("Stop ID: {0}", stopTimeUpdate.StopId);
                Console.WriteLine("Stop Sequence: {0}", stopTimeUpdate.StopSequence);

                if (stopTimeUpdate.NyctStopTimeUpdate != null) {
                    Console.WriteLine("Scheduled Track: {0}", stopTimeUpdate.NyctStopTimeUpdate.ScheduledTrack);
                    Console.WriteLine("Actual Track: {0}", stopTimeUpdate.NyctStopTimeUpdate.ActualTrack);
                }
                Console.WriteLine("-----------------------------------------------");
            }
        }

        protected static void PrintTripDescriptor(TripDescriptor trip)
        {
            Console.WriteLine("Trip ID: {0}", trip.TripId);
            Console.WriteLine("Route ID: {0}", trip.RouteId);
            if (!string.IsNullOrWhiteSpace(trip.StartDate)) {
                Console.WriteLine("Start Date: {0:F}",
                    new DateTime(int.Parse(trip.StartDate.Substring(0, 4)), int.Parse(trip.StartDate.Substring(4, 2)),
                        int.Parse(trip.StartDate.Substring(6, 2))));
            }
            Console.WriteLine("Schedule Relationship: {0}", trip.ScheduleRelationship);

            if (trip.NyctTripDescriptor != null) {
                Console.WriteLine("Direction: {0}", trip.NyctTripDescriptor.Direction);
                Console.WriteLine("Is Assigned: {0}", trip.NyctTripDescriptor.IsAssigned);
                Console.WriteLine("Train ID: {0}", trip.NyctTripDescriptor.TrainId);
            }
            Console.WriteLine("-----------------------------------------------");
        }

        protected static void PrintEntityList(SubwayLines lines, FeedMessage msg)
        {
            Console.WriteLine("Entity Count for {0}: {1}", lines.ToString(), msg.Entity.Count);
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Entity Breakdown");
            Console.WriteLine("=================================");
            Console.WriteLine("Trip Updates: {0}", msg.Entity.Count(e => e.TripUpdate != null));
            Console.WriteLine("Vehicle Positions: {0}", msg.Entity.Count(e => e.Vehicle != null));
            Console.WriteLine("Alerts: {0}", msg.Entity.Count(e => e.Alert != null));
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Trip Updates");
            Console.WriteLine("=================================");
            foreach (var entity in msg.Entity.Where(e => e.TripUpdate != null)) {
                PrintTripUpdate(entity);
            }
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Vehicle Positions");
            Console.WriteLine("=================================");
            foreach (var entity in msg.Entity.Where(e => e.Vehicle != null)) {
                PrintVehiclePosition(entity);
            }
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Alerts");
            Console.WriteLine("=================================");
            foreach (var entity in msg.Entity.Where(e => e.Alert != null)) {
                PrintAlert(entity);
            }
        }
    }
}