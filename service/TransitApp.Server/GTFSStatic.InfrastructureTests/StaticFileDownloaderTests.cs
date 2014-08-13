using System;
using NUnit.Framework;
using TransitApp.Server.GTFSStatic.Infrastructure.MTA;

namespace TransitApp.Server.GTFSStatic.InfrastructureTests
{
    [TestFixture]
    internal class StaticFileDownloaderTests
    {
        [Test]
        public async void Should_Return_ZipArchive()
        {
            var downloader = new StaticFileDownloader();
            var zipfile =
                await
                    downloader.DownloadZipFileFromUrl(
                        "http://web.mta.info/developers/data/nyct/subway/google_transit.zip");
            Assert.That(zipfile.Entries.Count, Is.GreaterThan(1));
        }
    }
}