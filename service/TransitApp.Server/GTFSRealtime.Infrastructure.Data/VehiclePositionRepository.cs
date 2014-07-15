using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class VehiclePositionRepository : RepositoryBase, IRepository<VehiclePosition>
    {
        public VehiclePositionRepository(string connectionString) : base(connectionString)
        {
            TableName = "dbo.realtime_vehicle_position";
            InsertCmdText =
                string.Format(
                    "INSERT INTO {0} ([trip_id],[current_stop_sequence],[current_status],[timestamp],[stop_id]) VALUES (@tripid,@currentstopsequence,@currentstatus,@timestamp,@stopid)",
                    TableName);
        }

        public void AddRange(IEnumerable<VehiclePosition> items)
        {
            Connection.Open();
            var cmd = new SqlCommand(InsertCmdText, Connection);
            cmd.Parameters.Add("@tripid", SqlDbType.NVarChar, 128);
            cmd.Parameters.Add("@currentstopsequence", SqlDbType.Int);
            cmd.Parameters.Add("@currentstatus", SqlDbType.NVarChar, 15);
            cmd.Parameters.Add("@timestamp", SqlDbType.DateTime);
            cmd.Parameters.Add("@stopid", SqlDbType.NVarChar, 8);
            
            foreach (var vehicle in items) {
                cmd.Parameters["@tripid"].Value = vehicle.TripId;
                cmd.Parameters["@currentstopsequence"].Value = vehicle.CurrentStopSequence;
                cmd.Parameters["@currentstatus"].Value = vehicle.CurrentStatus;
                cmd.Parameters["@timestamp"].Value = vehicle.Timestamp;
                cmd.Parameters["@stopid"].Value = vehicle.StopId;
                
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