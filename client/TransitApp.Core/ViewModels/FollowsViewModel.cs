using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TransitApp.Core.Models;
using TransitApp.Core.Services;

namespace TransitApp.Core.ViewModels
{
    public class FollowsViewModel : BaseViewModel
    {

        private readonly IMvxMessenger _messenger;
        private readonly IFollowService _service;
        private ICollection<FollowStation> _follows;
        private MvxCommand<FollowStation> _goToEditCommandg;

        public FollowsViewModel(IFollowService service, IMvxMessenger messenger)
        {
            _messenger = messenger;
            _service = service;
            RefleshFollows();
            _messenger.Subscribe<FollowsChanged>(x =>
            {
                RefleshFollows();
            }, MvxReference.Strong);
        }

        public ICollection<FollowStation> Follows
        {
            get
            {
                return _follows;
            }
            set
            {
                this._follows = value;
                this.RaisePropertyChanged(() => this.Follows);
            }
        }


        public ICommand GoToEditCommand
        {
            get
            {
                _goToEditCommandg = _goToEditCommandg ?? new MvxCommand<FollowStation>((x) =>
                    ShowViewModel<FollowEditViewModel>(new { stationId = x.Station.Id })
                );

                return _goToEditCommandg;
            }
        }

        public ICommand GoToAddCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SearchViewModel>());
            }
        }

        private void RefleshFollows()
        {
            Follows = _service.GetFollowsStations();
        }

    }
}