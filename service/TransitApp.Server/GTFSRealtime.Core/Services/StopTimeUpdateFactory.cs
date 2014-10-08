using System;
using System.Collections;
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
            // TODO Validate this.
            return results.Distinct(new StopTimeUpdateComparer());
        }
    }

    class StopTimeUpdateComparer : IEqualityComparer <StopTimeUpdate>
    {
        public bool Equals(StopTimeUpdate x, StopTimeUpdate y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the StopTimeUpdate's properties are equal.
            return x.TripId == y.TripId && x.StopId == y.StopId;
        }

        public int GetHashCode(StopTimeUpdate stopTimeUpdate)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(stopTimeUpdate, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashTripId = stopTimeUpdate.TripId.GetHashCode();

            //Get hash code for the Code field.
            int hashStopId = stopTimeUpdate.StopId.GetHashCode();

            //Calculate the hash code for the stopTimeUpdate.
            return hashTripId ^ hashStopId;
        }
    }
}