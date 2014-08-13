using System;
using LINQtoCSV;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Transfer
    {
        [CsvColumn(FieldIndex = 1, Name = "from_stop_id")]
        public string FromStopId { get; set; }

        [CsvColumn(FieldIndex = 2, Name = "to_stop_id")]
        public string ToStopId { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "transfer_type")]
        public int TransferType { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "min_transfer_time")]
        public int MinTransferTime { get; set; }
    }
}