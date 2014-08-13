using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.Shared.Core.Interfaces;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSStatic.Infrastructure.Data
{
    internal class AgencyRepository : RepositoryBase<Agency>, IGTFSRepository<Agency>
    {
        public AgencyRepository(string connectionString)
            : base(connectionString, "dbo.agency",
                new[] {
                    new ColumnMapping("agency_id", typeof (string)),
                    new ColumnMapping("agency_name", typeof (string)),
                    new ColumnMapping("agency_url", typeof (string)),
                    new ColumnMapping("agency_timezone", typeof (string)),
                    new ColumnMapping("agency_lang", typeof (string)),
                    new ColumnMapping("agency_phone", typeof (string))
                }) {}

        public void AddRange(IEnumerable<Agency> items)
        {
            SqlBulkInsertTable(items);
        }

        public void ClearAll()
        {
            PurgeTable();
        }

        public override void CreateDataTableFromItems(IEnumerable<Agency> items)
        {
            var agencies = items as IList<Agency> ?? items.ToList();
            base.CreateDataTableFromItems(agencies);

            foreach (var item in agencies) {
                InsertDataTable.Rows.Add(item.Id, item.Name, item.Url, item.Timezone, item.Language, item.Phone);
            }
        }
    }
}