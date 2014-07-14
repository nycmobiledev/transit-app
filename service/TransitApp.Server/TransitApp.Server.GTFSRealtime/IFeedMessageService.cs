using System.Threading.Tasks;
using TransitApp.Server.GTFSRealtime.DTO;

namespace TransitApp.Server.GTFSRealtime
{
    public interface IFeedMessageService
    {
        Task<FeedMessage> GetCurrentRealtimeFeedMessage(SubwayLines lines);
    }
}