using System.ServiceModel.Activation;
using XSockets.Client;
using XSockets.Core.XSocket.Helpers;
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
            //Get a connection (if it exists already that oen will be used)
            var conn = ClientPool.GetInstance("ws://127.0.0.1:4502/Zoo", "*");

            //We send an anonymous message here, but any object will work.
            conn.Send(new { message = "I was sent over WebSockets: " + message }.AsTextArgs("Say"));

            //Do your WCF regular stuff whatever it might be... and then return
            return string.Format("I was returned from WCF: " + message);
        }
    }

}