using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BirdChat_Server
{
    public class TcpServerAdapter : ITcpServerAdapter
    {
        private TcpClient _clientSocket;
        private TcpListener _serverSocket;
        
        public TcpServerAdapter(TcpListener serverSocket)
        {
            _serverSocket = serverSocket;
        }

        public string ReadAll()
        {
            //remember client socket to receive and send data
            _clientSocket = _serverSocket.AcceptTcpClient();

            int buffSize = _clientSocket.ReceiveBufferSize;

            //receiving buffer
            byte[] bytesFrom = new byte[buffSize];

            //receive name that clients sends during connect
            _clientSocket.GetStream().Read(bytesFrom, 0, buffSize);

            return Encoding.ASCII.GetString(bytesFrom);
        }

        public TcpClient ClientSocket => _clientSocket;

        public void CloseClientSocket()
        {
            _clientSocket?.Close();
        }
    }
}
