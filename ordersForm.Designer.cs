namespace Restaurant
{
    partial class ordersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ordersForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox1 = new PictureBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            tableListBox = new ListBox();
            orderGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderGridView).BeginInit();
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
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(-6, -4);
            guna2Panel1.Margin = new Padding(3, 4, 3, 4);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(1290, 145);
            guna2Panel1.TabIndex = 3;
            // 
            // tableListBox
            // 
            tableListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tableListBox.Font = new Font("Segoe UI", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableListBox.FormattingEnabled = true;
            tableListBox.ItemHeight = 21;
            tableListBox.Location = new Point(14, 148);
            tableListBox.Margin = new Padding(3, 4, 3, 4);
            tableListBox.Name = "tableListBox";
            tableListBox.Size = new Size(270, 340);
            tableListBox.TabIndex = 4;
            tableListBox.SelectedIndexChanged += tableListBox_SelectedIndexChanged;
            // 
            // orderGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            orderGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            orderGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.830189F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            orderGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            orderGridView.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            orderGridView.DefaultCellStyle = dataGridViewCellStyle3;
            orderGridView.GridColor = Color.FromArgb(231, 229, 255);
            orderGridView.Location = new Point(309, 148);
            orderGridView.Margin = new Padding(3, 4, 3, 4);
            orderGridView.Name = "orderGridView";
            orderGridView.RowHeadersVisible = false;
            orderGridView.RowHeadersWidth = 45;
            orderGridView.RowTemplate.Height = 27;
            orderGridView.Size = new Size(955, 551);
            orderGridView.TabIndex = 5;
            orderGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            orderGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            orderGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            orderGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            orderGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            orderGridView.ThemeStyle.BackColor = Color.White;
            orderGridView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            orderGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            orderGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            orderGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 8.830189F);
            orderGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            orderGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            orderGridView.ThemeStyle.HeaderStyle.Height = 30;
            orderGridView.ThemeStyle.ReadOnly = false;
            orderGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            orderGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            orderGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 8.830189F);
            orderGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            orderGridView.ThemeStyle.RowsStyle.Height = 27;
            orderGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            orderGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // guna2Button1
            // 
            guna2Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Enabled = false;
            guna2Button1.FillColor = Color.WhiteSmoke;
            guna2Button1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Location = new Point(309, 722);
            guna2Button1.Margin = new Padding(3, 4, 3, 4);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(227, 59);
            guna2Button1.TabIndex = 6;
            guna2Button1.Text = "Done";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2Button2
            // 
            guna2Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            guna2Button2.CustomizableEdges = customizableEdges5;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.WhiteSmoke;
            guna2Button2.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.Black;
            guna2Button2.Location = new Point(1037, 722);
            guna2Button2.Margin = new Padding(3, 4, 3, 4);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button2.Size = new Size(227, 59);
            guna2Button2.TabIndex = 7;
            guna2Button2.Text = "Back";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // ordersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1278, 795);
            Controls.Add(guna2Button2);
            Controls.Add(guna2Button1);
            Controls.Add(orderGridView);
            Controls.Add(tableListBox);
            Controls.Add(guna2Panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ordersForm";
            Text = "Orders";
            FormClosing += ordersForm_FormClosing;
            Load += ordersForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private ListBox tableListBox;
        private Guna.UI2.WinForms.Guna2DataGridView orderGridView;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}