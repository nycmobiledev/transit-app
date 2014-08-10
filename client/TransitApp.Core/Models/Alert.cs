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

		public int Direction { get; set; }

		public DateTime ArriveTime { get; set; }

		public Line Line { get; set; }

		public Station Station { get; set; }

		public string Destination { 
			get { 
				if (Direction == 1) {
					return Line.Start + " To " + Line.End;
				} else {
					return Line.End + " To " + Line.Start;
				}
			}
		}
	}
}
