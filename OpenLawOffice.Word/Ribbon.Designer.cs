namespace OpenLawOffice.Word
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.generalGroup = this.Factory.CreateRibbonGroup();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.button4 = this.Factory.CreateRibbonButton();
            this.groupDocuments = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.ActiveMatterTitle = this.Factory.CreateRibbonLabel();
            this.GenerateButton = this.Factory.CreateRibbonButton();
            this.FormSelector = this.Factory.CreateRibbonDropDown();
            this.tab1.SuspendLayout();
            this.generalGroup.SuspendLayout();
            this.groupDocuments.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.generalGroup);
            this.tab1.Groups.Add(this.groupDocuments);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "OpenLawOffice";
            this.tab1.Name = "tab1";
            // 
            // generalGroup
            // 
            this.generalGroup.Items.Add(this.button3);
            this.generalGroup.Items.Add(this.button2);
            this.generalGroup.Items.Add(this.button4);
            this.generalGroup.Label = "General";
            this.generalGroup.Name = "generalGroup";
            // 
            // button3
            // 
            this.button3.Image = global::OpenLawOffice.Word.Properties.Resources.plug_connect;
            this.button3.Label = "Click to Connect";
            this.button3.Name = "button3";
            this.button3.ShowImage = true;
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::OpenLawOffice.Word.Properties.Resources.plug_disconnect;
            this.button2.Label = "Click to Disconnect";
            this.button2.Name = "button2";
            this.button2.ShowImage = true;
            this.button2.Visible = false;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Image = global::OpenLawOffice.Word.Properties.Resources.book_open_list;
            this.button4.Label = "Logging";
            this.button4.Name = "button4";
            this.button4.ShowImage = true;
            this.button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button4_Click);
            // 
            // groupDocuments
            // 
            this.groupDocuments.Items.Add(this.button1);
            this.groupDocuments.Label = "Documents";
            this.groupDocuments.Name = "groupDocuments";
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = global::OpenLawOffice.Word.Properties.Resources.document_plus;
            this.button1.Label = "New Form";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.ActiveMatterTitle);
            this.group1.Items.Add(this.FormSelector);
            this.group1.Items.Add(this.GenerateButton);
            this.group1.Label = "Active Matter";
            this.group1.Name = "group1";
            this.group1.Visible = false;
            // 
            // ActiveMatterTitle
            // 
            this.ActiveMatterTitle.Label = "ActiveMatterTitle";
            this.ActiveMatterTitle.Name = "ActiveMatterTitle";
            // 
            // GenerateButton
            // 
            this.GenerateButton.Image = global::OpenLawOffice.Word.Properties.Resources.arrow;
            this.GenerateButton.Label = "Generate";
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.ShowImage = true;
            this.GenerateButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GenerateButton_Click);
            // 
            // FormSelector
            // 
            this.FormSelector.Label = "Form:";
            this.FormSelector.Name = "FormSelector";
            this.FormSelector.SizeString = "Motion for Discovery and Production of Evidence";
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.generalGroup.ResumeLayout(false);
            this.generalGroup.PerformLayout();
            this.groupDocuments.ResumeLayout(false);
            this.groupDocuments.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup generalGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupDocuments;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel ActiveMatterTitle;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton GenerateButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown FormSelector;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
