using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.GTFSStatic.Infrastructure.Data;
using TransitApp.Server.GTFSStatic.Infrastructure.MTA;

namespace TransitApp.Server.WebApi.ScheduledJobs
{
    public class GTFSStaticJob : ScheduledJob
    {
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

            var service = new StaticFileService(new StaticFileDownloader());


            StringBuilder sb = new StringBuilder();

            List<string> tableNames = new List<string>()
            {
                "agency",
                "calendar",
                "calendar_dates",
                "shapes",
                "stop_times",
                "transfers",
                "trips",
                "routes",
                "stops",
            };

            tableNames.ForEach(s => sb.AppendFormat("TRUNCATE TABLE {0};", s));

            using (var conn = new SqlConnection(dbConnStr))
            {
                using (var cmd = new SqlCommand(sb.ToString(), conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }


                //Agency
                using (var repository = new AgencyRepository() {Connection = conn})
                {
                    // Load Tables
                    repository.AddRange(await service.GetAgencies());
                }

//            using (var repository = new CalendarDateRepository(dbConnStr))
//            {
//                // Load Tables
//                repository.AddRange(service.GetCalendarDates());
//            }

                //Calendars
                using (var repository = new CalendarRepository() {Connection = conn})
                {
                    // Load Tables
                    repository.AddRange(await service.GetCalendars());
                }
                //Route
                using (var repository = new RouteRepository() {Connection = conn})
                {
                    // Load Tables
                    repository.AddRange(await service.GetRoutes());
                }
                //Shape
                using (var repository = new ShapeRepository() {Connection = conn})
                {
                    // Load Tables
                    repository.AddRange(await service.GetShapes());
                }
                //Stop
                using (var repository = new StopRepository() {Connection = conn})
                {
                    // Load Tables
                    repository.AddRange(await service.GetStops());
                }
                //Stop Time
                using (var repository = new StopTimeRepository() {Connection = conn})
                {
                    // Load Tables
                    repository.AddRange(await service.GetStopTimes());
                }
                //Transfer
                using (var repository = new TransferRepository() {Connection = conn})
                {
                    // Load Tables
                    repository.AddRange(await service.GetTransfers());
                }
                //Trip
                using (var repository = new TripRepository() {Connection = conn})
                {
                    // Load Tables
                    repository.AddRange(await service.GetTrips());
                }

                // Build Stations
                using (var cmd = new SqlCommand("sp_BuildStations", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
//                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}