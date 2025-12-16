namespace PayrollDBMS.UIForms
{
    partial class MainMenu
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
            this.rbDrop = new System.Windows.Forms.RadioButton();
            this.rbCreate = new System.Windows.Forms.RadioButton();
            this.rbPopulate = new System.Windows.Forms.RadioButton();
            this.rbQuery = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitle.Location = new System.Drawing.Point(70, 69);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(192, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Payroll DBMS: Main Menu\r\n";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(70, 101);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(465, 13);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "Please select one of the following. When you are done, click \'Run\', or click \'Exi" +
    "t\' to exit the menu.";
            // 
            // rbDrop
            // 
            this.rbDrop.AutoSize = true;
            this.rbDrop.Location = new System.Drawing.Point(73, 138);
            this.rbDrop.Name = "rbDrop";
            this.rbDrop.Size = new System.Drawing.Size(97, 17);
            this.rbDrop.TabIndex = 2;
            this.rbDrop.TabStop = true;
            this.rbDrop.Text = "1.  DROP table";
            this.rbDrop.UseVisualStyleBackColor = true;
            // 
            // rbCreate
            // 
            this.rbCreate.AutoSize = true;
            this.rbCreate.Location = new System.Drawing.Point(73, 161);
            this.rbCreate.Name = "rbCreate";
            this.rbCreate.Size = new System.Drawing.Size(109, 17);
            this.rbCreate.TabIndex = 3;
            this.rbCreate.TabStop = true;
            this.rbCreate.Text = "2.  CREATE table";
            this.rbCreate.UseVisualStyleBackColor = true;
            // 
            // rbPopulate
            // 
            this.rbPopulate.AutoSize = true;
            this.rbPopulate.Location = new System.Drawing.Point(73, 184);
            this.rbPopulate.Name = "rbPopulate";
            this.rbPopulate.Size = new System.Drawing.Size(123, 17);
            this.rbPopulate.TabIndex = 4;
            this.rbPopulate.TabStop = true;
            this.rbPopulate.Text = "3.  POPULATE table";
            this.rbPopulate.UseVisualStyleBackColor = true;
            // 
            // rbQuery
            // 
            this.rbQuery.AutoSize = true;
            this.rbQuery.Location = new System.Drawing.Point(73, 207);
            this.rbQuery.Name = "rbQuery";
            this.rbQuery.Size = new System.Drawing.Size(104, 17);
            this.rbQuery.TabIndex = 5;
            this.rbQuery.TabStop = true;
            this.rbQuery.Text = "4.  QUERY table";
            this.rbQuery.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(366, 257);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(256, 257);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(104, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rbQuery);
            this.Controls.Add(this.rbPopulate);
            this.Controls.Add(this.rbCreate);
            this.Controls.Add(this.rbDrop);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainMenu";
            this.Text = "Payroll DBMS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.RadioButton rbDrop;
        private System.Windows.Forms.RadioButton rbCreate;
        private System.Windows.Forms.RadioButton rbPopulate;
        private System.Windows.Forms.RadioButton rbQuery;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRun;
    }
}