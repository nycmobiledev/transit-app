using System.Collections.Generic;
using TransitApp.Server.GTFSRealtime.Core.DTO;

namespace TransitApp.Server.GTFSRealtime.Core.Interfaces
{
    public interface IModelFactory<out T>
    {
        IEnumerable<T> CreateItemsFromFeedMessage(FeedMessage msg);
    }
}