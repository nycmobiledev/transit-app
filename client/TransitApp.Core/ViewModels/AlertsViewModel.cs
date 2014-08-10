using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using TransitApp.Core.Services;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace TransitApp.Core.ViewModels
{
	public class AlertsViewModel : BaseViewModel
	{
		private readonly IAlertService _Service;
		private ICollection<Alert> _Alerts;
		private MvxCommand _RefreshCommand;

		public AlertsViewModel (IAlertService service)
		{
			_Service = service;
			ExecuteRefreshCommand ();
		}

		public ICollection<Alert> Alerts {
			get {
				return _Alerts;
			}
			set {
				this._Alerts = value;
				this.RaisePropertyChanged (() => this.Alerts);
			}
		}

		public ICommand RefreshCommand {
			get {
				return _RefreshCommand ?? (_RefreshCommand = new MvxCommand (this.ExecuteRefreshCommand));
			}
		}

		public ICommand EditCommand {
			get {
				return new MvxCommand (() => ShowViewModel<FollowsViewModel> ()); 
			}
		}

		private void ExecuteRefreshCommand ()
		{
			Alerts = _Service.GetAlerts ();
		}
	}
}
