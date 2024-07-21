namespace HW3_labDB
{
	partial class User_Form
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
			this.btn_LoanBook = new System.Windows.Forms.Button();
			this.btn_ReturnBook = new System.Windows.Forms.Button();
			this.btn_LoginLog = new System.Windows.Forms.Button();
			this.lbl_UserResult = new System.Windows.Forms.Label();
			this.listView_UserList = new System.Windows.Forms.ListView();
			this.lbl_LoanBook = new System.Windows.Forms.Label();
			this.numeric_BookID = new System.Windows.Forms.NumericUpDown();
			this.btn_ActivateLoan = new System.Windows.Forms.Button();
			this.btn_ActivateReturn = new System.Windows.Forms.Button();
			this.lbl_ReturnBook = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numeric_BookID)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_LoanBook
			// 
			this.btn_LoanBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.btn_LoanBook.Location = new System.Drawing.Point(26, 75);
			this.btn_LoanBook.Name = "btn_LoanBook";
			this.btn_LoanBook.Size = new System.Drawing.Size(144, 74);
			this.btn_LoanBook.TabIndex = 1;
			this.btn_LoanBook.Text = "Loan Book";
			this.btn_LoanBook.UseVisualStyleBackColor = true;
			this.btn_LoanBook.Click += new System.EventHandler(this.btn_LoanBook_Click);
			// 
			// btn_ReturnBook
			// 
			this.btn_ReturnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.btn_ReturnBook.Location = new System.Drawing.Point(26, 251);
			this.btn_ReturnBook.Name = "btn_ReturnBook";
			this.btn_ReturnBook.Size = new System.Drawing.Size(144, 74);
			this.btn_ReturnBook.TabIndex = 2;
			this.btn_ReturnBook.Text = "Return Book";
			this.btn_ReturnBook.UseVisualStyleBackColor = true;
			this.btn_ReturnBook.Click += new System.EventHandler(this.btn_ReturnBook_Click);
			// 
			// btn_LoginLog
			// 
			this.btn_LoginLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.btn_LoginLog.Location = new System.Drawing.Point(26, 422);
			this.btn_LoginLog.Name = "btn_LoginLog";
			this.btn_LoginLog.Size = new System.Drawing.Size(144, 74);
			this.btn_LoginLog.TabIndex = 4;
			this.btn_LoginLog.Text = "My Login History";
			this.btn_LoginLog.UseVisualStyleBackColor = true;
			this.btn_LoginLog.Click += new System.EventHandler(this.btn_LoginLog_Click);
			// 
			// lbl_UserResult
			// 
			this.lbl_UserResult.AutoSize = true;
			this.lbl_UserResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.lbl_UserResult.Location = new System.Drawing.Point(454, 23);
			this.lbl_UserResult.Name = "lbl_UserResult";
			this.lbl_UserResult.Size = new System.Drawing.Size(71, 26);
			this.lbl_UserResult.TabIndex = 6;
			this.lbl_UserResult.Text = "result:";
			// 
			// listView_UserList
			// 
			this.listView_UserList.HideSelection = false;
			this.listView_UserList.Location = new System.Drawing.Point(459, 75);
			this.listView_UserList.Name = "listView_UserList";
			this.listView_UserList.Size = new System.Drawing.Size(774, 421);
			this.listView_UserList.TabIndex = 11;
			this.listView_UserList.UseCompatibleStateImageBehavior = false;
			// 
			// lbl_LoanBook
			// 
			this.lbl_LoanBook.AutoSize = true;
			this.lbl_LoanBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.lbl_LoanBook.Location = new System.Drawing.Point(201, 229);
			this.lbl_LoanBook.Name = "lbl_LoanBook";
			this.lbl_LoanBook.Size = new System.Drawing.Size(190, 22);
			this.lbl_LoanBook.TabIndex = 12;
			this.lbl_LoanBook.Text = "Select book ID to loan:";
			// 
			// numeric_BookID
			// 
			this.numeric_BookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.numeric_BookID.Location = new System.Drawing.Point(249, 275);
			this.numeric_BookID.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.numeric_BookID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numeric_BookID.Name = "numeric_BookID";
			this.numeric_BookID.Size = new System.Drawing.Size(150, 28);
			this.numeric_BookID.TabIndex = 13;
			this.numeric_BookID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// btn_ActivateLoan
			// 
			this.btn_ActivateLoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.btn_ActivateLoan.Location = new System.Drawing.Point(293, 326);
			this.btn_ActivateLoan.Name = "btn_ActivateLoan";
			this.btn_ActivateLoan.Size = new System.Drawing.Size(106, 40);
			this.btn_ActivateLoan.TabIndex = 14;
			this.btn_ActivateLoan.Text = "Loan!";
			this.btn_ActivateLoan.UseVisualStyleBackColor = true;
			this.btn_ActivateLoan.Click += new System.EventHandler(this.btn_ActivateLoan_Click);
			// 
			// btn_ActivateReturn
			// 
			this.btn_ActivateReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.btn_ActivateReturn.Location = new System.Drawing.Point(293, 326);
			this.btn_ActivateReturn.Name = "btn_ActivateReturn";
			this.btn_ActivateReturn.Size = new System.Drawing.Size(106, 40);
			this.btn_ActivateReturn.TabIndex = 15;
			this.btn_ActivateReturn.Text = "Return!";
			this.btn_ActivateReturn.UseVisualStyleBackColor = true;
			this.btn_ActivateReturn.Click += new System.EventHandler(this.btn_ActivateReturn_Click);
			// 
			// lbl_ReturnBook
			// 
			this.lbl_ReturnBook.AutoSize = true;
			this.lbl_ReturnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.lbl_ReturnBook.Location = new System.Drawing.Point(201, 229);
			this.lbl_ReturnBook.Name = "lbl_ReturnBook";
			this.lbl_ReturnBook.Size = new System.Drawing.Size(203, 22);
			this.lbl_ReturnBook.TabIndex = 16;
			this.lbl_ReturnBook.Text = "Select book ID to return:";
			// 
			// User_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1272, 533);
			this.Controls.Add(this.lbl_ReturnBook);
			this.Controls.Add(this.btn_ActivateReturn);
			this.Controls.Add(this.btn_ActivateLoan);
			this.Controls.Add(this.numeric_BookID);
			this.Controls.Add(this.lbl_LoanBook);
			this.Controls.Add(this.listView_UserList);
			this.Controls.Add(this.lbl_UserResult);
			this.Controls.Add(this.btn_LoginLog);
			this.Controls.Add(this.btn_ReturnBook);
			this.Controls.Add(this.btn_LoanBook);
			this.Name = "User_Form";
			this.Text = "User_Form";
			((System.ComponentModel.ISupportInitialize)(this.numeric_BookID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btn_LoanBook;
		private System.Windows.Forms.Button btn_ReturnBook;
		private System.Windows.Forms.Button btn_LoginLog;
		private System.Windows.Forms.Label lbl_UserResult;
		private System.Windows.Forms.ListView listView_UserList;
		private System.Windows.Forms.Label lbl_LoanBook;
		private System.Windows.Forms.NumericUpDown numeric_BookID;
		private System.Windows.Forms.Button btn_ActivateLoan;
		private System.Windows.Forms.Button btn_ActivateReturn;
		private System.Windows.Forms.Label lbl_ReturnBook;
	}
}