using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSStatic.Infrastructure.Data
{
    public class RouteRepository : RepositoryBase<Route>
    {
        public RouteRepository(string connectionString)
            : base(
                connectionString, "dbo.routes",
                new[]
                {
                    new ColumnMapping("agency_id", typeof (string)), new ColumnMapping("route_id", typeof (string)),
                    new ColumnMapping("route_short_name", typeof (string)),
                    new ColumnMapping("route_long_name", typeof (string)), new ColumnMapping("route_type", typeof (int)),
                    new ColumnMapping("route_desc", typeof (string)), new ColumnMapping("route_url", typeof (string)),
                    new ColumnMapping("route_color", typeof (string)),
                    new ColumnMapping("route_text_color", typeof (string))
                })
        {}

        public override void CreateDataTableFromItems(IEnumerable<Route> items)
        {
            var newItems = items as IList<Route> ?? items.ToList();
            base.CreateDataTableFromItems(newItems);

            foreach (var item in newItems) {
                InsertDataTable.Rows.Add(item.AgencyId, item.RouteId, item.ShortName, item.LongName, item.RouteType,
                    item.Description, item.Url, item.Color, item.TextColor);
            }
        }
    }
}