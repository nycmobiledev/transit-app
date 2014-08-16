using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using Cirrious.MvvmCross.Plugins.File;

namespace TransitApp.Core.Services
{
    public class MockFollowService : FollowService
    {
        public MockFollowService(IMvxFileStore fileService, ILocalDataService localDbService)
            : base(fileService, localDbService)
        {
            AddFollows("701", new[] { "7" });
        }
    }
}