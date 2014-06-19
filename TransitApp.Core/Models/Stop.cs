using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace TransitApp.Core.Models
{
	[Table("Stops")]
    public class Stop
    {
        public string StopId { get; set; }
        
        public string Name { get; set; }
        
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string ParentStopId { get; set; }

        public string LocationType { get; set; }

		[Ignore]
		public double Distance { get; set; }
    }   
}
