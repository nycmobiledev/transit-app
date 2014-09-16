using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSStatic.Infrastructure.Data
{
    public class TripRepository: RepositoryBase<Trip>
    {
        public TripRepository()
            : base("dbo.trips", new[] {
                new ColumnMapping("route_id", typeof(string)), 
                new ColumnMapping("trip_id", typeof(string)), 
                new ColumnMapping("service_id", typeof(string)), 
                new ColumnMapping("trip_headsign", typeof(string)), 
                new ColumnMapping("direction_id", typeof(int)), 
                new ColumnMapping("shape_id", typeof(string))
            })
        {
            
        }

        public override void CreateDataTableFromItems(IEnumerable<Trip> items)
        {
            var newItems = items as IList<Trip> ?? items.ToList();
            base.CreateDataTableFromItems(newItems);

            foreach (var item in newItems)
            {
                InsertDataTable.Rows.Add(item.RouteId, item.TripId, item.ServiceId, item.TripHeadsign, item.Direction, item.ShapeId);
            }
        }
    }
}