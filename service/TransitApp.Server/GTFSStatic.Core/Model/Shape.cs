using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Shape
    {
        public string ShapeId { get; set; }
        public int Sequence { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
