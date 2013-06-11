using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace XSocketsWCF.Controllers
{
    /// <summary>
    /// A realtime controller
    /// </summary>
    public class ZooController : XSocketController
    {
        /// <summary>
        /// This method will be hit both from JavaScript, WCF and MVC examples
        /// Could have sent a custom object as well, but settled for a string in this case.
        /// </summary>
        /// <param name="message"></param>
        public void Say(string message)
        {
            //Just send it out to all subscribers
            this.SendToAll(new { message }, "say");

            //You can also use
            //this.Send, this.SendTo<T> etc...

            //Or use return statements if you want to...
        }
    }
}
