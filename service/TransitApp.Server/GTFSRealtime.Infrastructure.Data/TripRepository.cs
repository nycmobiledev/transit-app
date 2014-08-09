using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class TripRepository : RepositoryBase<Trip>, IRepository<Trip>
    {
        public TripRepository(string connectionString)
            : base(
                connectionString, "dbo.realtime_trips",
                new List<ColumnMapping>
                {
                    new ColumnMapping("trip_id", typeof (string)),
                    new ColumnMapping("start_date", typeof (DateTime)),
                    new ColumnMapping("route_id", typeof (string)),
                    new ColumnMapping("is_assigned", typeof (bool)),
                    new ColumnMapping("direction", typeof (string)),
                    new ColumnMapping("train_id", typeof (string))
                })
        {}

        public void AddRange(IEnumerable<Trip> items)
        {
            SqlBulkInsertTable(items);
        }

        public void ClearAll()
        {
            PurgeTable();
        }

        public override void CreateDataTableFromItems(IEnumerable<Trip> items)
        {
            var trips = items as IList<Trip> ?? items.ToList();
            base.CreateDataTableFromItems(trips);

            foreach (var item in trips) {
                var row = InsertDataTable.Rows.Add(item.TripId, item.StartDate.GetValueOrDefault(), item.RouteId,
                    item.IsAssigned, item.Direction, item.TrainId.Trim());

                if (!item.StartDate.HasValue) {
                    row["start_date"] = DBNull.Value;
                }
            }
        }
    }
}