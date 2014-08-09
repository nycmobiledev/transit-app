using System;

namespace TransitApp.Server.GTFSRealtime.Core.Model
{
    public class StopTimeUpdate
    {
        public string TripId { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? Departure { get; set; }
        public string StopId { get; set; }
        public string ScheduledTrack { get; set; }
        public string ActualTrack { get; set; }
    }
}