using System;
using TransitApp.Core.Interfaces;
using Android.Net;
using Android.Content;
using Android.App;

namespace TransitApp.Droid
{
	public class NetworkConnectionHelperDroid : IConnectivity
	{

		bool _isConnected;
		bool _isWifiConn;
		bool _isDataConn;

		public NetworkConnectionHelperDroid () 
		{

		}

		public bool IsConnected()
		{

			GetConnectivityDetails();
			return _isConnected;
		}

		public bool IsConnectedWifi()
		{
			GetConnectivityDetails();
			return _isWifiConn;
		}

		public bool IsConnectedMobile()
		{
			GetConnectivityDetails();
			return _isDataConn;
		}


		private void GetConnectivityDetails()
		{
			if (_networkHelper == null) {
				_networkHelper = (ConnectivityManager) Application.Context.GetSystemService (Android.Content.Context.ConnectivityService);
			}

			var activeConnection = _networkHelper.ActiveNetworkInfo;

			if ((activeConnection != null) && activeConnection.IsConnected)
			{
				// we are connected to a network.
				_isConnected = true;

			}

			if (_isConnected) {
				var mobileConn = _networkHelper.GetNetworkInfo (ConnectivityType.Mobile);
				if (mobileConn != null && mobileConn.GetState () == NetworkInfo.State.Connected) {
					_isDataConn = true;

				}

				var wifiConn = _networkHelper.GetNetworkInfo (ConnectivityType.Wifi);
				if (wifiConn != null && wifiConn.GetState () == NetworkInfo.State.Connected) {
					_isWifiConn = true;
				}
			}
		}

		private ConnectivityManager _networkHelper;

	}
}

