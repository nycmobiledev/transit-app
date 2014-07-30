using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class AlertRepository : RepositoryBase<Alert>, IRepository<Alert>
    {
        public AlertRepository(string connectionString)
            : base(
                connectionString, "dbo.realtime_alerts",
                new[]
                {
                    new ColumnMapping("trip_id", typeof(string)),
                    new ColumnMapping("alert_text", typeof(string))
                    
                })
        {}

        public void AddRange(IEnumerable<Alert> items)
        {
            SqlBulkInsertTable(items);
        }

        public override void CreateDataTableFromItems(IEnumerable<Alert> items)
        {
            var alerts = items as IList<Alert> ?? items.ToList();
            base.CreateDataTableFromItems(alerts);

            foreach (var item in alerts) {
                InsertDataTable.Rows.Add(item.TripId, item.Message);
            }
        }

        public void ClearAll()
        {
            PurgeTable();
        }
    }
}