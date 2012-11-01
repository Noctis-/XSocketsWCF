using System.ServiceModel;
using System.ServiceModel.Web;

namespace XSocketsWCF.WCF.Contract
{
    [ServiceContract]
    public interface IRoomService
    {
        [OperationContract]
        [WebGet(UriTemplate = "JoinRoom/{name}")]
        string JoinRoom(string name);
    }
}
