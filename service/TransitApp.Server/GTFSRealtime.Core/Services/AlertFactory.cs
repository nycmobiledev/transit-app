using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.DTO;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;


namespace TransitApp.Server.GTFSRealtime.Core.Services
{
    public class AlertFactory : IModelFactory<Model.Alert>
    {
        public IEnumerable<Model.Alert> CreateItemsFromFeedMessage(FeedMessage msg)
        {
            var results = new List<Model.Alert>();

            if (msg == null || msg.Entity.Count(e => e.Alert != null) == 0) {
                return results;
            }

            var alertList = msg.Entity.Where(e => e.Alert != null);
            results.AddRange(from e in alertList
                let alertMsg = e.Alert.HeaderText.Translations[0].Text
                from ie in e.Alert.InformedEntity
                select new Model.Alert {TripId = ie.Trip.TripId, Message = alertMsg});

            return results;
        }
    }
}