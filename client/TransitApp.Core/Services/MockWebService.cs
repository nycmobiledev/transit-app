using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
	public class MockWebService : IWebService
	{
		private Random _random = new Random (1);

		public ICollection<Station> FindStationsByName (string name)
		{
			var list = new List<Station> ();

			return list;
		}

		public ICollection<Alert> GetAlerts (Follow[] follows)
		{
			var list = new List<Alert> ();


			list.Add (new Alert () {
				TrainId = "1234",
				ArriveTime = DateTime.Now.AddMinutes (_random.Next(20)),
				Station = new Station () { Id = "717", Name = "Main Street" },
				Line = new Line () { Id = "7", Start = "Manhattan", End = "Queens", Name = "7" }
			});

			list.Add (new Alert () {
				TrainId = "4567",
				ArriveTime = DateTime.Now.AddMinutes (_random.Next(20)),
				Station = new Station () { Id = "555", Name = "Bronx - Flushing" },
				Line = new Line () { Id = "5X", Start = "Bronx", End = "Brooklyn", Name = "7" }
			});

			return list;
		}
	}
}