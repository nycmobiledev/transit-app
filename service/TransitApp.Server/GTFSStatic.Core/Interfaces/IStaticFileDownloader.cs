using System;
using System.IO.Compression;
using System.Threading.Tasks;

namespace TransitApp.Server.GTFSStatic.Core.Interfaces
{
    public interface IStaticFileDownloader
    {
        Task<ZipArchive> DownloadZipFileFromUrl(string url);
    }
}
