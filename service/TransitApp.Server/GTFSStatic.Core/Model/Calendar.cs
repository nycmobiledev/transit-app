using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Calendar
    {
        [CsvColumn(FieldIndex = 1, Name = "service_id")]
        public string ServiceId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "monday")]
        public char RunOnMonday { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "tuesday")]
        public char RunOnTuesday { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "wednesday")]
        public char RunOnWednesday { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "thursday")]
        public char RunOnThursday { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "friday")]
        public char RunOnFriday { get; set; }

        [CsvColumn(FieldIndex = 7, Name = "saturday")]
        public char RunOnSaturday { get; set; }

        [CsvColumn(FieldIndex = 8, Name = "sunday")]
        public char RunOnSunday { get; set; }

        [CsvColumn(FieldIndex = 9, Name = "start_date")]
        public string StartDate { get; set; }

        [CsvColumn(FieldIndex = 10, Name = "end_date")]
        public string EndDate { get; set; }
    }
}