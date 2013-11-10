using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using NetworkConnectivity.NetConnectivity;

namespace NetworkConnectivity.Phone
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
           // Mvx.RegisterSingleton<INetworkConnectivity>(new NetConnectivity());
        }
    }
}