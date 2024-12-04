namespace Restaurant
{
    partial class userForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            userNameLabel = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            makeOrderToolStripMenuItem = new ToolStripMenuItem();
            makeInvoiceToolStripMenuItem = new ToolStripMenuItem();
            separatelyToolStripMenuItem = new ToolStripMenuItem();
            totalToolStripMenuItem = new ToolStripMenuItem();
            listBox1 = new ListBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            priceLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            productNameBox = new Guna.UI2.WinForms.Guna2TextBox();
            productQuantityBox = new Guna.UI2.WinForms.Guna2TextBox();
            addTableButton = new Guna.UI2.WinForms.Guna2Button();
            orderGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            sumaLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            invoiceGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            contextMenuStrip2 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderGrid).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)invoiceGrid).BeginInit();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(19, 15);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(126, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel1.BackColor = Color.Goldenrod;
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(userNameLabel);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(-9, -1);
            guna2Panel1.Margin = new Padding(3, 4, 3, 4);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(1250, 138);
            guna2Panel1.TabIndex = 2;
            // 
            // userNameLabel
            // 
            userNameLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            userNameLabel.AutoSize = true;
            userNameLabel.Font = new Font("Segoe UI", 21.73585F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            userNameLabel.ForeColor = Color.Black;
            userNameLabel.Location = new Point(162, 54);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(112, 45);
            userNameLabel.TabIndex = 0;
            userNameLabel.Text = "owner";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(18, 18);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { makeOrderToolStripMenuItem, makeInvoiceToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(166, 52);
            // 
            // makeOrderToolStripMenuItem
            // 
            makeOrderToolStripMenuItem.Name = "makeOrderToolStripMenuItem";
            makeOrderToolStripMenuItem.Size = new Size(165, 24);
            makeOrderToolStripMenuItem.Text = "Make Order";
            makeOrderToolStripMenuItem.Click += makeOrderToolStripMenuItem_Click;
            // 
            // makeInvoiceToolStripMenuItem
            // 
            makeInvoiceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { separatelyToolStripMenuItem, totalToolStripMenuItem });
            makeInvoiceToolStripMenuItem.Name = "makeInvoiceToolStripMenuItem";
            makeInvoiceToolStripMenuItem.Size = new Size(165, 24);
            makeInvoiceToolStripMenuItem.Text = "Make Invoice";
            // 
            // separatelyToolStripMenuItem
            // 
            separatelyToolStripMenuItem.Name = "separatelyToolStripMenuItem";
            separatelyToolStripMenuItem.Size = new Size(154, 24);
            separatelyToolStripMenuItem.Text = "Separately";
            // 
            // totalToolStripMenuItem
            // 
            totalToolStripMenuItem.Name = "totalToolStripMenuItem";
            totalToolStripMenuItem.Size = new Size(154, 24);
            totalToolStripMenuItem.Text = "Total";
            totalToolStripMenuItem.Click += totalToolStripMenuItem_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.Font = new Font("Segoe UI", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Location = new Point(936, 211);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.MinimumSize = new Size(279, 324);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(279, 319);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold);
            guna2HtmlLabel1.Location = new Point(14, 160);
            guna2HtmlLabel1.Margin = new Padding(3, 4, 3, 4);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(75, 27);
            guna2HtmlLabel1.TabIndex = 5;
            guna2HtmlLabel1.Text = "Product:";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold);
            guna2HtmlLabel2.Location = new Point(379, 160);
            guna2HtmlLabel2.Margin = new Padding(3, 4, 3, 4);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(83, 27);
            guna2HtmlLabel2.TabIndex = 6;
            guna2HtmlLabel2.Text = "Quantity:";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold);
            guna2HtmlLabel3.Location = new Point(733, 160);
            guna2HtmlLabel3.Margin = new Padding(3, 4, 3, 4);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(50, 27);
            guna2HtmlLabel3.TabIndex = 7;
            guna2HtmlLabel3.Text = "Price:";
            // 
            // priceLabel
            // 
            priceLabel.BackColor = Color.Transparent;
            priceLabel.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold);
            priceLabel.Location = new Point(818, 160);
            priceLabel.Margin = new Padding(3, 4, 3, 4);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(3, 2);
            priceLabel.TabIndex = 8;
            priceLabel.Text = null;
            priceLabel.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // productNameBox
            // 
            productNameBox.CustomizableEdges = customizableEdges3;
            productNameBox.DefaultText = "";
            productNameBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            productNameBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            productNameBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            productNameBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            productNameBox.Enabled = false;
            productNameBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            productNameBox.Font = new Font("Segoe UI", 9F);
            productNameBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            productNameBox.Location = new Point(106, 144);
            productNameBox.Margin = new Padding(3, 4, 3, 4);
            productNameBox.Name = "productNameBox";
            productNameBox.PasswordChar = '\0';
            productNameBox.PlaceholderText = "";
            productNameBox.SelectedText = "";
            productNameBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            productNameBox.Size = new Size(253, 53);
            productNameBox.TabIndex = 9;
            productNameBox.TextChanged += productNameBox_TextChanged;
            // 
            // productQuantityBox
            // 
            productQuantityBox.CustomizableEdges = customizableEdges5;
            productQuantityBox.DefaultText = "";
            productQuantityBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            productQuantityBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            productQuantityBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            productQuantityBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            productQuantityBox.Enabled = false;
            productQuantityBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            productQuantityBox.Font = new Font("Segoe UI", 9F);
            productQuantityBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            productQuantityBox.Location = new Point(481, 144);
            productQuantityBox.Margin = new Padding(3, 4, 3, 4);
            productQuantityBox.Name = "productQuantityBox";
            productQuantityBox.PasswordChar = '\0';
            productQuantityBox.PlaceholderText = "";
            productQuantityBox.SelectedText = "";
            productQuantityBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            productQuantityBox.Size = new Size(160, 53);
            productQuantityBox.TabIndex = 10;
            productQuantityBox.KeyDown += productQuantityBox_KeyDown;
            // 
            // addTableButton
            // 
            addTableButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addTableButton.CustomizableEdges = customizableEdges7;
            addTableButton.DisabledState.BorderColor = Color.DarkGray;
            addTableButton.DisabledState.CustomBorderColor = Color.DarkGray;
            addTableButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            addTableButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            addTableButton.FillColor = Color.WhiteSmoke;
            addTableButton.Font = new Font("Segoe UI", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addTableButton.ForeColor = Color.Black;
            addTableButton.Location = new Point(936, 542);
            addTableButton.Margin = new Padding(3, 4, 3, 4);
            addTableButton.Name = "addTableButton";
            addTableButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            addTableButton.Size = new Size(280, 59);
            addTableButton.TabIndex = 11;
            addTableButton.Text = "+ Add Table";
            addTableButton.Click += addTableButton_Click;
            // 
            // orderGrid
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            orderGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.830189F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            orderGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            orderGrid.ColumnHeadersHeight = 4;
            orderGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8.830189F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            orderGrid.DefaultCellStyle = dataGridViewCellStyle3;
            orderGrid.GridColor = Color.FromArgb(231, 229, 255);
            orderGrid.Location = new Point(66, 416);
            orderGrid.Margin = new Padding(3, 4, 3, 4);
            orderGrid.Name = "orderGrid";
            orderGrid.RowHeadersVisible = false;
            orderGrid.RowHeadersWidth = 45;
            orderGrid.RowTemplate.Height = 27;
            orderGrid.Size = new Size(741, 195);
            orderGrid.TabIndex = 12;
            orderGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            orderGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            orderGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            orderGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            orderGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            orderGrid.ThemeStyle.BackColor = Color.White;
            orderGrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            orderGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            orderGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            orderGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 8.830189F);
            orderGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            orderGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            orderGrid.ThemeStyle.HeaderStyle.Height = 4;
            orderGrid.ThemeStyle.ReadOnly = false;
            orderGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            orderGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            orderGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 8.830189F);
            orderGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            orderGrid.ThemeStyle.RowsStyle.Height = 27;
            orderGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            orderGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            orderGrid.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
            tableLayoutPanel1.Controls.Add(sumaLabel2, 1, 0);
            tableLayoutPanel1.Controls.Add(guna2HtmlLabel4, 0, 0);
            tableLayoutPanel1.Location = new Point(650, 700);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(253, 49);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // sumaLabel2
            // 
            sumaLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            sumaLabel2.BackColor = Color.Transparent;
            sumaLabel2.Font = new Font("Segoe UI", 10.8679247F, FontStyle.Bold);
            sumaLabel2.Location = new Point(247, 43);
            sumaLabel2.Margin = new Padding(3, 4, 3, 4);
            sumaLabel2.Name = "sumaLabel2";
            sumaLabel2.Size = new Size(3, 2);
            sumaLabel2.TabIndex = 15;
            sumaLabel2.Text = null;
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 10.8679247F, FontStyle.Bold);
            guna2HtmlLabel4.Location = new Point(46, 22);
            guna2HtmlLabel4.Margin = new Padding(3, 4, 3, 4);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(46, 23);
            guna2HtmlLabel4.TabIndex = 14;
            guna2HtmlLabel4.Text = "Total:";
            guna2HtmlLabel4.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // invoiceGrid
            // 
            invoiceGrid.AllowUserToAddRows = false;
            invoiceGrid.AllowUserToDeleteRows = false;
            invoiceGrid.AllowUserToResizeColumns = false;
            invoiceGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            invoiceGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            invoiceGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.MediumBlue;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            invoiceGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            invoiceGrid.ColumnHeadersHeight = 30;
            invoiceGrid.ContextMenuStrip = contextMenuStrip2;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            invoiceGrid.DefaultCellStyle = dataGridViewCellStyle6;
            invoiceGrid.GridColor = Color.FromArgb(231, 229, 255);
            invoiceGrid.Location = new Point(10, 214);
            invoiceGrid.Margin = new Padding(3, 4, 3, 4);
            invoiceGrid.Name = "invoiceGrid";
            invoiceGrid.ReadOnly = true;
            invoiceGrid.RowHeadersVisible = false;
            invoiceGrid.RowHeadersWidth = 45;
            invoiceGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            invoiceGrid.RowTemplate.Height = 27;
            invoiceGrid.Size = new Size(893, 479);
            invoiceGrid.TabIndex = 14;
            invoiceGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            invoiceGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            invoiceGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            invoiceGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            invoiceGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            invoiceGrid.ThemeStyle.BackColor = Color.White;
            invoiceGrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            invoiceGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            invoiceGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            invoiceGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 8.830189F);
            invoiceGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            invoiceGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            invoiceGrid.ThemeStyle.HeaderStyle.Height = 30;
            invoiceGrid.ThemeStyle.ReadOnly = true;
            invoiceGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            invoiceGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            invoiceGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 8.830189F);
            invoiceGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            invoiceGrid.ThemeStyle.RowsStyle.Height = 27;
            invoiceGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            invoiceGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            invoiceGrid.KeyDown += invoiceGrid_KeyDown;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(18, 18);
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(193, 52);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(192, 24);
            deleteToolStripMenuItem.Text = "Delete ";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click_1;
            // 
            // userForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1230, 764);
            Controls.Add(invoiceGrid);
            Controls.Add(orderGrid);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(addTableButton);
            Controls.Add(productQuantityBox);
            Controls.Add(productNameBox);
            Controls.Add(priceLabel);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(listBox1);
            Controls.Add(guna2Panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "userForm";
            Text = "userForm";
            FormClosing += userForm_FormClosing;
            Load += userForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderGrid).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)invoiceGrid).EndInit();
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label userNameLabel;
        private ListBox listBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel priceLabel;
        private Guna.UI2.WinForms.Guna2TextBox productNameBox;
        private Guna.UI2.WinForms.Guna2TextBox productQuantityBox;
        private Guna.UI2.WinForms.Guna2Button addTableButton;
        private Guna.UI2.WinForms.Guna2DataGridView orderGrid;
        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel sumaLabel2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem makeOrderToolStripMenuItem;
        private ToolStripMenuItem makeInvoiceToolStripMenuItem;
        private ToolStripMenuItem separatelyToolStripMenuItem;
        private ToolStripMenuItem totalToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DataGridView invoiceGrid;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}