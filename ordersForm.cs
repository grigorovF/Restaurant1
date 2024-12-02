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
    public partial class ordersForm : Form
    {
        private Dictionary<string, DataTable> tableOrders;
        private string selectedTable;
        public ordersForm(Dictionary<string, DataTable> tableOrders, string selectedTable)
        {
            InitializeComponent();
            this.tableOrders = tableOrders;
            tableListBox.DataSource = selectedTable;
            tableListBox.SelectedIndexChanged += TableListBox_SelectedIndexChanged;
        }

        private void TableListBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tableListBox.SelectedIndex >= 0)
            {
                selectedTable = tableListBox.SelectedItem.ToString();

                if (tableOrders.ContainsKey(selectedTable))
                {
                    orderGridView.DataSource = tableOrders[selectedTable];
                }
                else
                {
                    orderGridView.DataSource = null;
                }
            }
        }
    }
}
