﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitApp.Core.Models;
using TransitApp.Core.Services;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.CrossCore;
using TransitApp.Core.Interfaces;
using Cirrious.MvvmCross.Plugins.File;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace TransitApp.Core.ViewModels
{
    public class AlertsViewModel : BaseViewModel
    {
        private readonly IMvxMessenger _messenger;
        private readonly IAlertService _service;
        private ObservableCollection<Alert> _alerts;
        private CoolTimer _coolTimer;
		private bool _isBusy = false;
        private MvxCommand _refreshCommand;
        private string _connectionAlertText="No Connection";
        private readonly ILocalDataService _localDbService;
        private IMvxFileStore _fileService;

		const int REFRESH_DELAY = 15000;

		const int RESPONSE_TIMEOUT = 5000;

        private bool _isConnected;

        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            private set
            {
                _isConnected = value;
                IsNotConnected = !value;
            }
        }

        private bool _isNotConnected;
        public bool IsNotConnected
        {
            get { return _isNotConnected; }
            private set
            {
                _isNotConnected = value;
                this.RaisePropertyChanged(() => this.IsNotConnected);
            }
        }

        public DateTime UpdateTime { get; private set; }
        public string ConnectionAlertText
        {
            get { return _connectionAlertText; }
            private set
            {
                _connectionAlertText = value;
                this.RaisePropertyChanged(() => this.ConnectionAlertText);
            }
        }

        public AlertsViewModel()
        {
            _messenger = Mvx.Resolve<IMvxMessenger>();
            _service = Mvx.Resolve<IAlertService>();
            _fileService = Mvx.Resolve<IMvxFileStore>();
            _localDbService = Mvx.Resolve<ILocalDataService>();
            //			NetworkConnectionHelper = Mvx.Resolve<IConnectivity> ();
            _messenger.Subscribe<FollowsChanged>( async x => await ExecuteRefreshCommand(), MvxReference.Strong);

        }

		public override async void Start()
    	{
    		base.Start();
			await ExecuteRefreshCommand();
			_coolTimer = new CoolTimer(DataCallBack, null, REFRESH_DELAY, -1);
    	}

		protected override void InitFromBundle(IMvxBundle parameters)
    	{
    		base.InitFromBundle(parameters);
			if (parameters.Data.ContainsKey("UpdateTime"))
			{
				UpdateTime = new DateTime( long.Parse( parameters.Data["UpdateTime"]), DateTimeKind.Utc  );
			}
    	}

    	protected override void SaveStateToBundle(IMvxBundle bundle)
    	{
    		base.SaveStateToBundle(bundle);
			if ( DateTime.MinValue != UpdateTime )
			{
				bundle.Data["UpdateTime"] = UpdateTime.Ticks.ToString();
			}
    	}

		public void Stop()
		{
			_coolTimer.Cancel();
		}


		public ObservableCollection<Alert> Alerts
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
                return _refreshCommand ?? (_refreshCommand = new MvxCommand(async () => await ExecuteRefreshCommand()));
            }
        }

        private async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            try
            {


                IsBusy = true;


				int timeout = RESPONSE_TIMEOUT;
                var task = _service.GetAlerts();
                if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                {
                    // Task completed within timeout.
                    // Consider that the task may have faulted or been canceled.
                    // We re-await the task so that any exceptions/cancellation is rethrown.

                    if (!task.IsFaulted)
                    {
                        Alerts = new ObservableCollection<Alert>(await task);
                        UpdateTime = System.DateTime.Now;
                        
                        IsConnected = true;
                    }
                    else
                    {
                        Debug.WriteLine("Task Exception: " + task.Exception);
                        IsConnected = false;
                        
                        UpdateStaleAlerts();
                    }

                }
                else
                {
                    IsConnected = false;
                    // Remove any completed Alerts
                    UpdateStaleAlerts();
                }
            }
            finally
            {
                IsBusy = false;
            }

           
        }

		void UpdateStaleAlerts()
		{
			ConnectionAlertText =
                          String.Format( 
				"Connection Lost : {0}s ago",
					(int) DateTime.Now.Subtract( UpdateTime == DateTime.MinValue ? DateTime.Now : UpdateTime ).TotalSeconds);

			InvokeOnMainThread( () =>
			{
				if ( null != Alerts )
				{
					lock( Alerts )
					{
						var expired = Alerts.Where( ( Alert arg ) => arg.ArrivalTime < DateTime.UtcNow ).ToList();

						foreach( var alert in Alerts )
						{
							alert.IsRealtime = false;
						}

						foreach( var alert in expired )
						{
							Alerts.Remove( alert );
						}
					}
				}
			} );
		}

        public void DataCallBack(object state)
        {
            Task.Run(new Func<Task>(ExecuteRefreshCommand));
			_coolTimer = new CoolTimer( DataCallBack, null, REFRESH_DELAY, -1 );
        }
    }
}
