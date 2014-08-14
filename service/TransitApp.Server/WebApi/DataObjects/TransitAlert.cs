using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DataObjects
{
    public class TransitAlert : EntityData
    {
        public string Route { get; set; }

        public string Time { get; set; }
    }
}