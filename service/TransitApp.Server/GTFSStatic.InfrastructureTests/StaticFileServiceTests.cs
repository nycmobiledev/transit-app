using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TransitApp.Server.GTFSStatic.Core.Interfaces;
using TransitApp.Server.GTFSStatic.Infrastructure.MTA;

namespace TransitApp.Server.GTFSStatic.InfrastructureTests
{
    [TestFixture]
    class StaticFileServiceTests
    {
        private Moq.Mock<IStaticFileDownloader> _downloadMock;
        private ZipArchive _archive;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            _archive = new ZipArchive(File.OpenRead("google_transit.zip"), ZipArchiveMode.Read);
            _downloadMock = new Mock<IStaticFileDownloader>(MockBehavior.Default);
            _downloadMock.Setup(d => d.DownloadZipFileFromUrl(It.IsAny<string>())).ReturnsAsync(_archive);
        }

        [Test]
        public void Should_Return_One_Agency()
        {
            var service = new StaticFileService(_downloadMock.Object);
            var list = service.GetAgencies().ToList();
            Assert.That(list.Count, Is.EqualTo(1));
            var agency = list[0];
            Assert.That(agency.Id, Is.EqualTo("MTA NYCT"));
            Assert.That(agency.Name, Is.EqualTo("MTA New York City Transit"));
            Assert.That(agency.Url, Is.EqualTo("http://www.mta.info"));
            Assert.That(agency.Timezone, Is.EqualTo("America/New_York"));
            Assert.That(agency.Language, Is.EqualTo("en"));
            Assert.That(agency.Phone, Is.EqualTo("718-330-1234"));
        }
    }
}
