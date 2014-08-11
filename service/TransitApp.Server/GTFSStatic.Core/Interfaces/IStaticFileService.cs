using System;
using System.Collections.Generic;
using TransitApp.Server.GTFSStatic.Core.Model;

namespace TransitApp.Server.GTFSStatic.Core.Interfaces
{
    public interface IStaticFileService
    {
        IList<Agency> GetAgencies();
        IList<Calendar> GetCalendars();
        IList<CalendarDate> GetCalendarDates();
        IList<Route> GetRoutes();
        IList<Shape> GetShapes();
        IList<Stop> GetStops();
        IList<StopTime> GetStopTimes();
        IList<Transfer> GetTransfers();
        IList<Trip> GetTrips();
    }
}