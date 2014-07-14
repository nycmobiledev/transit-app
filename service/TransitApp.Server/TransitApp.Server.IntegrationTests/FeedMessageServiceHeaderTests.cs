using System;
using NUnit.Framework;
using TransitApp.Server.GTFSRealtime;
using TransitApp.Server.GTFSRealtime.DTO;

namespace TransitApp.Server.IntegrationTests
{
    public class FeedMessageServiceHeaderTests : FeedMessageServiceTestsBase
    {
        [Test]
        public async void Should_Return_L_Train_Dataset()
        {
            var msg = await Service.GetCurrentRealtimeFeedMessage(SubwayLines.L);

            Assert.That(msg.Header.DataIncrementality, Is.EqualTo(FeedHeader.Incrementality.FULL_DATASET));
            Assert.That(msg.Header.NyctFeedHeader.TripReplacementPeriod.Count, Is.EqualTo(1));
            Assert.That(UnixTimeStampToDateTime(msg.Header.Timestamp), Is.EqualTo(DateTime.Now).Within(1).Minutes);

            foreach (var replacementPeriod in msg.Header.NyctFeedHeader.TripReplacementPeriod) {
                Assert.That(replacementPeriod.RouteId, Is.EqualTo("L"));
                var result = replacementPeriod.ReplacementPeriod.End - msg.Header.Timestamp;
                Assert.That(result, Is.EqualTo(1800));
            }

            DumpHeader(msg.Header);
        }

        [Test]
        public async void Should_Return_RED_GREEN_S_Train_Dataset()
        {
            var msg = await Service.GetCurrentRealtimeFeedMessage(SubwayLines.RED_GREEN_S);

            Assert.That(msg.Header.DataIncrementality, Is.EqualTo(FeedHeader.Incrementality.FULL_DATASET));
            Assert.That(msg.Header.NyctFeedHeader.TripReplacementPeriod.Count, Is.EqualTo(7));
            Assert.That(UnixTimeStampToDateTime(msg.Header.Timestamp), Is.EqualTo(DateTime.Now).Within(1).Minutes);

            foreach (var replacementPeriod in msg.Header.NyctFeedHeader.TripReplacementPeriod) {
                Assert.That(replacementPeriod.RouteId,
                    Is.EqualTo("1") | Is.EqualTo("2") | Is.EqualTo("3") | Is.EqualTo("4") | Is.EqualTo("5") |
                    Is.EqualTo("6") | Is.EqualTo("S"));
                var result = replacementPeriod.ReplacementPeriod.End - msg.Header.Timestamp;
                Assert.That(result, Is.EqualTo(1800));
            }

            DumpHeader(msg.Header);
        }
    }
}