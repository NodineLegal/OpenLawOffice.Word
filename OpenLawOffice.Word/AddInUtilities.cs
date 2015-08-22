using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;
using NLog;

namespace OpenLawOffice.Word
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class AddInUtilities : IAddInUtilities
    {
        public void DownloadFormDataForMatter(Guid id)
        {
            Task task;
            
            task = new Task(() =>
            {
                Common.Net.Response<List<Common.Models.Forms.FormFieldMatter>> resp;

                resp = CommManager.GetFormDataForMatter(id);

                if (Extensions.DynamicPropertyExists(resp.Package, "Error"))
                {
                    if (Globals.ThisAddIn.CanLog)
                        LogManager.GetCurrentClassLogger().Error("Error: " + resp.Error);
                    MessageBox.Show("Error: " + resp.Error, "Error");
                }
                else
                {
                    Microsoft.Office.Interop.Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;

                    resp.Package.ForEach(formFieldMatter =>
                    {
                        Microsoft.Office.Interop.Word.ContentControls contentControls;

                        contentControls = doc.SelectContentControlsByTitle(formFieldMatter.FormField.Title);

                        foreach (Microsoft.Office.Interop.Word.ContentControl cc in contentControls)
                        {
                            cc.Range.Text = formFieldMatter.Value;
                        }
                    });

                    //doc.SelectContentControlsByTitle("Case Number")[1].Range.Text = resp.Package.Single(x => x.FormField.Title == "Case Number").Value;
                    
                }
            });

            task.Start();
        }
    }
}
