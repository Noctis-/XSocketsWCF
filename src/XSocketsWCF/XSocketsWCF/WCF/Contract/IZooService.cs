using System.ServiceModel;
using System.ServiceModel.Web;

namespace XSocketsWCF.WCF.Contract
{
    [ServiceContract]
    public interface IZooService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Say/{message}")]
        string Say(string message);
    }
}
