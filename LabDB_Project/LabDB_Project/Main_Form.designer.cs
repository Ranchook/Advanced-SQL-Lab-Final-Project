namespace HW3_labDB
{
	partial class Main_Form
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
			this.btn_LoginForm = new System.Windows.Forms.Button();
			this.btn_RegisterForm = new System.Windows.Forms.Button();
			this.lblSearchBook = new System.Windows.Forms.Label();
			this.Combo_Cateogry1 = new System.Windows.Forms.ComboBox();
			this.txtbox_Category1 = new System.Windows.Forms.TextBox();
			this.btn_AddSearchCategory = new System.Windows.Forms.Button();
			this.btn_SearchBooks = new System.Windows.Forms.Button();
			this.txtbox_Category2 = new System.Windows.Forms.TextBox();
			this.Combo_Cateogry2 = new System.Windows.Forms.ComboBox();
			this.txtbox_Category3 = new System.Windows.Forms.TextBox();
			this.Combo_Cateogry3 = new System.Windows.Forms.ComboBox();
			this.listView_SearchRes = new System.Windows.Forms.ListView();
			this.btn_ClearSearch = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_LoginForm
			// 
			this.btn_LoginForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.btn_LoginForm.Location = new System.Drawing.Point(37, 327);
			this.btn_LoginForm.Name = "btn_LoginForm";
			this.btn_LoginForm.Size = new System.Drawing.Size(125, 74);
			this.btn_LoginForm.TabIndex = 0;
			this.btn_LoginForm.Text = "Login";
			this.btn_LoginForm.UseVisualStyleBackColor = true;
			this.btn_LoginForm.Click += new System.EventHandler(this.btn_LoginForm_Click);
			// 
			// btn_RegisterForm
			// 
			this.btn_RegisterForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.btn_RegisterForm.Location = new System.Drawing.Point(37, 453);
			this.btn_RegisterForm.Name = "btn_RegisterForm";
			this.btn_RegisterForm.Size = new System.Drawing.Size(125, 75);
			this.btn_RegisterForm.TabIndex = 1;
			this.btn_RegisterForm.Text = "Register";
			this.btn_RegisterForm.UseVisualStyleBackColor = true;
			this.btn_RegisterForm.Click += new System.EventHandler(this.btn_RegisterForm_Click);
			// 
			// lblSearchBook
			// 
			this.lblSearchBook.AutoSize = true;
			this.lblSearchBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.lblSearchBook.Location = new System.Drawing.Point(32, 47);
			this.lblSearchBook.Name = "lblSearchBook";
			this.lblSearchBook.Size = new System.Drawing.Size(158, 26);
			this.lblSearchBook.TabIndex = 2;
			this.lblSearchBook.Text = "Search a book:";
			// 
			// Combo_Cateogry1
			// 
			this.Combo_Cateogry1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Combo_Cateogry1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.Combo_Cateogry1.FormattingEnabled = true;
			this.Combo_Cateogry1.Location = new System.Drawing.Point(248, 47);
			this.Combo_Cateogry1.Name = "Combo_Cateogry1";
			this.Combo_Cateogry1.Size = new System.Drawing.Size(297, 30);
			this.Combo_Cateogry1.TabIndex = 4;
			// 
			// txtbox_Category1
			// 
			this.txtbox_Category1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.txtbox_Category1.Location = new System.Drawing.Point(607, 47);
			this.txtbox_Category1.Name = "txtbox_Category1";
			this.txtbox_Category1.Size = new System.Drawing.Size(605, 28);
			this.txtbox_Category1.TabIndex = 5;
			// 
			// btn_AddSearchCategory
			// 
			this.btn_AddSearchCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.btn_AddSearchCategory.Location = new System.Drawing.Point(945, 247);
			this.btn_AddSearchCategory.Name = "btn_AddSearchCategory";
			this.btn_AddSearchCategory.Size = new System.Drawing.Size(125, 74);
			this.btn_AddSearchCategory.TabIndex = 6;
			this.btn_AddSearchCategory.Text = "Add Search Category";
			this.btn_AddSearchCategory.UseVisualStyleBackColor = true;
			this.btn_AddSearchCategory.Click += new System.EventHandler(this.btn_AddSearchCategory_Click);
			// 
			// btn_SearchBooks
			// 
			this.btn_SearchBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.btn_SearchBooks.Location = new System.Drawing.Point(1099, 247);
			this.btn_SearchBooks.Name = "btn_SearchBooks";
			this.btn_SearchBooks.Size = new System.Drawing.Size(125, 74);
			this.btn_SearchBooks.TabIndex = 7;
			this.btn_SearchBooks.Text = "Search";
			this.btn_SearchBooks.UseVisualStyleBackColor = true;
			this.btn_SearchBooks.Click += new System.EventHandler(this.btn_SearchBooks_Click);
			// 
			// txtbox_Category2
			// 
			this.txtbox_Category2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.txtbox_Category2.Location = new System.Drawing.Point(607, 121);
			this.txtbox_Category2.Name = "txtbox_Category2";
			this.txtbox_Category2.Size = new System.Drawing.Size(605, 28);
			this.txtbox_Category2.TabIndex = 9;
			// 
			// Combo_Cateogry2
			// 
			this.Combo_Cateogry2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Combo_Cateogry2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.Combo_Cateogry2.FormattingEnabled = true;
			this.Combo_Cateogry2.Location = new System.Drawing.Point(248, 121);
			this.Combo_Cateogry2.Name = "Combo_Cateogry2";
			this.Combo_Cateogry2.Size = new System.Drawing.Size(297, 30);
			this.Combo_Cateogry2.TabIndex = 8;
			// 
			// txtbox_Category3
			// 
			this.txtbox_Category3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.txtbox_Category3.Location = new System.Drawing.Point(607, 196);
			this.txtbox_Category3.Name = "txtbox_Category3";
			this.txtbox_Category3.Size = new System.Drawing.Size(605, 28);
			this.txtbox_Category3.TabIndex = 11;
			// 
			// Combo_Cateogry3
			// 
			this.Combo_Cateogry3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Combo_Cateogry3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.Combo_Cateogry3.FormattingEnabled = true;
			this.Combo_Cateogry3.Location = new System.Drawing.Point(248, 196);
			this.Combo_Cateogry3.Name = "Combo_Cateogry3";
			this.Combo_Cateogry3.Size = new System.Drawing.Size(297, 30);
			this.Combo_Cateogry3.TabIndex = 10;
			// 
			// listView_SearchRes
			// 
			this.listView_SearchRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
			this.listView_SearchRes.HideSelection = false;
			this.listView_SearchRes.Location = new System.Drawing.Point(300, 327);
			this.listView_SearchRes.Name = "listView_SearchRes";
			this.listView_SearchRes.Size = new System.Drawing.Size(924, 334);
			this.listView_SearchRes.TabIndex = 12;
			this.listView_SearchRes.UseCompatibleStateImageBehavior = false;
			// 
			// btn_ClearSearch
			// 
			this.btn_ClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
			this.btn_ClearSearch.Location = new System.Drawing.Point(788, 247);
			this.btn_ClearSearch.Name = "btn_ClearSearch";
			this.btn_ClearSearch.Size = new System.Drawing.Size(125, 74);
			this.btn_ClearSearch.TabIndex = 13;
			this.btn_ClearSearch.Text = "Clear Search";
			this.btn_ClearSearch.UseVisualStyleBackColor = true;
			this.btn_ClearSearch.Click += new System.EventHandler(this.btn_ClearSearch_Click);
			// 
			// Main_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1252, 693);
			this.Controls.Add(this.btn_ClearSearch);
			this.Controls.Add(this.listView_SearchRes);
			this.Controls.Add(this.txtbox_Category3);
			this.Controls.Add(this.Combo_Cateogry3);
			this.Controls.Add(this.txtbox_Category2);
			this.Controls.Add(this.Combo_Cateogry2);
			this.Controls.Add(this.btn_SearchBooks);
			this.Controls.Add(this.btn_AddSearchCategory);
			this.Controls.Add(this.txtbox_Category1);
			this.Controls.Add(this.Combo_Cateogry1);
			this.Controls.Add(this.lblSearchBook);
			this.Controls.Add(this.btn_RegisterForm);
			this.Controls.Add(this.btn_LoginForm);
			this.Name = "Main_Form";
			this.Text = "MainForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_LoginForm;
		private System.Windows.Forms.Button btn_RegisterForm;
		private System.Windows.Forms.Label lblSearchBook;
		private System.Windows.Forms.ComboBox Combo_Cateogry1;
		private System.Windows.Forms.TextBox txtbox_Category1;
		private System.Windows.Forms.Button btn_AddSearchCategory;
		private System.Windows.Forms.Button btn_SearchBooks;
		private System.Windows.Forms.TextBox txtbox_Category2;
		private System.Windows.Forms.ComboBox Combo_Cateogry2;
		private System.Windows.Forms.TextBox txtbox_Category3;
		private System.Windows.Forms.ComboBox Combo_Cateogry3;
		private System.Windows.Forms.ListView listView_SearchRes;
		private System.Windows.Forms.Button btn_ClearSearch;
	}
}

