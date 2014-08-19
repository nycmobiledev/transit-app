using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSStatic.Infrastructure.Data
{
    internal class CalendarDateRepository : RepositoryBase<CalendarDate>
    {
        public CalendarDateRepository(string connectionString)
            : base(
                connectionString, "dbo.calendar_dates",
                new[]
                {
                    new ColumnMapping("service_id", typeof (string)), new ColumnMapping("date", typeof (string)),
                    new ColumnMapping("exception_type", typeof (string))
                })
        {}

        public override void CreateDataTableFromItems(IEnumerable<CalendarDate> items)
        {
            var newItems = items as IList<CalendarDate> ?? items.ToList();
            base.CreateDataTableFromItems(newItems);

            foreach (var item in newItems) {
                InsertDataTable.Rows.Add(item.ServiceId, item.Date.ToString("yyyyMMdd"), item.ExceptionType);
            }
        }
    }
}