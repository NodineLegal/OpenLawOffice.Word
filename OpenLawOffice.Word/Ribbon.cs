using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace OpenLawOffice.Word
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.TaskWindowManager.LoginTaskPane.Visible = ((RibbonToggleButton)sender).Checked;
        }

        private void toggleButton2_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.TaskWindowManager.LoggingTaskPane.Visible = ((RibbonToggleButton)sender).Checked;
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.TaskWindowManager.MatterSelectorTaskPane.Visible = true;
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Security.CloseSession();
            User.Label = null;
            toggleButton1.Visible = true;
            box1.Visible = false;
            button2.Visible = false;
        }
    }
}
