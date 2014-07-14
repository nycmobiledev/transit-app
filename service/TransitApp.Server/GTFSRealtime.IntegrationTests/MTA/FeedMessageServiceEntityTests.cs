using System;
using NUnit.Framework;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.IntegrationTests.MTA
{
    internal class FeedMessageServiceEntityTests : FeedMessageServiceTestsBase
    {
        [TestCase(SubwayLines.L)]
        [TestCase(SubwayLines.RED_GREEN_S)]
        public async void Should_Return_More_Than_One_Entity(SubwayLines lines)
        {
            var msg = await MtaFeedService.GetCurrentRealtimeFeedMessage(lines);
            Assert.That(msg.Entity.Count, Is.GreaterThan(0));

            PrintEntityList(lines, msg);
        }
    }
}