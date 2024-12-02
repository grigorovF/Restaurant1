using System.Drawing;
using Guna.UI2.WinForms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Linq;

namespace Restaurant
{
    public partial class Form1 : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True");
        protected Guna2TextBox passwordBox = new Guna2TextBox();
        public string getPasssword {
            get { return passwordBox.Text; }
        }
        public Form1()
        {
            InitializeComponent();

            Guna2HtmlLabel cafe = new Guna2HtmlLabel
            {
                Text = "My Cafe",
                Font = new Font("Segoe UI", 32, FontStyle.Bold | FontStyle.Italic),
                AutoSize = true
            };

            cafe.Size = TextRenderer.MeasureText(cafe.Text, cafe.Font);
            cafe.Location = new Point((this.ClientSize.Width - cafe.Width) / 2, 12);
            this.Controls.Add(cafe);



            int buttonWidth = 100;
            int buttonSpacing = 40;
            int totalButtonWidth = (buttonWidth * 2) + buttonSpacing;
            int centerX = (this.ClientSize.Width - totalButtonWidth) / 2;

            Guna2Button singIn = new Guna2Button
            {
                Text = "Sign In",
                Size = new Size(buttonWidth, 40),
                Location = new Point(centerX, 150),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FillColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                TabIndex = 1,
            };
            singIn.Click += singIn_Click;
            this.Controls.Add(singIn);


            Guna2Button exit = new Guna2Button
            {
                Text = "Exit",
                Size = new Size(buttonWidth, 40),
                Location = new Point(centerX + buttonWidth + buttonSpacing, 150),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FillColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                TabIndex = 2,
            };
            this.Controls.Add(exit);
            exit.Click += Exit_Click;



        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you realy want to exit application?", "Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else {
                
            }
        }

        private void singIn_Click(object sender, EventArgs e)
        {
            string password = passwordBox.Text;
            HashSet<string> pass = new HashSet<string>();
            try
            {
                conn.Open();
                string s1 = "SELECT * FROM userTable";
                using (SqlCommand cmd = new SqlCommand(s1, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pass.Add(reader.GetString(4));
                        }
                    }
                }
                if (pass.Contains(password))
                {
                    if (password == "12345")
                    {
                        ownerForm ownerForm = new ownerForm(getPasssword);
                        ownerForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        userForm userForm = new userForm(password);
                        userForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("This user doesn't exist!", "Invalid user", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    passwordBox.Text = null;
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

        private void makeBox()
        {
            passwordBox.PlaceholderText = "Enter your password";
            passwordBox.TextAlign = HorizontalAlignment.Center;
            passwordBox.UseSystemPasswordChar = true;
            passwordBox.Width = 300;
            passwordBox.Height = 40;
            passwordBox.TabIndex = 0;
            passwordBox.Size = new Size(passwordBox.Width, passwordBox.Height);
            passwordBox.Location = new Point((this.ClientSize.Width - passwordBox.Width) / 2, 80);
            this.Controls.Add(passwordBox);
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                singIn_Click(sender, e);
                e.Handled = true;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            makeBox();
            passwordBox.KeyDown += keyDown;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}
