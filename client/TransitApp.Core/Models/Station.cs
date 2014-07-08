using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransitApp.Core.Models
{    
    public class Station
    {
        public string StationId { get; set; }

        public string StationName { get; set; }

        public string[] Lines { get; set; }

        public bool IsFollowing { get; set; }
    }
}
