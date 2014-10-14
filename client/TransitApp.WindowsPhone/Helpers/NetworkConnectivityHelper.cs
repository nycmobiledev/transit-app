using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitApp.Core.Interfaces;
using Microsoft.Phone.Net.NetworkInformation;

namespace TransitApp.WindowsPhone.Helpers
{
    public class NetworkConnectivityHelper : IConnectivity
    {
        public bool IsConnected()
        {
            return DeviceNetworkInformation.IsWiFiEnabled || DeviceNetworkInformation.IsCellularDataEnabled || DeviceNetworkInformation.IsCellularDataRoamingEnabled;
        }
    }
}
