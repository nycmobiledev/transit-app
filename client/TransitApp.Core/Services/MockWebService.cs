using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{    
    public class MockWebService : IWebService
    {        
        public IList<Station> FindStationsByName(string name)
        {
            var list = new List<Station>();

            return list;
        }
        public IList<Alert> GetAlertsForStations(int[] ids)
        {
            var list = new List<Alert>();

            return list;
        }
    }
}