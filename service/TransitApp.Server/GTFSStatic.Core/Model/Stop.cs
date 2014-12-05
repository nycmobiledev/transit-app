using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Stop
    {
        [CsvColumn(FieldIndex = 1, Name = "stop_id")]
        public string StopId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "stop_code")]
        public string StopCode { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "stop_name")]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "stop_desc")]
        public string Desc { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "stop_lat")]
        public double Latitude { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "stop_lon")]
        public double Longitude { get; set; }

        [CsvColumn(FieldIndex = 7, Name = "zone_id")]
        public string ZoneId { get; set; }

        [CsvColumn(FieldIndex = 8, Name = "stop_url")]
        public string StopUrl { get; set; }
        
        [CsvColumn(FieldIndex = 9, Name = "location_type")]
        public int LocationType { get; set; }

        [CsvColumn(FieldIndex = 10, Name = "parent_station")]
        public string ParentId { get; set; }
    }
}