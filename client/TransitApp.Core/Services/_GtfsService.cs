using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace TransitApp.Core.Services
{
	public class _GtfsService : _IGtfsService, IDisposable
    {
		private ISQLiteConnectionFactory _factory;
		private ISQLiteConnection _connection;

		private ISQLiteConnection Connection {
			get { 
				if (_connection==null) {
					_connection = _factory.Create("Subway.db");   
				}

				return _connection;
			}
		}

        public _GtfsService(ISQLiteConnectionFactory factory)
        {   
			this._factory = factory;
        }    
         
		public List<Stop> GetNearbyStops(double lat, double lon)
        {
			var list = Connection.Table<Stop>().Where(x=>x.LocationType=="1").ToList();

			foreach (var item in list) {
				//caluate distance
				item.Distance = CaluateDistance(lat, lon, item.Latitude, item.Longitude);
			}

			//lESS THAN 3KM
			return list.Where(X=>X.Distance<=3).OrderBy(x=>x.Distance).ToList();
        }

        public void Dispose()
        {
			Connection.Close();
        }

		private double CaluateDistance(double lat1, double lon1, double lat2,double lon2) {
			// returns the distance in km between the pair of latitude and longitudes provided in decimal degrees
			var R = 6371; // km
			var dLat = (lat2 - lat1) * Math.PI / 180;
			var dLon = (lon2 - lon1) * Math.PI / 180;
			var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
				Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
				Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
			var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
			var d = R * c;

			return d;
		}
    }
}
