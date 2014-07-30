using System;
using System.Collections.Generic;
using System.Data;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class AlertRepository : RepositoryBase<Alert>, IRepository<Alert>
    {
        public AlertRepository(string connectionString) : base(connectionString)
        {
            TableName = "dbo.realtime_alerts";
        }

        public void AddRange(IEnumerable<Alert> items)
        {
            SqlBulkInsertTable(items);
        }

        public override Dictionary<string, string> CreateMappingDictionary()
        {
            return new Dictionary<string, string> {
                {"trip_id", "trip_id"},
                {"alert_text", "alert_text"}
            };
        }

        public override DataTable CreateDataTableFromItems(IEnumerable<Alert> items)
        {
            var dt = new DataTable();
            dt.Columns.Add("trip_id", typeof (string));
            dt.Columns.Add("alert_text", typeof (string));
            foreach (var item in items) {
                dt.Rows.Add(item.TripId, item.Message);
            }

            return dt;
        }

        public void ClearAll()
        {
            PurgeTable();
        }
    }
}