using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace TransitApp.Server.WebApi.ScheduledJobs
{
    public class GTFSStaticJob : ScheduledJob
    {
        /// <summary>
        /// When implemented in a derived class, executes the scheduled job asynchronously. Implementations that want to know whether
        ///             the scheduled job is being cancelled can get a <see cref="P:Microsoft.WindowsAzure.Mobile.Service.ScheduledJob.CancellationToken"/> from the <see cref="M:CancellationToken"/> property.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task"/> representing the asynchronous operation.
        /// </returns>
        public override Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}