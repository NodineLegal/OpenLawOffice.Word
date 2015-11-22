using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace OpenLawOffice.Word
{
    public partial class LoggingDialog : Form
    {
        public LoggingDialog()
        {
            InitializeComponent();
            EnableLogging.Checked = Globals.ThisAddIn.Settings.LoggingEnabled;
            LogPath.Text = Globals.ThisAddIn.Settings.LogPath;

            for (int i = 0; i < LogLevel.Items.Count; i++)
            {
                if ((string)LogLevel.Items[i] == Globals.ThisAddIn.Settings.LogLevel.Name)
                    LogLevel.SelectedIndex = i;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Settings.LoggingEnabled = EnableLogging.Checked;
            Globals.ThisAddIn.Settings.LogPath = LogPath.Text.Trim();
            Globals.ThisAddIn.Settings.LogLevel = NLog.LogLevel.FromString(LogLevel.Text);
            Globals.ThisAddIn.Settings.Save();
            Globals.ThisAddIn.ConfigLogging();

            if (Globals.ThisAddIn.CanLog)
                LogManager.GetCurrentClassLogger().Debug("Logging started at " + Globals.ThisAddIn.Settings.LogPath);

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            LogPath.Text = openFileDialog1.FileName;
        }
    }
}
