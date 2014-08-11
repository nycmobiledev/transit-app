using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TransitApp.Server.GTFSStatic.InfrastructureTests
{
    [TestFixture]
    class ZipArchiveTests
    {
        private ZipArchive _archive;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            _archive = new ZipArchive(File.OpenRead("google_transit.zip"), ZipArchiveMode.Read);
        }

        [Test]
        public void Should_Load_Agency_File_By_Name()
        {
            var entry = _archive.GetEntry("agency.txt");
            Assert.That(entry.Name, Is.EqualTo("agency.txt"));
        }
    }
}
