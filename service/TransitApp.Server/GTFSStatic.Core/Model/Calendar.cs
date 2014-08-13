using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Calendar
    {
        [CsvColumn(FieldIndex = 1, Name = "service_id")]
        public string ServiceId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "monday")]
        public bool RunOnMonday { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "tuesday")]
        public bool RunOnTuesday { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "wednesday")]
        public bool RunOnWednesday { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "thursday")]
        public bool RunOnThursday { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "friday")]
        public bool RunOnFriday { get; set; }

        [CsvColumn(FieldIndex = 7, Name = "saturday")]
        public bool RunOnSaturday { get; set; }

        [CsvColumn(FieldIndex = 8, Name = "sunday")]
        public bool RunOnSunday { get; set; }

        [CsvColumn(FieldIndex = 9, Name = "start_date")]
        public DateTime StartDate { get; set; }

        [CsvColumn(FieldIndex = 10, Name = "end_date")]
        public DateTime EndDate { get; set; }
    }
}