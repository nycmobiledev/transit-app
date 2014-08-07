using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitApp.Server.GTFSStatic.Core.Model
{
    class CalendarDate
    {
        public string ServiceId { get; set; }
        public DateTime Date { get; set; }
        public int ExceptionType { get; set; }
    }
}
