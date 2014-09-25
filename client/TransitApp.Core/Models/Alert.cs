using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransitApp.Core.Models
{
	public class Alert
	{
		public string StationId { get; set; }

		public string LineId { get; set; }

		public string TrainId { get; set; }
        public string DestinationStationId { get; set; }

		public int Direction { get; set; }

		public DateTime ArrivalTime { get; set; }

		public Line Line { get; set; }

		public Station Station { get; set; }

		public string Destination { 
			get { 
				if (Direction == 1) {
                    return String.Format("{0} To {1}", Line.Start, Line.End);
				} else {
                    return String.Format("{0} To {1}", Line.End, Line.Start);
				}
			}
		}
	}
}
