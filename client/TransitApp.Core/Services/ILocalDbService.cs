using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public interface ILocalDbService
    {
        ISQLiteConnection Connection { get; }
        
        T Get<T>(object id) where T : new();         

        ICollection<Follow> GetFollows();

        ICollection<Line> GetLines(IEnumerable<string> ids);
        
        ICollection<Station> GetStations(string searchQuery);
    }
}
