using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
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

        private string currentUser;
        private Dictionary<string, List<string>> userTables = new Dictionary<string, List<string>>();
        string password;

        public userForm(string password)
        {
            this.password = password;
            this.MinimumSize = new Size(141, 23);
            orderTable.Columns.Add("Product", Type.GetType("System.String"));
            orderTable.Columns.Add("Quantity", Type.GetType("System.Int32"));
            orderTable.Columns.Add("Price", Type.GetType("System.Double"));
            orderTable.Columns.Add("Total", Type.GetType("System.Double"));
            InitializeComponent();
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
                string s3 = "SELECT DISTINCT TableName FROM Tables WHERE UserID = @UserID";
                using (SqlCommand cmd3 = new SqlCommand(s3, conn))
                {
                    cmd3.Parameters.AddWithValue("@UserID", currentUser);
                    using (SqlDataReader reader = cmd3.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tableName = reader["TableName"].ToString();
                            listBox1.Items.Add(tableName);
                            DataTable invoiceTable = new DataTable();
                            invoiceTable.Columns.Add("Product", typeof(string));
                            invoiceTable.Columns.Add("Quantity", typeof(int));
                            invoiceTable.Columns.Add("Price", typeof(double));
                            invoiceTable.Columns.Add("Total", typeof(double));

                            invoiceDictionatry[tableName] = invoiceTable;
                        }
                    }
                }
                string s4 = "SELECT TableName, Product, Quantity, Price, Total FROM Tables WHERE UserID = @UserID";
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

                            // Add data to the corresponding table in the dictionary
                            if (invoiceDictionatry.ContainsKey(tableName))
                            {
                                invoiceDictionatry[tableName].Rows.Add(product, quantity, price, total);
                            }
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



        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    string selectedTable = listBox1.SelectedItem.ToString();
                    if (invoiceDictionatry.ContainsKey(selectedTable))
                    {
                        DataTable table = invoiceDictionatry[selectedTable];
                        if (invoiceGrid.CurrentCell != null)
                        {
                            int index = invoiceGrid.CurrentCell.RowIndex;
                            string productName = invoiceGrid.Rows[index].Cells[0].Value.ToString();
                            int quantity = Convert.ToInt32(invoiceGrid.Rows[index].Cells[1].Value);
                            table.Rows.RemoveAt(index);
                            invoiceGrid.DataSource = null;
                            invoiceGrid.DataSource = table;

                            try
                            {
                                conn.Open();
                                string s = "UPDATE itemTable SET Quantity = Quantity + @quantity WHERE Product = @Product";
                                SqlCommand update = new SqlCommand(s, conn);
                                update.Parameters.AddWithValue("@quantity", quantity);
                                update.Parameters.AddWithValue("@Product", productName);
                                update.ExecuteNonQuery();
                                MessageBox.Show("Product deleted and quantity updated!", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error Deleting Product", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a row to delete.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a table first.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

            DataTable orderTable = orderDictionary[selectedTable];
            try
            {
                conn.Open();
                foreach (DataRow row in orderTable.Rows)
                {
                    string product = row["Product"].ToString();
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    double price = Convert.ToDouble(row["Price"]);
                    double total = Convert.ToDouble(row["Total"]);

                    string s1 = @"INSERT INTO Tables (TableName, Product, Quantity, Price, Total, UserID)
                                  VALUES (@TableName, @Product, @Quantity, @Price, @Total, @UserID)";

                    using (SqlCommand insert = new SqlCommand(s1, conn))
                    {
                        insert.Parameters.AddWithValue("@TableName", selectedTable);
                        insert.Parameters.AddWithValue("@Product", product);
                        insert.Parameters.AddWithValue("@Quantity", quantity);
                        insert.Parameters.AddWithValue("@Price", price);
                        insert.Parameters.AddWithValue("@Total", total);
                        insert.Parameters.AddWithValue("@UserID", currentUser);
                        insert.ExecuteNonQuery();
                    }

                    string s2 = @"INSERT INTO Orders (OrderID, TableName, Product, Quantity, UserID)
                                  VALUES (@OrderID, @TableName, @Product, @Quantity, @UserID)";

                    using (SqlCommand insert2 = new SqlCommand(s2, conn))
                    {
                        insert2.Parameters.AddWithValue("@OrderID", getNummber());
                        insert2.Parameters.AddWithValue("@TableName", selectedTable);
                        insert2.Parameters.AddWithValue("@Product", product);
                        insert2.Parameters.AddWithValue("@Quantity", quantity);
                        insert2.Parameters.AddWithValue("@UserID", currentUser);
                        insert2.ExecuteNonQuery();
                    }
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            orderTable.Clear();
            orderGrid.DataSource = null;

        }

        private string getNummber() {
            HashSet<int> list = new HashSet<int>();
            Random random = new Random();

            int num;

            do
            {
                num = random.Next(0, 100000000);
            }
            while (list.Contains(num));

            return num.ToString();
        }

    }
}


