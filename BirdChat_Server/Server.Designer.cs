namespace BirdChat
{
    partial class Server
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
            this.lb_ServerProtocol = new System.Windows.Forms.ListBox();
            this.lbl_ServerProtocol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_ServerProtocol
            // 
            this.lb_ServerProtocol.FormattingEnabled = true;
            this.lb_ServerProtocol.Location = new System.Drawing.Point(22, 44);
            this.lb_ServerProtocol.Name = "lb_ServerProtocol";
            this.lb_ServerProtocol.Size = new System.Drawing.Size(417, 173);
            this.lb_ServerProtocol.TabIndex = 0;
            // 
            // lbl_ServerProtocol
            // 
            this.lbl_ServerProtocol.AutoSize = true;
            this.lbl_ServerProtocol.Location = new System.Drawing.Point(22, 25);
            this.lbl_ServerProtocol.Name = "lbl_ServerProtocol";
            this.lbl_ServerProtocol.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_ServerProtocol.Size = new System.Drawing.Size(80, 13);
            this.lbl_ServerProtocol.TabIndex = 1;
            this.lbl_ServerProtocol.Text = "Server Protocol";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 237);
            this.Controls.Add(this.lbl_ServerProtocol);
            this.Controls.Add(this.lb_ServerProtocol);
            this.MaximumSize = new System.Drawing.Size(483, 276);
            this.MinimumSize = new System.Drawing.Size(483, 276);
            this.Name = "Server";
            this.Text = "BirdChat Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_ServerProtocol;
        private System.Windows.Forms.Label lbl_ServerProtocol;
    }
}