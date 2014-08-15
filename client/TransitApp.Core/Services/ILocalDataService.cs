using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public interface ILocalDataService
    {
        Station GetStation(string id);
        Line GetLine(string id);

        ICollection<Line> GetLines(IEnumerable<string> ids);
        
        ICollection<Station> GetStations(string searchQuery);
    }
}
