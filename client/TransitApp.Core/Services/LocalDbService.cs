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

            // All of data get from internet, but only alert no local cache
            _connection.CreateTable<Station>();
            _connection.CreateTable<Line>();

            // users' settings
            _connection.CreateTable<Follow>();
        }

        public ISQLiteConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public T Get<T>(object id) where T : new()
        {
            var obj = Connection.Get<T>(id);

            if (obj is Station)
            {
                LoadLines(obj as Station);
            }

            return obj;
        }

        public ICollection<Line> GetLines(IEnumerable<string> ids)
        {
            if (ids == null || ids.Count() == 0)
            {
                return Connection.Table<Line>().ToList();
            }
            else
            {
                return Connection.Table<Line>().Where(x => ids.Contains(x.Id)).ToList();
            }
        }

        public ICollection<Follow> GetFollows()
        {
            var follows = Connection.Table<Follow>().ToList();

            foreach (var follow in follows)
            {
                follow.Line = this.Get<Line>(follow.LineId);
                follow.Station = this.Get<Station>(follow.StationId);
            }

            return follows;
        }

        public ICollection<Station> GetStations(string searchQuery)
        {
            //Search for stations
            return null;
            ObservableCollection<Station> stationResults = new ObservableCollection<Station>(_connection.Table<Station>().Where(t => t.Name.Contains(searchQuery)));
            return stationResults;
        }

        private void LoadLines(Station station) {
            var lineIds = station.LineIds.Split(',');
            var lines = new List<Line>();

            foreach (var lineId in lineIds)
            {
                lines.Add(this.Connection.Get<Line>(lineId));
            }

            station.Lines = lines;
        }
    }
}
