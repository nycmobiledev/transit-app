using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class StopTimeUpdateRepository : RepositoryBase<StopTimeUpdate>, IRepository<StopTimeUpdate>
    {
        public StopTimeUpdateRepository(string connectionString)
            : base(
                connectionString, "dbo.realtime_stop_time_updates",
                new List<ColumnMapping>
                {
                    new ColumnMapping("trip_id", typeof (string)),
                    new ColumnMapping("arrival", typeof (DateTime)),
                    new ColumnMapping("departure", typeof (DateTime)),
                    new ColumnMapping("stop_id", typeof (string)),
                    new ColumnMapping("scheduled_track", typeof (string)),
                    new ColumnMapping("actual_track", typeof (string))
                })
        {}

        public void AddRange(IEnumerable<StopTimeUpdate> items)
        {
            SqlBulkInsertTable(items);
        }

        public void ClearAll()
        {
            PurgeTable();
        }

        public override void CreateDataTableFromItems(IEnumerable<StopTimeUpdate> items)
        {
            var stopTimeUpdates = items as IList<StopTimeUpdate> ?? items.ToList();
            base.CreateDataTableFromItems(stopTimeUpdates);

            foreach (var item in stopTimeUpdates) {
                var row = InsertDataTable.Rows.Add(item.TripId, item.Arrival.GetValueOrDefault(),
                    item.Departure.GetValueOrDefault(), item.StopId, item.ScheduledTrack, item.ActualTrack);

                if (!item.Arrival.HasValue) {
                    row["arrival"] = DBNull.Value;
                }

                if (!item.Departure.HasValue) {
                    row["departure"] = DBNull.Value;
                }
            }
        }
    }
}