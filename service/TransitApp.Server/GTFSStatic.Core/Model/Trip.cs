using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Trip
    {
        [CsvColumn(FieldIndex = 1, Name = "route_id")]
        public string RouteId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "service_id")]
        public string ServiceId { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "trip_id")]
        public string TripId { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "trip_headsign")]
        public string TripHeadsign { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "direction_id")]
        public int Direction { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "block_id")]
        public string BlockId { get; set; }

        [CsvColumn(FieldIndex = 7, Name = "shape_id")]
        public string ShapeId { get; set; }
    }
}