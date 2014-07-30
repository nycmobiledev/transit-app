using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using TransitApp.Core.Models;
using System.Collections.ObjectModel;

namespace TransitApp.Core.Services
{
    public class LocalDbService : ILocalDbService
    {
        private readonly ISQLiteConnectionFactory _factory;
        private ISQLiteConnection _connection;

        public LocalDbService(ISQLiteConnectionFactory factory)
        {
            this._factory = factory;
        }

        private ISQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = _factory.Create("local.db");
                    _connection.CreateTable<Station>();                   
                }

                return _connection;
            }
        }

        public ITableQuery<Station> Stations
        {
            get
            {
                return _connection.Table<Station>();
            }
        }      

        public ICollection<Station> GetStations(string searchQuery)
        {
            ObservableCollection<Station> stationResults = new ObservableCollection<Station>(_connection.Table<Station>().Where(t => t.StationName.Contains(searchQuery)));
            return stationResults;
        }
    }
}
