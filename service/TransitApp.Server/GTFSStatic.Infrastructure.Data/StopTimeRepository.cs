using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSStatic.Infrastructure.Data
{
    public class StopTimeRepository : RepositoryBase<StopTime>
    {
        public StopTimeRepository()
            : base("dbo.stop_times",
                new[]
                {
                    new ColumnMapping("trip_id", typeof(string)), 
                    new ColumnMapping("stop_id", typeof(string)),
                    new ColumnMapping("arrival_time", typeof(string)), 
                    new ColumnMapping("departure_time", typeof(string)),
                    new ColumnMapping("stop_sequence", typeof(int)),
                    new ColumnMapping("pickup_type", typeof(int)),
                    new ColumnMapping("drop_off_type", typeof(int)),
                    new ColumnMapping("arrival_time_span", typeof(int)), 
                    new ColumnMapping("departure_time_span", typeof(int)),
                })
        { }

        public override void CreateDataTableFromItems(IEnumerable<StopTime> items)
        {
            var newItems = items as IList<StopTime> ?? items.ToList();
            base.CreateDataTableFromItems(newItems);

            foreach (var item in newItems)
            {
                InsertDataTable.Rows.Add(item.TripId, item.StopId, item.ArrivalTime,
                    item.DepartureTime, item.StopSequence, item.PickupType, item.DropoffType);
            }
        }
    }
}