using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace TransitApp.Server.WebApi.TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var t = AsyncMain();
            t.Wait();
        }

        private static async Task AsyncMain()
        {
            // Use this constructor instead after publishing to the cloud
            var mobileService = new MobileServiceClient(
                "https://wheresmytrain.azure-mobile.net/",
                "EPeYbipHNSFHMFJDrVcDlYVrxyUNzf38"
                );

            var obj = await mobileService.GetTable<TransitAlert>().ReadAsync();
            Console.WriteLine("Object Count: {0}", obj.Count());
        }
    }

    internal class TransitAlert
    {
        public string TripId { get; set; }
        public string StationId { get; set; }
        public int BatchVersion { get; set; }
        public string RouteId { get; set; }
        public string StationName { get; set; }
        public string RouteName { get; set; }
        public DateTime Time { get; set; }
        public String Direction { get; set; }
        public bool IsRealtime { get; set; }
    }
}