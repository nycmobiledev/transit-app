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
        ITableQuery<Station> Stations { get; }
        ITableQuery<Follow> Follows { get; }

        ICollection<Station> GetStations(string searchQuery);
    }
}
