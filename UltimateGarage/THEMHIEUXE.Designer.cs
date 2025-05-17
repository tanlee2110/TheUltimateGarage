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
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -1);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 82);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(169, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(299, 54);
            label1.TabIndex = 2;
            label1.Text = "THÊM HIỆU XE";
            // 
            // thembtn
            // 
            thembtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            thembtn.Location = new Point(419, 131);
            thembtn.Margin = new Padding(4, 4, 4, 4);
            thembtn.Name = "thembtn";
            thembtn.Size = new Size(118, 36);
            thembtn.TabIndex = 62;
            thembtn.Text = "Thêm";
            thembtn.UseVisualStyleBackColor = true;
            // 
            // thoatbtn
            // 
            thoatbtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            thoatbtn.Location = new Point(544, 131);
            thoatbtn.Margin = new Padding(4, 4, 4, 4);
            thoatbtn.Name = "thoatbtn";
            thoatbtn.Size = new Size(118, 36);
            thoatbtn.TabIndex = 63;
            thoatbtn.Text = "Thoát";
            thoatbtn.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F);
            label8.Location = new Point(44, 85);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(117, 38);
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
            themtxtbox.Location = new Point(170, 90);
            themtxtbox.Margin = new Padding(4, 5, 4, 5);
            themtxtbox.Name = "themtxtbox";
            themtxtbox.PlaceholderText = "";
            themtxtbox.SelectedText = "";
            themtxtbox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            themtxtbox.Size = new Size(449, 30);
            themtxtbox.TabIndex = 69;
            // 
            // THEMHIEUXE
            // 
            AcceptButton = thembtn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            CancelButton = thoatbtn;
            ClientSize = new Size(676, 182);
            Controls.Add(themtxtbox);
            Controls.Add(label8);
            Controls.Add(thembtn);
            Controls.Add(thoatbtn);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
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