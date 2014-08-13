using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ionic.Zip;
using LINQtoCSV;
using TransitApp.Server.GTFSStatic.Core.Interfaces;
using TransitApp.Server.GTFSStatic.Core.Model;

namespace TransitApp.Server.GTFSStatic.Infrastructure.MTA
{
    public class StaticFileService : IStaticFileService, IDisposable
    {
        private readonly IStaticFileDownloader _downloader;
        private readonly CsvFileDescription _inputFileDescription;
        private bool _disposed;
        private ZipFile _gtfsArchive;

        public StaticFileService(IStaticFileDownloader downloader)
        {
            _downloader = downloader;
            _inputFileDescription = new CsvFileDescription {SeparatorChar = ',', FirstLineHasColumnNames = true};
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Agency> GetAgencies()
        {
            return GetObjectsFromCsv<Agency>("agency.txt");
        }

        public IEnumerable<Calendar> GetCalendars()
        {
            return GetObjectsFromCsv<Calendar>("calendar.txt");
        }

        public IEnumerable<CalendarDate> GetCalendarDates()
        {
            return GetObjectsFromCsv<CalendarDate>("calendar_dates.txt");
        }

        public IEnumerable<Route> GetRoutes()
        {
            return GetObjectsFromCsv<Route>("routes.txt");
        }

        public IEnumerable<Shape> GetShapes()
        {
            return GetObjectsFromCsv<Shape>("shapes.txt");
        }

        public IEnumerable<Stop> GetStops()
        {
            return GetObjectsFromCsv<Stop>("stops.txt");
        }

        public IEnumerable<StopTime> GetStopTimes()
        {
            return GetObjectsFromCsv<StopTime>("stop_times.txt");
        }

        public IEnumerable<Transfer> GetTransfers()
        {
            return GetObjectsFromCsv<Transfer>("transfers.txt");
        }

        public IEnumerable<Trip> GetTrips()
        {
            return GetObjectsFromCsv<Trip>("trips.txt");
        }

        private async Task LoadZipFile()
        {
            if (_gtfsArchive == null) {
                _gtfsArchive =
                    await
                        _downloader.DownloadZipFileFromUrl(
                            "http://web.mta.info/developers/data/nyct/subway/google_transit.zip");
            }
        }

        private IList<T> GetObjectsFromCsv<T>(string fileName) where T : class, new()
        {
            IList<T> list = null;
            StreamReader reader = null;
            var memoryStream = new MemoryStream();

            try {
                Task.WaitAll(LoadZipFile());
                var zipEntry = _gtfsArchive.Entries.SingleOrDefault(z => z.FileName == fileName);
                zipEntry.Extract(memoryStream);
                //memoryStream.Position = 0;

                //Map CSV to Classes
                var csvcontext = new CsvContext();
                reader = new StreamReader(memoryStream);
                list = csvcontext.Read<T>(reader, _inputFileDescription).ToList();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } finally {
                //Close Stream
                if (reader != null) {
                    reader.Close();
                }

                memoryStream.Dispose();
            }

            return list;
        }

        ~StaticFileService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) {
                return;
            }

            if (disposing) {
                _gtfsArchive.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }
    }
}