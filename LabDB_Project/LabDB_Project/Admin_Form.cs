using LabDB_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW3_labDB
{
	public partial class Admin_Form : Form
	{
		public SqlConnection mySqlCon;
		public String admin_Mail;
		Login_Form parent_Form;
		public Admin_Form(Login_Form parentForm, String admin_mail)
		{
			InitializeComponent();
			mySqlCon = parentForm.userSQLCon;
			admin_Mail = admin_mail;
			parent_Form = parentForm;
			default_state();
		}

        private void btn_BlockUsers_Click(object sender, EventArgs e)
        {
			default_state();
			String[] column_Names = { "email" };
			fillListView("show_blocked_users", column_Names, admin_Mail);
			lbl_ResultLabel.Text = "Blocked Users:";
		}

		private void btn_UserStatus_Click(object sender, EventArgs e)
        {
			default_state();
			String[] colNames = { "email", "last_successful_login" };
			fillListView("show_successful_login", colNames, admin_Mail);
			lbl_ResultLabel.Text = "Users Last Successful Login:";
		}

		private void btn_AddBook_Click(object sender, EventArgs e)
		{
			default_state();
			AddBook_Form addBookForm = new AddBook_Form(parent_Form, admin_Mail);
			addBookForm.Show();
		}

		private void btn_RemoveBook_Click(object sender, EventArgs e)
		{
			default_state();
			String[] colNames = { "book_id", "book_name", "author_name", "genre_name", "year_published", "is_loaned" };
			fillListView("show_all_books", colNames, admin_Mail);
			lbl_ResultLabel.Text = "Books List:";
			lbl_RemoveBook.Visible = true;
			numeric_RemoveBookID.Visible = true;
			btn_ActivateRemoveBook.Visible = true;
		}

		private void btn_RemoveUser_Click(object sender, EventArgs e)
		{
			default_state();
			lbl_ResultLabel.Text = "Users list:";
			String[] colNames = { "email", "first_name", "last_name", "birth_date"};
			fillListView("show_all_users", colNames, admin_Mail);
			lbl_ResultLabel.Text = "Users List:";
			lbl_RemoveUser.Visible = true;
			txtbox_RemoveUser.Visible = true;
			btn_ActivateRemoveUser.Visible = true;
		}

		private void btn_BackupData_Click(object sender, EventArgs e)
		{
			default_state();
			try
			{
				mySqlCon.Open();
				string backupDir = "C:\\aaa";
				string backupFile = Path.Combine(backupDir, "DatabaseBackup.bak");
				// change the following line ***** HOMEWORK_DB
				SqlCommand backupCommand = new SqlCommand("BACKUP DATABASE HOMEWORK_DB TO DISK = '" + backupFile + "'", mySqlCon);
				backupCommand.ExecuteNonQuery();
				MessageBox.Show("Backup completed!");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error during backup: " + ex.Message);
			}
			finally
			{
				mySqlCon.Close();
			}
		}

		private void btn_RestoreData_Click(object sender, EventArgs e)
		{
			default_state();
			try
			{
				mySqlCon.Open();
				string backupFile = Path.Combine("C:\\aaa", "DatabaseBackup.bak");
				// change the following line ***** HOMEWORK_DB
				SqlCommand restoreCommand = new SqlCommand("USE master; RESTORE DATABASE HOMEWORK_DB FROM DISK = '" + backupFile + "'", mySqlCon);
				restoreCommand.ExecuteNonQuery();
				MessageBox.Show("Restore completed!");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error during restore: " + ex.Message);
			}
			finally
			{
				mySqlCon.Close();
			}
		}

		private void btn_MoreOptions_Click(object sender, EventArgs e)
		{
			default_state();
			MoreOptions_Form optionsform = new MoreOptions_Form(parent_Form, admin_Mail);
			optionsform.Show();
		}

		private void btn_ActivateRemove_Click(object sender, EventArgs e)
		{
			mySqlCon.Open();
			try
			{
				SqlCommand cmd = new SqlCommand("RemoveABook", mySqlCon);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue(@"book_id", numeric_RemoveBookID.Value);
				cmd.Parameters.AddWithValue("@admin_email", admin_Mail);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred: " + ex.Message);
				return;
			}
			finally
			{
				mySqlCon.Close();
			}
			MessageBox.Show("Book Removed!");
			default_state();
		}

		private void btn_ActivateRemoveUser_Click(object sender, EventArgs e)
		{
			mySqlCon.Open();
			try
			{
				SqlCommand cmd = new SqlCommand("RemoveAUser", mySqlCon);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@user_email", txtbox_RemoveUser.Text);
				cmd.Parameters.AddWithValue("@admin_email", admin_Mail);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred: " + ex.Message);
				return;
			}
			finally
			{
				mySqlCon.Close();
			}
			MessageBox.Show("User Removed!");
			default_state();
		}
	
		private void fillListView(string procedureName, string[] columnNames, string adminEmail)
        {
			mySqlCon.Open();

			SqlCommand cmd = new SqlCommand(procedureName, mySqlCon);
			cmd.CommandType = CommandType.StoredProcedure;

			if (procedureName != "show_all_books" && procedureName != "show_all_users")
			{
				cmd.Parameters.AddWithValue("@admin_email", adminEmail);
			}

			SqlDataReader reader = cmd.ExecuteReader();

			listView_Admin.Items.Clear(); // Clear previous entries
			listView_Admin.Columns.Clear(); // Clear previous columns

			foreach (string columnName in columnNames)
			{
				listView_Admin.Columns.Add(columnName, 100);
			}

			listView_Admin.GridLines = true;
			listView_Admin.View = View.Details;

			// Fill the ListView
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					ListViewItem item = new ListViewItem(reader[columnNames[0]].ToString());
					for (int i = 1; i < columnNames.Length; i++)
					{
						item.SubItems.Add(reader[columnNames[i]].ToString());
					}
					listView_Admin.Items.Add(item);
				}
			}
			else
			{
				MessageBox.Show("No data found!");
			}

			mySqlCon.Close();
		}

		void default_state()
		{
			listView_Admin.Items.Clear();
			listView_Admin.Columns.Clear();
			lbl_ResultLabel.Text = "";
			lbl_RemoveBook.Visible = false;
			numeric_RemoveBookID.Visible = false;
			btn_ActivateRemoveBook.Visible = false;
			lbl_RemoveUser.Visible = false;
			txtbox_RemoveUser.Visible = false;
			btn_ActivateRemoveUser.Visible = false;
			txtbox_RemoveUser.Text = "";
			numeric_RemoveBookID.Value = 1;
		}
	}
}
