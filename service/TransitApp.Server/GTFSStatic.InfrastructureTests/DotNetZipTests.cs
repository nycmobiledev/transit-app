using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ionic.Zip;

namespace TransitApp.Server.GTFSStatic.InfrastructureTests
{
    [TestFixture]
    class DotNetZipTests
    {
        [Test]
        public void Should_Open_Zip_File()
        {
            var zipfile = new ZipFile("google_transit.zip");
            Assert.That(zipfile.Count, Is.EqualTo(9));
            zipfile.Dispose();
        }

        [Test]
        public void Should_Open_Agency_File()
        {
            using (var zipfile = ZipFile.Read("google_transit.zip")) {
                var agencyFile = zipfile.Entries.SingleOrDefault(z => z.FileName == "agency.txt");
                using (var memoryStream = new MemoryStream()) {
                    agencyFile.Extract(memoryStream);
                    memoryStream.Position = 0;
                    var sr = new StreamReader(memoryStream);
                    var fileContent = sr.ReadToEnd();
                    Assert.That(fileContent.Length, Is.GreaterThan(0));
                    Assert.That(fileContent, Contains.Substring("New York City Transit"));
                    Console.WriteLine(fileContent);
                }
            }
        }
    }
}
