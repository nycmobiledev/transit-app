using System;
using System.Threading.Tasks;
using Ionic.Zip;

namespace TransitApp.Server.GTFSStatic.Core.Interfaces
{
    public interface IStaticFileDownloader
    {
        Task<ZipFile> DownloadZipFileFromUrl(string url);
    }
}
