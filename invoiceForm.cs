using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;

namespace Restaurant
{

    public partial class invoiceForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False; MultipleActiveResultSets=True");
        DataTable invoiceTable = new DataTable();
        int yoffset = 0;
        double totalSum = 0;
        public invoiceForm(DataTable invoiceTable)
        {
            this.invoiceTable = invoiceTable;
            InitializeComponent();
        }

        private string inNumber()
        {
            Random random = new Random();
            HashSet<int> generate = new HashSet<int>();
            int iNumber;
            do
            {
                iNumber = random.Next(0, 999999999);
            }
            while (generate.Contains(iNumber));

            return iNumber.ToString();
        }

        private void invoiceForm_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            Guna2HtmlLabel cafe = new Guna2HtmlLabel
            {
                Text = "My Cafe",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                AutoSize = true
            };

            cafe.Size = TextRenderer.MeasureText(cafe.Text, cafe.Font);
            cafe.Location = new Point((this.ClientSize.Width - cafe.Width) / 2, 15);
            this.Controls.Add(cafe);

            Guna2HtmlLabel street = new Guna2HtmlLabel
            {
                Text = "My 405 E 45th St, New York,  United States",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                AutoSize = true
            };

            street.Size = TextRenderer.MeasureText(street.Text, street.Font);
            street.Location = new Point((this.ClientSize.Width - street.Width) / 2, 35);
            this.Controls.Add(street);

            Guna2HtmlLabel date = new Guna2HtmlLabel
            {
                Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy") + "Time: " + DateTime.Now.ToString("HH/mm/ss"),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                AutoSize = true
            };

            date.Size = TextRenderer.MeasureText(date.Text, date.Font);
            date.Location = new Point((this.ClientSize.Width - date.Width) / 2, 55);
            this.Controls.Add(date);

            Guna2HtmlLabel serialNumber = new Guna2HtmlLabel
            {
                Text = "Invoice: " + inNumber(),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                AutoSize = true
            };

            serialNumber.Size = TextRenderer.MeasureText(serialNumber.Text, serialNumber.Font);
            serialNumber.Location = new Point((this.ClientSize.Width - serialNumber.Width) / 2, 75);
            this.Controls.Add(serialNumber);

            Guna2HtmlLabel headerProduct = new Guna2HtmlLabel
            {
                Text = "Product",
                Location = new Point(15, 110),
                AutoSize = true,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold)
            };
            this.Controls.Add(headerProduct);

            Guna2HtmlLabel headerQuantity = new Guna2HtmlLabel
            {
                Text = "Quantity",
                Location = new Point(125, 110),
                AutoSize = true,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold)
            };
            this.Controls.Add(headerQuantity);

            Guna2HtmlLabel headerPrice = new Guna2HtmlLabel
            {
                Text = "Price",
                Location = new Point(245, 110),
                AutoSize = true,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold)
            };
            this.Controls.Add(headerPrice);

            Guna2HtmlLabel headerTotal = new Guna2HtmlLabel
            {
                Text = "Total",
                Location = new Point(325, 110),
                AutoSize = true,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold)
            };
            this.Controls.Add(headerTotal);
            

            foreach (DataRow row in invoiceTable.Select()) {
                string product = row[0].ToString();
                string quantity = row[1].ToString();
                string price = row[2].ToString();
                string total = row[3].ToString();

                int y = 140 + yoffset;

                Guna2HtmlLabel productLabel = new Guna2HtmlLabel
                {
                    Text = product,
                    Location = new Point(15, y),
                    AutoSize = false,
                    Size = new Size(100, 35),
                    MinimumSize = new Size(100, 0),
                    AutoSizeHeightOnly = true,
                    Font = new Font(Font.FontFamily, 10)
                };
                this.Controls.Add(productLabel);

                Guna2HtmlLabel quantityLabel = new Guna2HtmlLabel
                {
                    Text = quantity,
                    Location = new Point(135, y),
                    AutoSize = true,
                    Font = new Font(Font.FontFamily, 10)
                };
                this.Controls.Add(quantityLabel);

                Guna2HtmlLabel priceLabel = new Guna2HtmlLabel
                {
                    Text = price,
                    Location = new Point(245, y),
                    AutoSize = true,
                    Font = new Font(Font.FontFamily, 10),
                    TextAlignment = ContentAlignment.MiddleRight 
                };
                this.Controls.Add(priceLabel);

                Guna2HtmlLabel totalLabel = new Guna2HtmlLabel
                {
                    Text = total,
                    Location = new Point(335, y),
                    AutoSize = true,
                    Font = new Font(Font.FontFamily, 10),
                    TextAlignment = ContentAlignment.MiddleRight
                };
                this.Controls.Add(totalLabel);

                yoffset += 40;
                totalSum = totalSum + double.Parse(totalLabel.Text);

            }
            //total


            Guna2HtmlLabel totalSumLabel = new Guna2HtmlLabel
            {
                Text = "Total: " + totalSum,
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlignment = ContentAlignment.MiddleLeft
            };
            totalSumLabel.Size = TextRenderer.MeasureText(totalSumLabel.Text, totalSumLabel.Font);
            totalSumLabel.Location = new Point((this.ClientSize.Width - totalSumLabel.Width) - 5, 170 + (invoiceTable.Rows.Count * 40));
            this.Controls.Add(totalSumLabel);

        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics g = e.Graphics;

            Pen p = new Pen(Color.Black, 3);
            Point p1 = new Point(5, 132);
            Point p2 = new Point(370, 132);
            g.DrawLine(p, p1, p2);
            
            Point p3 = new Point(5, 150 + (invoiceTable.Rows.Count * 40));
            Point p4 = new Point(370, 150 + (invoiceTable.Rows.Count * 40));
            g.DrawLine (p, p3, p4);
            
        }
    }
}
