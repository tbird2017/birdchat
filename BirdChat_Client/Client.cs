using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BirdChat_Lib;
using BirdChat_Client;

namespace BirdChat
{
    public partial class Client : Form
    {
        private ChatClient _cClient;

        /// <summary>
        /// constructor
        /// </summary>
        public Client()
        {
            InitializeComponent();
            tb_Message.Enabled = false;

            _cClient = new ChatClient();
            _cClient.NewTextReceived += new EventHandler<TextEventArgs>(AddToTextBoxEventHandler);
        }

        /// <summary>
        /// send message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            _cClient.SendMessage(tb_Message.Text);
            tb_Message.Clear();
        }

        /// <summary>
        /// connects to given server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            tb_NickName.Enabled = false;
            AddToTextBox("Trying to connect to chatserver ");

            try
            {
                _cClient.Connect(tb_NickName.Text);
                AddToTextBox("Connected to chatserver ...");

                //if connect succeeded, we're ready to write!
                tb_Message.Enabled = true;
            }
            catch (Exception ex)
            {
                tb_NickName.Enabled = true;
                AddToTextBox($"Could not connect to chatserver: {ex.Message}");
                return;
            }
        }

        /// <summary>
        /// Method to add Text to TextBox
        /// </summary>
        /// <param name="msg"></param>
        public void AddToTextBox(string msg)
        {
            //as we're calling the method from inside another thread, we may need to invoke the method first
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddToTextBox), new object[] { msg });
                return;
            }
            lb_ChatProtocol.Items.Add($"{DateTime.Now.ToString("hh:mm:ss")} >> {msg}");
            lb_ChatProtocol.Refresh();
            lb_ChatProtocol.TopIndex = lb_ChatProtocol.Items.Count - 1;
        }

        /// <summary>
        ///  Our new event (Client.AddToTextBoxEventHandler) handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToTextBoxEventHandler(object sender, TextEventArgs e) => AddToTextBox(e.Text);

        /// <summary>
        /// event handler if form has been closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_FormClosed(object sender, FormClosedEventArgs e) => _cClient.SendMessage($"{tb_NickName.Text} {Settings.Default.LeftChatString}");
    }
}