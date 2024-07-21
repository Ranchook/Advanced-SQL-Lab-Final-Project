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
	public partial class Main_Form : Form
	{
		public SqlConnection sqlCon = new SqlConnection(@"Data Source=RAN-COMPUTER\SQLEXPRESS;
														Initial Catalog=HOMEWORK_DB;
														Integrated Security=True;");
        public Main_Form()
		{
			InitializeComponent();
			Combo_Cateogry2.Visible = false;
			Combo_Cateogry3.Visible = false;
			txtbox_Category2.Visible = false;
			txtbox_Category3.Visible = false;
			FillSearchComboBox(Combo_Cateogry1);
			FillSearchComboBox(Combo_Cateogry2);
			FillSearchComboBox(Combo_Cateogry3);
            SetAdminPermissions();
        }

        private void SetAdminPermissions()
        {
            try
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand("AdminPermissionsLoop", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting admin permissions: " + ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void btn_LoginForm_Click(object sender, EventArgs e)
		{
			Login_Form loginform = new Login_Form(this);
			loginform.Show();
		}

		private void btn_RegisterForm_Click(object sender, EventArgs e)
		{
			Register_Form regform = new Register_Form(this);
			regform.Show();
		}

		private void btn_SearchBooks_Click(object sender, EventArgs e)
		{
			StringBuilder query = new StringBuilder("SELECT * FROM books");
			List<SqlParameter> parameters = new List<SqlParameter>();
			List<string> conditions = new List<string>();

			// For the first category
			if (!string.IsNullOrEmpty(Combo_Cateogry1.Text) && !string.IsNullOrEmpty(txtbox_Category1.Text))
			{
				conditions.Add($"{Combo_Cateogry1.Text} = @Category1");
				parameters.Add(new SqlParameter("Category1", txtbox_Category1.Text));
			}

			// For the second category
			if (Combo_Cateogry2.Visible && !string.IsNullOrEmpty(Combo_Cateogry2.Text) && !string.IsNullOrEmpty(txtbox_Category2.Text))
			{
				conditions.Add($"{Combo_Cateogry2.Text} = @Category2");
				parameters.Add(new SqlParameter("Category2", txtbox_Category2.Text));
			}

			// For the third category
			if (Combo_Cateogry3.Visible && !string.IsNullOrEmpty(Combo_Cateogry3.Text) && !string.IsNullOrEmpty(txtbox_Category3.Text))
			{
				conditions.Add($"{Combo_Cateogry3.Text} = @Category3");
				parameters.Add(new SqlParameter("Category3", txtbox_Category3.Text));
			}

			if (conditions.Count > 0)
			{
				query.Append(" WHERE ");
				query.Append(string.Join(" AND ", conditions));
			}

			// Create a SQL command to execute the query
			SqlCommand cmd = new SqlCommand(query.ToString(), sqlCon);

			cmd.Parameters.AddRange(parameters.ToArray());

			string[] columnNames = { "book_id", "book_name", "author_name", "genre_name", "year_published", "is_loaned" };
			fillListView(cmd, columnNames);
		}

		private void btn_AddSearchCategory_Click(object sender, EventArgs e)
		{
			if (Combo_Cateogry2.Visible == false)
			{
				Combo_Cateogry2.Visible = true;
				txtbox_Category2.Visible = true;
				// fill the combo box with the categories not selected in 1st combo box
			}
			else if (Combo_Cateogry3.Visible == false)
			{
				Combo_Cateogry3.Visible = true;
				txtbox_Category3.Visible = true;
				// fill the combo box with the categories not selected in 1st and 2nd combo boxes
			}
			else 
				MessageBox.Show("You can add up to 3 categories");
		}

		private void btn_ClearSearch_Click(object sender, EventArgs e)
		{
			Combo_Cateogry2.Visible = false;
			Combo_Cateogry3.Visible = false;
			txtbox_Category2.Visible = false;
			txtbox_Category3.Visible = false;
			txtbox_Category1.Text = "";
			txtbox_Category2.Text = "";
			txtbox_Category3.Text = "";
			Combo_Cateogry1.SelectedIndex = 0;
			Combo_Cateogry2.SelectedIndex = 0;
			Combo_Cateogry3.SelectedIndex = 0;
			listView_SearchRes.Items.Clear(); // Clear previous entries
			listView_SearchRes.Columns.Clear(); // Clear previous columns			

		}

		private void FillSearchComboBox(ComboBox combo)
		{
			sqlCon.Open();

			try
			{
				string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'books'";
				SqlCommand cmd = new SqlCommand(query, sqlCon);

				SqlDataReader reader = cmd.ExecuteReader();

				combo.Items.Clear();

				// Create a list to store column names
				List<string> columnNames = new List<string>();

				// Loop through each record and add column names to the list
				while (reader.Read())
				{
					columnNames.Add(reader["COLUMN_NAME"].ToString());
				}

				// Remove the last column name from the list (if it exists)
				if (columnNames.Count > 0)
				{
					columnNames.RemoveAt(columnNames.Count - 1);
				}

				// Add the remaining column names to the ComboBox
				foreach (string columnName in columnNames)
				{
					combo.Items.Add(columnName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred: " + ex.Message);
			}
			finally
			{
				sqlCon.Close();
			}
			combo.SelectedIndex = 0;
		}
		
		private void fillListView(SqlCommand cmd, string[] columnNames)
		{
			sqlCon.Open();

			SqlDataReader reader = cmd.ExecuteReader();

			listView_SearchRes.Items.Clear(); // Clear previous entries
			listView_SearchRes.Columns.Clear(); // Clear previous columns			

			foreach (string columnName in columnNames)
			{
				listView_SearchRes.Columns.Add(columnName, 100);
			}

			listView_SearchRes.GridLines = true;
			listView_SearchRes.View = View.Details;

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
					listView_SearchRes.Items.Add(item);
				}
			}
			else
			{
				MessageBox.Show("No data found!");
			}

			sqlCon.Close();
		}
	}
}
