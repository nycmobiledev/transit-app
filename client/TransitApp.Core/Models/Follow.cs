using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace TransitApp.Core.Models
{
    [Table("Follows")]
    public class Follow
    {
        [PrimaryKey]
        public string Id
        {
            get
            {
                return String.Format("{0}-{1}", StationId, LineId);
            }
			set{

			}
        }

        public string StationId { get; set; }

        public string LineId { get; set; }

        [Ignore]
        public Station Station { get; set; }

        [Ignore]
        public Line Line { get; set; }
    }


    public class FollowStation
    {
        public Station Station { get; set; }

        public ICollection<FollowLine> Lines { get; set; }
    }

    public class FollowLine
    {           
        public Line Line { get; set; }

        public bool IsFollow { get; set; }
    }
}
