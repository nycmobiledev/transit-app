using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSStatic.Infrastructure.Data
{
    public class StopRepository: RepositoryBase<Stop>
    {
        public StopRepository()
            : base("dbo.stops",
                new[]
                {
                    new ColumnMapping("stop_id", typeof(string)), 
                    new ColumnMapping("stop_name", typeof(string)), 
                    new ColumnMapping("stop_lat", typeof(double)), 
                    new ColumnMapping("stop_lon", typeof(double)),
                    new ColumnMapping("location_type", typeof(int)),
                    new ColumnMapping("parent_station", typeof(string))
                })
        { }

        public override void CreateDataTableFromItems(IEnumerable<Stop> items)
        {
            var newItems = items as IList<Stop> ?? items.ToList();
            base.CreateDataTableFromItems(newItems);

            foreach (var item in newItems)
            {
                InsertDataTable.Rows.Add(item.StopId, item.Name, item.Latitude, item.Longitude, item.LocationType, item.ParentId);
            }
        }
    }
}