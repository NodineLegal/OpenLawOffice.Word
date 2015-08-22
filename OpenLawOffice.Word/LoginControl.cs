using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLawOffice.Word
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void HideUIControls()
        {
            label4.Visible = Server.Visible = //RememberServer.Visible = RememberUsername.Visible =
            Username.Visible = label1.Visible = Password.Visible = label2.Visible =
            Cancel.Visible = Login.Visible = ErrorMessage.Visible = linkLabel1.Visible = false;
        }

        private void ShowUIControls()
        {
            label4.Visible = Server.Visible = //RememberServer.Visible = RememberUsername.Visible =
            Username.Visible = label1.Visible = Password.Visible = label2.Visible =
            Cancel.Visible = Login.Visible = ErrorMessage.Visible = linkLabel1.Visible = true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Password.Clear();
            Globals.ThisAddIn.TaskWindowManager.Hide("Login");
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

            HideUIControls();
            LoadingPanel.Show();

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
                        LoadingPanel.Hide();
                        ShowUIControls();
                    }));
                }
                else
                {
                    ErrorMessage.Invoke(new MethodInvoker(delegate
                    {
                        ErrorMessage.Text = "";
                        Globals.Ribbons.Ribbon.toggleButton1.Visible = false;
                        Globals.Ribbons.Ribbon.box1.Visible = true;
                        Globals.Ribbons.Ribbon.button2.Visible = true;
                        Globals.Ribbons.Ribbon.User.Label = Username.Text.Trim();
                        LoadingPanel.Hide();
                        ShowUIControls();
                        Globals.ThisAddIn.TaskWindowManager.Hide("Login");
                    }));
                }
            });

            task.Start();
        }

        private void LoginControl_Load(object sender, EventArgs e)
        {
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        public void LoadSettings()
        {
            Server.Text = Globals.ThisAddIn.Settings.ServerUrl;
            Username.Text = Globals.ThisAddIn.Settings.Username;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KeyInputBox input = new KeyInputBox();
            input.ShowDialog();
        }

        private void LoginControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Login_Click(null, null);
        }
    }
}
