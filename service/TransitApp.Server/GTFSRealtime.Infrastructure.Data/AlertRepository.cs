using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class AlertRepository : RepositoryBase<Alert>
    {
        public AlertRepository(string connectionString)
            : base(
                connectionString, "dbo.realtime_alerts",
                new[] {new ColumnMapping("trip_id", typeof (string)), new ColumnMapping("alert_text", typeof (string))})
        {}


        public override void CreateDataTableFromItems(IEnumerable<Alert> items)
        {
            var alerts = items as IList<Alert> ?? items.ToList();
            base.CreateDataTableFromItems(alerts);

            foreach (var item in alerts) {
                InsertDataTable.Rows.Add(item.TripId, item.Message);
            }
        }
    }
}