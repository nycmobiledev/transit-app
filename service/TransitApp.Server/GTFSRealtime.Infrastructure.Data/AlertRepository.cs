using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class AlertRepository: RepositoryBase, IRepository<Alert>
    {
        public AlertRepository(string connectionString) : base(connectionString)
        {
            TableName = "dbo.realtime_alerts";
            InsertCmdText = string.Format("INSERT INTO {0} (trip_id, alert_text) VALUES (@tripid, @alertText)", TableName);
        }

        public void AddRange(IEnumerable<Alert> items)
        {
            Connection.Open();
            var cmd = new SqlCommand(InsertCmdText, Connection);
            cmd.Parameters.Add("@tripid", SqlDbType.NVarChar, 128);
            cmd.Parameters.Add("@alertText", SqlDbType.NVarChar, 128);
            foreach (var alert in items) {
                cmd.Parameters["@tripid"].Value = alert.TripId;
                cmd.Parameters["@alertText"].Value = alert.Message;
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
