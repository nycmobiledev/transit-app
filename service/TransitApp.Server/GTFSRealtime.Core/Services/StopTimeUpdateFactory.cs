using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.DTO;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Core.Services
{
    public class StopTimeUpdateFactory : ModelFactoryBase, IModelFactory<StopTimeUpdate>
    {
        public IEnumerable<StopTimeUpdate> CreateItemsFromFeedMessage(FeedMessage msg)
        {
            var results = new List<StopTimeUpdate>();

            if (msg == null || msg.Entity.Count(e => e.TripUpdate != null) == 0) {
                return results;
            }

            var tripList = msg.Entity.Where(e => e.TripUpdate != null);
            foreach (var entity in tripList) {
                var tripId = entity.TripUpdate.Trip.TripId;
                foreach (var update in entity.TripUpdate.StopTimeUpdates) {
                    var stopUpdate = new StopTimeUpdate
                    {
                        TripId = tripId,
                        StopId = update.StopId,
                        ScheduledTrack = update.NyctStopTimeUpdate.ScheduledTrack,
                        ActualTrack = update.NyctStopTimeUpdate.ActualTrack
                    };

                    if (update.Arrival != null) {
                        stopUpdate.Arrival = UnixTimeStampToDateTime((ulong) update.Arrival.Time);
                    }
                    if (update.Departure != null) {
                        stopUpdate.Departure = UnixTimeStampToDateTime((ulong) update.Departure.Time);
                    }
                    results.Add(stopUpdate);
                }
            }

            return results;
        }
    }
}