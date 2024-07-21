namespace LabDB_Project
{
	partial class MoreOptions_Form
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
			this.date_MonthPick = new System.Windows.Forms.DateTimePicker();
			this.listView_Result = new System.Windows.Forms.ListView();
			this.lbl_Result = new System.Windows.Forms.Label();
			this.lbl_Instruction = new System.Windows.Forms.Label();
			this.lbl_SelectUser = new System.Windows.Forms.Label();
			this.combo_Users = new System.Windows.Forms.ComboBox();
			this.radio_Author = new System.Windows.Forms.RadioButton();
			this.radio_Genre = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// date_MonthPick
			// 
			this.date_MonthPick.CustomFormat = "MMMM-yyyy";
			this.date_MonthPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.date_MonthPick.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.date_MonthPick.Location = new System.Drawing.Point(30, 463);
			this.date_MonthPick.Name = "date_MonthPick";
			this.date_MonthPick.Size = new System.Drawing.Size(300, 28);
			this.date_MonthPick.TabIndex = 2;
			this.date_MonthPick.ValueChanged += new System.EventHandler(this.date_MonthPick_ValueChanged);
			// 
			// listView_Result
			// 
			this.listView_Result.HideSelection = false;
			this.listView_Result.Location = new System.Drawing.Point(400, 122);
			this.listView_Result.Name = "listView_Result";
			this.listView_Result.Size = new System.Drawing.Size(717, 469);
			this.listView_Result.TabIndex = 3;
			this.listView_Result.UseCompatibleStateImageBehavior = false;
			// 
			// lbl_Result
			// 
			this.lbl_Result.AutoSize = true;
			this.lbl_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.lbl_Result.Location = new System.Drawing.Point(395, 52);
			this.lbl_Result.Name = "lbl_Result";
			this.lbl_Result.Size = new System.Drawing.Size(80, 26);
			this.lbl_Result.TabIndex = 4;
			this.lbl_Result.Text = "Result:";
			// 
			// lbl_Instruction
			// 
			this.lbl_Instruction.AutoSize = true;
			this.lbl_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.lbl_Instruction.Location = new System.Drawing.Point(26, 415);
			this.lbl_Instruction.Name = "lbl_Instruction";
			this.lbl_Instruction.Size = new System.Drawing.Size(233, 26);
			this.lbl_Instruction.TabIndex = 7;
			this.lbl_Instruction.Text = "Please select a month:";
			// 
			// lbl_SelectUser
			// 
			this.lbl_SelectUser.AutoSize = true;
			this.lbl_SelectUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.lbl_SelectUser.Location = new System.Drawing.Point(26, 282);
			this.lbl_SelectUser.Name = "lbl_SelectUser";
			this.lbl_SelectUser.Size = new System.Drawing.Size(214, 26);
			this.lbl_SelectUser.TabIndex = 13;
			this.lbl_SelectUser.Text = "Please select a user:";
			// 
			// combo_Users
			// 
			this.combo_Users.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Users.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.combo_Users.FormattingEnabled = true;
			this.combo_Users.Location = new System.Drawing.Point(32, 332);
			this.combo_Users.Name = "combo_Users";
			this.combo_Users.Size = new System.Drawing.Size(319, 30);
			this.combo_Users.TabIndex = 20;
			this.combo_Users.SelectedIndexChanged += new System.EventHandler(this.combo_Users_SelectedIndexChanged);
			// 
			// radio_Author
			// 
			this.radio_Author.AutoSize = true;
			this.radio_Author.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.radio_Author.Location = new System.Drawing.Point(31, 68);
			this.radio_Author.Name = "radio_Author";
			this.radio_Author.Size = new System.Drawing.Size(244, 26);
			this.radio_Author.TabIndex = 21;
			this.radio_Author.TabStop = true;
			this.radio_Author.Text = "User\'s Author of the Month";
			this.radio_Author.UseVisualStyleBackColor = true;
			// 
			// radio_Genre
			// 
			this.radio_Genre.AutoSize = true;
			this.radio_Genre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.radio_Genre.Location = new System.Drawing.Point(31, 171);
			this.radio_Genre.Name = "radio_Genre";
			this.radio_Genre.Size = new System.Drawing.Size(241, 26);
			this.radio_Genre.TabIndex = 22;
			this.radio_Genre.TabStop = true;
			this.radio_Genre.Text = "User\'s Genre of the Month";
			this.radio_Genre.UseVisualStyleBackColor = true;
			// 
			// MoreOptions_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1162, 673);
			this.Controls.Add(this.radio_Genre);
			this.Controls.Add(this.radio_Author);
			this.Controls.Add(this.combo_Users);
			this.Controls.Add(this.lbl_SelectUser);
			this.Controls.Add(this.lbl_Instruction);
			this.Controls.Add(this.lbl_Result);
			this.Controls.Add(this.listView_Result);
			this.Controls.Add(this.date_MonthPick);
			this.Name = "MoreOptions_Form";
			this.Text = "MoreOptions_Form";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DateTimePicker date_MonthPick;
		private System.Windows.Forms.ListView listView_Result;
		private System.Windows.Forms.Label lbl_Result;
		private System.Windows.Forms.Label lbl_Instruction;
		private System.Windows.Forms.Label lbl_SelectUser;
		private System.Windows.Forms.ComboBox combo_Users;
		private System.Windows.Forms.RadioButton radio_Author;
		private System.Windows.Forms.RadioButton radio_Genre;
	}
}