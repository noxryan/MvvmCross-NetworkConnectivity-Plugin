using System;
using Android.App;
using Android.Content;
using Android.Net;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using NetworkConnectivity.NetConnectivity;

namespace NetworkConnectivity.Droid
{
    public class NetworkConnectivity : INetworkConnectivity
    {
        public NetworkConnectivity()
        {
            var obj = new NetworkConnectivity();
        }
        public ConnectivityManager ConnectionManager
        {
            get { return _connectionManager(); }
        }
        private ConnectivityManager _connectionManager()
        {
            var globals = Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
            var connectivityManager = globals.ApplicationContext.GetSystemService(Context.ConnectivityService) as ConnectivityManager;

            return connectivityManager;
        }
        public bool GetConnectionStatus()
        {
            bool isConnected = false;
            bool isAvailable = ConnectionManager.ActiveNetworkInfo.IsAvailable;

            if (isAvailable == true)
                isConnected = ConnectionManager.ActiveNetworkInfo.IsConnected;

            return isConnected;
        }
        public string GetConnectionType()
        {
            string strConnection = "Not Connected";

            if (this.GetConnectionStatus() == true)
                strConnection = ConnectionManager.ActiveNetworkInfo.TypeName;

            return strConnection;
        }
    }
}