using System;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    internal class Calendar
    {
        public string ServiceId { get; set; }
        public bool RunOnMonday { get; set; }
        public bool RunOnTuesday { get; set; }
        public bool RunOnWednesday { get; set; }
        public bool RunOnThursday { get; set; }
        public bool RunOnFriday { get; set; }
        public bool RunOnSaturday { get; set; }
        public bool RunOnSunday { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}