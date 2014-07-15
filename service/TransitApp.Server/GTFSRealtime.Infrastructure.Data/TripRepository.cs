using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class TripRepository : RepositoryBase, IRepository<Trip>
    {
        public TripRepository(string connectionString) : base(connectionString)
        {
            TableName = "dbo.realtime_trips";
            InsertCmdText =
                string.Format(
                    "INSERT INTO {0} ([trip_id],[start_date],[route_id],[is_assigned],[direction],[train_id]) VALUES (@tripid,@startdate,@routeid,@isassigned,@direction,@trainid)",
                    TableName);
        }

        public void AddRange(IEnumerable<Trip> items)
        {
            Connection.Open();
            var cmd = new SqlCommand(InsertCmdText, Connection);
            cmd.Parameters.Add("@tripid", SqlDbType.NVarChar, 128);
            cmd.Parameters.Add("@startdate", SqlDbType.SmallDateTime);
            cmd.Parameters.Add("@routeid", SqlDbType.NVarChar, 4);
            cmd.Parameters.Add("@isassigned", SqlDbType.Bit);
            cmd.Parameters.Add("@direction", SqlDbType.NVarChar, 5);
            cmd.Parameters.Add("@trainid", SqlDbType.NVarChar, 12);
            
            foreach (var trip in items) {
                cmd.Parameters["@tripid"].Value = trip.TripId;
                cmd.Parameters["@startdate"].Value = trip.StartDate;
                cmd.Parameters["@routeid"].Value = trip.RouteId;
                cmd.Parameters["@isassigned"].Value = trip.IsAssigned;
                cmd.Parameters["@direction"].Value = trip.Direction;
                cmd.Parameters["@trainid"].Value = trip.TrainId;
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