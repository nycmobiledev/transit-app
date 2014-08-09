using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using TransitApp.Core.Services;

namespace TransitApp.Core.ViewModels
{
    public class AlertsViewModel : BaseViewModel
    {
        private readonly IAlertService _Service;

        private IList<Alert> _Alerts;
        public AlertsViewModel(IAlertService service)
        {
            _Service = service;
            _Alerts = service.GetAlerts();
        }

        public IList<Alert> Alerts
        {
            get
            {
                return _Alerts;
            }
            set
            {
                this._Alerts = value; this.RaisePropertyChanged(() => this.Alerts);
            }

        }
    }
}
