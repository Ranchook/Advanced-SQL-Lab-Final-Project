using LabDB_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW3_labDB
{
	public partial class User_Form : Form
	{
        public SqlConnection mySqlCon;
        public String user_Mail;
        public User_Form(Login_Form parentForm, String user_mail)
		{
            InitializeComponent();
            mySqlCon = parentForm.userSQLCon;
            user_Mail = user_mail;
			numeric_BookID.Visible = false;
			lbl_ReturnBook.Visible = false;
			btn_ActivateReturn.Visible = false;
			lbl_LoanBook.Visible = false;
			btn_ActivateLoan.Visible = false;
		}

		private void btn_LoanBook_Click(object sender, EventArgs e)
		{
			default_state();
			lbl_LoanBook.Visible = true;
			btn_ActivateLoan.Visible = true;
			numeric_BookID.Visible = true;
			lbl_UserResult.Text = "Library Books list:";

			String[] colNames = { "book_id", "book_name", "author_name", "genre_name", "year_published", "is_loaned" };
			fillListView("show_all_books", colNames, user_Mail);
		}

		private void btn_ReturnBook_Click(object sender, EventArgs e)
		{

			default_state();
			lbl_ReturnBook.Visible = true;
			btn_ActivateReturn.Visible = true;
			numeric_BookID.Visible = true;

			lbl_UserResult.Text = "My Books list:";
			String[] colNames = { "book_id", "book_name", "author_name", "loan_date", "loan_return_date", "is_returned" };
			fillListViewFromView("UserLoanedBooks", colNames, user_Mail);


		}

		private void btn_LoginLog_Click(object sender, EventArgs e)
		{
			default_state();
			string[] columnNames = { "log_time", "is_success" };
			fillListViewFromView("UserLoginHistory", columnNames, user_Mail);
			lbl_UserResult.Text = "My Login History:";
		}

		private void btn_ActivateLoan_Click(object sender, EventArgs e)
		{
			mySqlCon.Open();

			try
			{
				SqlCommand cmd = new SqlCommand("LoanABook", mySqlCon);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue(@"book_id", numeric_BookID.Value);
				cmd.Parameters.AddWithValue("@user_email", user_Mail);
				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				MessageBox.Show("SQL error occurred: " + ex.Message);
				return;
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
			MessageBox.Show("Book Loaned!");
		}

		private void btn_ActivateReturn_Click(object sender, EventArgs e)
		{
			mySqlCon.Open();
			try
			{

			SqlCommand cmd = new SqlCommand("ReturnABook", mySqlCon);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue(@"book_id", numeric_BookID.Value);
			cmd.Parameters.AddWithValue("@user_email", user_Mail);
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
			MessageBox.Show("Book Returned!");
		}

		private void fillListView(string procedureName, string[] columnNames, string user_mail)
		{
			// Open the SQL connection
			mySqlCon.Open();

			// Create a SQL command to execute the stored procedure
			SqlCommand cmd = new SqlCommand(procedureName, mySqlCon);
			cmd.CommandType = CommandType.StoredProcedure;

			if(procedureName != "show_all_books")
				cmd.Parameters.AddWithValue("@user_email", user_mail);


			// Execute the stored procedure and capture the results
			SqlDataReader reader = cmd.ExecuteReader();

			// Configure the ListView
			listView_UserList.Items.Clear(); // Clear previous entries
			listView_UserList.Columns.Clear(); // Clear previous columns			

			foreach (string columnName in columnNames)
			{
				listView_UserList.Columns.Add(columnName, 100);
			}

			listView_UserList.GridLines = true;
			listView_UserList.View = View.Details;

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
					listView_UserList.Items.Add(item);
				}
			}
			else
			{
				MessageBox.Show("No data found!");
			}

			// Close the SQL connection
			mySqlCon.Close();
		}


		private void fillListViewFromView(string viewName, string[] columnNames, string user_mail)
		{
			mySqlCon.Open();

			SqlCommand cmd = new SqlCommand($"SELECT * FROM {viewName} WHERE email = @user_email", mySqlCon);
			cmd.Parameters.AddWithValue("@user_email", user_mail);

			SqlDataReader reader = cmd.ExecuteReader();

			listView_UserList.Items.Clear(); // Clear previous entries
			listView_UserList.Columns.Clear(); // Clear previous columns			

			foreach (string columnName in columnNames)
			{
				listView_UserList.Columns.Add(columnName, 100);
			}

			listView_UserList.GridLines = true;
			listView_UserList.View = View.Details;

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
					listView_UserList.Items.Add(item);
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
			listView_UserList.Items.Clear();
			listView_UserList.Columns.Clear();
			lbl_LoanBook.Visible = false;
			lbl_ReturnBook.Visible = false;
			btn_ActivateLoan.Visible = false;
			btn_ActivateReturn.Visible = false;
			numeric_BookID.Visible = false;
			lbl_UserResult.Text = "";
		}
	}
}