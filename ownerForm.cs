using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Restaurant
{
    public partial class ownerForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True");
        string password;
        public ownerForm(string password)
        {
            this.password = password;
            InitializeComponent();
        }

        private void itemGridDefault()
        {
            string s = "SELECT * FROM itemTable";
            using (SqlCommand cmd = new SqlCommand(s, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    itemGrid.DataSource = dt;
                }

            }
        }

        private void ownerForm_Load(object sender, EventArgs e)
        {
            incommingTab.Checked = true;
            usersTab.Checked = false;
            outcommingTab.Checked = false;
            addUser.Visible = false;
            incommingNummberTextBox.PlaceholderText = "[Incomming Invoice Number]";
            incommingNummberTextBox.PlaceholderForeColor = System.Drawing.Color.LightGray;

            try
            {
                conn.Open();
                string s = "SELECT * FROM userTable WHERE password = @password";
                using (SqlCommand cmd = new SqlCommand(s, conn))
                {
                    cmd.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label1.Text = reader.GetString(0) + " " + reader.GetString(1);
                        }
                    }
                }
                itemGridDefault();

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

        private void ownerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Are you realy want to sing out?", "Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {

            }
        }

        private void inNumberCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (inNumberCheck.Checked == true)
            {
                incommingNummberTextBox.Enabled = true;
                try
                {
                    conn.Open();
                    string load = "SELECT * FROM InboundInvoices";
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    using (SqlCommand loadInv = new SqlCommand(load, conn))
                    {
                        using (SqlDataReader reader = loadInv.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                collection.Add(reader["invoiceNumber"].ToString().Trim());
                            }
                            incommingNummberTextBox.AutoCompleteCustomSource = collection;
                            incommingNummberTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                            incommingNummberTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            else
            {
                incommingNummberTextBox.Enabled = false;
                incommingNummberTextBox.Text = null;
                incommingNummberTextBox.PlaceholderText = "[Incomming Invoice Number]";
                incommingNummberTextBox.PlaceholderForeColor = System.Drawing.Color.LightGray;
                try
                {
                    string s = "SELECT * FROM itemTable";
                    using (SqlCommand cmd = new SqlCommand(s, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            itemGrid.DataSource = dt;
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

        private void inItemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (inItemCombo.SelectedIndex >= 0)
                {
                    string s = "SELECT * FROM itemTable WHERE iNumber = @invoiceNumber AND Product = @Product";
                    using (SqlCommand cmd = new SqlCommand(s, conn))
                    {
                        cmd.Parameters.AddWithValue("@invoiceNumber", incommingNummberTextBox.Text);
                        cmd.Parameters.AddWithValue("@Product", inItemCombo.SelectedItem.ToString());
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            itemGrid.DataSource = dt;
                        }
                    }
                }
                else
                {
                    inItemCombo.Enabled = false;
                    string s = "SELECT * FROM itemTable WHERE iNumber = @invoiceNumber";
                    using (SqlCommand cmd = new SqlCommand(s, conn))
                    {
                        cmd.Parameters.AddWithValue("@invoiceNumber", incommingNummberTextBox.Text);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            itemGrid.DataSource = dt;
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

        private void incommingNummberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (incommingNummberTextBox.Text != null)
            {
                try
                {
                    conn.Open();
                    string s = "SELECT * FROM itemTable WHERE iNumber = @invoiceNumber";
                    using (SqlCommand cmd = new SqlCommand(s, conn))
                    {
                        cmd.Parameters.AddWithValue("@invoiceNumber", incommingNummberTextBox.Text);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            itemGrid.DataSource = dt;
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

        private void inItemCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (inItemCheck.Checked)
            {
                inItemCombo.Enabled = true;
                try
                {
                    conn.Open();
                    string s = "SELECT * FROM itemTable WHERE iNumber = @invoiceNumber";
                    using (SqlCommand cmd = new SqlCommand(s, conn))
                    {
                        cmd.Parameters.AddWithValue("@invoiceNumber", incommingNummberTextBox.Text);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                inItemCombo.Items.Add(reader.GetString(0));
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
            else
            {
                inItemCombo.Enabled = false;
                inItemCombo.Items.Clear();
                try
                {
                    string s = "SELECT * FROM itemTable WHERE iNumber = @invoiceNumber";
                    using (SqlCommand cmd = new SqlCommand(s, conn))
                    {
                        cmd.Parameters.AddWithValue("@invoiceNumber", incommingNummberTextBox.Text);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            itemGrid.DataSource = dt;
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

        private void addInvoice_Click(object sender, EventArgs e)
        {
            addInvoiceForm addInvoiceForm = new addInvoiceForm();
            addInvoiceForm.ShowDialog();
        }

        private void Users_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Users_Click(object sender, EventArgs e)
        {
            usersTab.Checked = true;
            if (usersTab.Checked)
            {
                incommingTab.Checked = false;
                addInvoice.Visible = false;
                incommingGroup.Visible = false;
                addUser.Visible = true;
                addInvoice.Visible = false;
                try
                {
                    string s = "SELECT * FROM userTable";
                    using (SqlCommand cmd = new SqlCommand(s, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            itemGrid.DataSource = dt;
                        }
                        itemGrid.Columns[4].Visible = false;
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

        private void backButton_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you realy want to sing out?", "Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }

        private void incommingTab_Click(object sender, EventArgs e)
        {

        }

        private void addUser_Click(object sender, EventArgs e)
        {
            addUserForm addUserForm = new addUserForm();
            addUserForm.Show();
        }
    }
}
