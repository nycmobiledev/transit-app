using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransitApp.Server.WebApi.DataObjects
{
    public class Follow
    {
        public string StationId { get; set; }

        public string LineId { get; set; }
    }
}