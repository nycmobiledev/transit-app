using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TransitApp.Core.Services
{
	public class TickerModel
	{
		public TickerModel ()
		{
		}
		public string TickerName {get; set;}
		public double Price {get;set;}
		public int PortfolioQty {get;set;}
	}
	public class WebService : IWebService
	{
		private CoolTimer  _coolTimer ;


		public WebService()
		{
			_coolTimer = new CoolTimer (TimerCallback,null,0,1000);

		}

		void TimerCallback(object state)
		{

		}

		public async Task<ICollection<Station>> FindStationsByName(string name)
		{
			//todo 
			throw new NotImplementedException();
		}
		public async Task<ICollection<Alert>> GetAlerts(IEnumerable<Follow> follows)
		{
			/*
			HttpClient client = new HttpClient ();
			string json = ""; //await client.GetStringAsync ("http://192.168.2.6:81/transitapp_svc/tables/Train");
			string url = "http://10.0.3.2/webapi45/api/ticker"; 
			string resp = await client.GetStringAsync (url); 
			var resp1 =  JsonConvert.DeserializeObject<List<TickerModel>>(resp);
			*/
			//todo 
			//var resp1 = JsonConvert.DeserializeObject<ICollection<Train>> (json);

			var list = new List<Alert>();

//			foreach (var follow in follows)
//			{
//				list.Add(new Alert()
//					{
//						TrainId = "1",
//						ArriveTime = DateTime.Now,
//						Station = new Station{Name = "union sq"},
//						Line = new Line{ Id = "1"}
//					});
//			}


//              MobileServiceClient client = new MobileServiceClient(
//                "http://transitapp.azure-mobile.net/",
//                "HaFafTMWBtEycDgGAgJDvlPKibkQIK93"
//            );

			HttpClient client = new HttpClient();



			client.DefaultRequestHeaders.Add("X-ZUMO-APPLICATION", "HaFafTMWBtEycDgGAgJDvlPKibkQIK93");

			var resp = await client.GetStringAsync("http://transitapp.azure-mobile.net/api/TransitAlert?stationsCsv=640");
				  
			list = JsonConvert.DeserializeObject<List<Alert>>(resp);


			return list;

		}
	}
}
