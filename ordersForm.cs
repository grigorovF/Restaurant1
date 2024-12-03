using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Restaurant
{
    public partial class ordersForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True");

        public ordersForm()
        {
            InitializeComponent();
        }

        private void ordersForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string s1 = "SELECT * FROM Orders";
                using (SqlCommand loadTables = new SqlCommand(s1, conn))
                {
                    using (SqlDataReader reader = loadTables.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableListBox.Items.Add(reader.GetString(1));
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(loadTables))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        orderGridView.DataSource = dt;
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do you really want to close?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                Form1 startForm = new Form1();
                startForm.Show();
            }
 
        }

        private void tableListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Close();
            if (tableListBox.SelectedIndex >= 0)
            {
                guna2Button1.Enabled = true;

                try
                {
                    conn.Open();
                    string s1 = "SELECT * FROM Orders WHERE TableName = @TableName";
                    using (SqlCommand loadItems = new SqlCommand(s1, conn))
                    {
                        loadItems.Parameters.AddWithValue("@TableName", tableListBox.SelectedItem.ToString());
                        using (SqlDataAdapter adapter = new SqlDataAdapter(loadItems))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            orderGridView.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }

            }
            else
            {
                guna2Button1.Enabled = false;

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var input = MessageBox.Show("Are you realy done with this order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (input == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    if (orderGridView.SelectedRows.Count > 0)
                    {
                        string s1 = "DELETE FROM Orders WHERE OrderID = @orderID AND TableName = @TableName";
                        foreach (DataGridViewRow row in orderGridView.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                string orderID = row.Cells[0].Value.ToString();
                                string tableName = tableListBox.SelectedItem.ToString();
                                using (SqlCommand cmd = new SqlCommand(s1, conn))
                                {
                                    cmd.Parameters.AddWithValue("@OrderID", this.orderGridView.SelectedCells.ToString());
                                    cmd.Parameters.AddWithValue("@TableName", tableListBox.SelectedItem.ToString());
                                    cmd.ExecuteNonQuery();
                                }

                            }
                        }
                    }
                    orderGridView.DataSource = null;
                    tableListBox.Items.Remove(tableListBox.SelectedItem);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error6", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void ordersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Do you really want to close?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                Form1 startForm = new Form1();
                startForm.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
