using System;
using System.Collections.Generic;
using TransitApp.Server.GTFSStatic.Core.Model;

namespace TransitApp.Server.GTFSStatic.Core.Interfaces
{
    public interface IStaticFileService
    {
        IEnumerable<Agency> GetAgencies();
        IEnumerable<Calendar> GetCalendars();
        IEnumerable<CalendarDate> GetCalendarDates();
        IEnumerable<Route> GetRoutes();
        IEnumerable<Shape> GetShapes();
        IEnumerable<Stop> GetStops();
        IEnumerable<StopTime> GetStopTimes();
        IEnumerable<Transfer> GetTransfers();
        IEnumerable<Trip> GetTrips();
    }
}