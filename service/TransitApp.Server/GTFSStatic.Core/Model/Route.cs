using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    class Route
    {
        public string AgencyId { get; set; }
        public string RouteId { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int RouteType { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Color { get; set; }
        public string TextColor { get; set; }
    }
}
