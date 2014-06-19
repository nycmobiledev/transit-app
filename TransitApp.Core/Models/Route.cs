using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace TransitApp.Core.Models
{
	[Table("Routes")]
    public class Route
    {
        public virtual string RouteId { get; set; }

        public virtual string ShortName { get; set; }

        public virtual string LongName { get; set; }

        public virtual string Description { get; set; }

        public virtual string Url { get; set; }

        public virtual string Color { get; set; }

        public virtual string TextColor { get; set; }


        //public virtual string agency_id { get; set; }
        //public virtual string route_type { get; set; }
    }
}