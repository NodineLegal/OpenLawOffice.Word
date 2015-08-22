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
using System.IO;

namespace OpenLawOffice.Word
{
    public partial class FormSelectorControl : UserControl
    {
        private OpenLawOffice.Common.Models.Matters.Matter _matter;

        public FormSelectorControl()
        {
            InitializeComponent();
        }

        private void HideUIControls()
        {
            button1.Visible = button2.Visible = Results.Visible = false;
        }

        private void ShowUIControls()
        {
            button1.Visible = button2.Visible = Results.Visible = true;
        }
       
        public void LoadAvailableForms(OpenLawOffice.Common.Models.Matters.Matter matter)
        {
            Task task;

            _matter = matter;
            HideUIControls();
            LoadingPanel.Show();

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

        private void button1_Click(object sender, EventArgs e)
        {
            FileDownloadClient client = new FileDownloadClient();
            string ext = "";
            Common.Models.Forms.Form model;

            model = (Common.Models.Forms.Form)Results.SelectedItem;
            
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

                utils.DownloadFormDataForMatter(_matter.Id.Value);

                Results.DataSource = null;
                Results.Items.Clear();
                Globals.ThisAddIn.TaskWindowManager.Hide("Select Form");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Results.DataSource = null;
            Results.Items.Clear();
            Globals.ThisAddIn.TaskWindowManager.Hide("Select Form");
        }
    }
}
