using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLawOffice.Word
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
            LoadSettings();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;

            Password.Select();

            if (Username.Text.Length == 0)
                Username.Select();

            if (Server.Text.Length == 0)
                Server.Select();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KeyInputBox input = new KeyInputBox();
            input.ShowDialog();
        }

        private void Login_Click(object sender, EventArgs e)
        {

            Task task;

            // Key?
            if (string.IsNullOrEmpty(Globals.ThisAddIn.Settings.Key))
            {
                KeyInputBox input = new KeyInputBox();
                input.ShowDialog();
            }

            progressBar1.Show();
            Server.Enabled = Username.Enabled = Password.Enabled = RememberServer.Enabled = RememberUsername.Enabled = false;
            linkLabel1.Enabled = false;

            Globals.ThisAddIn.Settings.ServerUrl = Server.Text.Trim();
            Globals.ThisAddIn.Settings.Username = Username.Text.Trim();
            Globals.ThisAddIn.Settings.Save();

            task = new Task(() =>
            {
                Common.Net.Response<dynamic> resp;

                resp = Globals.ThisAddIn.Security.Authenticate(Password.Text.Trim());

                if (Extensions.DynamicPropertyExists(resp.Package, "Error"))
                {
                    ErrorMessage.Invoke(new MethodInvoker(delegate
                    {
                        ErrorMessage.Text = resp.Package.Error;
                        progressBar1.Hide();
                        Server.Enabled = Username.Enabled = Password.Enabled = RememberServer.Enabled = RememberUsername.Enabled = true;
                        linkLabel1.Enabled = true;
                    }));
                }
                else
                {
                    ErrorMessage.Invoke(new MethodInvoker(delegate
                    {
                        ErrorMessage.Text = "";

                        progressBar1.Hide();
                        Server.Enabled = Username.Enabled = Password.Enabled = RememberServer.Enabled = RememberUsername.Enabled = true;
                        linkLabel1.Enabled = true;

                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }));
                }
            });

            task.Start();
        }

        private void LoginDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Login_Click(null, null);
        }

        public void LoadSettings()
        {
            Server.Text = Globals.ThisAddIn.Settings.ServerUrl;
            Username.Text = Globals.ThisAddIn.Settings.Username;
        }

        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Login_Click(null, null);
        }
    }
}
