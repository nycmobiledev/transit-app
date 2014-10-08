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
using TransitApp.Core.Interfaces;
using Cirrious.MvvmCross.Plugins.File;
using Newtonsoft.Json;

namespace TransitApp.Core.ViewModels
{
    public class AlertsViewModel : BaseViewModel
    {
        private readonly IMvxMessenger _messenger;
        private readonly IAlertService _service;
        private ICollection<Alert> _alerts;
        private CoolTimer _coolTimer;
        private bool _isBusy;
        private MvxCommand _refreshCommand;
		private string _connectionAlertText;
		private readonly ILocalDataService _localDbService;
		private IMvxFileStore _fileService;
		private const string _customerAlertFilePath = "CustomerAlerts.json";
		private const string _customerAlertAddnlData = "CustomerAlerts.json";

		public bool IsConnected { get; private set;}
		public DateTime UpdateTime { get; private set; }
		public string ConnectionAlertText { 
			get{ return _connectionAlertText;}
			private set{ 
				_connectionAlertText = value;
				this.RaisePropertyChanged(() => this.ConnectionAlertText);
			}
		}

        public AlertsViewModel()
        {
            _messenger = Mvx.Resolve<IMvxMessenger>();
            _service = Mvx.Resolve<IAlertService>();
			_fileService = Mvx.Resolve<IMvxFileStore> ();
			_localDbService = Mvx.Resolve<ILocalDataService> ();
			NetworkConnectionHelper = Mvx.Resolve<IConnectivity> ();
            _messenger.Subscribe<FollowsChanged>(x =>
            {
                ExecuteRefreshCommand();
            }, MvxReference.Strong);
			_coolTimer = new CoolTimer(DataCallBack,null,10000,-1);
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

		private IConnectivity NetworkConnectionHelper ;

        private async void ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

			if (NetworkConnectionHelper != null ) 
			{
				IsConnected = NetworkConnectionHelper.IsConnected ();
				if (IsConnected) {
					Alerts = await _service.GetAlerts ();
					UpdateTime = System.DateTime.Now;
					WriteAlertDetailsToFile ();
					ConnectionAlertText = "Refreshed time : " + UpdateTime.ToString ();;
				} else {
					ReadAlertDetailsFromFile ();
					ConnectionAlertText = "Refreshed time : " + UpdateTime.ToString () + ". Not connected to network...";
				}
			}


			IsBusy = false;
        }

		private void WriteAlertDetailsToFile()
		{
			var json = JsonConvert.SerializeObject(_alerts);
			_fileService.WriteFile(_customerAlertFilePath, json);
			_fileService.WriteFile (_customerAlertAddnlData, UpdateTime.ToString());
		}

		private void ReadAlertDetailsFromFile()
		{
			string json;
			if (_fileService.TryReadTextFile(_customerAlertFilePath, out json))
			{
				_alerts = JsonConvert.DeserializeObject<HashSet<Alert>>(json);
			}
			else
			{
				_alerts = new HashSet<Alert>();
			}

			string time;
			if (_fileService.TryReadTextFile (_customerAlertAddnlData, out time)) {
				UpdateTime = DateTime.Parse( time);
			}
		}

		public void DataCallBack(object state)
		{
			ExecuteRefreshCommand();
			_coolTimer = new CoolTimer(DataCallBack,null,10000,-1);
		}
    }
}
