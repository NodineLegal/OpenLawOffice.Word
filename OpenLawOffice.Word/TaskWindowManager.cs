using Microsoft.Office.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLawOffice.Word
{
    public class TaskWindowManager
    {
        private const int windowWidth = 350;

        private CustomTaskPaneCollection customTaskPanes;
        private LoginControl loginControl;
        private LoggingControl loggingControl;
        private MatterSelectorControl matterSelectorControl;
        private FormSelectorControl formSelectorControl;
        private CustomTaskPane loginTaskPane;
        private CustomTaskPane loggingTaskPane;
        private CustomTaskPane matterSelectorTaskPane;
        private CustomTaskPane formSelectorTaskPane;

        public TaskWindowManager(CustomTaskPaneCollection customTaskPanes)
        {
            loginControl = new LoginControl();
            loggingControl = new LoggingControl();
            matterSelectorControl = new MatterSelectorControl();
            formSelectorControl = new FormSelectorControl();

            loginTaskPane = customTaskPanes.Add(loginControl, "Login");
            loggingTaskPane = customTaskPanes.Add(loggingControl, "Logging");
            matterSelectorTaskPane = customTaskPanes.Add(matterSelectorControl, "Select Matter");
            formSelectorTaskPane = customTaskPanes.Add(formSelectorControl, "Select Form");
            this.customTaskPanes = customTaskPanes;

            loginTaskPane.Width = loggingTaskPane.Width = matterSelectorTaskPane.Width = 
                formSelectorTaskPane.Width = windowWidth;

            loginTaskPane.VisibleChanged += loginTaskPane_VisibleChanged;
            loggingTaskPane.VisibleChanged += loggingTaskPane_VisibleChanged;
            matterSelectorTaskPane.VisibleChanged += matterSelectorPane_VisibleChanged;
            formSelectorTaskPane.VisibleChanged += formSelectorTaskPane_VisibleChanged;
        }

        void formSelectorTaskPane_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons.Ribbon.button1.Enabled =
                !(matterSelectorTaskPane.Visible || formSelectorTaskPane.Visible);
        }

        void matterSelectorPane_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons.Ribbon.button1.Enabled = 
                !(matterSelectorTaskPane.Visible || formSelectorTaskPane.Visible);
        }

        void loggingTaskPane_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons.Ribbon.toggleButton2.Checked = loggingTaskPane.Visible;            
        }

        void loginTaskPane_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons.Ribbon.toggleButton1.Checked = loginTaskPane.Visible;
            loginControl.LoadSettings();
        }

        public void Show(string title)
        {
            CustomTaskPane pane = customTaskPanes.Single(x => x.Title == title);
            pane.Visible = true;
        }

        public void Hide(string title)
        {
            CustomTaskPane pane = customTaskPanes.Single(x => x.Title == title);
            pane.Visible = false;
        }

        public void HideAll()
        {
            IEnumerator<CustomTaskPane> e = customTaskPanes.GetEnumerator();
            while (e.MoveNext())
                e.Current.Visible = false;
        }

        public Microsoft.Office.Tools.CustomTaskPane LoginTaskPane
        {
            get { return loginTaskPane; }
        }

        public Microsoft.Office.Tools.CustomTaskPane LoggingTaskPane
        {
            get { return loggingTaskPane; }
        }

        public Microsoft.Office.Tools.CustomTaskPane MatterSelectorTaskPane
        {
            get { return matterSelectorTaskPane; }
        }

        public Microsoft.Office.Tools.CustomTaskPane FormSelectorTaskPane
        {
            get { return formSelectorTaskPane; }
        }
    }
}
