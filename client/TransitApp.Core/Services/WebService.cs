using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{   
    public class WebService : IWebService
    {
        private SemaphoreSlim _syncLock = new SemaphoreSlim(1);
        private readonly ILocalDataService _localDataService;

        public WebService(ILocalDataService localDataService)
        {
            _localDataService = localDataService;
        }

        public async Task<ICollection<Alert>> GetAlerts(IEnumerable<Follow> follows)
        {
            await _syncLock.WaitAsync();

            var list = new List<Alert>();
            if (null != follows && follows.Count() != 0)
            {
                var stations = String.Join(",", follows.Select(follow => follow.StationId));

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("X-ZUMO-APPLICATION", "HaFafTMWBtEycDgGAgJDvlPKibkQIK93");

                var resp = await client.GetStringAsync("http://transitapp.azure-mobile.net/api/TransitAlert?stationsCsv=" + stations);

                list = JsonConvert.DeserializeObject<List<Alert>>(resp);

                foreach (var item in list)
                {
                    item.Line = _localDataService.GetLine(item.LineId);
                    item.Station = _localDataService.GetStation(item.StationId);
                }

                list = list.OrderBy(alert => alert.ArrivalTime).ToList();
            }                        

            _syncLock.Release();

            return list;
        }
    }
}