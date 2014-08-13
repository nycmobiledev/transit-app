using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Route
    {
        [CsvColumn(FieldIndex = 1, Name = "agency_id")]
        public string AgencyId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "route_id")]
        public string RouteId { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "route_short_name")]
        public string ShortName { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "route_long_name")]
        public string LongName { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "route_type")]
        public int RouteType { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "route_desc")]
        public string Description { get; set; }

        [CsvColumn(FieldIndex = 7, Name = "route_url")]
        public string Url { get; set; }

        [CsvColumn(FieldIndex = 8, Name = "route_color")]
        public string Color { get; set; }

        [CsvColumn(FieldIndex = 9, Name = "route_text_color")]
        public string TextColor { get; set; }
    }
}