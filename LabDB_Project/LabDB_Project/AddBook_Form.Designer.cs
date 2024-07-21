namespace LabDB_Project
{
	partial class AddBook_Form
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
			this.btn_AddBook = new System.Windows.Forms.Button();
			this.txtbox_BookName = new System.Windows.Forms.TextBox();
			this.txtbox_Author = new System.Windows.Forms.TextBox();
			this.combo_Genre = new System.Windows.Forms.ComboBox();
			this.date_PublishYear = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numeric_BookID = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numeric_BookID)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_AddBook
			// 
			this.btn_AddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.btn_AddBook.Location = new System.Drawing.Point(629, 355);
			this.btn_AddBook.Name = "btn_AddBook";
			this.btn_AddBook.Size = new System.Drawing.Size(133, 71);
			this.btn_AddBook.TabIndex = 0;
			this.btn_AddBook.Text = "Add Book";
			this.btn_AddBook.UseVisualStyleBackColor = true;
			this.btn_AddBook.Click += new System.EventHandler(this.btn_AddBook_Click);
			// 
			// txtbox_BookName
			// 
			this.txtbox_BookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.txtbox_BookName.Location = new System.Drawing.Point(274, 119);
			this.txtbox_BookName.Name = "txtbox_BookName";
			this.txtbox_BookName.Size = new System.Drawing.Size(263, 28);
			this.txtbox_BookName.TabIndex = 2;
			// 
			// txtbox_Author
			// 
			this.txtbox_Author.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.txtbox_Author.Location = new System.Drawing.Point(274, 195);
			this.txtbox_Author.Name = "txtbox_Author";
			this.txtbox_Author.Size = new System.Drawing.Size(263, 28);
			this.txtbox_Author.TabIndex = 3;
			// 
			// combo_Genre
			// 
			this.combo_Genre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_Genre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.combo_Genre.FormattingEnabled = true;
			this.combo_Genre.Location = new System.Drawing.Point(274, 270);
			this.combo_Genre.Name = "combo_Genre";
			this.combo_Genre.Size = new System.Drawing.Size(263, 30);
			this.combo_Genre.TabIndex = 4;
			// 
			// date_PublishYear
			// 
			this.date_PublishYear.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.date_PublishYear.CustomFormat = "yyyy";
			this.date_PublishYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.date_PublishYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.date_PublishYear.Location = new System.Drawing.Point(274, 355);
			this.date_PublishYear.Name = "date_PublishYear";
			this.date_PublishYear.Size = new System.Drawing.Size(105, 28);
			this.date_PublishYear.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.label1.Location = new System.Drawing.Point(98, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 22);
			this.label1.TabIndex = 6;
			this.label1.Text = "Book ID:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.label2.Location = new System.Drawing.Point(98, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 22);
			this.label2.TabIndex = 7;
			this.label2.Text = "Book Name:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.label3.Location = new System.Drawing.Point(98, 195);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 22);
			this.label3.TabIndex = 8;
			this.label3.Text = "Author:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.label4.Location = new System.Drawing.Point(98, 270);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 22);
			this.label4.TabIndex = 9;
			this.label4.Text = "Genre:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.label5.Location = new System.Drawing.Point(98, 355);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(117, 22);
			this.label5.TabIndex = 10;
			this.label5.Text = "Publish Year:";
			// 
			// numeric_BookID
			// 
			this.numeric_BookID.Enabled = false;
			this.numeric_BookID.Location = new System.Drawing.Point(274, 43);
			this.numeric_BookID.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.numeric_BookID.Name = "numeric_BookID";
			this.numeric_BookID.ReadOnly = true;
			this.numeric_BookID.Size = new System.Drawing.Size(263, 22);
			this.numeric_BookID.TabIndex = 11;
			this.numeric_BookID.TabStop = false;
			// 
			// AddBook_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.numeric_BookID);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.date_PublishYear);
			this.Controls.Add(this.combo_Genre);
			this.Controls.Add(this.txtbox_Author);
			this.Controls.Add(this.txtbox_BookName);
			this.Controls.Add(this.btn_AddBook);
			this.Name = "AddBook_Form";
			this.Text = "AddBook_Form";
			((System.ComponentModel.ISupportInitialize)(this.numeric_BookID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_AddBook;
		private System.Windows.Forms.TextBox txtbox_BookName;
		private System.Windows.Forms.TextBox txtbox_Author;
		private System.Windows.Forms.ComboBox combo_Genre;
		private System.Windows.Forms.DateTimePicker date_PublishYear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numeric_BookID;
	}
}