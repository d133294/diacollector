using DiaCollector.Items;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ItemService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IItemService" in both code and config file together.
    [ServiceContract]
    public interface IItemService
    {
        
        [OperationContract]
        string Submit(ItemData data);
    }
}
