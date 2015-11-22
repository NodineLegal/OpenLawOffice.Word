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
using System.IO;

namespace OpenLawOffice.Word
{
    public partial class FormSelectorWindow : Form
    {
        public FormSelectorWindow()
        {
            InitializeComponent();
        }

        private void Contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Search_Click(sender, e);
        }

        private void Title_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Search_Click(sender, e);
        }

        private void CaseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Search_Click(sender, e);
        }

        private void Jurisdiction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Search_Click(sender, e);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Contact.Text = Title.Text = CaseNumber.Text = Jurisdiction.Text = "";
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Task task;

            DisableMatterSearchInput();
            DisableForms();
            DisableMatterSearchInput();

            MatterResults.Enabled = false;

            ProgressBarMatter.Show();

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
                    MatterResults.Invoke(new MethodInvoker(delegate
                    {
                        MatterResults.SelectedIndexChanged -= MatterResults_SelectedIndexChanged;
                        MatterResults.DataSource = resp.Package;
                        MatterResults.DisplayMember = "Title";
                        MatterResults.ValueMember = "Id";
                        MatterResults.SelectedIndex = -1;
                        MatterResults.SelectedIndexChanged += MatterResults_SelectedIndexChanged;

                        ProgressBarMatter.Hide();
                        MatterResults.Enabled = true;

                        EnableMatterSearchInput();
                        DisableForms();
                    }));
                }
            });

            task.Start();
        }

        private void DisableMatterSearchInput()
        {
            Contact.Enabled = Title.Enabled = CaseNumber.Enabled = Jurisdiction.Enabled = false;
        }

        private void EnableMatterSearchInput()
        {
            Contact.Enabled = Title.Enabled = CaseNumber.Enabled = Jurisdiction.Enabled = true;
        }

        private void DisableForms()
        {
            FormResults.DataSource = null;
            FormResults.Enabled = false;
            Select.Enabled = false;
        }

        private void FormResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = FormResults.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Select_Click(sender, e);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            FileDownloadClient client = new FileDownloadClient();
            string ext = "";
            Common.Models.Forms.Form model;
            Common.Models.Matters.Matter matter;

            model = (Common.Models.Forms.Form)FormResults.SelectedItem;
            matter = (Common.Models.Matters.Matter)MatterResults.SelectedItem;

            if (Path.HasExtension(model.Path))
                ext = Path.GetExtension(model.Path);

            // Save To
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = DateTime.Now.ToString("yyyy-MM-dd") + " " + model.Title + ext;
            dialog.Filter = "Word (*.docx,*.doc)|*.docx;*.doc|All files (*.*)|*.*";
            dialog.OverwritePrompt = true;
            DialogResult dr = dialog.ShowDialog();

            // Download
            if (dr == DialogResult.OK)
            {
                FileDownloadClient.DownloadFile(Globals.ThisAddIn.Settings.ServerUrl +
                    "JsonInterface/DownloadForm/" + model.Id.Value, dialog.OpenFile());

                // Open
                Microsoft.Office.Interop.Word.Document doc = Globals.ThisAddIn.Application.Documents.Open(dialog.FileName);


                // Fill
                Microsoft.Office.Core.COMAddIn addin = doc.Application.COMAddIns.Item(@"OpenLawOffice.Word");

                IAddInUtilities utils = (IAddInUtilities)addin.Object;

                utils.DownloadFormDataForMatter(matter.Id.Value);
            }
        }

        private void MatterResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.Models.Matters.Matter matter = (Common.Models.Matters.Matter)MatterResults.SelectedItem;
            Task task;

            ProgressBarForm.Show();

            Globals.ThisAddIn.ActiveMatter = matter;

            task = new Task(() =>
            {
                Common.Net.Response<List<Common.Models.Forms.Form>> resp;

                resp = CommManager.ListFormsForMatter(matter.Id.Value);

                if (Extensions.DynamicPropertyExists(resp.Package, "Error"))
                {
                    if (Globals.ThisAddIn.CanLog)
                        LogManager.GetCurrentClassLogger().Error("Error: " + resp.Error);
                    MessageBox.Show("Error: " + resp.Error, "Error");
                }
                else
                {
                    FormResults.Invoke(new MethodInvoker(delegate
                    {
                        FormResults.DataSource = resp.Package;
                        FormResults.DisplayMember = "Title";
                        FormResults.ValueMember = "Id";

                        ProgressBarForm.Hide();
                        FormResults.Enabled = true;
                        Select.Enabled = true;
                    }));
                }
            });

            task.Start();
        }

        private void Contact_TextChanged(object sender, EventArgs e)
        {
            DisableForms();
            MatterResults.SelectedIndexChanged -= MatterResults_SelectedIndexChanged;
            MatterResults.DataSource = null;
            MatterResults.SelectedIndexChanged += MatterResults_SelectedIndexChanged;
        }

        private void Title_TextChanged(object sender, EventArgs e)
        {
            DisableForms();
            MatterResults.SelectedIndexChanged -= MatterResults_SelectedIndexChanged;
            MatterResults.DataSource = null;
            MatterResults.SelectedIndexChanged += MatterResults_SelectedIndexChanged;
        }

        private void CaseNumber_TextChanged(object sender, EventArgs e)
        {
            DisableForms();
            MatterResults.SelectedIndexChanged -= MatterResults_SelectedIndexChanged;
            MatterResults.DataSource = null;
            MatterResults.SelectedIndexChanged += MatterResults_SelectedIndexChanged;
        }

        private void Jurisdiction_TextChanged(object sender, EventArgs e)
        {
            DisableForms();
            MatterResults.SelectedIndexChanged -= MatterResults_SelectedIndexChanged;
            MatterResults.DataSource = null;
            MatterResults.SelectedIndexChanged += MatterResults_SelectedIndexChanged;
        }

        private void FormSelectorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
