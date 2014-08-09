using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class VehiclePositionRepository : RepositoryBase<VehiclePosition>, IRepository<VehiclePosition>
    {
        public VehiclePositionRepository(string connectionString)
            : base(
                connectionString, "dbo.realtime_vehicle_position",
                new List<ColumnMapping>
                {
                    new ColumnMapping("trip_id", typeof (string)),
                    new ColumnMapping("current_stop_sequence", typeof (int)),
                    new ColumnMapping("current_status", typeof (string)),
                    new ColumnMapping("timestamp", typeof (DateTime)),
                    new ColumnMapping("stop_id", typeof (string))
                })
        {}

        public void AddRange(IEnumerable<VehiclePosition> items)
        {
            SqlBulkInsertTable(items);
        }

        public void ClearAll()
        {
            PurgeTable();
        }

        public override void CreateDataTableFromItems(IEnumerable<VehiclePosition> items)
        {
            var vehiclePositions = items as IList<VehiclePosition> ?? items.ToList();
            base.CreateDataTableFromItems(vehiclePositions);

            foreach (var item in vehiclePositions) {
                InsertDataTable.Rows.Add(item.TripId, item.CurrentStopSequence, item.CurrentStatus, item.Timestamp,
                    item.StopId);
            }
        }
    }
}