using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using System.Threading.Tasks;

namespace TransitApp.Core.Services
{
    public interface IWebService
    {
       Task<ICollection<Station>> FindStationsByName(string name);

       Task<ICollection<Alert>> GetAlerts(IEnumerable<Follow> follows);
    }
}
