using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using TransitApp.Server.GTFSStatic.Infrastructure.Data;
using TransitApp.Server.GTFSStatic.Infrastructure.MTA;

namespace TransitApp.Server.WebApi.ScheduledJobs
{
    public class CreateStaticScheduleJob : ScheduledJob
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

            using (var conn = new SqlConnection(dbConnStr))
            {
                conn.Open();

               
                using (var cmd = new SqlCommand("sp_CreateStaticSchedule", conn))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.StoredProcedure;

                    TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    DateTime easternTimeNow = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.Utc,
                                                                    easternZone);
                    cmd.Parameters.AddWithValue("@today", easternTimeNow);
                }
            }
        }
    }
}