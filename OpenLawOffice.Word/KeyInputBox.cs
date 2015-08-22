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
    public partial class KeyInputBox : Form
    {
        public string EncryptionKey
        {
            get { return Key.Text; }
            set { Key.Text = value; }
        }

        public KeyInputBox()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Settings.Key = Key.Text;
            Globals.ThisAddIn.Settings.Save();
            Close();
        }
    }
}
