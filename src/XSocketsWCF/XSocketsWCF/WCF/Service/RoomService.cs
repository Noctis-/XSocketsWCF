using System.ServiceModel.Activation;
using XSockets.Core.XSocket.Helpers;
using XSockets.External.Client.Net;
using XSocketsWCF.WCF.Contract;

namespace XSocketsWCF.WCF.Service
{
    /// <summary>
    /// Showing that you can boost a existing WCF to realtime with a few lines of code.
    /// Just create a XSockets connection, and then publish messages from your WCF
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RoomService : IRoomService
    {
        private static WebSocket websocket;

        static RoomService()
        {
            //We will connect to the default controller (generic)
            //To learn howto write your own plugins to XSockets look at http://xsockets.net/api/net-c#snippet35
            websocket = new WebSocket("ws://127.0.0.1:4502/Generic","Generic"){ Origin = "http://localhost:1377"};
            websocket.Connect();
        }

        public string JoinRoom(string name)
        {
            //Use XSockets to tell everyone listening that a person entered the room
            //We send an anonymous message here, but any object will work.
            websocket.Send(new { Message = name + " just entered the room" }.AsTextArgs("OnUserJoined"));

            //Do your WCF regular stuff whatever it might be... and then return
            return string.Format("Hello and welcome " + name);
        }
    }

}