using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSStatic.Infrastructure.Data
{
    public class ShapeRepository: RepositoryBase<Shape>
    {
        public ShapeRepository(string connectionString)
            : base(
                connectionString, "dbo.shapes",
                new[]
                {
                    new ColumnMapping("shape_id", typeof(string)), 
                    new ColumnMapping("shape_pt_sequence", typeof(int)), 
                    new ColumnMapping("shape_pt_lat", typeof(double)), 
                    new ColumnMapping("shape_pt_lon", typeof(double))
                })
        { }

        public override void CreateDataTableFromItems(IEnumerable<Shape> items)
        {
            var newItems = items as IList<Shape> ?? items.ToList();
            base.CreateDataTableFromItems(newItems);

            foreach (var item in newItems)
            {
                InsertDataTable.Rows.Add(item.ShapeId, item.Sequence, item.Latitude, item.Longitude);
            }
        }
    }
}