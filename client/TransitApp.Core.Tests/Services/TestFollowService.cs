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
    using Cirrious.MvvmCross.Plugins.File;

    /// <summary>
    /// Defines the TestFirstViewModel type.
    /// </summary>
    [TestFixture]
    public class TestFollowService : BaseTest
    {
        IFollowService followService;

        public override void CreateTestableObject()
        {
            this.followService = Ioc.Resolve<IFollowService>();
        }

        [Test]
        public void TestGetFollows()
        {
            var follows = this.followService.GetFollows();

            Assert.AreEqual("7", follows.First(x => x.Id == "701-7").LineId);
        }

        [Test]
        public void TestAddFollows()
        {
            this.followService.AddFollows("501", new string[] { "4", "5", "6" });

            Assert.IsTrue(this.followService.GetFollows().Any(x => x.LineId == "4" && x.StationId == "501"));

            this.followService.DeleteFollows("501");
        }

        [Test]
        public void TestDeleteFollows()
        {
            this.followService.AddFollows("501", new string[] { "4", "5", "6" });
            this.followService.DeleteFollows("501");

            Assert.IsFalse(this.followService.GetFollows().Any(x => x.StationId == "501"));
        }

        [Test]
        public void TestDeleteFollow()
        {
            this.followService.AddFollows("501", new string[] { "4", "5X", "6" });
            this.followService.DeleteFollows("501", new string[] { "4" });

            Assert.AreEqual(2, this.followService.GetFollows().Count(x => x.StationId == "501"));

            this.followService.DeleteFollows("501");

        }

        [Test]
        public void TestGetFollowsGroupByStation()
        {
            this.followService.AddFollows("501", new string[] { "4", "6" });
            this.followService.AddFollows("701", new string[] { "7" });

            var follows = this.followService.GetFollowsGroupByStation();

            Assert.AreEqual(2, follows.Count);

            Assert.IsFalse(follows.First(x => x.Station.Id == "701").Lines.First(x => x.Line.Id == "7X").IsFollow);

            Assert.IsFalse(follows.First(x => x.Station.Id == "501").Lines.First(x => x.Line.Id == "5").IsFollow);
        }        
    }
}
