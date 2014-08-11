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
		private readonly IAlertService _service;
		private ICollection<Alert> _alerts;
		private MvxCommand _refreshCommand;

		public AlertsViewModel (IAlertService service)
		{
			_service = service;
			ExecuteRefreshCommand ();
		}

		public ICollection<Alert> Alerts {
			get {
				return _alerts;
			}
			set {
				this._alerts = value;
				this.RaisePropertyChanged (() => this.Alerts);
			}
		}

		public ICommand RefreshCommand {
			get {
				return _refreshCommand ?? (_refreshCommand = new MvxCommand (this.ExecuteRefreshCommand));
			}
		}

		public ICommand EditCommand {
			get {
				return new MvxCommand (() => ShowViewModel<FollowsViewModel> ()); 
			}
		}

		private void ExecuteRefreshCommand ()
		{
			Alerts = _service.GetAlerts ();
		}
	}
}
