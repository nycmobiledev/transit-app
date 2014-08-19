using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSStatic.Infrastructure.Data
{
    public class CalendarRepository : RepositoryBase<Calendar>
    {
        public CalendarRepository(string connectionString)
            : base(
                connectionString, "dbo.calendar",
                new[]
                {
                    new ColumnMapping("service_id", typeof (string)), new ColumnMapping("monday", typeof (string)),
                    new ColumnMapping("tuesday", typeof (string)), new ColumnMapping("wednesday", typeof (string)),
                    new ColumnMapping("thursday", typeof (string)), new ColumnMapping("friday", typeof (string)),
                    new ColumnMapping("saturday", typeof (string)), new ColumnMapping("sunday", typeof (string)),
                    new ColumnMapping("start_date", typeof (string)), new ColumnMapping("end_date", typeof (string))
                })
        {}

        public override void CreateDataTableFromItems(IEnumerable<Calendar> items)
        {
            var newItems = items as IList<Calendar> ?? items.ToList();
            base.CreateDataTableFromItems(newItems);

            foreach (var item in newItems) {
                InsertDataTable.Rows.Add(item.ServiceId, ConvertBoolToZeroOneString(item.RunOnMonday),
                    ConvertBoolToZeroOneString(item.RunOnTuesday), ConvertBoolToZeroOneString(item.RunOnWednesday),
                    ConvertBoolToZeroOneString(item.RunOnThursday), ConvertBoolToZeroOneString(item.RunOnFriday),
                    ConvertBoolToZeroOneString(item.RunOnSaturday), ConvertBoolToZeroOneString(item.RunOnSunday),
                    item.StartDate.ToString("yyyyMMdd"), item.EndDate.ToString("yyyyMMdd"));
            }
        }

        private static string ConvertBoolToZeroOneString(bool value)
        {
            return value ? "1" : "0";
        }
    }
}