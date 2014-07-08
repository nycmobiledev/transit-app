using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransitApp.Core.Models
{
    public class Alert
    {
        public Alert()
        {
            
        }

        public string TrainId { get; set; }

        public DateTime ArriveTime { get; set; }

        public string Line { get; set; }

        public Station Station { get; set; }
    }
}
