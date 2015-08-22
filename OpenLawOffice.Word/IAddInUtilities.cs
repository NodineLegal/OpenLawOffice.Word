using System;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace OpenLawOffice.Word
{
    [ComVisible(true)]
    [Guid("82F1EAF1-33F6-4848-A69B-04079D849BF5")]
    public interface IAddInUtilities
    {
        void DownloadFormDataForMatter(Guid id);
    }
}