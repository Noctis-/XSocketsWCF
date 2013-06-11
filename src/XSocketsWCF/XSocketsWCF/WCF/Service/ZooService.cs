using System.ServiceModel.Activation;
using XSockets.Core.XSocket.Helpers;
using XSockets.External;
using XSocketsWCF.WCF.Contract;

namespace XSocketsWCF.WCF.Service
{
    /// <summary>
    /// Showing that you can boost a existing WCF to realtime with a few lines of code.
    /// Just create a XSockets connection, and then publish messages from your WCF
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ZooService : IZooService
    {        
        public string Say(string message)
        {
            //Add a message to our QueueHelper that will process messages and send them to XSockets.
            //Note that this Queue can be used from MVC or anything else serverside as well...
            Helpers.XSocketsQueue.QueueMessage(new { message = "I was sent over WebSockets: " + message }.AsTextArgs("Say"));

            //Do your WCF regular stuff whatever it might be... and then return
            return string.Format("I was returned from WCF: " + message);
        }
    }

}