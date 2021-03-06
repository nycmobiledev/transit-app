﻿using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class TripRepository : RepositoryBase<Trip>
    {
        public TripRepository()
            : base("dbo.realtime_trips",
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