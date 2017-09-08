using BirdChat_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BirdChat_Client
{
    public class TcpClientAdapter : ITcpClientAdapter
    {
        private TcpClient _clientSocket;
        private NetworkStream _serverStream;

        public TcpClientAdapter() { }

        public TcpClientAdapter(TcpClient clientSocket)
        {
            _clientSocket = clientSocket;
            _serverStream = _clientSocket.GetStream();
        }

        public virtual string ReadAll()
        {
            int buffSize = _clientSocket.ReceiveBufferSize;
            byte[] inStream = new byte[buffSize];

            _serverStream = _clientSocket.GetStream();
            _serverStream.Read(inStream, 0, buffSize);

            return Encoding.ASCII.GetString(inStream);
        }

        public virtual void Send(string msg)
        {
            //add a defined end string so that we can identify the end of the stream when receiving in the server
            byte[] outStream = Encoding.ASCII.GetBytes(msg + Settings.Default.MsgEndString);
            _serverStream.Write(outStream, 0, outStream.Length);
            _serverStream.Flush();
        }
    }
}
