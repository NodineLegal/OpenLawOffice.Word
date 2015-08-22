namespace OpenLawOffice.Word
{
    partial class LoginControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.Server = new System.Windows.Forms.TextBox();
            this.RememberServer = new System.Windows.Forms.CheckBox();
            this.RememberUsername = new System.Windows.Forms.CheckBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.LoadingPanel = new OpenLawOffice.Word.LoadingPanelControl();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Server";
            // 
            // Server
            // 
            this.Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server.Location = new System.Drawing.Point(7, 67);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(315, 26);
            this.Server.TabIndex = 14;
            this.Server.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginControl_KeyPress);
            // 
            // RememberServer
            // 
            this.RememberServer.AutoSize = true;
            this.RememberServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RememberServer.Location = new System.Drawing.Point(7, 99);
            this.RememberServer.Name = "RememberServer";
            this.RememberServer.Size = new System.Drawing.Size(95, 20);
            this.RememberServer.TabIndex = 15;
            this.RememberServer.Text = "Remember";
            this.RememberServer.UseVisualStyleBackColor = true;
            this.RememberServer.Visible = false;
            // 
            // RememberUsername
            // 
            this.RememberUsername.AutoSize = true;
            this.RememberUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RememberUsername.Location = new System.Drawing.Point(7, 195);
            this.RememberUsername.Name = "RememberUsername";
            this.RememberUsername.Size = new System.Drawing.Size(95, 20);
            this.RememberUsername.TabIndex = 17;
            this.RememberUsername.Text = "Remember";
            this.RememberUsername.UseVisualStyleBackColor = true;
            this.RememberUsername.Visible = false;
            // 
            // Username
            // 
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(7, 163);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(315, 26);
            this.Username.TabIndex = 18;
            this.Username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginControl_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Username";
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(7, 258);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(315, 26);
            this.Password.TabIndex = 20;
            this.Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginControl_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Password";
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(7, 449);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(315, 29);
            this.Cancel.TabIndex = 22;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Image = global::OpenLawOffice.Word.Properties.Resources.arrow;
            this.Login.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Login.Location = new System.Drawing.Point(7, 414);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(315, 29);
            this.Login.TabIndex = 21;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ErrorMessage.Location = new System.Drawing.Point(6, 331);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(319, 80);
            this.ErrorMessage.TabIndex = 23;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(3, 297);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(174, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Change Encryption Key";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LoadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadingPanel.Location = new System.Drawing.Point(0, 0);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(325, 507);
            this.LoadingPanel.TabIndex = 24;
            this.LoadingPanel.Visible = false;
            // 
            // LoginControl
            // 
            this.Controls.Add(this.LoadingPanel);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RememberUsername);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RememberServer);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(325, 507);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginControl_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.TextBox Username;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.TextBox Password;
        //private System.Windows.Forms.Button Login;
        //private System.Windows.Forms.TextBox Server;
        //private System.Windows.Forms.Label label3;
        //private System.Windows.Forms.CheckBox RememberUsername;
        //private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Server;
        private System.Windows.Forms.CheckBox RememberServer;
        private System.Windows.Forms.CheckBox RememberUsername;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Label ErrorMessage;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private LoadingPanelControl LoadingPanel;
    }
}
