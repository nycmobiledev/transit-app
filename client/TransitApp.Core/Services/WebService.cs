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
    public class WebService : IWebService
    {
        public WebService()
        {

        }

		public async Task<ICollection<Station>> FindStationsByName(string name)
        {
            //todo 
            throw new NotImplementedException();
        }
        public async Task<ICollection<Alert>> GetAlerts(IEnumerable<Follow> follows)
        {
			HttpClient client = new HttpClient ();
			string json = await client.GetStringAsync ("");

            //todo 
			return JsonConvert.DeserializeObject<ICollection<Alert>> (json);
        }
    }
}
