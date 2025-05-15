namespace UltimateGarage
{
    partial class TIEPNHANXE
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
            panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.CustomizableEdges = customizableEdges1;
            panel1.FillColor = Color.FromArgb(222, 227, 62);
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panel1.Size = new Size(611, 74);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(169, 10);
            label1.Name = "label1";
            label1.Size = new Size(259, 47);
            label1.TabIndex = 0;
            label1.Text = "PHIẾU THU TIỀN";
            // 
            // TIEPNHANXE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 450);
            Controls.Add(panel1);
            Name = "TIEPNHANXE";
            Text = "TIEPNHANXE";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel label1;
    }
}