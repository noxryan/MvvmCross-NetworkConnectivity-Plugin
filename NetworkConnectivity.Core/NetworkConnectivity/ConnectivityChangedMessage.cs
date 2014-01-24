using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace NetworkConnectivity.NetworkConnectivity
{
    public class ConnectivityChangedMessage : MvxMessage
    {
        public ConnectivityChangedMessage(object sender, bool connected)
            : base(sender)
        {
            Connected = connected;
        }

        public bool Connected { get; private set; }
    }
}
