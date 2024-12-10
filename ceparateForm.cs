using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Restaurant
{
    public partial class ceparateForm : Form
    {
        string password;
        string selectedTable;
        DataTable table;
        public ceparateForm(string password, string selectedTable, DataTable table)
        {
            this.table = table;
            this.selectedTable = selectedTable;
            this.password = password;
            InitializeComponent();
        }

        private void ceparateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            //userForm userForm = new userForm(password);
        }

        private void ceparateForm_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in table.Rows)
            {
                string product = row["Product"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);
                double price = Convert.ToDouble(row["Price"]);
                listBox1.Items.Add(product + ", " + quantity.ToString() + ", " + price.ToString());
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0) {
                string s = listBox1.SelectedItem.ToString();
                string[] array = s.Split(new string[] { ", " }, StringSplitOptions.None);
                string item = array[0];
                int quantity = Convert.ToInt32(array[1]);
                double price = Convert.ToDouble(array[2]);
                
                var input = Interaction.InputBox(
                                "How many " + item + " do you want to pay for? \nMaximal value is " + quantity + ".", "Enter Quantity", "1");

                int enteredQ;
                if (int.TryParse(input, out enteredQ))
                {
                    if (enteredQ <= quantity)
                    {
                        int q = quantity - enteredQ;
                        listBox2.Items.Add(item + ", " + enteredQ + ", " + price);
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        listBox1.Items.Add(item + ", " + q + ", " + price);

                    }
                    else {
                        MessageBox.Show("Please enter correct value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }
    }
}
