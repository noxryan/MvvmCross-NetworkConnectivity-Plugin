using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using NetworkConnectivity.NetConnectivity;

namespace NetworkConnectivity.Droid
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<INetworkConnectivity>(new NetworkConnectivity());
        }
    }
}