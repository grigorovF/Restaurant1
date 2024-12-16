using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;

namespace Restaurant
{
    public partial class addInvoiceForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False");
        private Panel parentPanel;
        private int y = 0;

        private List<List<Guna2TextBox>> productBoxes = new List<List<Guna2TextBox>>();

        public addInvoiceForm()
        {
            InitializeComponent();
            InitializeParentPanel();
        }

        private void InitializeParentPanel()
        {
            parentPanel = new Panel
            {
                Location = new Point(12, 180),
                AutoScroll = true,
                Width = this.ClientSize.Width - 24,
                Height = 400
            };
            this.Controls.Add(parentPanel);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("For quantity, enter only nummbers!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                MessageBox.Show("For price, enter only nummbers and commas!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addnewRow();
                e.Handled = true;
            }
        }
        private void addnewRow()
        {
            Panel panel = new Panel
            {
                Width = parentPanel.ClientSize.Width - 20,
                Height = 40,
                Location = new Point(0, y),
                Margin = new Padding(0, 5, 0, 5)
            };

            Guna2TextBox textBox1 = new Guna2TextBox { Width = 120, TextAlign = HorizontalAlignment.Center };
            Guna2TextBox textBox2 = new Guna2TextBox { Width = 120, TextAlign = HorizontalAlignment.Center };
            Guna2TextBox textBox3 = new Guna2TextBox { Width = 120, TextAlign = HorizontalAlignment.Center };

            textBox1.Location = new Point(12, (panel.Height - textBox1.Height) / 2);
            textBox2.Location = new Point(175, (panel.Height - textBox2.Height) / 2);
            textBox3.Location = new Point(338, (panel.Height - textBox3.Height) / 2);

            textBox2.KeyPress += textBox2_KeyPress;
            textBox3.KeyPress += textBox3_KeyPress;
            textBox3.KeyDown += textBox3_KeyDown;

            panel.Controls.Add(textBox1);
            panel.Controls.Add(textBox2);
            panel.Controls.Add(textBox3);

            productBoxes.Add(new List<Guna2TextBox> { textBox1, textBox2, textBox3 });

            parentPanel.Controls.Add(panel);

            y += panel.Height + 5;

            parentPanel.Height = y;

            parentPanel.AutoScrollPosition = new Point(0, parentPanel.VerticalScroll.Maximum);

        }

        private void addInvoiceForm_Load(object sender, EventArgs e)
        {
            addnewRow();

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numberTextBox.Text) || string.IsNullOrWhiteSpace(supplierTextBox.Text))
            {
                MessageBox.Show("Enter valid different serial number or supplier", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();
                    bool exist = false;
                    string checkInvoiceQuery = "SELECT * FROM InboundInvoices WHERE invoiceNumber = @invoiceNumber AND Supplier = @Supplier";

                    using (SqlCommand checkInv = new SqlCommand(checkInvoiceQuery, conn))
                    {
                        checkInv.Parameters.AddWithValue("@invoiceNumber", numberTextBox.Text);
                        checkInv.Parameters.AddWithValue("@Supplier", supplierTextBox.Text);

                        using (SqlDataReader reader = checkInv.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                MessageBox.Show("This invoice already exists", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                exist = true;
                            }
                        }
                    }

                    if (!exist)
                    {
                        
                        string insertInvoiceQuery = "INSERT INTO InboundInvoices (invoiceNumber, Supplier, incomingDate) VALUES (@invoiceNumber, @Supplier, @incomingDate)";

                        using (SqlCommand insertInv = new SqlCommand(insertInvoiceQuery, conn))
                        {
                            insertInv.Parameters.AddWithValue("@invoiceNumber", numberTextBox.Text);
                            insertInv.Parameters.AddWithValue("@Supplier", supplierTextBox.Text);
                            insertInv.Parameters.AddWithValue("@incomingDate", DateTime.Now); 
                            insertInv.ExecuteNonQuery();
                        }

                        foreach (List<Guna2TextBox> textBox in productBoxes)
                        {
                            string product = textBox[0].Text;
                            int quantity = Convert.ToInt32(textBox[1].Text);
                            double price = Convert.ToDouble(textBox[2].Text);

                            string checkQuery = "SELECT * FROM itemTable WHERE Product = @Product";

                            using (SqlCommand checkProduct = new SqlCommand(checkQuery, conn))
                            {
                                checkProduct.Parameters.AddWithValue("@Product", product);

                                using (SqlDataReader productReader = checkProduct.ExecuteReader())
                                {   
                                    bool productExist = false;
                                    while (productReader.Read())
                                    {
                                        if (productReader[0].ToString() == product && double.Parse(productReader[2].ToString()) == price)
                                        {
                                            productExist = true;
                                            break;
                                        }
                                          
                                    }
                                    productReader.Close();
                                    if (productExist) {
                                        string updateQuery = "UPDATE itemTable SET Quantity = Quantity + @quantity WHERE Product = @Product";
                                        using (SqlCommand update = new SqlCommand(updateQuery, conn))
                                        {
                                            update.Parameters.AddWithValue("@quantity", quantity);
                                            update.Parameters.AddWithValue("@Product", product);
                                            update.ExecuteNonQuery();
                                        }
                                    }

                                    else
                                    {
                                        string insertQuery = @"INSERT INTO itemTable (Product, Quantity, Price, iNumber)
                                                                   VALUES (@Product, @Quantity, @Price, @iNumber)";
                                        using (SqlCommand insert = new SqlCommand(insertQuery, conn))
                                        {
                                            insert.Parameters.AddWithValue("@Product", product);
                                            insert.Parameters.AddWithValue("@Quantity", quantity);
                                            insert.Parameters.AddWithValue("@Price", price);
                                            insert.Parameters.AddWithValue("@iNumber", numberTextBox.Text);
                                            insert.ExecuteNonQuery();
                                        }
                                    }
                                    
                                    
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
        }
    }

}
