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
	public partial class Register_Form : Form
	{
		public SqlConnection mySqlCon;
		public Main_Form parentForm;
		Dictionary<int, string> randomQuestions = new Dictionary<int, string>();  // To store the random questions

		public Register_Form(Main_Form parent_Form)
		{
			InitializeComponent();
			mySqlCon = parent_Form.sqlCon;
			parentForm = parent_Form;

			// Hide the questions and answers
			lbl_RegQ1.Visible = false;
			lbl_RegQ2.Visible = false;
			lbl_RegQ3.Visible = false;
			lbl_RegQ4.Visible = false;
			lbl_RegQ5.Visible = false;
			btn_Submit.Visible = false;
			txtbox_RegQ1.Visible = false;
			txtbox_RegQ2.Visible = false;
			txtbox_RegQ3.Visible = false;
			txtbox_RegQ4.Visible = false;
			txtbox_RegQ5.Visible = false;
		}

		public void FetchRandomQuestions()
		{
			randomQuestions.Clear();  // Clear previous questions

			if (mySqlCon.State == ConnectionState.Closed)
			{
				mySqlCon.Open();
			}

			// Create a SQL command to fetch 5 random questions along with their IDs
			SqlCommand cmdFetchQuestions = new SqlCommand("SELECT TOP 5 question_number, question FROM restore_questions ORDER BY NEWID()", mySqlCon);

			SqlDataReader reader = cmdFetchQuestions.ExecuteReader();

			while (reader.Read())
			{
				// Add the question and its ID to the dictionary
				int id = reader.GetInt32(0);
				string question = reader.GetString(1);
				randomQuestions[id] = question;
			}
			mySqlCon.Close();
		}

		private void btn_Next_Click(object sender, EventArgs e)
		{
			if (txtbox_RegMail.Text == "" || txtbox_RegFirstName.Text == ""
			|| txtbox_RegPass.Text == "" || txtbox_LastName.Text == "")
			{
				MessageBox.Show("Please fill all the fields");
				return;
			}
			FetchRandomQuestions();  // Fetch random questions

			int index = 1;  // For finding controls like lbl_RegQ1, lbl_RegQ2, etc.
			foreach (var question in randomQuestions.Values)
			{
				Label lbl = (Label)this.Controls.Find("lbl_RegQ" + index, true).FirstOrDefault();
				if (lbl != null)
					lbl.Text = question;
				index++;
			}

			// Show the questions and answers
			lbl_RegQ1.Visible = true;
			lbl_RegQ2.Visible = true;
			lbl_RegQ3.Visible = true;
			lbl_RegQ4.Visible = true;
			lbl_RegQ5.Visible = true;
			btn_Submit.Visible = true;
			txtbox_RegQ1.Visible = true;
			txtbox_RegQ2.Visible = true;
			txtbox_RegQ3.Visible = true;
			txtbox_RegQ4.Visible = true;
			txtbox_RegQ5.Visible = true;

			// Hide the next button
			btn_Next.Visible = false;

			// Hide the registration details
			lbl_RegMail.Visible = false;
			lbl_RegFirstName.Visible = false;
			lbl_RegLastName.Visible = false;
			lbl_RegDOB.Visible = false;
			lbl_RegPass.Visible = false;
			txtbox_RegMail.Visible = false;
			txtbox_RegFirstName.Visible = false;
			txtbox_RegPass.Visible = false;
			date_RegDOB.Visible = false;
			txtbox_LastName.Visible = false;
		}

		private void btn_Submit_Click(object sender, EventArgs e)
		{
			mySqlCon.Open();

			SqlCommand cmdCreateUser = new SqlCommand("create_user", mySqlCon);
			cmdCreateUser.CommandType = CommandType.StoredProcedure;

			cmdCreateUser.Parameters.AddWithValue("@user_email", txtbox_RegMail.Text);
			cmdCreateUser.Parameters.AddWithValue("@first_name", txtbox_RegFirstName.Text);
			cmdCreateUser.Parameters.AddWithValue("@last_name", txtbox_RegPass.Text);
			cmdCreateUser.Parameters.AddWithValue("@birth_date", date_RegDOB.Value);
			cmdCreateUser.Parameters.AddWithValue("@password", txtbox_LastName.Text);

			cmdCreateUser.ExecuteNonQuery();
			SqlCommand cmdInsertQuestions = new SqlCommand("insert_questions", mySqlCon);
			cmdInsertQuestions.CommandType = CommandType.StoredProcedure;

			cmdInsertQuestions.Parameters.AddWithValue("@user_email", txtbox_RegMail.Text);

			int index = 1;  // For naming parameters like @random1, @random2, etc.
			foreach (var key in randomQuestions.Keys)
			{
				cmdInsertQuestions.Parameters.AddWithValue($"@random{index}", key);
				index++;
			}

			// 2. Run the insert_questions stored procedure
			cmdInsertQuestions.Parameters.AddWithValue("@answer1", txtbox_RegQ1.Text);
			cmdInsertQuestions.Parameters.AddWithValue("@answer2", txtbox_RegQ2.Text);
			cmdInsertQuestions.Parameters.AddWithValue("@answer3", txtbox_RegQ3.Text);
			cmdInsertQuestions.Parameters.AddWithValue("@answer4", txtbox_RegQ4.Text);
			cmdInsertQuestions.Parameters.AddWithValue("@answer5", txtbox_RegQ5.Text);

			cmdInsertQuestions.ExecuteNonQuery();

			// Create SQL Server login
			string createLoginCommand = $"CREATE LOGIN [{txtbox_RegMail.Text}] WITH PASSWORD = '{txtbox_RegPass.Text}';";
			SqlCommand cmdCreateLogin = new SqlCommand(createLoginCommand, mySqlCon);
			cmdCreateLogin.ExecuteNonQuery();

			string createUserCommand = $"CREATE USER [{txtbox_RegMail.Text}] FOR LOGIN [{txtbox_RegMail.Text}];";
            SqlCommand cmdCreateUserSQL = new SqlCommand(createUserCommand, mySqlCon);
            cmdCreateUserSQL.ExecuteNonQuery();

            // Grant permissions to 'books' table
            string grantBooksPermission = $"GRANT SELECT ON books TO [{txtbox_RegMail.Text}];";
            SqlCommand cmdGrantBooks = new SqlCommand(grantBooksPermission, mySqlCon);
            cmdGrantBooks.ExecuteNonQuery();

            // Grant permissions to 'UserLoanedBooks' view
            string grantUserLoanedBooksPermission = $"GRANT SELECT ON UserLoanedBooks TO [{txtbox_RegMail.Text}];";
            SqlCommand cmdGrantUserLoanedBooks = new SqlCommand(grantUserLoanedBooksPermission, mySqlCon);
            cmdGrantUserLoanedBooks.ExecuteNonQuery();

            // Grant permissions to 'UserLoginHistory' view
            string grantUserLoginHistoryPermission = $"GRANT SELECT ON UserLoginHistory TO [{txtbox_RegMail.Text}];";
            SqlCommand cmdGrantUserLoginHistory = new SqlCommand(grantUserLoginHistoryPermission, mySqlCon);
            cmdGrantUserLoginHistory.ExecuteNonQuery();


            mySqlCon.Close();

            MessageBox.Show("Registration successful!");
            this.Close();
        }
	}
}
