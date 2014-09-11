using System;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;
using Ionic.Zip;
using TransitApp.Server.GTFSStatic.Core.Interfaces;

namespace TransitApp.Server.GTFSStatic.Infrastructure.MTA
{
    public class StaticFileDownloader : IStaticFileDownloader
    {
        public async Task<ZipFile> DownloadZipFileFromUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(url).ConfigureAwait(false);

                return ZipFile.Read(await responseMessage.Content.ReadAsStreamAsync());
            }
        }
    }
}