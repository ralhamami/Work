namespace Team_Alpha_Testing
{
    partial class TFSTests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSTests));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnGenerateTest = new System.Windows.Forms.Button();
            this.clbTests = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Test Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Test Cases";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Please wait. Fetching test cases from Team Foundation Server..."});
            this.listBox1.Location = new System.Drawing.Point(331, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(447, 316);
            this.listBox1.TabIndex = 11;
            // 
            // btnGenerateTest
            // 
            this.btnGenerateTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateTest.Enabled = false;
            this.btnGenerateTest.Location = new System.Drawing.Point(11, 371);
            this.btnGenerateTest.Name = "btnGenerateTest";
            this.btnGenerateTest.Size = new System.Drawing.Size(166, 23);
            this.btnGenerateTest.TabIndex = 10;
            this.btnGenerateTest.Text = "Import as Local Test";
            this.btnGenerateTest.UseVisualStyleBackColor = true;
            this.btnGenerateTest.Click += new System.EventHandler(this.btnGenerateTest_Click);
            // 
            // clbTests
            // 
            this.clbTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clbTests.FormattingEnabled = true;
            this.clbTests.Location = new System.Drawing.Point(11, 37);
            this.clbTests.Name = "clbTests";
            this.clbTests.Size = new System.Drawing.Size(314, 319);
            this.clbTests.TabIndex = 9;
            this.clbTests.SelectedIndexChanged += new System.EventHandler(this.clbTests_SelectedIndexChanged);
            // 
            // TFSTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(789, 408);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnGenerateTest);
            this.Controls.Add(this.clbTests);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFSTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Foundation Server Tests";
            this.Load += new System.EventHandler(this.TFSTest_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnGenerateTest;
        private System.Windows.Forms.CheckedListBox clbTests;
    }
}