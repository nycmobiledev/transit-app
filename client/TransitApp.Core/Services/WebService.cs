using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using ModernHttpClient;
using TransitApp.Core.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


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

            var result = new List<Alert>();
            if (null != follows && follows.Count() != 0)
            {
                var stations = String.Join(",", follows.Select(follow => follow.StationId));

                var client = new HttpClient(new NativeMessageHandler());

                
                client.DefaultRequestHeaders.Add("X-ZUMO-APPLICATION", "EPeYbipHNSFHMFJDrVcDlYVrxyUNzf38");
                var resp = await client.GetStringAsync("http://wheresmytrain.azure-mobile.net/api/TransitAlert?stationsCsv=" + stations);

                var alerts = JsonConvert.DeserializeObject<List<Alert>>(resp);
			
                //Remove extra trains until the sever side supports.
                foreach (var item in alerts.OrderBy(alert => alert.ArrivalTime))
                {
//                    if (item.ArrivalTime > DateTime.UtcNow && follows.Any(x => x.LineId == item.LineId && x.StationId == item.StationId))
                    {
                        item.Line = _localDataService.GetLine(item.LineId);
                        item.Station = _localDataService.GetStation(item.StationId);
                        result.Add(item);
                    }
                }
            }

            _syncLock.Release();

            return result;
        }
    }
}