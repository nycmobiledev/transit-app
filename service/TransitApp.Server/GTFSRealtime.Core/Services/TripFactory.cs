using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.DTO;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Core.Services
{
    public class TripFactory : ModelFactoryBase, IModelFactory<Trip>
    {
        public IEnumerable<Trip> CreateItemsFromFeedMessage(FeedMessage msg)
        {
            var results = new List<Trip>();

            if (msg == null || msg.Entity.Count(e => e.TripUpdate != null) == 0) {
                return results;
            }

            var tripList = msg.Entity.Where(e => e.TripUpdate != null);
            foreach (var entity in tripList) {
                var myTrip = new Trip
                {
                    TripId = entity.TripUpdate.Trip.TripId,
                    RouteId = entity.TripUpdate.Trip.RouteId,
                    TrainId = entity.TripUpdate.Trip.NyctTripDescriptor.TrainId,
                    IsAssigned = entity.TripUpdate.Trip.NyctTripDescriptor.IsAssigned,
                    Direction = entity.TripUpdate.Trip.NyctTripDescriptor.Direction.ToString()
                };

                if (!string.IsNullOrWhiteSpace(entity.TripUpdate.Trip.StartDate)) {
                    myTrip.StartDate = new DateTime(int.Parse(entity.TripUpdate.Trip.StartDate.Substring(0, 4)),
                        int.Parse(entity.TripUpdate.Trip.StartDate.Substring(4, 2)),
                        int.Parse(entity.TripUpdate.Trip.StartDate.Substring(6, 2)));
                }

                results.Add(myTrip);
            }

            return results;
        }
    }
}