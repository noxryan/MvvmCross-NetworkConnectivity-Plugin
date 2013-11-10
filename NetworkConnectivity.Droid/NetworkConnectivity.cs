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
        private ConnectivityManager ConnectionManager()
        {
            var globals = Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
            var connectivityManager = globals.ApplicationContext.GetSystemService(Context.ConnectivityService) as ConnectivityManager;

            return connectivityManager;
        }
        public bool GetConnectionStatus()
        {
            bool isConnected = false;
            bool isAvailable = this.ConnectionManager().ActiveNetworkInfo.IsAvailable;

            if (isAvailable == true)
                isConnected = this.ConnectionManager().ActiveNetworkInfo.IsConnected;

            return isConnected;
        }
        public string GetConnectionType()
        {
            string strConnection = "Not Connected";

            if(this.GetConnectionStatus() == true)
                strConnection = this.ConnectionManager().ActiveNetworkInfo.TypeName;

            return strConnection;
        }
    }
}