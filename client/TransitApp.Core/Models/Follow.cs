using System;
using System.Collections.Generic;
using System.Linq;

namespace TransitApp.Core.Models
{
    public class Follow
    {
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

        public Station Station { get; set; }

        public Line Line { get; set; }
    }
}