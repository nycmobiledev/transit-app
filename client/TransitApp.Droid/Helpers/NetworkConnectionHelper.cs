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
			_networkHelper = (ConnectivityManager) Application.Context.GetSystemService (Android.Content.Context.ConnectivityService);
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

			var activeConnection = _networkHelper.ActiveNetworkInfo;

			if ((activeConnection != null) && activeConnection.IsConnected) {
				// we are connected to a network.
				_isConnected = true;

			} else {
				_isConnected = false;
			}

			if (_isConnected) {
				var mobileConn = _networkHelper.GetNetworkInfo (ConnectivityType.Mobile);
				if (mobileConn != null && mobileConn.GetState () == NetworkInfo.State.Connected) {
					_isDataConn = true;

				} else {
					_isDataConn = false;
				}

				var wifiConn = _networkHelper.GetNetworkInfo (ConnectivityType.Wifi);
				if (wifiConn != null && wifiConn.GetState () == NetworkInfo.State.Connected) {
					_isWifiConn = true;
				} else {
					_isWifiConn = false;
				}
			} else {
				_isDataConn = false;
				_isWifiConn = false;
			}
		}

		private ConnectivityManager _networkHelper;

	}
}

