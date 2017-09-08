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
    public class ClientHandler
    {
        private string _clientName;
        private Hashtable _clientList;
        private TcpClientAdapter _adapter;

        public void startClient(TcpClient inClientSocket, string clientName, Hashtable clientList)
        {
            _clientName = clientName;
            _clientList = clientList;

            _adapter = new TcpClientAdapter(inClientSocket);

            //client communication should happen in own thread
            new Thread(() => DoChat()).Start();
        }

        private void DoChat()
        {
            while (true)
            {
                try
                {
                    //receive data from client
                    var dataFromClient = _adapter.ReadAll();

                    dataFromClient = dataFromClient.CropUntilMsgEndSign();

                    if (dataFromClient.Contains(Settings.Default.LeftChatString))
                    {
                        ChatServer.GetInstance.DisconnectClient(dataFromClient.CropUntilLeftChatSign());
                        return;
                    }

                    Server.GetInstance.AddToListBox($"Text received from client {_clientName}: {dataFromClient}");

                    //and send to all connected clients
                    new Broadcaster(_clientList).SendMessageBroadCast(dataFromClient, _clientName);
                }
                catch (Exception ex)
                {
                    Server.GetInstance.AddToListBox(ex.ToString());
                    break;
                }
            }
        }
    }
}
