namespace OpenLawOffice.Word
{
    partial class FormSelectorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Results = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LoadingPanel = new OpenLawOffice.Word.LoadingPanelControl();
            this.SuspendLayout();
            // 
            // Results
            // 
            this.Results.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Results.FormattingEnabled = true;
            this.Results.ItemHeight = 20;
            this.Results.Location = new System.Drawing.Point(3, 3);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(319, 584);
            this.Results.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 628);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(319, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::OpenLawOffice.Word.Properties.Resources.arrow;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(3, 593);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(319, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Use Selected Document";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadingPanel.Location = new System.Drawing.Point(0, 0);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(325, 682);
            this.LoadingPanel.TabIndex = 27;
            this.LoadingPanel.Visible = false;
            // 
            // FormSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoadingPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Results);
            this.Name = "FormSelectorControl";
            this.Size = new System.Drawing.Size(325, 682);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Results;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private LoadingPanelControl LoadingPanel;
    }
}
