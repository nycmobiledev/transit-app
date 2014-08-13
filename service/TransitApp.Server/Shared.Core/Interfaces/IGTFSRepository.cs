using System;
using System.Collections.Generic;

namespace TransitApp.Server.Shared.Core.Interfaces
{
    public interface IGTFSRepository<T>
    {
        void AddRange(IEnumerable<T> items);

        void ClearAll();
    }
}