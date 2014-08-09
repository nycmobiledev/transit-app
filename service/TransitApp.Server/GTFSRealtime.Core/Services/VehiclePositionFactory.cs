using System;
using System.Collections.Generic;
using System.Linq;
using TransitApp.Server.GTFSRealtime.Core.DTO;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using VehiclePosition = TransitApp.Server.GTFSRealtime.Core.Model.VehiclePosition;

namespace TransitApp.Server.GTFSRealtime.Core.Services
{
    public class VehiclePositionFactory : ModelFactoryBase, IModelFactory<VehiclePosition>
    {
        public IEnumerable<VehiclePosition> CreateItemsFromFeedMessage(FeedMessage msg)
        {
            var results = new List<VehiclePosition>();

            if (msg == null || msg.Entity.Count(e => e.Vehicle != null) == 0) {
                return results;
            }

            var vehicleList = msg.Entity.Where(e => e.Vehicle != null);
            results.AddRange(
                vehicleList.Select(
                    entity =>
                        new VehiclePosition
                        {
                            TripId = entity.Vehicle.Trip.TripId,
                            CurrentStopSequence = (int) entity.Vehicle.CurrentStopSequence,
                            CurrentStatus = entity.Vehicle.CurrentStatus.ToString(),
                            Timestamp = UnixTimeStampToDateTime(entity.Vehicle.Timestamp),
                            StopId = entity.Vehicle.StopId
                        }));

            return results;
        }
    }
}