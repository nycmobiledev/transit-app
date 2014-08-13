using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Shape
    {
        [CsvColumn(FieldIndex = 1, Name = "shape_id")]
        public string ShapeId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "shape_pt_sequence")]
        public int Sequence { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "shape_pt_lat")]
        public double Latitude { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "shape_pt_lon")]
        public double Longitude { get; set; }
    }
}