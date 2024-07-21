namespace HW3_labDB
{
	partial class Admin_Form
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
			this.btn_BlockUsers = new System.Windows.Forms.Button();
			this.btn_UserStatus = new System.Windows.Forms.Button();
			this.listView_Admin = new System.Windows.Forms.ListView();
			this.btn_AddBook = new System.Windows.Forms.Button();
			this.btn_RemoveBook = new System.Windows.Forms.Button();
			this.btn_RemoveUser = new System.Windows.Forms.Button();
			this.lbl_ResultLabel = new System.Windows.Forms.Label();
			this.btn_RestoreData = new System.Windows.Forms.Button();
			this.btn_BackupData = new System.Windows.Forms.Button();
			this.btn_MoreOptions = new System.Windows.Forms.Button();
			this.lbl_RemoveBook = new System.Windows.Forms.Label();
			this.lbl_RemoveUser = new System.Windows.Forms.Label();
			this.btn_ActivateRemoveBook = new System.Windows.Forms.Button();
			this.numeric_RemoveBookID = new System.Windows.Forms.NumericUpDown();
			this.txtbox_RemoveUser = new System.Windows.Forms.TextBox();
			this.btn_ActivateRemoveUser = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numeric_RemoveBookID)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_BlockUsers
			// 
			this.btn_BlockUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_BlockUsers.Location = new System.Drawing.Point(12, 12);
			this.btn_BlockUsers.Name = "btn_BlockUsers";
			this.btn_BlockUsers.Size = new System.Drawing.Size(190, 67);
			this.btn_BlockUsers.TabIndex = 0;
			this.btn_BlockUsers.Text = "Show Blocked Users";
			this.btn_BlockUsers.UseVisualStyleBackColor = true;
			this.btn_BlockUsers.Click += new System.EventHandler(this.btn_BlockUsers_Click);
			// 
			// btn_UserStatus
			// 
			this.btn_UserStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_UserStatus.Location = new System.Drawing.Point(12, 100);
			this.btn_UserStatus.Name = "btn_UserStatus";
			this.btn_UserStatus.Size = new System.Drawing.Size(190, 67);
			this.btn_UserStatus.TabIndex = 1;
			this.btn_UserStatus.Text = "Show Users Status";
			this.btn_UserStatus.UseVisualStyleBackColor = true;
			this.btn_UserStatus.Click += new System.EventHandler(this.btn_UserStatus_Click);
			// 
			// listView_Admin
			// 
			this.listView_Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.listView_Admin.HideSelection = false;
			this.listView_Admin.Location = new System.Drawing.Point(542, 90);
			this.listView_Admin.Name = "listView_Admin";
			this.listView_Admin.Size = new System.Drawing.Size(955, 348);
			this.listView_Admin.TabIndex = 2;
			this.listView_Admin.UseCompatibleStateImageBehavior = false;
			// 
			// btn_AddBook
			// 
			this.btn_AddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_AddBook.Location = new System.Drawing.Point(12, 188);
			this.btn_AddBook.Name = "btn_AddBook";
			this.btn_AddBook.Size = new System.Drawing.Size(190, 67);
			this.btn_AddBook.TabIndex = 3;
			this.btn_AddBook.Text = "Add Book";
			this.btn_AddBook.UseVisualStyleBackColor = true;
			this.btn_AddBook.Click += new System.EventHandler(this.btn_AddBook_Click);
			// 
			// btn_RemoveBook
			// 
			this.btn_RemoveBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_RemoveBook.Location = new System.Drawing.Point(12, 276);
			this.btn_RemoveBook.Name = "btn_RemoveBook";
			this.btn_RemoveBook.Size = new System.Drawing.Size(190, 67);
			this.btn_RemoveBook.TabIndex = 4;
			this.btn_RemoveBook.Text = "Remove Book";
			this.btn_RemoveBook.UseVisualStyleBackColor = true;
			this.btn_RemoveBook.Click += new System.EventHandler(this.btn_RemoveBook_Click);
			// 
			// btn_RemoveUser
			// 
			this.btn_RemoveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_RemoveUser.Location = new System.Drawing.Point(12, 363);
			this.btn_RemoveUser.Name = "btn_RemoveUser";
			this.btn_RemoveUser.Size = new System.Drawing.Size(190, 67);
			this.btn_RemoveUser.TabIndex = 5;
			this.btn_RemoveUser.Text = "Remove User";
			this.btn_RemoveUser.UseVisualStyleBackColor = true;
			this.btn_RemoveUser.Click += new System.EventHandler(this.btn_RemoveUser_Click);
			// 
			// lbl_ResultLabel
			// 
			this.lbl_ResultLabel.AutoSize = true;
			this.lbl_ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.lbl_ResultLabel.Location = new System.Drawing.Point(537, 32);
			this.lbl_ResultLabel.Name = "lbl_ResultLabel";
			this.lbl_ResultLabel.Size = new System.Drawing.Size(80, 26);
			this.lbl_ResultLabel.TabIndex = 6;
			this.lbl_ResultLabel.Text = "Result:";
			// 
			// btn_RestoreData
			// 
			this.btn_RestoreData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_RestoreData.Location = new System.Drawing.Point(219, 100);
			this.btn_RestoreData.Name = "btn_RestoreData";
			this.btn_RestoreData.Size = new System.Drawing.Size(190, 67);
			this.btn_RestoreData.TabIndex = 10;
			this.btn_RestoreData.Text = "Restore Data";
			this.btn_RestoreData.UseVisualStyleBackColor = true;
			this.btn_RestoreData.Click += new System.EventHandler(this.btn_RestoreData_Click);
			// 
			// btn_BackupData
			// 
			this.btn_BackupData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_BackupData.Location = new System.Drawing.Point(219, 12);
			this.btn_BackupData.Name = "btn_BackupData";
			this.btn_BackupData.Size = new System.Drawing.Size(190, 67);
			this.btn_BackupData.TabIndex = 9;
			this.btn_BackupData.Text = "Backup Data";
			this.btn_BackupData.UseVisualStyleBackColor = true;
			this.btn_BackupData.Click += new System.EventHandler(this.btn_BackupData_Click);
			// 
			// btn_MoreOptions
			// 
			this.btn_MoreOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btn_MoreOptions.Location = new System.Drawing.Point(219, 188);
			this.btn_MoreOptions.Name = "btn_MoreOptions";
			this.btn_MoreOptions.Size = new System.Drawing.Size(190, 67);
			this.btn_MoreOptions.TabIndex = 11;
			this.btn_MoreOptions.Text = "More Options";
			this.btn_MoreOptions.UseVisualStyleBackColor = true;
			this.btn_MoreOptions.Click += new System.EventHandler(this.btn_MoreOptions_Click);
			// 
			// lbl_RemoveBook
			// 
			this.lbl_RemoveBook.AutoSize = true;
			this.lbl_RemoveBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.lbl_RemoveBook.Location = new System.Drawing.Point(231, 276);
			this.lbl_RemoveBook.Name = "lbl_RemoveBook";
			this.lbl_RemoveBook.Size = new System.Drawing.Size(217, 22);
			this.lbl_RemoveBook.TabIndex = 12;
			this.lbl_RemoveBook.Text = "Select Book ID to remove:";
			// 
			// lbl_RemoveUser
			// 
			this.lbl_RemoveUser.AutoSize = true;
			this.lbl_RemoveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.lbl_RemoveUser.Location = new System.Drawing.Point(231, 276);
			this.lbl_RemoveUser.Name = "lbl_RemoveUser";
			this.lbl_RemoveUser.Size = new System.Drawing.Size(267, 22);
			this.lbl_RemoveUser.TabIndex = 13;
			this.lbl_RemoveUser.Text = "Enter a user mail to remove him:";
			// 
			// btn_ActivateRemoveBook
			// 
			this.btn_ActivateRemoveBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
			this.btn_ActivateRemoveBook.Location = new System.Drawing.Point(384, 368);
			this.btn_ActivateRemoveBook.Name = "btn_ActivateRemoveBook";
			this.btn_ActivateRemoveBook.Size = new System.Drawing.Size(108, 58);
			this.btn_ActivateRemoveBook.TabIndex = 14;
			this.btn_ActivateRemoveBook.Text = "Remove Book";
			this.btn_ActivateRemoveBook.UseVisualStyleBackColor = true;
			this.btn_ActivateRemoveBook.Click += new System.EventHandler(this.btn_ActivateRemove_Click);
			// 
			// numeric_RemoveBookID
			// 
			this.numeric_RemoveBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
			this.numeric_RemoveBookID.Location = new System.Drawing.Point(310, 328);
			this.numeric_RemoveBookID.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.numeric_RemoveBookID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numeric_RemoveBookID.Name = "numeric_RemoveBookID";
			this.numeric_RemoveBookID.Size = new System.Drawing.Size(150, 24);
			this.numeric_RemoveBookID.TabIndex = 15;
			this.numeric_RemoveBookID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// txtbox_RemoveUser
			// 
			this.txtbox_RemoveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
			this.txtbox_RemoveUser.Location = new System.Drawing.Point(235, 328);
			this.txtbox_RemoveUser.Name = "txtbox_RemoveUser";
			this.txtbox_RemoveUser.Size = new System.Drawing.Size(257, 24);
			this.txtbox_RemoveUser.TabIndex = 16;
			// 
			// btn_ActivateRemoveUser
			// 
			this.btn_ActivateRemoveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
			this.btn_ActivateRemoveUser.Location = new System.Drawing.Point(384, 368);
			this.btn_ActivateRemoveUser.Name = "btn_ActivateRemoveUser";
			this.btn_ActivateRemoveUser.Size = new System.Drawing.Size(108, 58);
			this.btn_ActivateRemoveUser.TabIndex = 17;
			this.btn_ActivateRemoveUser.Text = "Remove User";
			this.btn_ActivateRemoveUser.UseVisualStyleBackColor = true;
			this.btn_ActivateRemoveUser.Click += new System.EventHandler(this.btn_ActivateRemoveUser_Click);
			// 
			// Admin_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1505, 482);
			this.Controls.Add(this.btn_ActivateRemoveUser);
			this.Controls.Add(this.txtbox_RemoveUser);
			this.Controls.Add(this.numeric_RemoveBookID);
			this.Controls.Add(this.btn_ActivateRemoveBook);
			this.Controls.Add(this.lbl_RemoveUser);
			this.Controls.Add(this.lbl_RemoveBook);
			this.Controls.Add(this.btn_MoreOptions);
			this.Controls.Add(this.btn_RestoreData);
			this.Controls.Add(this.btn_BackupData);
			this.Controls.Add(this.lbl_ResultLabel);
			this.Controls.Add(this.btn_RemoveUser);
			this.Controls.Add(this.btn_RemoveBook);
			this.Controls.Add(this.btn_AddBook);
			this.Controls.Add(this.listView_Admin);
			this.Controls.Add(this.btn_UserStatus);
			this.Controls.Add(this.btn_BlockUsers);
			this.Name = "Admin_Form";
			this.Text = "Admin_Form";
			((System.ComponentModel.ISupportInitialize)(this.numeric_RemoveBookID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_BlockUsers;
		private System.Windows.Forms.Button btn_UserStatus;
		private System.Windows.Forms.ListView listView_Admin;
		private System.Windows.Forms.Button btn_AddBook;
		private System.Windows.Forms.Button btn_RemoveBook;
		private System.Windows.Forms.Button btn_RemoveUser;
		private System.Windows.Forms.Label lbl_ResultLabel;
		private System.Windows.Forms.Button btn_RestoreData;
		private System.Windows.Forms.Button btn_BackupData;
		private System.Windows.Forms.Button btn_MoreOptions;
		private System.Windows.Forms.Label lbl_RemoveBook;
		private System.Windows.Forms.Label lbl_RemoveUser;
		private System.Windows.Forms.Button btn_ActivateRemoveBook;
		private System.Windows.Forms.NumericUpDown numeric_RemoveBookID;
		private System.Windows.Forms.TextBox txtbox_RemoveUser;
		private System.Windows.Forms.Button btn_ActivateRemoveUser;
	}
}