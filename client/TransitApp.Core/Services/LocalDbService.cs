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
            _connection = _factory.Create("TransitApp.db");
            _connection.CreateTable<Station>();
            _connection.CreateTable<Follow>();                   

        }

        private ISQLiteConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public ITableQuery<Station> Stations
        {
            get
            {
                return Connection.Table<Station>();
            }
        }

        public ITableQuery<Follow> Follows
        {
            get
            {
                return Connection.Table<Follow>();
            }
        }

        public ICollection<Station> GetStations(string searchQuery)
        {
            //Search for stations
            return null;
            ObservableCollection<Station> stationResults = new ObservableCollection<Station>(_connection.Table<Station>().Where(t => t.Name.Contains(searchQuery)));
            return stationResults;
        }
    }
}
