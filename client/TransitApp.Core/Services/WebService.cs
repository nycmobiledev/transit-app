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

        public ICollection<Station> FindStationsByName(string name)
        {
            //todo 
            throw new NotImplementedException();
        }
        public ICollection<Alert> GetAlerts(IEnumerable<Follow> follows)
        {
            //todo 
            throw new NotImplementedException();
        }
    }
}
