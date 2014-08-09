using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using TransitApp.Core.Models;

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
    }
}
