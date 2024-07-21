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
	public partial class AddBook_Form : Form
	{
		public SqlConnection mySqlCon;
		public String admin_Mail;
		Login_Form parent_Form;
		public AddBook_Form(Login_Form parentForm, String admin_mail)
		{
			InitializeComponent();
			mySqlCon = parentForm.userSQLCon;
			admin_Mail = admin_mail;
			parent_Form = parentForm;
			// put next book id in the id field
			numeric_BookID.Value = GetNextExpectedID(mySqlCon, "books", "book_id");
			// fill genre combo box
			FillGenreComboBox();
		}

		private void btn_AddBook_Click(object sender, EventArgs e)
		{
			// Create a SQL command to execute the stored procedure
			SqlCommand cmd = new SqlCommand("AddABook", mySqlCon);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("admin_email", admin_Mail);
			cmd.Parameters.AddWithValue("book_name", txtbox_BookName.Text);
			cmd.Parameters.AddWithValue("author_name", txtbox_Author.Text);
			cmd.Parameters.AddWithValue("genre_name", combo_Genre.Text);
			cmd.Parameters.AddWithValue("year_published", date_PublishYear.Value.Year);
			if(combo_Genre.Text == "" ||
				txtbox_BookName.Text == "" ||
				txtbox_Author.Text == "")
			{
				MessageBox.Show("Please fill all the fields!");
				return;
			}
			mySqlCon.Open();
			
			SqlDataReader reader = cmd.ExecuteReader();

			mySqlCon.Close();

			MessageBox.Show("Book Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Close();
		}

		private void FillGenreComboBox()
		{
			mySqlCon.Open();

			SqlCommand cmd = new SqlCommand("SELECT name FROM genre", mySqlCon);

			SqlDataReader reader = cmd.ExecuteReader();

			// Loop through each record
			while (reader.Read())
			{
				combo_Genre.Items.Add(reader["name"].ToString());
			}

			// Close the reader and the connection
			reader.Close();
			mySqlCon.Close();
			combo_Genre.SelectedIndex = 0;
		}

		int GetNextExpectedID(SqlConnection sql_con, string table_name, String first_col_name)
		{
			int nextID = 1; // Default if there are no records

			// Query the database to get the last ID using the first column
			string query = "SELECT MAX([" + first_col_name + "]) FROM " + table_name;
			if (sql_con.State != ConnectionState.Open)
			{
				sql_con = new SqlConnection(sql_con.ConnectionString);
				sql_con.Open();
			}
			SqlCommand sql_cmd = sql_con.CreateCommand();
			sql_cmd.CommandText = query;
			object result = sql_cmd.ExecuteScalar();
			sql_con.Close();

			if (result != DBNull.Value)
			{
				int lastID = Convert.ToInt32(result);
				nextID = lastID + 1;
			}
			return nextID;
		}
	}
}
