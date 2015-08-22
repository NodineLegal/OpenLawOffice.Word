using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace OpenLawOffice.Word
{
    public partial class LoggingControl : UserControl
    {
        public LoggingControl()
        {
            InitializeComponent();

            EnableLogging.Checked = Globals.ThisAddIn.Settings.LoggingEnabled;
            LogPath.Text = Globals.ThisAddIn.Settings.LogPath;
            LogLevel.SelectedText = Globals.ThisAddIn.Settings.LogLevel.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            LogPath.Text = openFileDialog1.FileName;
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

            Globals.ThisAddIn.TaskWindowManager.Hide("Logging");
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            EnableLogging.Checked = Globals.ThisAddIn.Settings.LoggingEnabled;
            LogPath.Text = Globals.ThisAddIn.Settings.LogPath;
            LogLevel.Text = null;
            LogLevel.SelectedText = Globals.ThisAddIn.Settings.LogLevel.Name;
            Globals.ThisAddIn.TaskWindowManager.Hide("Logging");
        }
    }
}
