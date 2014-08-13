using System;
using System.Linq;
using Ionic.Zip;
using Moq;
using NUnit.Framework;
using TransitApp.Server.GTFSStatic.Core.Interfaces;
using TransitApp.Server.GTFSStatic.Infrastructure.MTA;

namespace TransitApp.Server.GTFSStatic.InfrastructureTests
{
    [TestFixture]
    internal class StaticFileServiceTests
    {
        private Mock<IStaticFileDownloader> _downloadMock;
        private ZipFile _archive;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            _archive = ZipFile.Read("google_transit.zip");
            _downloadMock = new Mock<IStaticFileDownloader>(MockBehavior.Default);
            _downloadMock.Setup(d => d.DownloadZipFileFromUrl(It.IsAny<string>())).ReturnsAsync(_archive);
        }

        [Test]
        public void Should_Return_One_Agency()
        {
            var service = new StaticFileService(_downloadMock.Object);
            var list = service.GetAgencies();
            Assert.That(list.Count(), Is.EqualTo(1));

            var agency = list.First();
            Assert.That(agency.Id, Is.EqualTo("MTA NYCT"));
            Assert.That(agency.Name, Is.EqualTo("MTA New York City Transit"));
            Assert.That(agency.Url, Is.EqualTo("http://www.mta.info"));
            Assert.That(agency.Timezone, Is.EqualTo("America/New_York"));
            Assert.That(agency.Language, Is.EqualTo("en"));
            Assert.That(agency.Phone, Is.EqualTo("718-330-1234"));
        }
    }
}