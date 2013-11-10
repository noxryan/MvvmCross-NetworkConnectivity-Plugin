namespace NetworkConnectivity.NetConnectivity
{
    public interface INetworkConnectivity
    {
        bool GetConnectionStatus();
        string GetConnectionType();
    }
}
