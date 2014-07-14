using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransitApp.Server.GTFSRealtime;
using TransitApp.Server.GTFSRealtime.Entities;

namespace TransitApp.Server.IntegrationTests
{
    [TestFixture]
    public class FeedMessageServiceTests
    {
        private const string apiKey = "80730fbe1b42c61fc060da055cb33334";
        private const string url = "http://datamine.mta.info/mta_esi.php?key={0}&feed_id=";
        private string combinedUrl;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            combinedUrl = string.Format(url, apiKey);
        }
    }
}
