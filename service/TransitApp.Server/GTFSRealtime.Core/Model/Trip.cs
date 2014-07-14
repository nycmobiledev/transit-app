using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitApp.Server.GTFSRealtime.Core.Model
{
    public class Trip
    {
        public string TripId { get; set; }
        public DateTime? StartDate { get; set; }
        public string RouteId { get; set; }
        public bool? IsAssigned { get; set; }
        public string Direction { get; set; }
        public string TrainId { get; set; }
    }
}
