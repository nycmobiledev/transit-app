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
	public class TestFollowService : BaseTest
	{
		FollowService followService;

		public override void CreateTestableObject ()
		{
			this.followService = new FollowService (Ioc.Resolve<ILocalDbService> ());
		}

		[Test]
		public void TestGetFollows ()
		{
			var follows = this.followService.GetFollows ();

			Assert.AreEqual ("7", follows.First (x => x.Id == "701-7").LineId);
		}

		[Test]
		public void TestAddFollows ()
		{
			this.followService.AddFollows ("101", new string[] { "1", "2", "3" });

			Assert.IsTrue (this.followService.GetFollows ().Any (x => x.LineId == "1" && x.StationId == "101"));
		}

		[Test]
		public void TestDeleteFollows ()
		{
			this.followService.AddFollows ("101", new string[] { "1", "2", "3" });
			this.followService.DeleteFollows ("101", null);

			Assert.IsFalse (this.followService.GetFollows ().Any (x => x.StationId == "101"));
		}

		[Test]
		public void TestDeleteFollow ()
		{
			this.followService.AddFollows ("101", new string[] { "1", "2", "3" });
			this.followService.DeleteFollows ("101", new string[] { "1" });

			Assert.AreEqual (2, this.followService.GetFollows ().Count (x => x.StationId == "101"));
		}

		///// <summary>
		///// Tests my property.
		///// </summary>
		//[Test]
		//public void TestMyProperty()
		//{
		//    //// arrange
		//    bool changed = false;

		//    this.firstViewModel.PropertyChanged += (sender, args) =>
		//        {
		//            if (args.PropertyName == "MyProperty")
		//            {
		//                changed = true;
		//            }
		//        };

		//    //// act
		//    this.firstViewModel.MyProperty = "Hello MvvmCross";

		//    //// assert
		//    Assert.AreEqual(changed, true);
		//}

		///// <summary>
		///// Tests my command.
		///// </summary>
		//[Test]
		//public void TestMyCommand()
		//{
		//    //// arrange

		//    //// act
		//    this.firstViewModel.MyCommand.Execute(null);

		//    //// assert
		//}
	}
}
