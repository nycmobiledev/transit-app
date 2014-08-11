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
        private readonly IStaticFileDownloader _downloader;
        private ZipArchive _gtfsArchive;

        public StaticFileService(IStaticFileDownloader downloader)
        {
            _downloader = downloader;
        }

        private async Task LoadZipFile()
        {
            if (_gtfsArchive != null) {
                _gtfsArchive =
                    await
                        _downloader.DownloadZipFileFromUrl(
                            "http://web.mta.info/developers/data/nyct/subway/google_transit.zip");
            }
        }

        public IList<Agency> GetAgencies()
        {
            throw new NotImplementedException();

        }

        public IList<Calendar> GetCalendars()
        {
            throw new NotImplementedException();
        }

        public IList<CalendarDate> GetCalendarDates()
        {
            throw new NotImplementedException();
        }

        public IList<Route> GetRoutes()
        {
            throw new NotImplementedException();
        }

        public IList<Shape> GetShapes()
        {
            throw new NotImplementedException();
        }

        public IList<Stop> GetStops()
        {
            throw new NotImplementedException();
        }

        public IList<StopTime> GetStopTimes()
        {
            throw new NotImplementedException();
        }

        public IList<Transfer> GetTransfers()
        {
            throw new NotImplementedException();
        }

        public IList<Trip> GetTrips()
        {
            throw new NotImplementedException();
        }
    }
}
