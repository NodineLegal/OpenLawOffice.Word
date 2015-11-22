using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Threading.Tasks;
using NLog;
using System.IO;
using System.Windows.Forms;

namespace OpenLawOffice.Word
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            button1.Enabled = false;
            Globals.ThisAddIn.ActiveMatterChanged += ThisAddIn_ActiveMatterChanged;
        }

        void ThisAddIn_ActiveMatterChanged(object oldValue, object newValue)
        {
            if (newValue == null)
            {
                group1.Visible = false;
                ActiveMatterTitle.Label = "";
                FormSelector.Items.Clear();
            }
            else
            {
                Common.Models.Matters.Matter matter = (Common.Models.Matters.Matter)newValue;
                Task task;

                group1.Visible = true;
                ActiveMatterTitle.Label = matter.Title;
                
                task = new Task(() =>
                {
                    Common.Net.Response<List<Common.Models.Forms.Form>> resp;

                    resp = CommManager.ListFormsForMatter(matter.Id.Value);

                    if (Extensions.DynamicPropertyExists(resp.Package, "Error"))
                    {
                        if (Globals.ThisAddIn.CanLog)
                            LogManager.GetCurrentClassLogger().Error("Error: " + resp.Error);
                    }
                    else
                    {
                        resp.Package.ForEach(x =>
                        {
                            RibbonDropDownItem item = Factory.CreateRibbonDropDownItem();
                            item.Label = x.Title;
                            item.Tag = x;
                            FormSelector.Items.Add(item);
                        });
                    }
                });

                task.Start();
            }
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            FormSelectorWindow win = new FormSelectorWindow();
            win.Show();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Security.CloseSession();
            button3.Visible = true;
            button2.Visible = false;
            button1.Enabled = false;
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            LoginDialog win = new LoginDialog();
            if (win.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                button2.Visible = true;
                button3.Visible = false;
                button1.Enabled = true;
            }
        }

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {
            LoggingDialog win = new LoggingDialog();
            win.ShowDialog();
        }

        private void GenerateButton_Click(object sender, RibbonControlEventArgs e)
        {
            FileDownloadClient client = new FileDownloadClient();
            string ext = "";
            Common.Models.Forms.Form model;
            Common.Models.Matters.Matter matter;

            model = (Common.Models.Forms.Form)FormSelector.SelectedItem.Tag;

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

                utils.DownloadFormDataForMatter(Globals.ThisAddIn.ActiveMatter.Id.Value);
            }
        }
    }
}
