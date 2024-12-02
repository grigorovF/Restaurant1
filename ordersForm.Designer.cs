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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            userNameLabel = new Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            tableListBox = new ListBox();
            orderGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderGridView).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(17, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(110, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // userNameLabel
            // 
            userNameLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            userNameLabel.AutoSize = true;
            userNameLabel.Font = new Font("Segoe UI", 21.73585F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            userNameLabel.ForeColor = Color.Black;
            userNameLabel.Location = new Point(142, 57);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(112, 45);
            userNameLabel.TabIndex = 0;
            userNameLabel.Text = "owner";
            // 
            // guna2Panel1
            // 
            guna2Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel1.BackColor = Color.Goldenrod;
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(userNameLabel);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Location = new Point(-5, -3);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(1129, 123);
            guna2Panel1.TabIndex = 3;
            // 
            // tableListBox
            // 
            tableListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableListBox.FormattingEnabled = true;
            tableListBox.ItemHeight = 17;
            tableListBox.Location = new Point(12, 126);
            tableListBox.Name = "tableListBox";
            tableListBox.Size = new Size(237, 310);
            tableListBox.TabIndex = 4;
            // 
            // orderGridView
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            orderGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 8.830189F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            orderGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            orderGridView.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            orderGridView.DefaultCellStyle = dataGridViewCellStyle6;
            orderGridView.GridColor = Color.FromArgb(231, 229, 255);
            orderGridView.Location = new Point(270, 126);
            orderGridView.Name = "orderGridView";
            orderGridView.RowHeadersVisible = false;
            orderGridView.RowHeadersWidth = 45;
            orderGridView.Size = new Size(836, 468);
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
            // ordersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1118, 676);
            Controls.Add(orderGridView);
            Controls.Add(tableListBox);
            Controls.Add(guna2Panel1);
            Name = "ordersForm";
            Text = "Orders";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orderGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label userNameLabel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private ListBox tableListBox;
        private Guna.UI2.WinForms.Guna2DataGridView orderGridView;
    }
}