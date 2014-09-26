using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using TransitApp.Core.Services;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.CrossCore;

namespace TransitApp.Core.ViewModels
{
	public class AlertsViewModel : BaseViewModel
    {
        private readonly IMvxMessenger _messenger;
        private readonly IAlertService _service;
        private ICollection<Alert> _alerts;
        //private CoolTimer _coolTimer;
        private bool _isBusy;
        private MvxCommand _refreshCommand;

        public AlertsViewModel()
        {
            _messenger = Mvx.Resolve<IMvxMessenger>();
            _service = Mvx.Resolve<IAlertService>();

            _messenger.Subscribe<FollowsChanged>(x => ExecuteRefreshCommand());

            ExecuteRefreshCommand();
        }        

        public ICollection<Alert> Alerts
        {
            get
            {
                return _alerts;
            }
            set
            {
                this._alerts = value;
                this.RaisePropertyChanged(() => this.Alerts);
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value; RaisePropertyChanged(() => IsBusy);
            }
        }

        public ICommand GoToEditCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<FollowsViewModel>());
            }
        }        

        public ICommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new MvxCommand(this.ExecuteRefreshCommand));
            }
        }

		private async void ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Alerts = await _service.GetAlerts();
            IsBusy = false;
        }
    }
}
