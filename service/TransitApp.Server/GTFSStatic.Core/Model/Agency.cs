using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Agency
    {
        [CsvColumn(FieldIndex = 1, Name = "agency_id")]
        public string Id { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "agency_name")]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "agency_url")]
        public string Url { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "agency_timezone")]
        public string Timezone { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "agency_lang")]
        public string Language { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "agency_phone")]
        public string Phone { get; set; }
    }
}