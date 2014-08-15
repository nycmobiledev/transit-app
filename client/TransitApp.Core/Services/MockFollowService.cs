using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public class MockFollowService : FollowService
    {
        public MockFollowService(ILocalDataService localDbService)
            : base(localDbService)
        {
            
        }

    }
}