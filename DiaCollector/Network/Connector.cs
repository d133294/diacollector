using System;
using System.ServiceModel;
//using System.ServiceModel.Description;
using System.ServiceModel.Web;
using DiaCollector.Helpers;
using DiaCollector.Items;
using DiaCollectorService;

namespace DiaCollector.Network
{
    public class Connector
    {
        const string ItemServiceUrl = "https://diacollector.asuscomm.com:8000/ItemService";

        private static Connector _instance;
        private bool _initialized;
        private Uri _serverUri;
        private ChannelFactory<IItemService> _httpFactory;
        private IItemService _httpProxy;

        public static Connector Instance { get { return _instance ?? (_instance = new Connector()); } }

        public void SendItem(ItemData itemData)
        {
            try
            {
                ClientInitialize();

                var result = _httpProxy.Submit(itemData);
                LoggerIt.Debug("[DIACOLLECTOR] Item Service Response: {0}", result);
            }
            catch (Exception ex)
            {
                LoggerIt.Error("[DIACOLLECTOR] Error sending Item: " + itemData.Name + ", " + ex.Message);
            }
        }

        private void ClientInitialize()
        {
            try
            {
                if (!_initialized)
                {
                    _serverUri = new Uri(ItemServiceUrl);

                    LoggerIt.Log("[DIACOLLECTOR] Initializing Client Service connection to {0}", _serverUri.AbsoluteUri);
                    
                    WebHttpBinding webHttpBinding = new WebHttpBinding
                    {
                        OpenTimeout = TimeSpan.FromMilliseconds(5000),
                        SendTimeout = TimeSpan.FromMilliseconds(5000),
                        CloseTimeout = TimeSpan.FromMilliseconds(5000),
                    };

                    _httpFactory = new WebChannelFactory<IItemService>(webHttpBinding, _serverUri);
                    _httpProxy = _httpFactory.CreateChannel();

                    _initialized = true;
                }
            }
            catch (Exception ex)
            {
                LoggerIt.Log("[DIACOLLECTOR] Exception in ClientInitialize() {0}", ex);
            }
        }
    }
}
