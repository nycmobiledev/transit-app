using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransitApp.Server.WebApi.ScheduledJobs;

namespace TransitApp.Server.WebApi.TestConsole
{
    [TestFixture]
    public class JobsTest
    {

        [Test]
        public async void Test_CanExecuteStaticJob()
        {
            GTFSStaticJob job = new GTFSStaticJob();

            await job.ExecuteAsync();
        }

        [Test]
        public async void Test_CanExecuteRealtimeJob()
        {
            GTFSRealtimeJob job = new GTFSRealtimeJob();

            await job.ExecuteAsync();
        }
    }
}
