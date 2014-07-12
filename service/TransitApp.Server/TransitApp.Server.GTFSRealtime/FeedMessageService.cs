using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TransitApp.Server.GTFSRealtime.Entities;

namespace TransitApp.Server.GTFSRealtime
{
    public class FeedMessageService
    {
        //http://datamine.mta.info/mta_esi.php?key=80730fbe1b42c61fc060da055cb33334&feed_id={0}
        private readonly string _baseUrl;

        public FeedMessageService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<FeedMessage> GetCurrentRealtimeFeedMessage(SubwayLines lines)
        {
            //var requestUrl = string.Format(_baseUrl, (int) lines);
            throw new NotImplementedException();
        }

        private async Task<byte[]> GetUrlContents(string url)
        {
            var client = new HttpClient {MaxResponseContentBufferSize = 1000000};
            return await client.GetByteArrayAsync(url);
        }
    }

    public enum SubwayLines
    {
        RED_GREEN_S = 1,
        L = 2
    }
}
