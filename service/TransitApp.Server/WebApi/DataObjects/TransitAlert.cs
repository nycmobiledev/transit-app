using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace TransitApp.Server.WebApi.DataObjects
{
    public class TransitAlert : EntityData
    {
        public string TripId { get; set; }
        public string StationId { get; set; }
        public int Version { get; set; }
        public string RouteId { get; set; }
        public string StationName { get; set; }
        public string RouteName { get; set; }
        public DateTime Time { get; set; }
        public String Direction { get; set; }
        public bool IsRealtime { get; set; }
    }
}