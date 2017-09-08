using System;
using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using BirdChat_Lib;
using BirdChat_Server;
using BirdChat_Client;

namespace BirdChat
{
    public class Broadcaster
    {
        private Hashtable _clientsList;

        /// <summary>
        /// class to hold informations to all clients
        /// </summary>
        /// <param name="cList">List of clients</param>
        public Broadcaster(Hashtable cList) => _clientsList = cList;

        public void SendMessageBroadCast(string msg, string uName)
        {
            SendBroadCast(msg, uName, MessageType.Message);
        }

        public void SendSysInfoBroadCast(string msg, string uName)
        {
            SendBroadCast(msg, uName, MessageType.SystemInformation);
        }

        /// <summary>
        /// sends message to all connected clients
        /// </summary>
        /// <param name="msg">text to send</param>
        /// <param name="uName">sender that sends message</param>
        /// <param name="type">determines if message is text or something from system</param>
        private void SendBroadCast(string msg, string uName, MessageType type)
        {
            if (_clientsList.Count == 0)
            {
                Server.GetInstance.AddToListBox($"No clients connected anymore. Not sending anything to anyone.");
                return;
            }

            //Inform server to show broadcast message
            Server.GetInstance.AddToListBox($"Sending message of type \"{type.ToString()}\" to {_clientsList.Count} clients");

            //loop through all connected clients and send the msg from uName to them
            foreach (DictionaryEntry Item in _clientsList)
            {
                //check if its a message (add "says") or just an information from chat system (joined / left ...)
                var message = type == MessageType.Message ? $"{uName} says: {msg}" : $"{msg}";

                new TcpClientAdapter((TcpClient)Item.Value).Send(message);
            }
        }
    }
}
