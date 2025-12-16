namespace PayrollDBMS.UIForms
{
    partial class DropForm
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
            this.lblTables = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitle.Location = new System.Drawing.Point(70, 69);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Payroll DBMS: DROP Table";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(70, 101);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(599, 13);
            this.lblInstruction.TabIndex = 2;
            this.lblInstruction.Text = "Please enter a table name, or \'All\' to drop all tables. When you are done, click " +
    "\'Run\', or click \'Back\' to return to the main menu.";
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Location = new System.Drawing.Point(71, 170);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(75, 13);
            this.lblTables.TabIndex = 3;
            this.lblTables.Text = "Current tables:";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(256, 350);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(104, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run";
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(366, 350);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(104, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(73, 130);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(323, 20);
            this.txtTableName.TabIndex = 9;
            // 
            // DropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTitle);
            this.Name = "DropForm";
            this.Text = "DROP Table";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtTableName;
    }
}