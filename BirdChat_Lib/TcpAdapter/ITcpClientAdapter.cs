using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdChat_Client
{
    public interface ITcpClientAdapter
    {
        string ReadAll();
        void Send(string msg);
    }
}
