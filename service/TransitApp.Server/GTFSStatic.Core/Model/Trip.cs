using System;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Trip
    {
        public string RouteId { get; set; } 
        public string TripId { get; set; }
        public string ServiceId { get; set; }
        public string TripHeadsign { get; set; }
        public int Direction { get; set; }
        public string ShapeId { get; set; }
    }
}