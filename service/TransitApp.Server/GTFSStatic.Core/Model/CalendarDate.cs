using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class CalendarDate
    {
        [CsvColumn(FieldIndex = 1, Name = "service_id")]
        public string ServiceId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "date")]
        public DateTime Date { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "exception_type")]
        public int ExceptionType { get; set; }
    }
}