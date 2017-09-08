using BirdChat;
using BirdChat_Lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BirdChat_Server
{
    public class ChatServer
    {
        private TcpListener _serverSocket;
        private bool _running;

        private static ChatServer _Instance;
        private static Hashtable _ClientsList = new Hashtable();

        private TcpServerAdapter _adapter;

        /// <summary>
        /// singleton => instance
        /// </summary>
        public static ChatServer GetInstance
        {
            get
            {
                if (_Instance == null) _Instance = new ChatServer();
                return _Instance;
            }
        }

        /// <summary>
        /// list of all currently connected clients
        /// </summary>
        public Hashtable ClientsList { get => _ClientsList; set => _ClientsList = value; }

        /// <summary>
        /// ends server and closes all communication
        /// </summary>
        public void End()
        {
            _running = false;
            _adapter.CloseClientSocket();
            _serverSocket.Stop();
        }

        /// <summary>
        /// starts server
        /// </summary>
        public void Start()
        {
            //singleton lock: if server's already running, we're done here. 
            if (_running) return;

            Server.GetInstance.AddToListBox("Starting Chat Server ...");

            _running = true;

            //create socket to which the clients can connect
            _serverSocket = new TcpListener(IPAddress.Parse(Settings.Default.ServerIP), Settings.Default.ServerPort);
            _serverSocket.Start();
            Server.GetInstance.AddToListBox("Chat Server Started ....");

            _adapter = new TcpServerAdapter(_serverSocket);

            //create server thread not to block UI
            new Thread(() =>
            {
                while ((_running))
                {
                    try
                    {
                        var clientName = _adapter.ReadAll();

                        //search for end string and crop everything after that
                        clientName = clientName.CropUntilMsgEndSign();

                        //handle multiple connects with same nick name
                        while (ClientsList.Contains(clientName)) clientName += "_";

                        Server.GetInstance.AddToListBox(clientName + " Joined chat room ");
                        ClientsList.Add(clientName, _adapter.ClientSocket);

                        //inform everyone that cName has joined the chat room
                        new Broadcaster(ClientsList).SendSysInfoBroadCast(clientName + " Joined ", clientName);

                        //start client communication
                        new ClientHandler().startClient(_adapter.ClientSocket, clientName, ClientsList);
                    }
                    catch (Exception e)
                    {
                        //listener closed
                    }
                }
            }).Start();
        }

        public void DisconnectClient(string clientName)
        {
            clientName = clientName.Trim();
            Server.GetInstance.AddToListBox(clientName + " Left the chat room ");

            ClientsList.Remove(clientName);

            //inform everyone that cName has joined the chat room
            new Broadcaster(ClientsList).SendSysInfoBroadCast(clientName + " Left ", clientName);
        }
    }
}
