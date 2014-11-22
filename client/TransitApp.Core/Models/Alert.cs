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
		public bool IsRealtime { get; set; }

		public Line Line { get; set; }

		public Station Station { get; set; }
        public Station DestinationStation { get; set; }

		public string Destination {
		    get
		    {

		       
		        if (null != DestinationStation)
		        {
		            return DestinationStation.Name ;
		        }
		        return "";
		    }
		}

	    public string DirectionLabel
	    {
	        get
	        {
	            return String.Format("{0}",Direction == "N" ? "Uptown" : "Downtown").ToUpper();
	        }
	    }
	}
}
