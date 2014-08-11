using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public class AlertService : IAlertService
    {
        private readonly ILocalDbService _LocalDbService;
        private readonly IWebService _WebService;
        public AlertService(ILocalDbService localDbService, IWebService webService)
        {
            _WebService = webService;
            _LocalDbService = localDbService;
        }

        public ICollection<Alert> GetAlerts()
        {            
            var follows = _LocalDbService.GetFollows();            
         
            return _WebService.GetAlerts(follows);
        }
    }
}
