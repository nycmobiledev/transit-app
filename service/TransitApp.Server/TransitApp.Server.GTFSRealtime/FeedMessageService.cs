using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ProtoBuf;
using TransitApp.Server.GTFSRealtime.DTO;

namespace TransitApp.Server.GTFSRealtime
{
    public class FeedMessageService
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
            var resultStream = await GetUrlContents(requestUrl);
            return Serializer.Deserialize<FeedMessage>(resultStream);
        }

        private static async Task<Stream> GetUrlContents(string url)
        {
            using (var client = new HttpClient {MaxResponseContentBufferSize = 1000000}) {
                return await client.GetStreamAsync(url);
            }
        }
    }

    public enum SubwayLines
    {
        RED_GREEN_S = 1,
        L = 2
    }
}