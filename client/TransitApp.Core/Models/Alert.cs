using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransitApp.Core.Models
{
	public class Alert
	{
		public string StationId { get; set; }

        [Newtonsoft.Json.JsonProperty("RouteId")]
		public string LineId { get; set; }

		public string TrainId { get; set; }
        public string DestinationStationId { get; set; }

		public string Direction { get; set; }

		public DateTime ArrivalTime { get; set; }
		public int ArrivalTimeSeconds { get; set; }

		public Line Line { get; set; }

		public Station Station { get; set; }
        public Station DestinationStation { get; set; }

		public string Destination {
		    get
		    {

		        if (null == Line)
		        {
		            return null;
		        }
		        if (null != DestinationStation)
		        {
		            return ((Direction == "N") ? "Uptown to " : "Downtown to ") + DestinationStation.Name ;
		        }
		        if ( Direction == "N") {
                    return String.Format("Uptown");
				} else {
                    return String.Format("Downtown");
				}
			}
		}
	}
}
