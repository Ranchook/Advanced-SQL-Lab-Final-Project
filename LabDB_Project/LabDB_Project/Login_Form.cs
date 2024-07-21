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
	public partial class Login_Form : Form
	{
		public SqlConnection mySqlCon;
		public Main_Form parentForm;
		public SqlConnection userSQLCon;
		public Login_Form(Main_Form parent_Form)
		{
			InitializeComponent();
			mySqlCon = parent_Form.sqlCon;
			parentForm = parent_Form;
		}

		private void btn_login_Click(object sender, EventArgs e)
		{
			mySqlCon.Open();

			SqlCommand cmdLogin = new SqlCommand("user_check", mySqlCon);
			cmdLogin.CommandType = CommandType.StoredProcedure;

			cmdLogin.Parameters.AddWithValue("@user_email", txtbox_MailLogin.Text);
			cmdLogin.Parameters.AddWithValue("@psw", txtbox_PassLogin.Text);

			// Create an output parameter to get the result from SQL
			SqlParameter outputParam = new SqlParameter("@result", SqlDbType.NVarChar, 500);
			outputParam.Direction = ParameterDirection.Output;
			cmdLogin.Parameters.Add(outputParam);

			cmdLogin.ExecuteNonQuery();

			// Get the output parameter value
			string result = cmdLogin.Parameters["@result"].Value.ToString();
			
			mySqlCon.Close();

			MessageBox.Show("Result from database: " + result);

			if (result == "Login Successful" ||
				result == "Login Successful - User was previously blocked but is now unblocked after 20 minutes.")
			{
				string userId = txtbox_MailLogin.Text;
				string password = txtbox_PassLogin.Text;

				string connString = $@"Data Source=RAN-COMPUTER\SQLEXPRESS; Initial Catalog=HOMEWORK_DB; Integrated Security=True; User id={userId}; Password={password};";

                userSQLCon = new SqlConnection(connString);

                // Fetch the user_role for this user
                try
                {
                    userSQLCon.Open();

					SqlCommand cmdUserRole = new SqlCommand("SELECT user_role FROM users WHERE email = @email", userSQLCon);
					cmdUserRole.Parameters.AddWithValue("@email", txtbox_MailLogin.Text);

					int user_role = Convert.ToInt32(cmdUserRole.ExecuteScalar());

					userSQLCon.Close();

					if (user_role == 2)
					{
						User_Form UserForm = new User_Form(this, txtbox_MailLogin.Text);
						UserForm.Show();
					}
					else if (user_role == 3)
					{
						Admin_Form adminForm = new Admin_Form(this, txtbox_MailLogin.Text);
						adminForm.Show();
					}
				}
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
				this.Close();
			}
		}

		private bool EmailExists(string email)
		{
			mySqlCon.Open();

			string query = "SELECT COUNT(*) FROM users WHERE email = @user_email";
			using (SqlCommand command = new SqlCommand(query, mySqlCon))
			{
				command.Parameters.AddWithValue("@user_email", email);

				int count = Convert.ToInt32(command.ExecuteScalar());
				mySqlCon.Close();
				return count > 0;
			}
		}
		
		private void btn_ForgotPass_Click(object sender, EventArgs e)
		{
			string emailToCheck = txtbox_MailLogin.Text;

			if (emailToCheck == "")
			{
				MessageBox.Show("Please put mail address");
				return;
			}
			if (EmailExists(emailToCheck))
			{
				ForgotPass forgotpass = new ForgotPass(parentForm, txtbox_MailLogin.Text);
				forgotpass.Show();
			}
			else
			{
				MessageBox.Show("Email does not exist in the database.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
