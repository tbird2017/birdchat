using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.Net;
using BirdChat_Lib;
using BirdChat_Server;

namespace BirdChat
{
    public partial class Server : Form
    {
        private static Server _Instance;
        private static ChatServer _CServer;

        /// <summary>
        /// singleton to avoid multiple servers
        /// </summary>
        public static Server GetInstance
        {
            get
            {
                if (_Instance == null || _Instance.IsDisposed)
                {
                    _Instance = new Server();
                    _CServer = ChatServer.GetInstance;
                    _CServer.Start();

                }
                return _Instance;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public Server() => InitializeComponent();

        /// <summary>
        /// Method to add Text to ListBox
        /// </summary>
        /// <param name="msg"></param>
        public void AddToListBox(string msg)
        {
            //as we're calling the method from inside another thread, we may need to invoke the method first
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new Action<string>(AddToListBox), new object[] { msg });
                }
                catch
                {
                    //maybe server already disposed => ignore event
                    return;
                }
                return;
            }

            lb_ServerProtocol.Items.Add($"{DateTime.Now.ToString("hh:mm:ss.fff")} - {msg}");
            lb_ServerProtocol.Refresh();
            lb_ServerProtocol.TopIndex = lb_ServerProtocol.Items.Count - 1;
        }

        /// <summary>
        /// Event risen if Form is Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_FormClosed(object sender, FormClosedEventArgs e) => _CServer.End();
    }
}
