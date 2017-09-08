using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdChat_Server
{
    public interface ITcpServerAdapter
    {
        string ReadAll();
    }
}
