using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.Mobile.Service;

namespace TransitApp.Server.WebApi.DataObjects
{
    public class TransitAlert 
    {
        public string TripId { get; set; }
        public string StationId { get; set; }
        public int BatchVersion { get; set; }
        public string RouteId { get; set; }
        public string StationName { get; set; }
        public string RouteName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public String DestinationStationId { get; set; }
        public bool IsRealtime { get; set; }
        public string Direction { get; set; }
    }
}