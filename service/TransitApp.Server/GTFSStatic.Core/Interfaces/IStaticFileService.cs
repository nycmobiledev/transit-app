using System;
using System.Collections.Generic;
using TransitApp.Server.GTFSStatic.Core.Model;

namespace TransitApp.Server.GTFSStatic.Core.Interfaces
{
    public interface IStaticFileService
    {
        IList<Agency> GetAgencies();
    }
}