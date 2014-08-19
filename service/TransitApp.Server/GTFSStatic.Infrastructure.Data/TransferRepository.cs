using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSStatic.Core.Model;
using TransitApp.Server.Shared.Infrastructure.Data;

namespace TransitApp.Server.GTFSStatic.Infrastructure.Data
{
    public class TransferRepository : RepositoryBase<Transfer>
    {
        public TransferRepository(string connectionString)
            : base(connectionString, "dbo.transfers", new[] {
                new ColumnMapping("from_stop_id", typeof(string)), 
                new ColumnMapping("to_stop_id", typeof(string)), 
                new ColumnMapping("transfer_type", typeof(int)), 
                new ColumnMapping("min_transfer_time", typeof(int))
            })
        {
            
        }

        public override void CreateDataTableFromItems(IEnumerable<Transfer> items)
        {
            var newItems = items as IList<Transfer> ?? items.ToList();
            base.CreateDataTableFromItems(newItems);

            foreach (var item in newItems)
            {
                InsertDataTable.Rows.Add(item.FromStopId, item.ToStopId, item.TransferType, item.MinTransferTime);
            }
        }
    }
}