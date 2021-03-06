﻿using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class VehiclePositionRepository : RepositoryBase<VehiclePosition>
    {
        public VehiclePositionRepository()
            : base("dbo.realtime_vehicle_position",
                new List<ColumnMapping>
                {
                    new ColumnMapping("trip_id", typeof (string)),
                    new ColumnMapping("current_stop_sequence", typeof (int)),
                    new ColumnMapping("current_status", typeof (string)),
                    new ColumnMapping("timestamp", typeof (DateTime)),
                    new ColumnMapping("stop_id", typeof (string))
                })
        {}

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