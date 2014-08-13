using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class StopTime
    {
        [CsvColumn(FieldIndex = 1, Name = "trip_id")]
        public string TripId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "stop_id")]
        public string StopId { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "arrival_time")]
        public DateTime ArrivalTime { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "departure_time")]
        public DateTime DepartureTime { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "stop_sequence")]
        public int StopSequence { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "pickup_type")]
        public string PickupType { get; set; }

        [CsvColumn(FieldIndex = 7, Name = "drop_off_type")]
        public string DropoffType { get; set; }
    }
}