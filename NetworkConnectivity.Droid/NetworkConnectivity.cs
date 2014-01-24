using System;
using Android.App;
using Android.Content;
using Android.Net;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Plugins.Messenger;
using NetworkConnectivity.NetworkConnectivity;

namespace NetworkConnectivity.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Android.Net.ConnectivityManager.ConnectivityAction })]
    public class NetworkConnectivity : BroadcastReceiver, INetworkConnectivity
    {
        public NetworkConnectivity()
        {

        }
        public ConnectivityManager ConnectionManager
        {
            get { return _connectionManager; }
        }
        private ConnectivityManager _connectionManager
        {
            get
            {
                var globals = Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
                var connectivityManager = globals.ApplicationContext.GetSystemService(Context.ConnectivityService) as ConnectivityManager;

                return connectivityManager;
            }
        }
        public bool GetConnectionStatus()
        {
            if (ConnectionManager.ActiveNetworkInfo != null && ConnectionManager.ActiveNetworkInfo.IsAvailable && ConnectionManager.ActiveNetworkInfo.IsConnected)
                return true;
            return false;
        }
        public string GetConnectionType()
        {
            string strConnection = "Not Connected";

            if (this.GetConnectionStatus() == true)
                strConnection = ConnectionManager.ActiveNetworkInfo.TypeName;
            return strConnection;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            Mvx.Resolve<IMvxMessenger>().Publish(new ConnectivityChangedMessage(this, GetConnectionStatus()));
        }
    }
}