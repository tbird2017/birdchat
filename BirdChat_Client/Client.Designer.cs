using System;
using System.Windows.Forms;

namespace BirdChat
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_NickName = new System.Windows.Forms.TextBox();
            this.lbl_NickName = new System.Windows.Forms.Label();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.lb_ChatProtocol = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tb_NickName
            // 
            this.tb_NickName.Location = new System.Drawing.Point(105, 27);
            this.tb_NickName.Name = "tb_NickName";
            this.tb_NickName.Size = new System.Drawing.Size(268, 20);
            this.tb_NickName.TabIndex = 0;
            // 
            // lbl_NickName
            // 
            this.lbl_NickName.AutoSize = true;
            this.lbl_NickName.Location = new System.Drawing.Point(28, 30);
            this.lbl_NickName.Name = "lbl_NickName";
            this.lbl_NickName.Size = new System.Drawing.Size(57, 13);
            this.lbl_NickName.TabIndex = 1;
            this.lbl_NickName.Text = "NickName";
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Location = new System.Drawing.Point(31, 372);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(50, 13);
            this.lbl_Message.TabIndex = 4;
            this.lbl_Message.Text = "Message";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(445, 27);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(611, 388);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 6;
            this.btn_Send.Text = "send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tb_Message
            // 
            this.tb_Message.Location = new System.Drawing.Point(34, 390);
            this.tb_Message.Name = "tb_Message";
            this.tb_Message.Size = new System.Drawing.Size(571, 20);
            this.tb_Message.TabIndex = 7;
            // 
            // lb_ChatProtocol
            // 
            this.lb_ChatProtocol.FormattingEnabled = true;
            this.lb_ChatProtocol.Location = new System.Drawing.Point(31, 64);
            this.lb_ChatProtocol.MaximumSize = new System.Drawing.Size(655, 303);
            this.lb_ChatProtocol.MinimumSize = new System.Drawing.Size(655, 303);
            this.lb_ChatProtocol.Name = "lb_ChatProtocol";
            this.lb_ChatProtocol.Size = new System.Drawing.Size(655, 303);
            this.lb_ChatProtocol.TabIndex = 8;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 457);
            this.Controls.Add(this.lb_ChatProtocol);
            this.Controls.Add(this.tb_Message);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.lbl_NickName);
            this.Controls.Add(this.tb_NickName);
            this.Name = "Client";
            this.Text = "BirdChat Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_NickName;
        private System.Windows.Forms.Label lbl_NickName;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox tb_Message;
        private System.Windows.Forms.ListBox lb_ChatProtocol;
    }
}