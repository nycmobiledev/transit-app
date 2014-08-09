using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public class WebService : IWebService
    {
        public WebService()
        {

        }

        public IList<Station> FindStationsByName(string name)
        {
            //todo 
            throw new NotImplementedException();
        }
        public IList<Alert> GetAlerts(Follow[] follows)
        {
            //todo 
            throw new NotImplementedException();
        }
    }
}
