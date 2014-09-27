using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using ModernHttpClient;
using TransitApp.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TransitApp.Core.Services
{
    public class TickerModel
    {
        public TickerModel()
        {
        }

        public string TickerName { get; set; }
        public double Price { get; set; }
        public int PortfolioQty { get; set; }
    }

    public class WebService : IWebService
    {
        private readonly ILocalDataService _localDataService;

        public WebService(ILocalDataService localDataService)
        {
            _localDataService = localDataService;
        }

        private void TimerCallback(object state)
        {
        }

        public async Task<ICollection<Station>> FindStationsByName(string name)
        {
            //todo 
            throw new NotImplementedException();
        }

        public async Task<ICollection<Alert>> GetAlerts(IEnumerable<Follow> follows)
        {
            var list = new List<Alert>();
            if (null == follows || follows.Count() == 0)
            {
                return list;
            }

            var stations = String.Join(",", follows.Select(follow => follow.StationId));

            var client = new HttpClient(new NativeMessageHandler());

            client.DefaultRequestHeaders.Add("X-ZUMO-APPLICATION", "HaFafTMWBtEycDgGAgJDvlPKibkQIK93");

            string resp = null;


            resp =
                await
                    client.GetStringAsync("http://transitapp.azure-mobile.net/api/TransitAlert?stationsCsv=" + stations);
            list = JsonConvert.DeserializeObject<List<Alert>>(resp);

            foreach (var item in list)
            {
                item.Line = _localDataService.GetLine(item.LineId);
                item.Station = _localDataService.GetStation(item.StationId);
            }

            return list.OrderBy(alert => alert.ArrivalTime).ToList();
        }
    }
}