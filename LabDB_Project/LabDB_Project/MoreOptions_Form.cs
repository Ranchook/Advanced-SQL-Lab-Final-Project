using HW3_labDB;
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

namespace LabDB_Project
{
	public partial class MoreOptions_Form : Form
	{
		public SqlConnection mySqlCon;
		public String admin_Mail;
		public MoreOptions_Form(Login_Form parentForm, String admin_mail)
		{
			InitializeComponent();
			mySqlCon = parentForm.userSQLCon;
			admin_Mail = admin_mail;
			lbl_Result.Text = "";

			FillUsersComboBox();
			radio_Author.CheckedChanged += Radio_CheckedChanged;

			void Radio_CheckedChanged(object sender, EventArgs e)
			{
				if(radio_Author.Checked)
				{
					lbl_Result.Text = "User's Author of the Month:";
					String[] colNames = { "first_name", "last_name", "book_name", "author_name" };
					fillListView("GetBooksOfMostLoanedAuthor_PerUser", colNames, combo_Users.Text);
				}
				else if(radio_Genre.Checked)
				{
					lbl_Result.Text = "User's Genre of the Month:";
					String[] colNames = { "first_name", "last_name", "book_name", "genre_name" };
					fillListView("GetBooksOfMostLoanedGenre_PerUser", colNames, combo_Users.Text);
				}
			}
		}

		private void combo_Users_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (radio_Author.Checked)
			{
				lbl_Result.Text = "User's Author of the Month:";
				String[] colNames = { "first_name", "last_name", "book_name", "author_name" };
				fillListView("GetBooksOfMostLoanedAuthor_PerUser", colNames, combo_Users.Text);
			}
			else if (radio_Genre.Checked)
			{
				lbl_Result.Text = "User's Genre of the Month:";
				String[] colNames = { "first_name", "last_name", "book_name", "genre_name" };
				fillListView("GetBooksOfMostLoanedGenre_PerUser", colNames, combo_Users.Text);
			}
		}

		private void date_MonthPick_ValueChanged(object sender, EventArgs e)
		{
			if (radio_Author.Checked)
			{
				lbl_Result.Text = "User's Author of the Month:";
				String[] colNames = { "first_name", "last_name", "book_name", "author_name" };
				fillListView("GetBooksOfMostLoanedAuthor_PerUser", colNames, combo_Users.Text);
			}
			else if (radio_Genre.Checked)
			{
				lbl_Result.Text = "User's Genre of the Month:";
				String[] colNames = { "first_name", "last_name", "book_name", "genre_name" };
				fillListView("GetBooksOfMostLoanedGenre_PerUser", colNames, combo_Users.Text);
			}
		}
		void FillUsersComboBox()
		{
			mySqlCon.Open();
			SqlCommand cmd = new SqlCommand("SELECT email FROM users WHERE user_role <> 3", mySqlCon);
			SqlDataReader reader = cmd.ExecuteReader();

			// Loop through each record
			while (reader.Read())
			{
				combo_Users.Items.Add(reader["email"].ToString());
			}

			reader.Close();
			mySqlCon.Close();
			combo_Users.SelectedIndex = 0;
		}
		private void fillListView(string procedureName, string[] columnNames, string user_mail)
		{
			mySqlCon.Open();

			SqlCommand cmd = new SqlCommand(procedureName, mySqlCon);
			cmd.Parameters.Add(new SqlParameter("@TargetMonth",date_MonthPick.Value.Month));
			cmd.Parameters.Add(new SqlParameter("@TargetYear", date_MonthPick.Value.Year));
			cmd.Parameters.Add(new SqlParameter("@user_email", user_mail));
			cmd.CommandType = CommandType.StoredProcedure;

			SqlDataReader reader = cmd.ExecuteReader();

			listView_Result.Items.Clear(); // Clear previous entries
			listView_Result.Columns.Clear(); // Clear previous columns			

			foreach (string columnName in columnNames)
			{
				listView_Result.Columns.Add(columnName, 100);
			}

			listView_Result.GridLines = true;
			listView_Result.View = View.Details;

			// Fill the ListView
			if (reader.HasRows)
			{
				if (reader.FieldCount == columnNames.Length)  // Make sure the field count matches
				{
					while (reader.Read())
					{
						ListViewItem item = new ListViewItem(reader[columnNames[0]].ToString());
						for (int i = 1; i < columnNames.Length; i++)
						{
							item.SubItems.Add(reader[columnNames[i]].ToString());
						}
						listView_Result.Items.Add(item);
					}
				}
				else
				{
					MessageBox.Show("No data found!");
				}
			}
			else
			{
				MessageBox.Show("No data found!");
			}
			mySqlCon.Close();
		}
	}
}
