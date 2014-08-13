using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Stop
    {
        public string StopId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude  { get; set; }
        public int LocationType  { get; set; }
        public string ParentId { get; set; }
    }
}
