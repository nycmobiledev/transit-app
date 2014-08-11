using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransitApp.Core.Models
{
    [Table("Stations")]
    public class Station
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        // I thought adding another StationLines table is fussy, so I thought using string to store id might be easier. for example 1,2,3,4
        public string LineIds { get; set; }

        [Ignore]
        public IList<Line> Lines { get; set; }

        [Obsolete]
        public bool IsFollowing { get; set; }
    }
}
