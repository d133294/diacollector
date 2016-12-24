using System.ServiceModel;
using System.ServiceModel.Web;
using DiaCollector.Items;

namespace DiaCollectorService
{
    [ServiceContract]
    public interface IItemService
    {
        [OperationContract]
        [WebInvoke(Method="POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string Submit(ItemData data);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string SendTrinity();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string HealthCheck();
    }
}
