using System;
using System.Collections.Generic;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public class AlertRepository: RepositoryBase, IAlertRepository
    {
        public AlertRepository(string connectionString) : base(connectionString)
        {
            TableName = "dbo.realtime_alerts";
        }

        public void Add(Alert item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Alert> items)
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            PurgeTable();
        }
    }
}
