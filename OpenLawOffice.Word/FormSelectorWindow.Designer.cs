namespace OpenLawOffice.Word
{
    partial class FormSelectorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Contact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProgressBarMatter = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.MatterResults = new System.Windows.Forms.ListBox();
            this.Clear = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.Jurisdiction = new System.Windows.Forms.TextBox();
            this.CaseNumber = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProgressBarForm = new System.Windows.Forms.ProgressBar();
            this.Close = new System.Windows.Forms.Button();
            this.Select = new System.Windows.Forms.Button();
            this.FormResults = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contact";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Case No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jurisdiction";
            // 
            // Contact
            // 
            this.Contact.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contact.Location = new System.Drawing.Point(9, 44);
            this.Contact.Name = "Contact";
            this.Contact.Size = new System.Drawing.Size(351, 22);
            this.Contact.TabIndex = 4;
            this.Contact.TextChanged += new System.EventHandler(this.Contact_TextChanged);
            this.Contact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Contact_KeyPress);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(862, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "OpenLawOffice: Form Selection";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProgressBarMatter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.MatterResults);
            this.groupBox1.Controls.Add(this.Clear);
            this.groupBox1.Controls.Add(this.Search);
            this.groupBox1.Controls.Add(this.Jurisdiction);
            this.groupBox1.Controls.Add(this.CaseNumber);
            this.groupBox1.Controls.Add(this.Title);
            this.groupBox1.Controls.Add(this.Contact);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 615);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Select Matter";
            // 
            // ProgressBarMatter
            // 
            this.ProgressBarMatter.Location = new System.Drawing.Point(9, 412);
            this.ProgressBarMatter.Name = "ProgressBarMatter";
            this.ProgressBarMatter.Size = new System.Drawing.Size(351, 23);
            this.ProgressBarMatter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBarMatter.TabIndex = 12;
            this.ProgressBarMatter.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Results";
            // 
            // MatterResults
            // 
            this.MatterResults.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatterResults.FormattingEnabled = true;
            this.MatterResults.ItemHeight = 16;
            this.MatterResults.Location = new System.Drawing.Point(9, 271);
            this.MatterResults.Name = "MatterResults";
            this.MatterResults.Size = new System.Drawing.Size(351, 324);
            this.MatterResults.TabIndex = 10;
            this.MatterResults.SelectedIndexChanged += new System.EventHandler(this.MatterResults_SelectedIndexChanged);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(188, 204);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(172, 23);
            this.Clear.TabIndex = 9;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(9, 204);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(172, 23);
            this.Search.TabIndex = 8;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Jurisdiction
            // 
            this.Jurisdiction.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jurisdiction.Location = new System.Drawing.Point(9, 176);
            this.Jurisdiction.Name = "Jurisdiction";
            this.Jurisdiction.Size = new System.Drawing.Size(351, 22);
            this.Jurisdiction.TabIndex = 7;
            this.Jurisdiction.TextChanged += new System.EventHandler(this.Jurisdiction_TextChanged);
            this.Jurisdiction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Jurisdiction_KeyPress);
            // 
            // CaseNumber
            // 
            this.CaseNumber.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaseNumber.Location = new System.Drawing.Point(9, 132);
            this.CaseNumber.Name = "CaseNumber";
            this.CaseNumber.Size = new System.Drawing.Size(351, 22);
            this.CaseNumber.TabIndex = 6;
            this.CaseNumber.TextChanged += new System.EventHandler(this.CaseNumber_TextChanged);
            this.CaseNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CaseNumber_KeyPress);
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(9, 88);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(351, 22);
            this.Title.TabIndex = 5;
            this.Title.TextChanged += new System.EventHandler(this.Title_TextChanged);
            this.Title.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Title_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProgressBarForm);
            this.groupBox2.Controls.Add(this.Close);
            this.groupBox2.Controls.Add(this.Select);
            this.groupBox2.Controls.Add(this.FormResults);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(390, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 615);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Select Form";
            // 
            // ProgressBarForm
            // 
            this.ProgressBarForm.Location = new System.Drawing.Point(6, 271);
            this.ProgressBarForm.Name = "ProgressBarForm";
            this.ProgressBarForm.Size = new System.Drawing.Size(472, 23);
            this.ProgressBarForm.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBarForm.TabIndex = 14;
            this.ProgressBarForm.Visible = false;
            // 
            // Close
            // 
            this.Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close.Location = new System.Drawing.Point(248, 586);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(230, 23);
            this.Close.TabIndex = 13;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Select
            // 
            this.Select.Location = new System.Drawing.Point(6, 586);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(230, 23);
            this.Select.TabIndex = 12;
            this.Select.Text = "Use Selected Form";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // FormResults
            // 
            this.FormResults.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormResults.FormattingEnabled = true;
            this.FormResults.ItemHeight = 16;
            this.FormResults.Location = new System.Drawing.Point(6, 21);
            this.FormResults.Name = "FormResults";
            this.FormResults.Size = new System.Drawing.Size(472, 564);
            this.FormResults.TabIndex = 11;
            this.FormResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormResults_MouseDoubleClick);
            // 
            // FormSelectorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Close;
            this.ClientSize = new System.Drawing.Size(878, 649);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(894, 688);
            this.MinimumSize = new System.Drawing.Size(894, 688);
            this.Name = "FormSelectorWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OLO Form Selection";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSelectorWindow_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Contact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox Jurisdiction;
        private System.Windows.Forms.TextBox CaseNumber;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox MatterResults;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.ListBox FormResults;
        private System.Windows.Forms.ProgressBar ProgressBarMatter;
        private System.Windows.Forms.ProgressBar ProgressBarForm;


    }
}