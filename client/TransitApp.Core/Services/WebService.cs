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

		public async Task<List<Alert>> GetAlerts(IEnumerable<Follow> follows)
		{
			var result = new List<Alert>();
			if (null != follows && follows.Count() != 0)
			{
				var stations = String.Join(",", follows.Select(follow => follow.StationId));

				var client = new HttpClient(new NativeMessageHandler());

				
				client.DefaultRequestHeaders.Add("X-ZUMO-APPLICATION", "EPeYbipHNSFHMFJDrVcDlYVrxyUNzf38");

				var content = new StringContent( JsonConvert.SerializeObject(follows), Encoding.UTF8, "application/json") ;

			   var resp = await client.PostAsync("http://wheresmytrain.azure-mobile.net/api/TransitAlert", content);


				var value = await resp.Content.ReadAsStringAsync();
				var alerts = JsonConvert.DeserializeObject<List<Alert>>(value);
			
				//Remove extra trains until the sever side supports.
				foreach (var item in alerts.OrderBy(alert => alert.ArrivalTimeSeconds))
				{
                    // Set the Arrival Time based on local clock
				    item.ArrivalTime = DateTime.UtcNow.AddSeconds(item.ArrivalTimeSeconds);
						item.Line = _localDataService.GetLine(item.LineId);
						item.Station = _localDataService.GetStation(item.StationId);
					    item.DestinationStation = _localDataService.GetStation(item.DestinationStationId);
						result.Add(item);
					
				}
			}

			return result;
		}
	}
}