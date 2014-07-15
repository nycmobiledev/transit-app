using System;
using System.Collections.Generic;

namespace TransitApp.Server.GTFSRealtime.Core.Interfaces
{
    public interface IRepository<T>
    {
        void AddRange(IEnumerable<T> items);

        void ClearAll();
    }
}