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
            outcommingTab.Checked = false;
            incommingTab.Checked = true;
            usersTab.Checked = false;
            outcommingTab.Checked = false;
            addUser.Visible = false;
            incommingNummberTextBox.PlaceholderText = "[Incomming Invoice Number]";
            incommingNummberTextBox.PlaceholderForeColor = System.Drawing.Color.LightGray;

            try
            {
                conn.Open();
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                string load = "SELECT invoiceNumber FROM outcommingInvoices";
                using (SqlCommand cmd = new SqlCommand(load, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            collection.Add(reader.GetString(0));
                        }
                        outcommingInvoiceBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        outcommingInvoiceBox.AutoCompleteCustomSource = collection;
                        outcommingInvoiceBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    }
                }
                string s = "SELECT * FROM userTable WHERE password = @password";
                using (SqlCommand cmd1 = new SqlCommand(s, conn))
                {
                    cmd1.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader1 = cmd1.ExecuteReader())
                    {
                        if (reader1.Read())
                        {
                            label1.Text = reader1.GetString(0) + " " + reader1.GetString(1);
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
                outcommingTab.Checked = false;
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
            incommingGroup.Visible = true;
            outcommingGroup.Visible = false;
            addInvoice.Visible = true;
            outcommingTab.Checked = false;
            incommingTab.Checked = true;
            usersTab.Checked = false;
            outcommingTab.Checked = false;
            addUser.Visible = false;
            incommingNummberTextBox.PlaceholderText = "[Incomming Invoice Number]";
            incommingNummberTextBox.PlaceholderForeColor = System.Drawing.Color.LightGray;
            try
            {
                conn.Open();
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

        private void addUser_Click(object sender, EventArgs e)
        {
            addUserForm addUserForm = new addUserForm();
            addUserForm.Show();
        }

        private void outcommingTab_Click(object sender, EventArgs e)
        {
            outcommingTab.Checked = true;
            incommingTab.Checked = false;
            usersTab.Checked = false;
            incommingGroup.Visible = false;
            outcommingGroup.Visible = true;
            addInvoice.Visible = false;
            try
            {
                conn.Open();
                string s1 = "SELECT * FROM outcommingInvoices";
                using (SqlCommand cmd1 = new SqlCommand(s1, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd1))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        itemGrid.DataSource = dt;
                    }
                }
            }
            catch { }
            finally
            {
                conn.Close();
            }

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (guna2CheckBox2.Checked == true)
                {
                    outcommingInvoiceBox.Enabled = true;
                    waiterCheck.Checked = false;
                    dateCheck.Checked = false;
                }
                else
                {
                    dateLabel.Visible = true;
                    waiterLabel.Visible = true;
                    tableLayoutPanel1.Visible = true;
                    tableLayoutPanel2.Visible = true;
                    guna2HtmlLabel2.Visible = true;
                    outcommingInvoiceBox.Enabled = false;
                    outcommingInvoiceBox.Text = null;
                    string s1 = "SELECT * FROM outcommingInvoices";
                    using (SqlCommand cmd1 = new SqlCommand(s1, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd1))
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

                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            finally
            {
                conn.Close();
            }
        }


        private void outcommingInvoiceBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outcommingInvoiceBox.Text))
            {
                try

                {
                    conn.Open();
                    dateLabel.Visible = true;
                    waiterLabel.Visible = true;
                    tableLayoutPanel1.Visible = true;
                    tableLayoutPanel2.Visible = true;
                    guna2HtmlLabel2.Visible = true;
                    guna2HtmlLabel1.Visible = true;
                    string s1 = "SELECT * FROM outcommingProducts WHERE invoiceNumber = @invoiceNumber";
                    using (SqlCommand cmd1 = new SqlCommand(s1, conn))
                    {
                        cmd1.Parameters.AddWithValue("@invoiceNumber", outcommingInvoiceBox.Text);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd1))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            itemGrid.DataSource = dataTable;
                        }
                    }

                    string s2 = "SELECT * FROM outcommingInvoices WHERE invoiceNumber = @invoiceNumber";
                    using (SqlCommand cmd2 = new SqlCommand(s2, conn))
                    {
                        cmd2.Parameters.AddWithValue("@invoiceNumber", outcommingInvoiceBox.Text);
                        using (SqlDataReader reader = cmd2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                waiterLabel.Text = reader[1].ToString();
                                DateTime dateTime = Convert.ToDateTime(reader[2].ToString());
                                dateLabel.Text = dateTime.ToString("HH/mm/ss") + ", " + dateTime.ToString("dd/MM/yyyy");
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
            else {
                dateLabel.Visible = false;
                waiterLabel.Visible = false;
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel2.Visible = false;
                guna2HtmlLabel2.Visible = false;
                guna2HtmlLabel1.Visible = false;
            }
        }

        private void waiterCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (waiterCheck.Checked)
            {
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel2.Visible = false;
                waiterLabel.Visible = false;
                dateLabel.Visible = false;
                guna2CheckBox2.Checked = false;
                dateCheck.Checked = false;
                waiterCombo.Enabled = true;
                try {
                    conn.Open();
                    string s = "SELECT * FROM userTable WHERE NOT password = '0000' AND NOT password = '1234' AND NOT password = '12345'";
                    using (SqlCommand cmd = new SqlCommand(s, conn)) {
                        using (SqlDataReader r = cmd.ExecuteReader()) {
                            while (r.Read()) { 
                                string item = r[3].ToString();
                                waiterCombo.Items.Add(item);
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
            else { 
                waiterCombo.Items.Clear();
                waiterCombo.Text = null;
                try{
                string s1 = "SELECT * FROM outcommingInvoices";
                    using (SqlCommand cmd1 = new SqlCommand(s1, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd1))
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
    }
}
