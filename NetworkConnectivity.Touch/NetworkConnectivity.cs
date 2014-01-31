using System;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Plugins.Messenger;
using NetworkConnectivity.NetworkConnectivity;

namespace NetworkConnectivity.Touch
{
    public class NetworkConnectivity : INetworkConnectivity
    {

        public NetworkConnectivity()
        {
            Reachability.ReachabilityChanged += (object sender, EventArgs e) => { UpdateConnectionStatus(); };
        }

        void UpdateConnectionStatus()
        {
            Mvx.Resolve<IMvxMessenger>().Publish(new ConnectivityChangedMessage(this, GetConnectionStatus()));
        }

        public bool GetConnectionStatus()
        {
            if (Reachability.InternetConnectionStatus() == NetworkStatus.NotReachable)
                return false;
            return true;
        }

        public string GetConnectionType()
        {
            NetworkStatus netStatus = Reachability.InternetConnectionStatus();
            if (netStatus == NetworkStatus.ReachableViaCarrierDataNetwork)
                return "MOBILE";
            else if (netStatus == NetworkStatus.ReachableViaWiFiNetwork)
                return "WIFI";
            else
                return "Not Connected";
        } 
    }
}