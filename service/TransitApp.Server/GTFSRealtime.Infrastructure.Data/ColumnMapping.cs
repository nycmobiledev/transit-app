using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class ColumnMapping
    {
        public ColumnMapping(string databaseColumnName, Type dataTableColumnType) : this(databaseColumnName, databaseColumnName, dataTableColumnType) {}

        public ColumnMapping(string databaseColumnName, string dataTableColumnName, Type dataTableColumnType)
        {
            DatabaseColumnName = databaseColumnName;
            DataTableColumnName = dataTableColumnName;
            DataTableColumnType = dataTableColumnType;
        }

        public string DatabaseColumnName { get; set; }
        public string DataTableColumnName { get; set; }
        public Type DataTableColumnType { get; set; }
    }
}
