using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using XSockets.Core.Common.Socket;
using XSockets.Core.Common.Socket.Event.Interface;
using XSockets.External;

namespace XSocketsWCF.Helpers
{
    /// <summary>
    /// A queue consumer sending messages to XSockets whenever there are messages in the queue
    /// </summary>
    public static class XSocketsQueue
    {
        public static BlockingCollection<ITextArgs> textQueue;

        private static IXWebSocket websocket;

        private static object Locker = new object();

        static XSocketsQueue()
        {
            websocket = new XWebSocket("ws://127.0.0.1:4502/Zoo", "http://mysite.com");

            textQueue = new BlockingCollection<ITextArgs>();

            websocket.OnOpen += websocket_OnOpen;
        }

        public static void QueueMessage(ITextArgs textArgs)
        {
            //Lock just in case...
            lock (Locker)
            {
                textQueue.Add(textArgs);
            }
        }

        static void websocket_OnOpen(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                //Will send messages to the XSockets server as soon as there is messages in the queue.
                foreach (var v in textQueue.GetConsumingEnumerable())
                {
                    ((IXWebSocket)sender).Send(v);
                }
            });
        }
    }
}