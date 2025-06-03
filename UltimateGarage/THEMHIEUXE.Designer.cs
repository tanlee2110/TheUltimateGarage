namespace UltimateGarage
{
    partial class THEMHIEUXE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(THEMHIEUXE));
            panel1 = new Panel();
            label1 = new Label();
            thembtn = new Button();
            thoatbtn = new Button();
            label8 = new Label();
            themtxtbox = new Guna.UI2.WinForms.Guna2TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(222, 227, 62);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -1);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(475, 49);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(133, 7);
            label1.Name = "label1";
            label1.Size = new Size(204, 37);
            label1.TabIndex = 2;
            label1.Text = "THÊM HIỆU XE";
            // 
            // thembtn
            // 
            thembtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            thembtn.Location = new Point(293, 79);
            thembtn.Margin = new Padding(3, 2, 3, 2);
            thembtn.Name = "thembtn";
            thembtn.Size = new Size(83, 22);
            thembtn.TabIndex = 62;
            thembtn.Text = "Thêm";
            thembtn.UseVisualStyleBackColor = true;
            thembtn.Click += thembtn_Click;
            // 
            // thoatbtn
            // 
            thoatbtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            thoatbtn.Location = new Point(381, 79);
            thoatbtn.Margin = new Padding(3, 2, 3, 2);
            thoatbtn.Name = "thoatbtn";
            thoatbtn.Size = new Size(83, 22);
            thoatbtn.TabIndex = 63;
            thoatbtn.Text = "Thoát";
            thoatbtn.UseVisualStyleBackColor = true;
            thoatbtn.Click += thoatbtn_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F);
            label8.Location = new Point(31, 51);
            label8.Name = "label8";
            label8.Size = new Size(79, 25);
            label8.TabIndex = 68;
            label8.Text = "Hiệu xe:";
            // 
            // themtxtbox
            // 
            themtxtbox.BackColor = Color.Transparent;
            themtxtbox.BorderColor = Color.Black;
            themtxtbox.BorderRadius = 5;
            themtxtbox.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            themtxtbox.CustomizableEdges = customizableEdges1;
            themtxtbox.DefaultText = "";
            themtxtbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            themtxtbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            themtxtbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            themtxtbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            themtxtbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            themtxtbox.Font = new Font("Segoe UI", 9F);
            themtxtbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            themtxtbox.IconRightCursor = Cursors.AppStarting;
            themtxtbox.Location = new Point(119, 54);
            themtxtbox.Name = "themtxtbox";
            themtxtbox.PlaceholderText = "";
            themtxtbox.SelectedText = "";
            themtxtbox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            themtxtbox.Size = new Size(314, 18);
            themtxtbox.TabIndex = 69;
            // 
            // THEMHIEUXE
            // 
            AcceptButton = thembtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            CancelButton = thoatbtn;
            ClientSize = new Size(473, 109);
            Controls.Add(themtxtbox);
            Controls.Add(label8);
            Controls.Add(thembtn);
            Controls.Add(thoatbtn);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "THEMHIEUXE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm hiệu xe";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button thembtn;
        private Button thoatbtn;
        private Label label8;
        private Guna.UI2.WinForms.Guna2TextBox themtxtbox;
    }
}