namespace PayrollDBMS.UIForms
{
    partial class LoginForm
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
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(70, 101);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(84, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Enter username:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(73, 117);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(362, 20);
            this.txtUser.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(70, 158);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(83, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Enter password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(73, 174);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(362, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(173, 237);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(168, 23);
            this.btnSignIn.TabIndex = 9;
            this.btnSignIn.Text = "Sign in";
            this.btnSignIn.Click += new System.EventHandler(this.BtnSignIn_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitle.Location = new System.Drawing.Point(70, 69);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 20);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Payroll DBMS: Login";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 319);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Name = "LoginForm";
            this.Text = "Login to Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Label lblTitle;
    }
}