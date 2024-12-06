using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class addUserForm : Form
    {
        public addUserForm()
        {
            InitializeComponent();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4_TextChanged != null)
            {
                paswordLabel.Visible = true;
                if (guna2TextBox3.Text != guna2TextBox4.Text)
                {
                    paswordLabel.Text = "Passwords don't match!";
                    paswordLabel.ForeColor = Color.Red;
                }
                else
                {
                    paswordLabel.Text = "Passwords match!";
                    paswordLabel.ForeColor = Color.Green;
                }

            }
            else { 
                paswordLabel.Visible= false;
            }
        }
    }
}
