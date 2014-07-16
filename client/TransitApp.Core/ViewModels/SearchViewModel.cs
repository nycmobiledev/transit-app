using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Services;
using TransitApp.Core.Models;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

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

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }


        public void Search(string searchText)
        {
            List<Station> stationResults = _localDbService.GetStations(searchText).ToList();
            stationsSearchResults = stationResults;
        }

		private List<Station> stationsSearchResults;

		public List<Station> StationsSearchResults
		{
			get { return this.StationsSearchResults; }
			set { this.stationsSearchResults = value; this.RaisePropertyChanged(() => this.StationsSearchResults); }
		}

        private MvxCommand _selectStationCommand;

        public IMvxCommand SelectStationCommand
        {
            get
            {
                return _selectStationCommand ?? (_selectStationCommand = new MvxCommand(() => ExecuteSelectStationCommand()));
            }
        }

        private void ExecuteSelectStationCommand()
        {
            //do something
        }





    }
}
