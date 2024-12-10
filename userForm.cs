using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Restaurant
{
    public partial class userForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False; MultipleActiveResultSets=True");
        private Dictionary<string, DataTable> orderDictionary = new Dictionary<string, DataTable>();
        private Dictionary<string, DataTable> invoiceDictionatry = new Dictionary<string, DataTable>();
        DataTable orderTable = new DataTable();

        string password;
        string iNummber;
        private string currentUser;
        private Dictionary<string, List<string>> userTables = new Dictionary<string, List<string>>();

        public userForm(string password)
        {
            this.password = password;
            InitializeComponent();
        }
        private string getNummber()
        {
            HashSet<int> list = new HashSet<int>();
            Random random = new Random();
            int num;
            do
            {
                num = random.Next(0, 100000000);
            }
            while (list.Contains(num));

            iNummber = num.ToString();

            return iNummber;
        }
        private void userForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void userForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string s1 = "SELECT * FROM userTable WHERE password = @password";
                using (SqlCommand sqlCommand = new SqlCommand(s1, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentUser = reader.GetString(0) + " " + reader.GetString(1);
                            userNameLabel.Text = currentUser;
                        }
                    }
                }


                string s2 = "SELECT Product FROM itemTable";
                using (SqlCommand cmd2 = new SqlCommand(s2, conn))
                {
                    using (SqlDataReader dataReader2 = cmd2.ExecuteReader())
                    {
                        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                        while (dataReader2.Read())
                        {
                            collection.Add(dataReader2["Product"].ToString().Trim());
                        }

                        productNameBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                        productNameBox.AutoCompleteCustomSource = collection;
                        productNameBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }

                string s4 = "SELECT * FROM Tables WHERE UserID = @UserID";
                using (SqlCommand cmd4 = new SqlCommand(s4, conn))
                {
                    cmd4.Parameters.AddWithValue("@UserID", currentUser);
                    using (SqlDataReader reader = cmd4.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tableName = reader["TableName"].ToString();
                            string product = reader["Product"].ToString();
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            double price = Convert.ToDouble(reader["Price"]);
                            double total = Convert.ToDouble(reader["Total"]);

                            // Ensure the table exists in invoiceDictionatry
                            if (!invoiceDictionatry.ContainsKey(tableName))
                            {
                                DataTable invoiceTable = new DataTable();
                                invoiceTable.Columns.Add("Product", typeof(string));
                                invoiceTable.Columns.Add("Quantity", typeof(int));
                                invoiceTable.Columns.Add("Price", typeof(double));
                                invoiceTable.Columns.Add("Total", typeof(double));
                                invoiceDictionatry[tableName] = invoiceTable;

                                // Add table to listBox1
                                listBox1.Items.Add(tableName);
                            }

                            // Add data to the table
                            invoiceDictionatry[tableName].Rows.Add(product, quantity, price, total);
                        }
                    }
                }
                //using (SqlDataAdapter adapter) { }

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


        private void productNameBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string s1 = "SELECT * FROM itemTable WHERE Product = @Product";
                using (SqlCommand sqlCommand = new SqlCommand(s1, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@Product", productNameBox.Text);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            priceLabel.Text = sqlDataReader.GetValue(2).ToString();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex >= 0)
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    string selectedTable = listBox1.SelectedItem.ToString();
                    productNameBox.Enabled = true;
                    productQuantityBox.Enabled = true;

                    if (invoiceDictionatry.ContainsKey(selectedTable))
                    {
                        invoiceGrid.DataSource = invoiceDictionatry[selectedTable];
                    }
                }
            }
        }

        private void addTableButton_Click(object sender, EventArgs e)
        {
            string tableName = Interaction.InputBox("Enter table name: ", "Table Name");
            if (!string.IsNullOrEmpty(tableName) && !orderDictionary.ContainsKey(tableName))
            {
                listBox1.Items.Add(tableName);
                if (listBox1.SelectedItem != null)
                {
                    productNameBox.Enabled = true;
                    productQuantityBox.Enabled = true;

                }
                if (!userTables.ContainsKey(currentUser))
                {
                    userTables[currentUser] = new List<string>();
                }
                userTables[currentUser].Add(tableName);

                DataTable invoiceTable = new DataTable();
                invoiceTable.Columns.Add("Product", typeof(string));
                invoiceTable.Columns.Add("Quantity", typeof(int));
                invoiceTable.Columns.Add("Price", typeof(double));
                invoiceTable.Columns.Add("Total", typeof(double));
                invoiceDictionatry[tableName] = invoiceTable;
                invoiceGrid.DataSource = invoiceTable;

            }
            listBox1.SelectedItem = tableName;
        }

        private void productQuantityBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(productNameBox.Text) || listBox1.SelectedIndex < 0)
                    return;

                string selectedTable = listBox1.SelectedItem.ToString();
                int availableQ = 0;
                double sum = 0;
                double fsum = 0;

                try
                {
                    conn.Open();
                    string s1 = "SELECT Quantity FROM itemTable WHERE Product=@Product";
                    SqlCommand selectQuantity = new SqlCommand(s1, conn);
                    selectQuantity.Parameters.AddWithValue("@Product", productNameBox.Text);
                    SqlDataReader reader1 = selectQuantity.ExecuteReader();

                    if (reader1.Read())
                        availableQ = int.Parse(reader1["Quantity"].ToString());
                    reader1.Close();

                    int orderedQ = int.Parse(productQuantityBox.Text);
                    if (availableQ < orderedQ)
                    {
                        MessageBox.Show("There are only " + availableQ + " in the store", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    /*string s2 = "UPDATE itemTable SET Quantity = Quantity - @orderedQ WHERE Product = @Product";
                    SqlCommand updateQuantity = new SqlCommand(s2, conn);
                    updateQuantity.Parameters.AddWithValue("@orderedQ", orderedQ);
                    updateQuantity.Parameters.AddWithValue("@Product", productNameBox.Text);
                    updateQuantity.ExecuteNonQuery();
                    */
                    double price = double.Parse(priceLabel.Text);
                    sum = price * orderedQ;

                    if (!orderDictionary.ContainsKey(selectedTable))
                    {
                        orderDictionary[selectedTable] = new DataTable();
                        orderDictionary[selectedTable].Columns.Add("Product", typeof(string));
                        orderDictionary[selectedTable].Columns.Add("Quantity", typeof(int));
                        orderDictionary[selectedTable].Columns.Add("Price", typeof(double));
                        orderDictionary[selectedTable].Columns.Add("Total", typeof(double));
                    }

                    DataTable orderTable = orderDictionary[selectedTable];
                    bool productExists = false;
                    foreach (DataRow row in orderTable.Rows)
                    {
                        if (row["Product"].ToString() == productNameBox.Text)
                        {
                            int existingQ = Convert.ToInt32(row["Quantity"]);
                            int newQ = existingQ + orderedQ;
                            row["Quantity"] = newQ;
                            row["Total"] = newQ * price;
                            productExists = true;
                            break;
                        }
                    }
                    if (!productExists)
                    {
                        orderTable.Rows.Add(productNameBox.Text, orderedQ, price, sum);
                    }
                    orderGrid.DataSource = orderTable;

                    if (!invoiceDictionatry.ContainsKey(selectedTable))
                    {
                        DataTable newInvoiceTable = new DataTable();
                        newInvoiceTable.Columns.Add("Product", typeof(string));
                        newInvoiceTable.Columns.Add("Quantity", typeof(int));
                        newInvoiceTable.Columns.Add("Price", typeof(double));
                        newInvoiceTable.Columns.Add("Total", typeof(double));
                        invoiceDictionatry[selectedTable] = newInvoiceTable;
                    }

                    DataTable invoiceTable = invoiceDictionatry[selectedTable];
                    bool invoiceProductExists = false;
                    foreach (DataRow row in invoiceTable.Rows)
                    {
                        if (row["Product"].ToString() == productNameBox.Text)
                        {
                            int existingQ = Convert.ToInt32(row["Quantity"]);
                            int newQ = existingQ + orderedQ;
                            row["Quantity"] = newQ;
                            row["Total"] = newQ * price;
                            invoiceProductExists = true;
                            break;
                        }
                    }
                    if (!invoiceProductExists)
                    {
                        invoiceTable.Rows.Add(productNameBox.Text, orderedQ, price, sum);
                    }


                    invoiceGrid.DataSource = invoiceTable;
                    string s2 = @"INSERT INTO Tables (TableName, Product, Quantity, Price, Total, UserID)
                          VALUES (@TableName, @Product, @Quantity, @Price, @Total, @UserID)";
                    using (SqlCommand insertCmd = new SqlCommand(s2, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@TableName", selectedTable);
                        insertCmd.Parameters.AddWithValue("@Product", productNameBox.Text);
                        insertCmd.Parameters.AddWithValue("@Quantity", orderedQ);
                        insertCmd.Parameters.AddWithValue("@Price", price);
                        insertCmd.Parameters.AddWithValue("@Total", sum);
                        insertCmd.Parameters.AddWithValue("@UserID", currentUser);
                        insertCmd.ExecuteNonQuery();
                    }


                    conn.Close();
                    productNameBox.Text = "";
                    productQuantityBox.Text = "";
                    priceLabel.Text = "";

                    sumaLabel2.Text = calculateSum().ToString("F2");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }
        private double calculateSum()
        {
            double s = 0.0;
            if (invoiceGrid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in invoiceGrid.Rows)
                {
                    if (row.Cells["Total"].Value != null && !string.IsNullOrEmpty(row.Cells["Total"].Value.ToString()))
                    {
                        s += Convert.ToDouble(row.Cells["Total"].Value);
                    }
                }
            }
            return s;
        }





        private void makeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a table first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedTable = listBox1.SelectedItem.ToString();

            if (!orderDictionary.ContainsKey(selectedTable) || orderDictionary[selectedTable].Rows.Count == 0)
            {
                MessageBox.Show("No orders to save for this table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    Random random = new Random();
                    HashSet<int> ids = new HashSet<int>();
                    int id;
                    do
                    {
                        id = random.Next(0, 100);
                    }
                    while (ids.Contains(id));
                    conn.Open();
                    string s1 = @"INSERT INTO Orders(OrderID, TableName, Product, Quantity, UserID)
                                VALUES(@OrderID, @TableName, @Product, @Quantity, @UserID)";
                    foreach (DataGridViewRow row in orderGrid.Rows)
                    {
                        string OrderID = id.ToString();
                        string TableName = listBox1.SelectedItem.ToString();
                        string product = row.Cells["Product"].Value?.ToString();
                        int quantity = int.Parse(row.Cells["Quantity"].Value?.ToString());
                        string UserID = currentUser;


                        using (SqlCommand addOrder = new SqlCommand(s1, conn))
                        {
                            addOrder.Parameters.AddWithValue("@OrderID", OrderID);
                            addOrder.Parameters.AddWithValue("@TableName", TableName);
                            addOrder.Parameters.AddWithValue("@Product", product);
                            addOrder.Parameters.AddWithValue("@Quantity", quantity);
                            addOrder.Parameters.AddWithValue("@UserID", UserID);
                            addOrder.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Order can't be sent. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
            orderTable.Clear();
            orderGrid.DataSource = null;

        }



        private void totalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a table first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedTable = listBox1.SelectedItem.ToString();

            if (!invoiceDictionatry.ContainsKey(selectedTable) || invoiceDictionatry[selectedTable].Rows.Count == 0)
            {
                MessageBox.Show("No orders for this table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable table = invoiceDictionatry[selectedTable];
            invoiceForm invoiceForm = new invoiceForm(table, userNameLabel.Text.ToString(), getNummber(), selectedTable);
            invoiceForm.TableDeleted += RefreshTables;
            invoiceForm.ShowDialog();
            
        }
        private void RefreshTables()
        {
           
            listBox1.Items.Clear();
            invoiceDictionatry.Clear();
            invoiceGrid.DataSource = null;
            try
            {
                conn.Open();
                string query = "SELECT TableName FROM Tables WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", currentUser);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tableName = reader["TableName"].ToString();
                            listBox1.Items.Add(tableName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }



        private void invoiceGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (invoiceGrid.SelectedRows.Count >= 0)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        string selectedTable = listBox1.SelectedItem.ToString();
                        if (invoiceDictionatry.ContainsKey(selectedTable))
                        {
                            DataTable table = invoiceDictionatry[selectedTable];

                            foreach (DataGridViewRow row in invoiceGrid.SelectedRows)
                            {
                                if (row.IsNewRow) continue;

                                int index = row.Index;
                                string productName = row.Cells[0].Value.ToString();
                                int quantity = Convert.ToInt32(row.Cells[1].Value.ToString());

                                table.Rows.RemoveAt(index);
                                invoiceGrid.DataSource = null;
                                invoiceGrid.DataSource = table;

                                try
                                {
                                    conn.Open();
                                    string s1 = "UPDATE itemTable SET Quantity = Quantity + @quantity WHERE Product = @Product";
                                    using (SqlCommand delete = new SqlCommand(s1, conn))
                                    {
                                        delete.Parameters.AddWithValue("@Quantity", quantity);
                                        delete.Parameters.AddWithValue("@Product", productName);
                                        delete.ExecuteNonQuery();
                                        MessageBox.Show("Product is deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error deleting product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    conn.Close();
                                }
                            }


                        }
                    }

                }
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (invoiceGrid.SelectedRows.Count >= 0)
                {
                    string selectedTable = listBox1.SelectedItem.ToString();
                    if (invoiceDictionatry.ContainsKey(selectedTable))
                    {
                        DataTable table = invoiceDictionatry[selectedTable];

                        foreach (DataGridViewRow row in invoiceGrid.SelectedRows)
                        {
                            if (row.IsNewRow) continue;

                            int index = row.Index;
                            string productName = row.Cells[0].Value.ToString();
                            int quantity = Convert.ToInt32(row.Cells[1].Value.ToString());

                            table.Rows.RemoveAt(index);
                            invoiceGrid.DataSource = null;
                            invoiceGrid.DataSource = table;

                            try
                            {
                                conn.Open();
                                string s1 = "UPDATE itemTable SET Quantity = Quantity + @quantity WHERE Product = @Product";
                                using (SqlCommand delete = new SqlCommand(s1, conn))
                                {
                                    delete.Parameters.AddWithValue("@Quantity", quantity);
                                    delete.Parameters.AddWithValue("@Product", productName);
                                    delete.ExecuteNonQuery();
                                    MessageBox.Show("Product is deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                string s2 = "DELETE Product, Quantity FROM Orders WHERE Product = @Product";
                                using (SqlCommand deleteOrder = new SqlCommand(s1, conn))
                                {
                                    deleteOrder.Parameters.AddWithValue("@Product", productName);
                                    deleteOrder.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error deleting product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select product", "Error deleting product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select table", "Error deleting product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void productQuantityBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("For quantity, enter only nummbers!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

            }
        }

        private void separatelyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedTable = listBox1.SelectedItem.ToString();
            DataTable table = invoiceDictionatry[selectedTable];

            ceparateForm ceparateForm = new ceparateForm(password, selectedTable, table);
            ceparateForm.ShowDialog();
        }
    }
}


