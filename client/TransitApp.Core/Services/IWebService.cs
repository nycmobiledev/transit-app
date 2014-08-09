using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public interface IWebService
    {
        IList<Station> FindStationsByName(string name);

        IList<Alert> GetAlerts(Follow[] follows);
    }
}
