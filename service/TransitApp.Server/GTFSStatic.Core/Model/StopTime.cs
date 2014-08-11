using System;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class StopTime
    {
        public string TripId { get; set; }
        public string StopId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int StopSequence { get; set; }
        public string PickupType { get; set; }
        public string DropoffType { get; set; }
    }
}