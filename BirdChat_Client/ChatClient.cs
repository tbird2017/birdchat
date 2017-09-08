using BirdChat_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BirdChat;

namespace BirdChat_Client
{
    public class ChatClient
    {
        private ITcpClientAdapter _adapter;
        
        public event EventHandler<TextEventArgs> NewTextReceived;
                
        public ITcpClientAdapter Adapter { get => _adapter; set => _adapter = value; }

        public void Connect(string nickName)
        {
            //create a socket ..
            var clientSocket = new TcpClient();

            //..connet to it ..
            clientSocket.Connect(Settings.Default.ServerIP, Settings.Default.ServerPort);

            //..and instanciate the adapter that covers all the sending and receiving stuff
            Adapter = new TcpClientAdapter(clientSocket);
            
            Adapter.Send(nickName);

            //reveice new messages has to happen in own thread not to block anything.
            new Thread(() => GetMessage()).Start();
        }


        /// <summary>
        /// Retrieves the message from the server and displays it to the textbox
        /// </summary>
        public void GetMessage(bool loop = true)
        {
            while (true)
            {
                var returndata = Adapter.ReadAll();

                //if we're not receiving anything important ... just move on
                if (!returndata.Contains(Settings.Default.MsgEndString)) return;

                //search for end string and crop everything after that
                returndata = returndata.CropUntilMsgEndSign();

                OnTextReceived(new TextEventArgs(returndata));

                //for testing...
                if (!loop) break;
            }
        }

        // Standard event raising pattern.
        public virtual void OnTextReceived(TextEventArgs e)
        {
            // Invoke the Event.
            // If there are no subscribers, NewTextReceived will be null so we need to check
            // to avoid a NullReferenceException.
            NewTextReceived?.Invoke(this, e);
        }

        public void SendMessage(string msg)
        {
            Adapter.Send(msg);
        }
    }
}
