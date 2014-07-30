using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.DTO;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using Alert = TransitApp.Server.GTFSRealtime.Core.Model.Alert;


namespace TransitApp.Server.GTFSRealtime.Core.Services
{
    public class AlertFactory : ModelFactoryBase, IModelFactory<Alert>
    {
        public IEnumerable<Alert> CreateItemsFromFeedMessage(FeedMessage msg)
        {
            var results = new List<Alert>();

            if (msg == null || msg.Entity.Count(e => e.Alert != null) == 0) {
                return results;
            }

            var alertList = msg.Entity.Where(e => e.Alert != null);
            results.AddRange(from e in alertList
                let alertMsg = e.Alert.HeaderText.Translations[0].Text
                from ie in e.Alert.InformedEntity
                select new Alert {TripId = ie.Trip.TripId, Message = alertMsg});

            return results;
        }
    }
}