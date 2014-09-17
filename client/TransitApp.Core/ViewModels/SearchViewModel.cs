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
		private ILocalDataService _localDbService;
		private ICollection<Station> searchResults;
		private string _searchText;

		public SearchViewModel(ILocalDataService localDbService)
		{
			_localDbService = localDbService;

		}

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; this.RaisePropertyChanged(() => this.SearchText); Search(value); }
        }
        
        public void Search(string searchText)
        {
			this.SearchResults = _localDbService.GetStations(searchText);
        }

		public ICollection<Station> SearchResults
		{
			get { return this.searchResults; }
			set { this.searchResults = value; this.RaisePropertyChanged(() => this.SearchResults); }
		}

		public ICommand SelectCommand
        {
            get
            {
				return new MvxCommand<Station>((x)=>
					ShowViewModel<FollowEditViewModel>(new {stationId = x.Id})
				);
            }
        }      
    }
}
