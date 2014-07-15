using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.GTFSRealtime.Core.Services;
using TransitApp.Server.GTFSRealtime.Infrastructure.Data;
using TransitApp.Server.GTFSRealtime.Infrastructure.MTA;

namespace TransitApp.Server.GTFSRealtime.IntegrationTests.DataLoader
{
    [TestFixture]
    internal class DataLoaderTests
    {
        private string _combinedUrl;
        private FeedMessageService _mtaFeedService;
        private const string ApiKey = "80730fbe1b42c61fc060da055cb33334";
        private const string Url = "http://datamine.mta.info/mta_esi.php?key={0}&feed_id=";

        private const string DbConnStr =
            "Server=tcp:tei624ww1k.database.windows.net,1433;Database=mta_nyc_subway;User ID=nymobile.net@tei624ww1k;Password=NYCm0b1l3;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

        [TestFixtureSetUp]
        public void SetupTestFixture()
        {
            _combinedUrl = string.Format(Url, ApiKey);
            _mtaFeedService = new FeedMessageService(_combinedUrl);
        }

        [Test]
        public async void Should_Fill_Alerts_Table()
        {
            var msgL = await _mtaFeedService.GetCurrentRealtimeFeedMessage(SubwayLines.L);
            var msgIrt = await _mtaFeedService.GetCurrentRealtimeFeedMessage(SubwayLines.RED_GREEN_S);

            var alertFactory = new AlertFactory();
            var alertsIrt = alertFactory.CreateItemsFromFeedMessage(msgIrt);
            var alertsL = alertFactory.CreateItemsFromFeedMessage(msgL);

            // Clear Tables
            using (var alertRepos = new AlertRepository(DbConnStr)) {
                alertRepos.ClearAll();

                // Load Tables
                alertRepos.AddRange(alertsIrt);
                alertRepos.AddRange(alertsL);
            }
        }
    }
}
