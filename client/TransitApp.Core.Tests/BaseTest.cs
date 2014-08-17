// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the BaseTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using TransitApp.Core.Services;
using Cirrious.CrossCore.Plugins;

namespace TransitApp.Core.Tests
{
    using Cirrious.CrossCore.Core;
    using Cirrious.CrossCore.Platform;
    using Cirrious.MvvmCross.Platform;
    using Cirrious.MvvmCross.Test.Core;
    using Cirrious.MvvmCross.Views;
    using Mocks;
    using NUnit.Framework;
    using Cirrious.MvvmCross.Plugins.File;
    using Cirrious.MvvmCross.Plugins.File.Wpf;
    using Cirrious.MvvmCross.Plugins.Messenger;

    /// <summary>
    /// Defines the BaseTest type.
    /// </summary>
    [TestFixture]
    public abstract class BaseTest : MvxIoCSupportingTest
    {
        /// <summary>
        /// The mock dispatcher.
        /// </summary>
        private MockDispatcher mockDispatcher;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public virtual void SetUp()
        {
            this.ClearAll();

            this.mockDispatcher = new MockDispatcher();
            
            Ioc.RegisterSingleton<IMvxViewDispatcher>(this.mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(this.mockDispatcher);
            Ioc.RegisterSingleton<IMvxTrace>(new TestTrace());
            Ioc.RegisterSingleton<IMvxSettings>(new MvxSettings());

            Ioc.RegisterSingleton<IMvxFileStore>(new MvxWpfFileStore());

            Ioc.RegisterType<ILocalDataService, LocalDataService>();
            Ioc.RegisterType<IMvxMessenger, MvxMessengerHub>();
            Ioc.RegisterType<IFollowService, MockFollowService>();                        
                       

            this.Initialize();
            this.CreateTestableObject();
        }

        /// <summary>
        /// Creates the testable object.
        /// </summary>
        public virtual void CreateTestableObject()
        {
        }

        /// <summary>
        /// Tears down.
        /// </summary>
        [TearDown]
        public virtual void TearDown()
        {
            this.Terminate();
        }

        /// <summary>
        /// Initializes this instance.
        /// Any specific setup code for derived classes should override this method.
        /// </summary>
        protected virtual void Initialize()
        {
        }

        /// <summary>
        /// Terminates this instance.
        /// Any specific termination code for derived classes should override this method.
        /// </summary>
        protected virtual void Terminate()
        {
        }
    }
}
