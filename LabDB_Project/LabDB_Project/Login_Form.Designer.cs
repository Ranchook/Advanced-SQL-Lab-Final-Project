namespace LabDB_Project
{
	partial class Login_Form
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
			this.lbl_PassLogin = new System.Windows.Forms.Label();
			this.lbl_UserLogin = new System.Windows.Forms.Label();
			this.txtbox_PassLogin = new System.Windows.Forms.TextBox();
			this.txtbox_MailLogin = new System.Windows.Forms.TextBox();
			this.btn_login = new System.Windows.Forms.Button();
			this.btn_ForgotPass = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_PassLogin
			// 
			this.lbl_PassLogin.AutoSize = true;
			this.lbl_PassLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.lbl_PassLogin.Location = new System.Drawing.Point(168, 246);
			this.lbl_PassLogin.Name = "lbl_PassLogin";
			this.lbl_PassLogin.Size = new System.Drawing.Size(88, 20);
			this.lbl_PassLogin.TabIndex = 9;
			this.lbl_PassLogin.Text = "Password:";
			// 
			// lbl_UserLogin
			// 
			this.lbl_UserLogin.AutoSize = true;
			this.lbl_UserLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.lbl_UserLogin.Location = new System.Drawing.Point(168, 140);
			this.lbl_UserLogin.Name = "lbl_UserLogin";
			this.lbl_UserLogin.Size = new System.Drawing.Size(61, 20);
			this.lbl_UserLogin.TabIndex = 8;
			this.lbl_UserLogin.Text = " Email:";
			// 
			// txtbox_PassLogin
			// 
			this.txtbox_PassLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.txtbox_PassLogin.Location = new System.Drawing.Point(301, 241);
			this.txtbox_PassLogin.Name = "txtbox_PassLogin";
			this.txtbox_PassLogin.PasswordChar = '*';
			this.txtbox_PassLogin.Size = new System.Drawing.Size(290, 27);
			this.txtbox_PassLogin.TabIndex = 7;
			// 
			// txtbox_MailLogin
			// 
			this.txtbox_MailLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.txtbox_MailLogin.Location = new System.Drawing.Point(301, 135);
			this.txtbox_MailLogin.Name = "txtbox_MailLogin";
			this.txtbox_MailLogin.Size = new System.Drawing.Size(290, 27);
			this.txtbox_MailLogin.TabIndex = 6;
			// 
			// btn_login
			// 
			this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_login.Location = new System.Drawing.Point(635, 299);
			this.btn_login.Name = "btn_login";
			this.btn_login.Size = new System.Drawing.Size(106, 67);
			this.btn_login.TabIndex = 10;
			this.btn_login.Text = "Login";
			this.btn_login.UseVisualStyleBackColor = true;
			this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
			// 
			// btn_ForgotPass
			// 
			this.btn_ForgotPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_ForgotPass.Location = new System.Drawing.Point(485, 299);
			this.btn_ForgotPass.Name = "btn_ForgotPass";
			this.btn_ForgotPass.Size = new System.Drawing.Size(106, 67);
			this.btn_ForgotPass.TabIndex = 50;
			this.btn_ForgotPass.Text = "Forgot Passwod";
			this.btn_ForgotPass.UseVisualStyleBackColor = true;
			this.btn_ForgotPass.Click += new System.EventHandler(this.btn_ForgotPass_Click);
			// 
			// Login_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btn_ForgotPass);
			this.Controls.Add(this.btn_login);
			this.Controls.Add(this.lbl_PassLogin);
			this.Controls.Add(this.lbl_UserLogin);
			this.Controls.Add(this.txtbox_PassLogin);
			this.Controls.Add(this.txtbox_MailLogin);
			this.Name = "Login_Form";
			this.Text = "Login_Form";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_PassLogin;
		private System.Windows.Forms.Label lbl_UserLogin;
		private System.Windows.Forms.TextBox txtbox_PassLogin;
		private System.Windows.Forms.TextBox txtbox_MailLogin;
		private System.Windows.Forms.Button btn_login;
		private System.Windows.Forms.Button btn_ForgotPass;
	}
}