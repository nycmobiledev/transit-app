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
	public class WebService1 : IWebService
	{
		private SemaphoreSlim _syncLock = new SemaphoreSlim(1);

		private readonly ILocalDataService _localDataService;
		private const string ALERTS_URL = "http://192.168.56.1/transit-app-svc/api/TransitAlert?stationsCsv=";

		public WebService1(ILocalDataService localDataService)
		{
			_localDataService = localDataService;
		}

		public async Task<List<Alert>> GetAlerts(IEnumerable<Follow> follows)
		{
			await _syncLock.WaitAsync();

			var result = new List<Alert>();
			if (null != follows && follows.Count() != 0)
			{
				var stations = String.Join(",", follows.Select(follow => follow.StationId));

				var client = new HttpClient(new NativeMessageHandler());


			
				var resp = await client.GetStringAsync( ALERTS_URL + stations);


				var alerts = JsonConvert.DeserializeObject<List<Alert>>(resp);

				int i = 0;
				Random rand = new Random ();
				List<int> nos = new List<int> ();
				nos.Add (rand.Next (1, 100));
				nos.Add (rand.Next (1, 100));
				nos.Add (rand.Next (1, 100));
				nos.Add (rand.Next (1, 100));
				nos.Add (rand.Next (1, 100));
				nos.Add (rand.Next (1, 100));
				nos.Add (rand.Next (1, 100));

				//Remove extra trains until the sever side supports.
				foreach (var item in alerts.OrderBy(alert => alert.ArrivalTime))
				{

					if (i > 100)
						break;
					if(!nos.Contains(i++) )
						continue;
					item.Line = _localDataService.GetLine(item.LineId);
					item.Station = _localDataService.GetStation(item.StationId);
					result.Add(item);

				}
			}

			_syncLock.Release();

			return result;
		}
	}
}