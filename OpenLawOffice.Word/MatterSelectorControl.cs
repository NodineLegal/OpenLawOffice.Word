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
    public partial class MatterSelectorControl : UserControl
    {
        public MatterSelectorControl()
        {
            InitializeComponent();
        }

        private void HideUIControls()
        {
            Cancel.Visible = Next.Visible = groupBox1.Visible = groupBox2.Visible = false;
        }

        private void ShowUIControls()
        {
            Cancel.Visible = Next.Visible = groupBox1.Visible = groupBox2.Visible = true;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Task task;

            HideUIControls();
            LoadingPanel.Show();

            task = new Task(() =>
            {
                Common.Net.Response<List<OpenLawOffice.Common.Models.Matters.Matter>> resp;

                resp = CommManager.ListMatters(Contact.Text.Trim(), Title.Text.Trim(),
                    CaseNumber.Text.Trim(), Jurisdiction.Text.Trim(), true);

                if (Extensions.DynamicPropertyExists(resp.Package, "Error"))
                {
                    if (Globals.ThisAddIn.CanLog)
                        LogManager.GetCurrentClassLogger().Error("Error: " + resp.Error);
                    MessageBox.Show("Error: " + resp.Error, "Error");
                }
                else
                {
                    Results.Invoke(new MethodInvoker(delegate
                    {
                        Results.DataSource = resp.Package;
                        Results.DisplayMember = "Title";
                        Results.ValueMember = "Id";
                        LoadingPanel.Hide();
                        ShowUIControls();
                    }));
                }
            });

            task.Start();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Contact.Text = Title.Text = CaseNumber.Text = Jurisdiction.Text = "";
            Results.Items.Clear();
            Globals.ThisAddIn.TaskWindowManager.Hide("Select Matter");
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.TaskWindowManager.MatterSelectorTaskPane.Visible = false;
            Globals.ThisAddIn.TaskWindowManager.FormSelectorTaskPane.Visible = true;

            ((FormSelectorControl)Globals.ThisAddIn.TaskWindowManager.FormSelectorTaskPane.Control)
                .LoadAvailableForms((OpenLawOffice.Common.Models.Matters.Matter)Results.SelectedItem);
        }

        private void Results_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Results.SelectedItem != null)
                Next.Enabled = true;
            else
                Next.Enabled = false;
        }
    }
}
