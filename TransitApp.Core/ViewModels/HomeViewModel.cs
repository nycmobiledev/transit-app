using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Services;
using Cirrious.MvvmCross.Plugins.Location;
using TransitApp.Core.Models;

namespace TransitApp.Core.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		private readonly IGtfsService _gtfsService;
		private readonly IMvxLocationWatcher _watcher;
		private MvxGeoLocation _mylocation;
		private List<Stop> _stops;

		public HomeViewModel (IGtfsService gtfsService, IMvxLocationWatcher locationWatcher)
		{
			_gtfsService = gtfsService;

			//default location which near TimeSquare
			_mylocation = new MvxGeoLocation (){ Coordinates=new MvxCoordinates(){Latitude=40.758651, Longitude=-73.984616 } };

			_watcher = locationWatcher;		
			_watcher.Start (new MvxLocationOptions (), OnSuccess, OnError);
		}

		public List<Stop> Stops
		{
			get { return _stops; }
			set { _stops = value; RaisePropertyChanged(() => Stops); }
		}

		public MvxGeoLocation MyLocation
		{
			get { return _mylocation; }
			set { _mylocation = value; RaisePropertyChanged(() => MyLocation); }
		}

		public IMvxCommand SearchNearbyStops{ get{ return new MvxCommand(SearchNearByStopsAction); } }


		private void OnSuccess (MvxGeoLocation location)
		{
			MyLocation = location;
		}

		private void OnError (MvxLocationError error)
		{
			Mvx.Warning ("Error seen during location {0}", error.Code);
		}

		private void SearchNearByStopsAction(){
			Stops = _gtfsService.GetNearbyStops(_mylocation.Coordinates.Latitude, _mylocation.Coordinates.Longitude);
		}
	}
}
