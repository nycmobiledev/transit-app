using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace TransitApp.Server.WebApi.DataObjects
{
    public class TransitAlert : EntityData
    {
        public string Route { get; set; }

        public string Time { get; set; }
    }
}