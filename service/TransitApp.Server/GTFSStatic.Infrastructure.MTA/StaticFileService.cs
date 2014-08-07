using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using TransitApp.Server.GTFSStatic.Core.Interfaces;
using TransitApp.Server.GTFSStatic.Core.Model;

namespace TransitApp.Server.GTFSStatic.Infrastructure.MTA
{
    class StaticFileService: IStaticFileService
    {
        private readonly string _fileUrl;
        private ZipArchive _gtfsArchive;

        public StaticFileService(string fileUrl)
        {
            _fileUrl = fileUrl;
        }

        public IList<Agency> GetAgencies()
        {
            throw new NotImplementedException();
        }
    }
}
