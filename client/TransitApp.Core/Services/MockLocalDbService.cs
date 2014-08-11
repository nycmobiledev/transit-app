using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using TransitApp.Core.Models;
using System.Collections.ObjectModel;

namespace TransitApp.Core.Services
{
    public class MockLocalDbService : LocalDbService
    {
        public MockLocalDbService(ISQLiteConnectionFactory factory)
            : base(factory)
        {
            MockData();
        }

        private void MockData()
        {
			this.Connection.InsertOrReplace(new Station() { Id = "701", Name = "Flushing - Main St", LineIds = "7,7X" });
			this.Connection.InsertOrReplace(new Station() { Id = "501", Name = "Eastchester - Dyre Av", LineIds = "4,5,6,5X,6X" });

			this.Connection.InsertOrReplace(new Line() { Id = "4", Start = "Bronx", End = "Brooklyn", Name = "4" });
			this.Connection.InsertOrReplace(new Line() { Id = "5", Start = "Bronx", End = "Brooklyn", Name = "5" });
			this.Connection.InsertOrReplace(new Line() { Id = "5X", Start = "Bronx", End = "Brooklyn", Name = "5 Express" });
			this.Connection.InsertOrReplace(new Line() { Id = "6", Start = "Bronx", End = "Brooklyn", Name = "6" });
			this.Connection.InsertOrReplace(new Line() { Id = "6X", Start = "Bronx", End = "Brooklyn", Name = "6 Express" });
			this.Connection.InsertOrReplace(new Line() { Id = "7", Start = "Manhattan", End = "Queens", Name = "7" });
			this.Connection.InsertOrReplace(new Line() { Id = "7X", Start = "Manhattan", End = "Queens", Name = "7 Express" });

			this.Connection.InsertOrReplace(new Follow() { LineId = "7", StationId = "701" });
			this.Connection.InsertOrReplace(new Follow() { LineId = "5X", StationId = "501" });
        }
    }
}
