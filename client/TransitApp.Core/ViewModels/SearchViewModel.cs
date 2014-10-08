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
        private readonly ILocalDataService _localDbService;
        private ICollection<Station> searchResults;
        private string _searchText;
        private CoolTimer _timer;

        public SearchViewModel(ILocalDataService localDbService)
        {
            _localDbService = localDbService;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            string value;
            if (parameters.Data != null && parameters.Data.TryGetValue("IsFirst", out value))
            {
                IsStartViewModel = value == "true";                
            }
        }

        public override void Start()
        {
            if (IsStartViewModel)
            {
                // or change to Image
                Cirrious.CrossCore.Mvx.Resolve<IMessageDialog>().SendMessage("At first time use this app,\r\nyou can add some trains that you want to follow.", "Welcome!");                            
            }
        }
        
        public bool IsStartViewModel { get; set; }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; this.RaisePropertyChanged(() => this.SearchText); Search(value); }
        }

        public void Search(string searchText)
        {
            if (_timer != null)
            {
                _timer.Cancel();
            }

            _timer = new CoolTimer((x) =>
            {
                this.SearchResults = _localDbService.GetStations((string)x);
                _timer = null;
            }, searchText, 500);
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
                return new MvxCommand<Station>((x) =>
                    ShowViewModel<FollowEditViewModel>(new { stationId = x.Id })
                );
            }
        }

        public void GoBack()
        {
            if (IsStartViewModel)
            {
                ShowViewModel<HomeViewModel>();
            }
            else
            {
                Close(this);
            }
        }
    }
}
