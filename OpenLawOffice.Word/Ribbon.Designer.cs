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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.generalGroup = this.Factory.CreateRibbonGroup();
            this.toggleButton1 = this.Factory.CreateRibbonToggleButton();
            this.toggleButton2 = this.Factory.CreateRibbonToggleButton();
            this.groupDocuments = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.label1 = this.Factory.CreateRibbonLabel();
            this.User = this.Factory.CreateRibbonLabel();
            this.box1 = this.Factory.CreateRibbonBox();
            this.tab1.SuspendLayout();
            this.generalGroup.SuspendLayout();
            this.groupDocuments.SuspendLayout();
            this.box1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.generalGroup);
            this.tab1.Groups.Add(this.groupDocuments);
            this.tab1.Label = "OpenLawOffice";
            this.tab1.Name = "tab1";
            // 
            // generalGroup
            // 
            this.generalGroup.Items.Add(this.toggleButton1);
            this.generalGroup.Items.Add(this.box1);
            this.generalGroup.Items.Add(this.button2);
            this.generalGroup.Items.Add(this.toggleButton2);
            this.generalGroup.Label = "General";
            this.generalGroup.Name = "generalGroup";
            // 
            // toggleButton1
            // 
            this.toggleButton1.Image = global::OpenLawOffice.Word.Properties.Resources.plug_disconnect;
            this.toggleButton1.Label = "Click to Connect";
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.ShowImage = true;
            this.toggleButton1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton1_Click);
            // 
            // toggleButton2
            // 
            this.toggleButton2.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton2.Image")));
            this.toggleButton2.Label = "Logging";
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.ShowImage = true;
            this.toggleButton2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton2_Click);
            // 
            // groupDocuments
            // 
            this.groupDocuments.Items.Add(this.button1);
            this.groupDocuments.Label = "Documents";
            this.groupDocuments.Name = "groupDocuments";
            // 
            // button1
            // 
            this.button1.Image = global::OpenLawOffice.Word.Properties.Resources.document_plus;
            this.button1.Label = "New Document";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::OpenLawOffice.Word.Properties.Resources.plug_connect;
            this.button2.Label = "Click to Disconnect";
            this.button2.Name = "button2";
            this.button2.ShowImage = true;
            this.button2.Visible = false;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Label = "User:";
            this.label1.Name = "label1";
            // 
            // User
            // 
            this.User.Label = "User";
            this.User.Name = "User";
            // 
            // box1
            // 
            this.box1.Items.Add(this.label1);
            this.box1.Items.Add(this.User);
            this.box1.Name = "box1";
            this.box1.Visible = false;
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
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup generalGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupDocuments;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton1;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label1;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel User;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
