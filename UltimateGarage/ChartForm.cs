using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace UltimateGarage
{
    public partial class ChartForm : Form
    {
        private List<string> labels;
        private List<double> values;
        private string title;

        public ChartForm(List<string> labels, List<double> values, string title = "Biểu đồ doanh thu theo tháng")
        {
            InitializeComponent();
            this.labels = labels;
            this.values = values;
            this.title = title;
            this.DoubleBuffered = true;
            this.Width = 800;
            this.Height = 600;
            this.Text = title;

            // Thêm Label cho title
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);
            this.Controls.Add(lblTitle);

            int legendX = 550;
            int legendY = 150;
            int boxSize = 24;
            int spacing = 30;
            Font legendFont = new Font("Arial", 14, FontStyle.Bold);
            Color[] colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow,
                Color.Purple, Color.Orange, Color.Pink, Color.Brown,
                Color.Cyan, Color.Magenta, Color.Lime, Color.Gray
            };

            for (int i = 0; i < 12; i++)
            {
                // Panel màu
                Panel colorBox = new Panel();
                colorBox.BackColor = colors[i % colors.Length];
                colorBox.Width = boxSize;
                colorBox.Height = boxSize;
                colorBox.Left = legendX;
                colorBox.Top = legendY + i * spacing;
                colorBox.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(colorBox);

                // Label tháng
                Label lbl = new Label();
                lbl.Text = $"Tháng {i + 1}";
                lbl.Font = legendFont;
                lbl.ForeColor = Color.Black;
                lbl.BackColor = Color.Transparent;
                lbl.AutoSize = true;
                lbl.Left = legendX + boxSize + 8;
                lbl.Top = legendY + i * spacing + (boxSize - lbl.Height) / 2;
                this.Controls.Add(lbl);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawPieChart(e.Graphics);
        }

        private void DrawPieChart(Graphics g)
        {
            // Tính toán tổng giá trị (tối đa 12 tháng)
            double total = 0;
            int n = 12;
            for (int i = 0; i < n; i++)
            {
                double value = (values != null && i < values.Count) ? values[i] : 0;
                total += value;
            }

            if (total <= 0 || values.TrueForAll(v => v == 0))
            {
                using (Font font = new Font("Arial", 16, FontStyle.Bold))
                {
                    g.DrawString("Không có dữ liệu để vẽ biểu đồ", font, Brushes.Red, 20, 300);
                }
                return;
            }

            // Vẽ biểu đồ tròn
            Rectangle pieRect = new Rectangle(100, 100, 400, 400);
            float startAngle = 0;
            Color[] colors = new Color[] 
            { 
                Color.Red, Color.Blue, Color.Green, Color.Yellow, 
                Color.Purple, Color.Orange, Color.Pink, Color.Brown,
                Color.Cyan, Color.Magenta, Color.Lime, Color.Gray
            };

            // Vẽ từng phần của biểu đồ (nếu có dữ liệu)
            if (total > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    double value = (values != null && i < values.Count) ? values[i] : 0;
                    if (value <= 0) continue;
                    float sweepAngle = (float)(value / total * 360);
                    using (Brush brush = new SolidBrush(colors[i % colors.Length]))
                    {
                        g.FillPie(brush, pieRect, startAngle, sweepAngle);
                    }

                    // Tính phần trăm
                    double percent = value / total * 100;
                    string percentText = $"{percent:0.#}%";

                    // Tính góc ở giữa phần này
                    float midAngle = startAngle + sweepAngle / 2;
                    double radians = midAngle * Math.PI / 180;

                    // Tính vị trí text (giữa hình tròn, cách tâm một đoạn)
                    float centerX = pieRect.Left + pieRect.Width / 2;
                    float centerY = pieRect.Top + pieRect.Height / 2;
                    float radius = pieRect.Width / 2 * 0.7f; // 0.7 để text nằm trong hình tròn
                    float textX = centerX + (float)(radius * Math.Cos(radians)) - 15;
                    float textY = centerY + (float)(radius * Math.Sin(radians)) - 10;

                    // Vẽ text phần trăm
                    using (Font percentFont = new Font("Arial", 12, FontStyle.Bold))
                    {
                        g.DrawString(percentText, percentFont, Brushes.Black, textX, textY);
                    }

                    startAngle += sweepAngle;
                }
            }
        }
    }
}
