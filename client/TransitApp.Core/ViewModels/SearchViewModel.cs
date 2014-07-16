using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Services;
using TransitApp.Core.Models;

namespace TransitApp.Core.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
		private IWebService _webService;
		private ILocalDbService _localDbService;

		public SearchViewModel(IWebService webService, ILocalDbService localDbService)
		{
			if (webService == null) //add other parameters that indicate no web connection?
			{ 
				//no connection, do something?
			}
			_webService = webService;

			if (localDbService == null) 
			{
				throw new ArgumentNullException ("localDbService");
			}

			_localDbService = localDbService;
		}


		private List<Station> stationsSearchResults;

		public List<Station> StationsSearchResults
		{
			get { return this.StationsSearchResults; }
			set { this.stationsSearchResults = value; this.RaisePropertyChanged(() => this.StationsSearchResults); }
		}

		public void Search(string searchQuery)
		{
			List<Station> stationResults = _localDbService.GetStations (searchQuery).ToList();
			stationsSearchResults = stationResults;
		}



    }
}
