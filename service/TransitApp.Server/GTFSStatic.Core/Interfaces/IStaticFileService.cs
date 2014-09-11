using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitApp.Server.GTFSStatic.Core.Model;

namespace TransitApp.Server.GTFSStatic.Core.Interfaces
{
    public interface IStaticFileService
    {
        Task<IEnumerable<Agency>> GetAgencies();
        Task<IEnumerable<Calendar>> GetCalendars();
        Task<IEnumerable<CalendarDate>> GetCalendarDates();
        Task<IEnumerable<Route>> GetRoutes();
        Task<IEnumerable<Shape>> GetShapes();
        Task<IEnumerable<Stop>> GetStops();
        Task<IEnumerable<StopTime>> GetStopTimes();
        Task<IEnumerable<Transfer>> GetTransfers();
        Task<IEnumerable<Trip>> GetTrips();
    }
}