using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Services;
using TransitApp.Core.Models;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace TransitApp.Core.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
		private IWebService _webService;
		private ILocalDbService _localDbService;

		public SearchViewModel(IWebService webService, ILocalDbService localDbService)
		{
			_webService = webService;

			_localDbService = localDbService;
		}

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; this.RaisePropertyChanged(() => this.SearchText); Search(value); }
        }
        
        public void Search(string searchText)
        {
			ObservableCollection<Station> stationResults = new ObservableCollection<Station> (_localDbService.GetStations(searchText));
            stationsSearchResults = stationResults;
        }

		private ObservableCollection<Station> stationsSearchResults;

		public ObservableCollection<Station> StationsSearchResults
		{
			get { return this.StationsSearchResults; }
			set { this.stationsSearchResults = value; this.RaisePropertyChanged(() => this.StationsSearchResults); }
		}

        private MvxCommand<Station> _selectStationCommand;

        public ICommand SelectStationCommand
        {
            get
            {
                return _selectStationCommand ?? (_selectStationCommand = new MvxCommand<Station>(this.ExecuteSelectStationCommand));
            }
        }

        private void ExecuteSelectStationCommand(Station station)
        {
            if (station.IsFollowing)
            {
                station.IsFollowing = false;
            }
            else
            {
                station.IsFollowing = true;
            }
        }





    }
}
