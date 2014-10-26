using System;
using System.Net.Http;
using System.Threading.Tasks;
using ProtoBuf;
using TransitApp.Server.GTFSRealtime.Core.DTO;
using TransitApp.Server.GTFSRealtime.Core.Interfaces;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.MTA
{
    public class FeedMessageService : IFeedMessageService
    {
        //http://datamine.mta.info/mta_esi.php?key=80730fbe1b42c61fc060da055cb33334&feed_id=1
        //http://datamine.mta.info/mta_esi.php?key={0}&feed_id={1}
        private readonly string _baseUrl;

        public FeedMessageService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<FeedMessage> GetCurrentRealtimeFeedMessage(SubwayLines lines)
        {
            var requestUrl = _baseUrl + (int) lines;
            using (var client = new HttpClient()) {
                var resultStream = client.GetStreamAsync(requestUrl);
                try
                {
                    return Serializer.Deserialize<FeedMessage>(await resultStream);
                }
                catch (Exception e)
                {
                    // TODO Save the stream so we can debug it.
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}