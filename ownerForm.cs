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
                    itenGrid.DataSource = dt;
                }

            }
        }

        private void ownerForm_Load(object sender, EventArgs e)
        {
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
                    string select = "SELECT * FROM InboundInvoices";
                    using (SqlCommand cmd = new SqlCommand(select, conn)) {
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
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
                incommingNummberTextBox.Enabled = false;
                incommingNummberTextBox.Text = null;
                try {
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
        }

        private void inItemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
