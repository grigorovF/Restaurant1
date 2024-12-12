using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Management;


namespace Restaurant
{
    public partial class ceparateForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False; MultipleActiveResultSets=True");
        string password;
        string selectedTable;
        DataTable table;

        private string number() {
            Random random = new Random();
            int number;

            HashSet<int> numbers = new HashSet<int>();
            do { 
                number = random.Next(0, 99999);
            }
            while (numbers.Contains(number));

            return number.ToString();
        }
        public ceparateForm(string password,  string selectedTable, DataTable table)
        {
            this.table = table;
            this.selectedTable = selectedTable;
            this.password = password;
            InitializeComponent();
        }

        private void ceparateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            userForm userForm = new userForm(password);
        }

        private void ceparateForm_Load(object sender, EventArgs e)
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
                            userNameLabel.Text = reader.GetString(0) + " " + reader.GetString(1);
                         }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally {
                conn.Close();
            }
            foreach (DataRow row in table.Rows)
            {
                string product = row["Product"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);
                double price = Convert.ToDouble(row["Price"]);
                listBox1.Items.Add("Product: " + product + " - Quantity: " + quantity.ToString() + " - Price: " + price.ToString());
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string s = listBox1.SelectedItem.ToString();
                string[] array = s.Split(new string[] { " - " }, StringSplitOptions.None);
                string product = array[0].Replace("Product: ", "").Trim();
                int quantity = Convert.ToInt32(array[1].Replace("Quantity: ", "").Trim());
                double price = Convert.ToDouble(array[2].Replace("Price: ", "").Trim());

                var input = Interaction.InputBox(
                               "How many " + product + " do you want to pay for? Price is: "+  price +"\nMaximal value is " + quantity + ".", "Enter Quantity");


               int enteredQ;
                if (int.TryParse(input, out enteredQ))
                {
                    if (enteredQ <= quantity)
                    {
                        int q = quantity - enteredQ;
                        listBox2.Items.Add("Product: " + product +" - Quantity: " + enteredQ + " - Price: " + price);
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        listBox1.Items.Add("Product: "+product + " - Quantity: " + q + " - Price: " + price);

                    }
                    else
                    {
                        MessageBox.Show("Please enter correct value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Price", typeof(double));
            dt.Columns.Add("Total", typeof(double));
            //paying
           foreach (var row in listBox2.Items)
           {
                string s = row.ToString();
                string[] array = s.Split(new string[] { " - " }, StringSplitOptions.None);
                string product = array[0].Replace("Product: ", "").Trim();
                int quantity = Convert.ToInt32(array[1].Replace("Quantity: ", "").Trim());
                double price = Convert.ToDouble(array[2].Replace("Price: ", "").Trim());

                dt.Rows.Add(product, quantity, price, quantity * price);
                
                try
                {
                    conn.Open();
                    string selectQuery = @"SELECT Quantity FROM Tables WHERE TableName = @TableName AND Product = @Product AND UserID = @UserID";
                    int currentQuantity = 0;

                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, conn))
                    {
                        selectCommand.Parameters.AddWithValue("@TableName", selectedTable);
                        selectCommand.Parameters.AddWithValue("@Product", product);
                        selectCommand.Parameters.AddWithValue("@UserID", userNameLabel.Text);

                        var result = selectCommand.ExecuteScalar();
                        currentQuantity = Convert.ToInt32(result);
                        
                    }
                    double Total = (currentQuantity - quantity) * price; 
                    string s1 = @"UPDATE Tables 
                  SET Quantity = Quantity - @quantity, 
                      Total = @Total 
                  WHERE TableName = @TableName 
                  AND Product = @Product 
                  AND UserID = @UserID";

                    using (SqlCommand update = new SqlCommand(s1, conn))
                    {
                        update.Parameters.AddWithValue("@quantity", quantity);
                        update.Parameters.AddWithValue("@Total", Total);
                        update.Parameters.AddWithValue("@TableName", selectedTable);
                        update.Parameters.AddWithValue("@Product", product);
                        update.Parameters.AddWithValue("@UserID", userNameLabel.Text);
                        update.ExecuteNonQuery();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error adding rest of products", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
            RefreshListBox1();

            invoiceForm invoiceForm = new invoiceForm(dt, userNameLabel.Text, number(), selectedTable);
            invoiceForm.ShowDialog();
            
        }
        private void RefreshListBox1()
        {
            listBox1.Items.Clear();
            try
            {
                conn.Open();
                string query = "SELECT Product, Quantity, Price FROM Tables WHERE TableName = @TableName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TableName", selectedTable);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string product = reader["Product"].ToString();
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            double price = Convert.ToDouble(reader["Price"]);
                            if (quantity > 0)
                            {
                                listBox1.Items.Add("Product: " + product + " - Quantity: " + quantity + " - Price: " + price + " - Total: " + price * quantity);
                            }
                            else
                            {
                                string s = "DELETE FROM TABLES WHERE Quantity = '0'";
                                using (SqlCommand del = new SqlCommand(s, conn)) {
                                    del.ExecuteNonQuery();
                                }
                                    listBox1.Items.Remove(listBox1.SelectedItem);
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
