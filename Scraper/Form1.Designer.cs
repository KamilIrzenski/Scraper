namespace Scraper
{
    partial class Form1
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
            this.btnPageLoad = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.deputiesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnPageLoad
            // 
            this.btnPageLoad.Location = new System.Drawing.Point(704, 36);
            this.btnPageLoad.Name = "btnPageLoad";
            this.btnPageLoad.Size = new System.Drawing.Size(75, 23);
            this.btnPageLoad.TabIndex = 0;
            this.btnPageLoad.Text = "Zaladuj";
            this.btnPageLoad.UseVisualStyleBackColor = true;
            this.btnPageLoad.Click += new System.EventHandler(this.btnPageLoad_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(37, 36);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(605, 20);
            this.textBoxPage.TabIndex = 1;
            this.textBoxPage.Text = "http://sejm.gov.pl/Sejm9.nsf/poslowie.xsp?type=A";
            // 
            // deputiesListBox
            // 
            this.deputiesListBox.FormattingEnabled = true;
            this.deputiesListBox.Location = new System.Drawing.Point(37, 79);
            this.deputiesListBox.Name = "deputiesListBox";
            this.deputiesListBox.Size = new System.Drawing.Size(427, 355);
            this.deputiesListBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 450);
            this.Controls.Add(this.deputiesListBox);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.btnPageLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPageLoad;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.ListBox deputiesListBox;
    }
}

