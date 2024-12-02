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
        SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False");
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
            try {
                conn.Open();
                string s1 = "SELECT * FROM userTable WHERE password = @password";
                using (SqlCommand sqlCommand = new SqlCommand(s1, conn)) {
                    sqlCommand.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            currentUser = reader.GetString(0) + " " + reader.GetString(1);
                            userNameLabel.Text = "Usrer: " + currentUser;
                        }
                    }
                }
            }
            catch(Exception ex)
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
