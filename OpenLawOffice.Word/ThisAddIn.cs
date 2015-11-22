using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using NLog.Config;
using NLog.Targets;
using NLog;

namespace OpenLawOffice.Word
{
    public partial class ThisAddIn
    {
        private AddInUtilities _utilities;
        private Common.Models.Matters.Matter _activeMatter;

        public Security Security { get; set; }
        public Settings Settings { get; set; }
        public Common.Models.Matters.Matter ActiveMatter 
        {
            get { return _activeMatter; }
            set
            {
                Common.Models.Matters.Matter old = _activeMatter;
                _activeMatter = value;
                ActiveMatterChanged(old, _activeMatter);
            }
        }

        public delegate void PropertyChangedDelegate(object oldValue, object newValue);
        public event PropertyChangedDelegate ActiveMatterChanged;

        public bool CanLog
        {
            get
            {
                if (Settings.LoggingEnabled) return true;
                return false;
            }
        }
        
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Settings = new Word.Settings();
            this.Security = new Security();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Settings.Save();
        }

        protected override object RequestComAddInAutomationService()
        {
            if (_utilities == null)
                _utilities = new AddInUtilities();

            return _utilities;
        }

        public void ConfigLogging()
        {
            LoggingConfiguration config = new LoggingConfiguration();

            FileTarget target = new FileTarget();
            config.AddTarget("file", target);

            target.Layout = @"${date:format=yyyy-MM-dd H\:mm\:ss} ${logger} ${message}";
            target.FileName = Globals.ThisAddIn.Settings.LogPath;

            LoggingRule rule = new LoggingRule("*", Globals.ThisAddIn.Settings.LogLevel, target);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
        }


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
