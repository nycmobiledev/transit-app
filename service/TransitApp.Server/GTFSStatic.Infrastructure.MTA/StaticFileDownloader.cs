using System;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;
using TransitApp.Server.GTFSStatic.Core.Interfaces;

namespace TransitApp.Server.GTFSStatic.Infrastructure.MTA
{
    public class StaticFileDownloader : IStaticFileDownloader
    {
        public async Task<ZipArchive> DownloadZipFileFromUrl(string url)
        {
            using (var client = new HttpClient {MaxResponseContentBufferSize = 1000000}) {
                var resultStream = client.GetStreamAsync(url);
                return new ZipArchive(await resultStream, ZipArchiveMode.Read);
            }
        }
    }
}