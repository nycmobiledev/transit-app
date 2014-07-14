using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitApp.Server.GTFSRealtime.Core.Model
{
    public class VehiclePosition
    {
        public string TripId { get; set; }
        public int CurrentStopSequence { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime Timestamp { get; set; }
        public string StopId { get; set; }
    }
}
