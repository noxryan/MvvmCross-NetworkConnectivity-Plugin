namespace NetworkConnectivity.NetworkConnectivity
{
    public interface INetworkConnectivity
    {
        bool GetConnectionStatus();
        string GetConnectionType();
    }
}
