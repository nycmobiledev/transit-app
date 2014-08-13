using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Stop
    {
        [CsvColumn(FieldIndex = 1, Name = "stop_id")]
        public string StopId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "stop_name")]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "stop_lat")]
        public double Latitude { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "stop_lon")]
        public double Longitude { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "location_type")]
        public int LocationType { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "parent_station")]
        public string ParentId { get; set; }
    }
}