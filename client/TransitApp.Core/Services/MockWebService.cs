using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using System.Threading.Tasks;

namespace TransitApp.Core.Services
{
    public class MockWebService : IWebService
    {
        private Random _random = new Random(1);
        private readonly ILocalDataService _localDbService;

        public MockWebService(ILocalDataService localDbService)
        {
            _localDbService = localDbService;
        }

        public async Task<ICollection<Station>> FindStationsByName(string name)
        {
            var list = new List<Station>();

			return list;
        }

		public  async Task<List<Alert>> GetAlerts(IEnumerable<Follow> follows)
        {
            var list = new List<Alert>();

            foreach (var follow in follows)
            {
                list.Add(new Alert()
                {
                    TrainId = _random.Next(20).ToString(),
                    ArrivalTime = DateTime.UtcNow.AddMinutes(_random.Next(20)),
                    Station = _localDbService.GetStation(follow.StationId),
                    Line = _localDbService.GetLine(follow.LineId)
                });
            }

            return list;
        }
    }
}