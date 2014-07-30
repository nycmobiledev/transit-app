using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class StopTimeUpdateRepository : RepositoryBase<StopTimeUpdate>, IRepository<StopTimeUpdate>
    {
        public StopTimeUpdateRepository(string connectionString) : base(connectionString)
        {
            TableName = "dbo.realtime_stop_time_updates";
            
        }

        public void AddRange(IEnumerable<StopTimeUpdate> items)
        {
            SqlBulkInsertTable(items);

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

        public override DataTable CreateDataTableFromItems(IEnumerable<StopTimeUpdate> items)
        {
            var dt = new DataTable();
            dt.Columns.Add("trip_id", typeof (string));
            dt.Columns.Add("arrival", typeof (DateTime));
            dt.Columns.Add("departure", typeof (DateTime));
            dt.Columns.Add("stop_id", typeof (string));
            dt.Columns.Add("scheduled_track", typeof (string));
            dt.Columns.Add("actual_track", typeof (string));

            foreach (var item in items) {
                dt.Rows.Add(item.TripId, item.Arrival.GetValueOrDefault(), item.Departure.GetValueOrDefault(),
                    item.StopId, item.ScheduledTrack, item.ActualTrack);
            }

            return dt;
        }

        public override Dictionary<string, string> CreateMappingDictionary()
        {
            return new Dictionary<string, string> {
                {"trip_id", "trip_id"},
                {"arrival", "arrival"},
                {"departure", "departure"},
                {"stop_id", "stop_id"},
                {"scheduled_track", "scheduled_track"},
                {"actual_track", "actual_track"}
            };
        }
    }
}