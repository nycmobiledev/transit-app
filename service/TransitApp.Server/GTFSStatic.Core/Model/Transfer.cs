using System;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    public class Transfer
    {
        public string FromStopId { get; set; } 
        public string ToStopId { get; set; }
        public int TransferType { get; set; }
        public int MinTransferTime { get; set; }
    }
}