namespace UltimateGarage
{
    partial class CHITIETPNK
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHITIETPNK));
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ngaynhapdtpicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            mpntxtbox = new Guna.UI2.WinForms.Guna2TextBox();
            pnkvtptdtgrid = new Guna.UI2.WinForms.Guna2DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            thoatbtn = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnkvtptdtgrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(222, 227, 62);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1030, 49);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(256, 8);
            label1.Name = "label1";
            label1.Size = new Size(501, 37);
            label1.TabIndex = 1;
            label1.Text = "PHIẾU NHẬP KHO VẬT TƯ PHỤ TÙNG";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(155, 59);
            label2.Name = "label2";
            label2.Size = new Size(117, 21);
            label2.TabIndex = 4;
            label2.Text = "Mã phiếu nhập:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(531, 56);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 5;
            label3.Text = "Ngày nhập:";
            // 
            // ngaynhapdtpicker
            // 
            ngaynhapdtpicker.Checked = true;
            ngaynhapdtpicker.CustomizableEdges = customizableEdges1;
            ngaynhapdtpicker.FillColor = Color.FromArgb(241, 196, 15);
            ngaynhapdtpicker.Font = new Font("Segoe UI", 9F);
            ngaynhapdtpicker.Format = DateTimePickerFormat.Long;
            ngaynhapdtpicker.Location = new Point(634, 58);
            ngaynhapdtpicker.Margin = new Padding(1);
            ngaynhapdtpicker.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            ngaynhapdtpicker.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            ngaynhapdtpicker.Name = "ngaynhapdtpicker";
            ngaynhapdtpicker.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ngaynhapdtpicker.Size = new Size(218, 19);
            ngaynhapdtpicker.TabIndex = 6;
            ngaynhapdtpicker.Value = new DateTime(2025, 5, 18, 22, 10, 29, 776);
            // 
            // mpntxtbox
            // 
            mpntxtbox.BackColor = Color.Transparent;
            mpntxtbox.BorderColor = Color.Black;
            mpntxtbox.BorderRadius = 5;
            mpntxtbox.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            mpntxtbox.CustomizableEdges = customizableEdges3;
            mpntxtbox.DefaultText = "";
            mpntxtbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            mpntxtbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            mpntxtbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            mpntxtbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            mpntxtbox.FillColor = Color.Gainsboro;
            mpntxtbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            mpntxtbox.Font = new Font("Segoe UI", 9F);
            mpntxtbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            mpntxtbox.IconRightCursor = Cursors.AppStarting;
            mpntxtbox.Location = new Point(290, 59);
            mpntxtbox.Name = "mpntxtbox";
            mpntxtbox.PlaceholderText = "";
            mpntxtbox.ReadOnly = true;
            mpntxtbox.SelectedText = "";
            mpntxtbox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            mpntxtbox.Size = new Size(237, 19);
            mpntxtbox.TabIndex = 73;
            // 
            // pnkvtptdtgrid
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(251, 225, 184);
            pnkvtptdtgrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            pnkvtptdtgrid.BackgroundColor = SystemColors.ControlDark;
            pnkvtptdtgrid.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(243, 156, 18);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            pnkvtptdtgrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            pnkvtptdtgrid.ColumnHeadersHeight = 33;
            pnkvtptdtgrid.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(252, 235, 207);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(247, 189, 97);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            pnkvtptdtgrid.DefaultCellStyle = dataGridViewCellStyle3;
            pnkvtptdtgrid.GridColor = Color.FromArgb(250, 218, 171);
            pnkvtptdtgrid.Location = new Point(13, 84);
            pnkvtptdtgrid.Margin = new Padding(1);
            pnkvtptdtgrid.Name = "pnkvtptdtgrid";
            pnkvtptdtgrid.RowHeadersVisible = false;
            pnkvtptdtgrid.RowHeadersWidth = 51;
            pnkvtptdtgrid.RowTemplate.Height = 33;
            pnkvtptdtgrid.Size = new Size(1008, 366);
            pnkvtptdtgrid.TabIndex = 74;
            pnkvtptdtgrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Orange;
            pnkvtptdtgrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(251, 225, 184);
            pnkvtptdtgrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            pnkvtptdtgrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            pnkvtptdtgrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            pnkvtptdtgrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            pnkvtptdtgrid.ThemeStyle.BackColor = SystemColors.ControlDark;
            pnkvtptdtgrid.ThemeStyle.GridColor = Color.FromArgb(250, 218, 171);
            pnkvtptdtgrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(243, 156, 18);
            pnkvtptdtgrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            pnkvtptdtgrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            pnkvtptdtgrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            pnkvtptdtgrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            pnkvtptdtgrid.ThemeStyle.HeaderStyle.Height = 33;
            pnkvtptdtgrid.ThemeStyle.ReadOnly = false;
            pnkvtptdtgrid.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(252, 235, 207);
            pnkvtptdtgrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            pnkvtptdtgrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            pnkvtptdtgrid.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            pnkvtptdtgrid.ThemeStyle.RowsStyle.Height = 33;
            pnkvtptdtgrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(247, 189, 97);
            pnkvtptdtgrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "MaVTPT";
            Column1.HeaderText = "Mã VTPT";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.DataPropertyName = "TenVTPT";
            Column2.HeaderText = "Tên VTPT";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.DataPropertyName = "SoLuong";
            Column3.HeaderText = "Số lượng";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.DataPropertyName = "GiaNhap";
            Column4.HeaderText = "Đơn giá nhập";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // thoatbtn
            // 
            thoatbtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            thoatbtn.Location = new Point(938, 461);
            thoatbtn.Margin = new Padding(3, 2, 3, 2);
            thoatbtn.Name = "thoatbtn";
            thoatbtn.Size = new Size(83, 22);
            thoatbtn.TabIndex = 75;
            thoatbtn.Text = "Thoát";
            thoatbtn.UseVisualStyleBackColor = true;
            thoatbtn.Click += thoat_btnClick;
            // 
            // CHITIETPNK
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 492);
            Controls.Add(thoatbtn);
            Controls.Add(pnkvtptdtgrid);
            Controls.Add(mpntxtbox);
            Controls.Add(ngaynhapdtpicker);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(1);
            MaximizeBox = false;
            Name = "CHITIETPNK";
            Text = "CHITIETPNK";
            Load += CHITIETPNK_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnkvtptdtgrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker ngaynhapdtpicker;
        private Guna.UI2.WinForms.Guna2TextBox mpntxtbox;
        private Guna.UI2.WinForms.Guna2DataGridView pnkvtptdtgrid;
        private Button thoatbtn;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}