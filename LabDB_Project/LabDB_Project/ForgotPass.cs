using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HW3_labDB
{
    public partial class ForgotPass : Form
    {
        public SqlConnection mySqlCon;
        String user_Email;
        int question1, question2, question3; 

        public ForgotPass(Main_Form parentForm, String user_mail)
        {
            InitializeComponent();
            mySqlCon = parentForm.sqlCon;
            user_Email = user_mail;

            lbl_NewPass.Visible = false;
            txtbox_newPass.Visible = false;
            btn_SaveNewPass.Visible = false;

            // Fetch the random questions for the user
            FetchRandomQuestions();
        }

        private void FetchRandomQuestions()
        {
            mySqlCon.Open();
            SqlCommand cmd = new SqlCommand("get_random_questions", mySqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_email", user_Email);

            SqlDataReader reader = cmd.ExecuteReader();

            int index = 1;
            while (reader.Read())
            {
                int questionNumber = reader.GetInt32(0);
                string questionText = reader.GetString(1);
                Label lbl = (Label)this.Controls.Find("lbl_Q" + index, true)[0];
                lbl.Text = "Q" + questionNumber + ": " + questionText;

                // Store the question numbers
                if (index == 1) question1 = questionNumber;
                else if (index == 2) question2 = questionNumber;
                else if (index == 3) question3 = questionNumber;

                index++;
            }

            mySqlCon.Close();
        }

		private void btn_SaveNewPass_Click_1(object sender, EventArgs e)
		{
			mySqlCon.Open();
			SqlCommand cmd = new SqlCommand("reset_user_password", mySqlCon);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@user_email", user_Email);
			cmd.Parameters.AddWithValue("@newPassword", txtbox_newPass.Text);
			cmd.ExecuteNonQuery();

			mySqlCon.Close();

			string changePasswordQuery = $"ALTER LOGIN {user_Email} WITH PASSWORD = '{txtbox_newPass.Text}'";
			mySqlCon.Open();
			SqlCommand cmd2 = new SqlCommand(changePasswordQuery, mySqlCon);
			cmd.ExecuteNonQuery();
            mySqlCon.Close();

			MessageBox.Show("Password reset successfully!");
			this.Close();  // Close the ForgotPass form
		}

		private void btn_RestorePass_Click(object sender, EventArgs e)
        {
            mySqlCon.Open();
            SqlCommand cmd = new SqlCommand("validate_answers", mySqlCon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user_email", user_Email);
            cmd.Parameters.AddWithValue("@answer1", txtbox_Q1.Text);
            cmd.Parameters.AddWithValue("@answer2", txtbox_Q2.Text);
            cmd.Parameters.AddWithValue("@answer3", txtbox_Q3.Text);
            cmd.Parameters.AddWithValue("@question1", question1);
            cmd.Parameters.AddWithValue("@question2", question2);
            cmd.Parameters.AddWithValue("@question3", question3);

            SqlParameter outputParam = new SqlParameter("@isCorrect", SqlDbType.Bit);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);

            cmd.ExecuteNonQuery();

            bool isCorrect = Convert.ToBoolean(cmd.Parameters["@isCorrect"].Value);

            mySqlCon.Close();

            if (isCorrect)
            {
                lbl_NewPass.Visible = true;
                txtbox_newPass.Visible = true;
                btn_SaveNewPass.Visible = true;

                lbl_Q1.Visible = false;
                lbl_Q2.Visible = false;
                lbl_Q3.Visible = false;
                txtbox_Q1.Visible = false;
                txtbox_Q2.Visible = false;
                txtbox_Q3.Visible = false;
                btn_SubmitAnswer.Visible = false;
            }
            else
            {
                MessageBox.Show("Invalid answers provided. Please try again.");
            }
        }

    }
}
