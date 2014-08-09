using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public interface IWebService
    {
        ICollection<Station> FindStationsByName(string name);

        ICollection<Alert> GetAlerts(Follow[] follows);
    }
}
