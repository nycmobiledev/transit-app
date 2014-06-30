using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;

namespace transit_app.ScheduledJobs
{
    // A scheduled job which can be invoked manually by submitting an HTTP
    // POST request to the path "/jobs/sample".

    public class RefreshMTAData : ScheduledJob
    {
        public override Task ExecuteAsync()
        {
            Services.Log.Info("MTA data refreshed!");
            return Task.FromResult(true);
        }
    }
}