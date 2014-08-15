// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the TestFirstViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TransitApp.Core.Tests.Services
{
    using System.Linq;
    using Core.ViewModels;
    using NUnit.Framework;

    using TransitApp.Core.Services;

    /// <summary>
    /// Defines the TestFirstViewModel type.
    /// </summary>
    [TestFixture]
    public class TestLocalDataService : BaseTest
    {
        LocalDataService localDataService;

        public override void CreateTestableObject()
        {
            this.localDataService = new LocalDataService();
        }

        [Test]
        public void TestGetLocalData()
        {
            var train7 = this.localDataService.GetLine("7");

            Assert.AreEqual("Queens", train7.Start);
        }

        [Test]
        public void TestGetLocalDataStationLines()
        {
            var station7 = this.localDataService.GetStation("701");

            Assert.AreEqual(2, station7.Lines.Count);

            Assert.AreEqual("Flushing Local", station7.Lines.First().Name);
        }  

    }
}
