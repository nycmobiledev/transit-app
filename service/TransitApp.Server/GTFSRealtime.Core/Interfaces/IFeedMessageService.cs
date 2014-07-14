using System;
using System.Threading.Tasks;
using TransitApp.Server.GTFSRealtime.Core.DTO;
using TransitApp.Server.GTFSRealtime.Core.Model;

namespace TransitApp.Server.GTFSRealtime.Core.Interfaces
{
    public interface IFeedMessageService
    {
        Task<FeedMessage> GetCurrentRealtimeFeedMessage(SubwayLines lines);
    }
}