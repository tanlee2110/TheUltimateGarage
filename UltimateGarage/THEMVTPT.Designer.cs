namespace UltimateGarage
{
    partial class THEMVTPT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(THEMVTPT));
            thembtn = new Button();
            thoatbtn = new Button();
            label7 = new Label();
            label8 = new Label();
            panel1 = new Panel();
            VatTuPhuTung_Title = new Label();
            mavttxtbox = new Guna.UI2.WinForms.Guna2TextBox();
            tenvttxtbox = new Guna.UI2.WinForms.Guna2TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // thembtn
            // 
            thembtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            thembtn.Location = new Point(309, 101);
            thembtn.Margin = new Padding(3, 2, 3, 2);
            thembtn.Name = "thembtn";
            thembtn.Size = new Size(83, 22);
            thembtn.TabIndex = 68;
            thembtn.Text = "Thêm";
            thembtn.UseVisualStyleBackColor = true;
            thembtn.Click += thembtn_Click;
            // 
            // thoatbtn
            // 
            thoatbtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            thoatbtn.Location = new Point(398, 101);
            thoatbtn.Margin = new Padding(3, 2, 3, 2);
            thoatbtn.Name = "thoatbtn";
            thoatbtn.Size = new Size(83, 22);
            thoatbtn.TabIndex = 69;
            thoatbtn.Text = "Thoát";
            thoatbtn.UseVisualStyleBackColor = true;
            thoatbtn.Click += thoatbtn_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F);
            label7.Location = new Point(32, 71);
            label7.Name = "label7";
            label7.Size = new Size(93, 25);
            label7.TabIndex = 65;
            label7.Text = "Tên VTPT:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F);
            label8.Location = new Point(34, 47);
            label8.Name = "label8";
            label8.Size = new Size(91, 25);
            label8.TabIndex = 66;
            label8.Text = "Mã VTPT:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(222, 227, 62);
            panel1.Controls.Add(VatTuPhuTung_Title);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(494, 45);
            panel1.TabIndex = 70;
            // 
            // VatTuPhuTung_Title
            // 
            VatTuPhuTung_Title.Anchor = AnchorStyles.Top;
            VatTuPhuTung_Title.AutoSize = true;
            VatTuPhuTung_Title.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold);
            VatTuPhuTung_Title.ForeColor = Color.Black;
            VatTuPhuTung_Title.Location = new Point(69, 7);
            VatTuPhuTung_Title.Margin = new Padding(4, 0, 4, 0);
            VatTuPhuTung_Title.Name = "VatTuPhuTung_Title";
            VatTuPhuTung_Title.Size = new Size(346, 37);
            VatTuPhuTung_Title.TabIndex = 71;
            VatTuPhuTung_Title.Text = "THÊM VẬT TƯ PHỤ TÙNG";
            // 
            // mavttxtbox
            // 
            mavttxtbox.BackColor = Color.Transparent;
            mavttxtbox.BorderColor = Color.Black;
            mavttxtbox.BorderRadius = 5;
            mavttxtbox.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            mavttxtbox.CustomizableEdges = customizableEdges1;
            mavttxtbox.DefaultText = "";
            mavttxtbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            mavttxtbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            mavttxtbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            mavttxtbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            mavttxtbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            mavttxtbox.Font = new Font("Segoe UI", 9F);
            mavttxtbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            mavttxtbox.IconRightCursor = Cursors.AppStarting;
            mavttxtbox.Location = new Point(134, 49);
            mavttxtbox.Name = "mavttxtbox";
            mavttxtbox.PlaceholderText = "";
            mavttxtbox.SelectedText = "";
            mavttxtbox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            mavttxtbox.Size = new Size(314, 18);
            mavttxtbox.TabIndex = 72;
            // 
            // tenvttxtbox
            // 
            tenvttxtbox.BackColor = Color.Transparent;
            tenvttxtbox.BorderColor = Color.Black;
            tenvttxtbox.BorderRadius = 5;
            tenvttxtbox.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            tenvttxtbox.CustomizableEdges = customizableEdges3;
            tenvttxtbox.DefaultText = "";
            tenvttxtbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tenvttxtbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tenvttxtbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tenvttxtbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tenvttxtbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tenvttxtbox.Font = new Font("Segoe UI", 9F);
            tenvttxtbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tenvttxtbox.IconRightCursor = Cursors.AppStarting;
            tenvttxtbox.Location = new Point(134, 73);
            tenvttxtbox.Name = "tenvttxtbox";
            tenvttxtbox.PlaceholderText = "";
            tenvttxtbox.SelectedText = "";
            tenvttxtbox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tenvttxtbox.Size = new Size(314, 18);
            tenvttxtbox.TabIndex = 73;
            // 
            // THEMVTPT
            // 
            AcceptButton = thembtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            CancelButton = thoatbtn;
            ClientSize = new Size(490, 131);
            Controls.Add(tenvttxtbox);
            Controls.Add(mavttxtbox);
            Controls.Add(panel1);
            Controls.Add(thembtn);
            Controls.Add(thoatbtn);
            Controls.Add(label7);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "THEMVTPT";
            Text = "Thêm vật tư phụ tùng";
            Load += THEMVTPT_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button thembtn;
        private Button thoatbtn;
        private Label label7;
        private Label label8;
        private Panel panel1;
        private Label VatTuPhuTung_Title;
        private Guna.UI2.WinForms.Guna2TextBox mavttxtbox;
        private Guna.UI2.WinForms.Guna2TextBox tenvttxtbox;
    }
}