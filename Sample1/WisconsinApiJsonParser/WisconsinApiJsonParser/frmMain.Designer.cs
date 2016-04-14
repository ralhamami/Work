namespace WisconsinApiJsonParser
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCaseType = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cboOperation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstLocal = new System.Windows.Forms.ListBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.dgvCaseListTest = new System.Windows.Forms.DataGridView();
            this.dgvCaseListConcat = new System.Windows.Forms.DataGridView();
            this.dgvDiff = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseListTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseListConcat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiff)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Case Type:";
            // 
            // txtCaseType
            // 
            this.txtCaseType.Location = new System.Drawing.Point(404, 81);
            this.txtCaseType.Name = "txtCaseType";
            this.txtCaseType.Size = new System.Drawing.Size(100, 20);
            this.txtCaseType.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(571, 81);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRun
            // 
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Location = new System.Drawing.Point(571, 31);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "From:";
            // 
            // dpToDate
            // 
            this.dpToDate.CustomFormat = "yyyy-MM-dd";
            this.dpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpToDate.Location = new System.Drawing.Point(404, 55);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(96, 20);
            this.dpToDate.TabIndex = 4;
            // 
            // dpFromDate
            // 
            this.dpFromDate.CustomFormat = "yyyy-MM-dd";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFromDate.Location = new System.Drawing.Point(404, 29);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(96, 20);
            this.dpFromDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "County:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Last Name Filter:";
            // 
            // txtCounty
            // 
            this.txtCounty.Location = new System.Drawing.Point(181, 81);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(100, 20);
            this.txtCounty.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Enabled = false;
            this.txtLastName.Location = new System.Drawing.Point(181, 55);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // cboOperation
            // 
            this.cboOperation.FormattingEnabled = true;
            this.cboOperation.Items.AddRange(new object[] {
            "Cases",
            "Docketed Civil Judgments",
            "Civil Judgment Events",
            "Open Civil Judgments"});
            this.cboOperation.Location = new System.Drawing.Point(181, 27);
            this.cboOperation.Name = "cboOperation";
            this.cboOperation.Size = new System.Drawing.Size(134, 21);
            this.cboOperation.TabIndex = 0;
            this.cboOperation.SelectedIndexChanged += new System.EventHandler(this.cboOperation_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Operation:";
            // 
            // lstLocal
            // 
            this.lstLocal.FormattingEnabled = true;
            this.lstLocal.Location = new System.Drawing.Point(16, 174);
            this.lstLocal.Name = "lstLocal";
            this.lstLocal.Size = new System.Drawing.Size(210, 251);
            this.lstLocal.TabIndex = 8;
            this.lstLocal.SizeChanged += new System.EventHandler(this.lstLocal_SizeChanged);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(66, 107);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(342, 29);
            this.lblResult.TabIndex = 41;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(67, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Test Case Values";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(292, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "WIWSCaseListTest";
            // 
            // btnCommit
            // 
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit.Location = new System.Drawing.Point(16, 427);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 48;
            this.btnCommit.Text = "Commit List";
            this.toolTip1.SetToolTip(this.btnCommit, "Commited to RISOKCSQLT005 Analyst.dbo.WIWSCaseListTest");
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(534, 288);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "WIWSCaseListConcat";
            // 
            // dgvCaseListTest
            // 
            this.dgvCaseListTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaseListTest.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaseListTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaseListTest.Location = new System.Drawing.Point(232, 304);
            this.dgvCaseListTest.Name = "dgvCaseListTest";
            this.dgvCaseListTest.RowHeadersVisible = false;
            this.dgvCaseListTest.Size = new System.Drawing.Size(240, 121);
            this.dgvCaseListTest.TabIndex = 50;
            // 
            // dgvCaseListConcat
            // 
            this.dgvCaseListConcat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaseListConcat.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaseListConcat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaseListConcat.Location = new System.Drawing.Point(478, 304);
            this.dgvCaseListConcat.Name = "dgvCaseListConcat";
            this.dgvCaseListConcat.RowHeadersVisible = false;
            this.dgvCaseListConcat.Size = new System.Drawing.Size(240, 121);
            this.dgvCaseListConcat.TabIndex = 51;
            // 
            // dgvDiff
            // 
            this.dgvDiff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiff.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiff.Location = new System.Drawing.Point(232, 174);
            this.dgvDiff.Name = "dgvDiff";
            this.dgvDiff.RowHeadersVisible = false;
            this.dgvDiff.Size = new System.Drawing.Size(486, 111);
            this.dgvDiff.TabIndex = 52;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(439, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Differences";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(292, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "WIWSCaseListTest";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(534, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "WIWSCaseListConcat";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvDiff);
            this.Controls.Add(this.dgvCaseListConcat);
            this.Controls.Add(this.dgvCaseListTest);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lstLocal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboOperation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCaseType);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dpToDate);
            this.Controls.Add(this.dpFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCounty);
            this.Controls.Add(this.txtLastName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "WIWSCaseList Test Utility";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseListTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseListConcat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCaseType;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cboOperation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstLocal;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvCaseListTest;
        private System.Windows.Forms.DataGridView dgvCaseListConcat;
        private System.Windows.Forms.DataGridView dgvDiff;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;




    }
}

