using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Restaurant
{
    public partial class addUserForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True");

        public addUserForm()
        {
            InitializeComponent();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void backButtonToOwner_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void addUserToBase_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text) || string.IsNullOrEmpty(guna2TextBox3.Text)
                || string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox5.Text) || string.IsNullOrEmpty(guna2TextBox6.Text))
            {
                MessageBox.Show("You must enter a value.", "Required Field", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    conn.Open();
                    string s1 = "SELECT COUNT (*) FROM userTable WHERE password = @password";
                    using (SqlCommand check = new SqlCommand(s1, conn))
                    {
                        check.Parameters.AddWithValue("@password", guna2TextBox5.Text);
                        int count = (int)(check.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("User with this password already exists. \nYou must enter a different password!", "Password required", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }

                        else
                        {
                            string s2 = "INSERT INTO userTable VALUES (@firstName, @lastName, @mailAdresse, @userN, @password, @bDate)";
                            using (SqlCommand insert = new SqlCommand(s2, conn))
                            {
                                insert.Parameters.AddWithValue("@firstName", guna2TextBox1.Text);
                                insert.Parameters.AddWithValue("@lastName", guna2TextBox2.Text);
                                insert.Parameters.AddWithValue("@mailAdresse", guna2TextBox3.Text);
                                insert.Parameters.AddWithValue("@userN", guna2TextBox4.Text);
                                insert.Parameters.AddWithValue("@password", guna2TextBox5.Text);
                                insert.Parameters.AddWithValue("@bDate", guna2DateTimePicker1.Value);
                                insert.ExecuteNonQuery();
                                MessageBox.Show("New user is successfully added", "New user", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            }
                        }
                    }
                }


                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            passwordCheck();
        }





        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            passwordCheck();
        }

        private void passwordCheck()
        {
            if (!string.IsNullOrEmpty(guna2TextBox6.Text))
            {
                paswordLabel.Visible = true;
                if (guna2TextBox5.Text != guna2TextBox6.Text)
                {
                    paswordLabel.Text = "Passwords don't match!";
                    paswordLabel.ForeColor = Color.Red;
                }
                else
                {
                    paswordLabel.Text = "Passwords match!";
                    paswordLabel.ForeColor = Color.Green;
                }

            }
            else
            {
                paswordLabel.Visible = false;
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");
        }

        private void guna2TextBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToString();
        }
    }


}
