using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace TransitApp.Core.Services
{
    public class MockFollowService : FollowService
    {
        public MockFollowService(IMvxFileStore fileService, ILocalDataService localDbService, IMvxMessenger messenger)
            : base(fileService, localDbService, messenger)
        {
            AddFollows("701", new[] { "7" });            
        }
         
    }
}