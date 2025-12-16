namespace PayrollDBMS.UIForms
{
    partial class QueryForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.lblField = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lstHint = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitle.Location = new System.Drawing.Point(70, 69);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(215, 20);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Payroll DBMS: QUERY Table";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(70, 101);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(476, 13);
            this.lblInstruction.TabIndex = 5;
            this.lblInstruction.Text = "Please select a QUERY. When you are done, click \'Run\', or click \'Back\' to return " +
    "to the main menu.";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(256, 379);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(104, 23);
            this.btnRun.TabIndex = 15;
            this.btnRun.Text = "Run";
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(366, 379);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(104, 23);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // cboTable
            // 
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Items.AddRange(new object[] {
            "Attendance",
            "Departments",
            "Employees",
            "Payroll",
            "Salary"});
            this.cboTable.Location = new System.Drawing.Point(73, 175);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(140, 21);
            this.cboTable.TabIndex = 22;
            this.cboTable.SelectedValueChanged += new System.EventHandler(this.CboTable_SelectedValueChanged);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(70, 150);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(92, 13);
            this.lblTable.TabIndex = 23;
            this.lblTable.Text = "1.  Select TABLE:";
            // 
            // cboField
            // 
            this.cboField.FormattingEnabled = true;
            this.cboField.Items.AddRange(new object[] {
            "Attendance",
            "Departments",
            "Employees",
            "Payroll",
            "Salary"});
            this.cboField.Location = new System.Drawing.Point(239, 175);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(140, 21);
            this.cboField.TabIndex = 24;
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.CboField_SelectedIndexChanged);
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(236, 150);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(88, 13);
            this.lblField.TabIndex = 25;
            this.lblField.Text = "2.  Select FIELD:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(406, 176);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(199, 20);
            this.txtSearch.TabIndex = 26;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(403, 150);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(108, 13);
            this.lblSearch.TabIndex = 27;
            this.lblSearch.Text = "3.  Enter search term:";
            // 
            // lstHint
            // 
            this.lstHint.FormattingEnabled = true;
            this.lstHint.Location = new System.Drawing.Point(73, 218);
            this.lstHint.Name = "lstHint";
            this.lstHint.Size = new System.Drawing.Size(617, 147);
            this.lstHint.TabIndex = 29;
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstHint);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.cboTable);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTitle);
            this.Name = "QueryForm";
            this.Text = "QUERY Table";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ListBox lstHint;
    }
}