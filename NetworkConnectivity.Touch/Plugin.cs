using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using NetworkConnectivity.NetworkConnectivity;

namespace NetworkConnectivity.Touch
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<INetworkConnectivity>(new NetworkConnectivity());
        }
    }
}