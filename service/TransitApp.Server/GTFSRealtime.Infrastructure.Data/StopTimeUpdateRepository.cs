using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class StopTimeUpdateRepository : RepositoryBase, IRepository<StopTimeUpdate>
    {
        public StopTimeUpdateRepository(string connectionString) : base(connectionString)
        {
            TableName = "dbo.realtime_stop_time_updates";
            InsertCmdText =
                string.Format(
                    "INSERT INTO {0} ([trip_id],[arrival],[departure],[stop_id],[scheduled_track],[actual_track]) VALUES (@tripid,@arrival,@departure,@stopid,@scheduledtrack,@actualtrack)",
                    TableName);
        }

        public void AddRange(IEnumerable<StopTimeUpdate> items)
        {
            Connection.Open();
            var cmd = new SqlCommand(InsertCmdText, Connection);
            cmd.Parameters.Add("@tripid", SqlDbType.NVarChar, 128);
            cmd.Parameters.Add("@arrival", SqlDbType.DateTime);
            cmd.Parameters.Add("@departure", SqlDbType.DateTime);
            cmd.Parameters.Add("@stopid", SqlDbType.NVarChar, 8);
            cmd.Parameters.Add("@scheduledtrack", SqlDbType.NVarChar, 4);
            cmd.Parameters.Add("@actualtrack", SqlDbType.NVarChar, 4);

            foreach (var stop in items) {
                cmd.Parameters["@tripid"].Value = stop.TripId;
                if (stop.Arrival.HasValue) {
                    cmd.Parameters["@arrival"].Value = stop.Arrival.GetValueOrDefault();
                } else {
                    cmd.Parameters["@arrival"].Value = DBNull.Value;
                }

                if (stop.Departure.HasValue) {
                    cmd.Parameters["@departure"].Value = stop.Departure.GetValueOrDefault();
                } else {
                    cmd.Parameters["@departure"].Value = DBNull.Value;
                }
                cmd.Parameters["@stopid"].Value = stop.StopId;
                cmd.Parameters["@scheduledtrack"].Value = stop.ScheduledTrack;
                cmd.Parameters["@actualtrack"].Value = stop.ActualTrack;
                cmd.ExecuteNonQuery();
            }
            Connection.Close();
        }

        public void ClearAll()
        {
            PurgeTable();
        }
    }
}