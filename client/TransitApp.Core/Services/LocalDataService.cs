using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.IO;

namespace TransitApp.Core.Services
{
    public class LocalDataService : ILocalDataService
    {
        private class LocalData
        {
            public ICollection<Line> Lines { get; set; }

            public ICollection<Station> Stations { get; set; }
        }

        private LocalData _localData;

        public LocalDataService()
        {
            //Get Data From embedded resources
            var assembly = typeof(LocalDataService).Assembly;
            var resourceNames = assembly.GetManifestResourceNames();

            var resourcePaths = resourceNames
                .Where(x => x.EndsWith("LocalData.json", StringComparison.CurrentCultureIgnoreCase))
                .ToArray();

            var json = new StreamReader(assembly.GetManifestResourceStream(resourcePaths.Single())).ReadToEnd();

            _localData = JsonConvert.DeserializeObject<LocalData>(json);

            foreach (var station in _localData.Stations)
            {
                station.Lines = _localData.Lines.Where(x => station.Lines.Any(y => y.Id == x.Id)).ToList();
            }
        }

        public Line GetLine(string id)
        {
            return _localData.Lines.FirstOrDefault(x => x.Id == id);
        }

        public Station GetStation(string id)
        {
            return _localData.Stations.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Line> GetLines(IEnumerable<string> ids)
        {
            if (ids == null || ids.Count() == 0)
            {
                return _localData.Lines;
            }
            else
            {
                return _localData.Lines.Where(x => ids.Contains(x.Id)).ToList();
            }
        }

        public ICollection<Station> GetStations(string searchQuery)
        {
            //Search for stations
            return null;
            ObservableCollection<Station> stationResults = new ObservableCollection<Station>(_localData.Stations.Where(t => t.Name.Contains(searchQuery)));
            return stationResults;
        }
    }
}
