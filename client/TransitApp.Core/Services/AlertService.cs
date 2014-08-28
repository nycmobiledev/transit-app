using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using System.Threading.Tasks;

namespace TransitApp.Core.Services
{
    public class AlertService : IAlertService
    {
        private readonly IFollowService _followService;
        private readonly IWebService _WebService;
        public AlertService(IFollowService followService, IWebService webService)
        {
            _WebService = webService;
            _followService = followService;
        }

        public async Task<ICollection<Alert>> GetAlerts()
        {            
            var follows = _followService.GetFollows();            
         
            return await _WebService.GetAlerts(follows);
        }
    }
}
