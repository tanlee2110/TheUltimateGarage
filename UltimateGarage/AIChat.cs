using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;

namespace UltimateGarage
{
    public partial class AIChat : Form
    {
        private readonly HttpClient httpClient;
        private readonly List<ChatMessage> chatHistory;

        public AIChat()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            chatHistory = new List<ChatMessage>();
            
            // Thêm tin nhắn chào mừng
            AddMessage("AI", "Xin chào! Tôi là trợ lý AI của garage. Tôi có thể giúp bạn:\n" +
                "• Đề xuất cách sửa chữa xe\n" +
                "• Giải thích các vấn đề thường gặp\n" +
                "• Tư vấn về bảo dưỡng xe\n" +
                "• Ước tính chi phí sửa chữa\n\n" +
                "Hãy mô tả vấn đề của xe để tôi có thể giúp bạn!", false);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtChat.Clear();
            chatHistory.Clear();
            AddMessage("AI", "Xin chào! Tôi là trợ lý AI của garage. Tôi có thể giúp bạn:\n" +
                "• Đề xuất cách sửa chữa xe\n" +
                "• Giải thích các vấn đề thường gặp\n" +
                "• Tư vấn về bảo dưỡng xe\n" +
                "• Ước tính chi phí sửa chữa\n\n" +
                "Hãy mô tả vấn đề của xe để tôi có thể giúp bạn!", false);
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && !ModifierKeys.HasFlag(Keys.Shift))
            {
                e.Handled = true;
                SendMessage();
            }
        }

        private async void SendMessage()
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
                return;

            string userMessage = txtInput.Text.Trim();
            AddMessage("Bạn", userMessage, true);
            chatHistory.Add(new ChatMessage { Sender = "User", Content = userMessage });

            txtInput.Clear();
            btnSend.Enabled = false;
            btnSend.Text = "Đang xử lý...";

            try
            {
                string aiResponse = await GetAIResponse(userMessage);
                AddMessage("AI", aiResponse, false);
                chatHistory.Add(new ChatMessage { Sender = "AI", Content = aiResponse });
            }
            catch (Exception ex)
            {
                AddMessage("AI", "Xin lỗi, có lỗi xảy ra khi xử lý yêu cầu của bạn. Vui lòng thử lại sau.", false);
            }
            finally
            {
                btnSend.Enabled = true;
                btnSend.Text = "Gửi";
            }
        }

        private void AddMessage(string sender, string message, bool isUser)
        {
            txtChat.SelectionStart = txtChat.TextLength;
            txtChat.SelectionLength = 0;

            // Thêm tên người gửi
            txtChat.SelectionColor = isUser ? Color.Blue : Color.Green;
            txtChat.AppendText($"{sender}: ");
            
            // Thêm nội dung tin nhắn
            txtChat.SelectionColor = Color.Black;
            txtChat.AppendText(message + "\n\n");
            
            txtChat.ScrollToCaret();
        }

        private async Task<string> GetAIResponse(string userMessage)
        {
            // Sử dụng AI đơn giản dựa trên từ khóa
            string response = GenerateSimpleAIResponse(userMessage);
            
            // Thêm delay để tạo cảm giác AI đang suy nghĩ
            await Task.Delay(1000);
            
            return response;
        }

        private string GenerateSimpleAIResponse(string userMessage)
        {
            string message = userMessage.ToLower();
            
            // Các từ khóa về động cơ
            if (message.Contains("động cơ") || message.Contains("máy") || message.Contains("engine"))
            {
                if (message.Contains("không nổ") || message.Contains("không khởi động"))
                {
                    return "Vấn đề động cơ không nổ có thể do:\n" +
                           "• Ắc quy yếu hoặc hết điện\n" +
                           "• Bugi bị mòn hoặc bẩn\n" +
                           "• Bộ lọc gió bị tắc\n" +
                           "• Hết xăng\n" +
                           "• Hệ thống đánh lửa bị lỗi\n\n" +
                           "Khuyến nghị: Kiểm tra ắc quy trước, sau đó đến bugi và bộ lọc gió.";
                }
                else if (message.Contains("tiếng ồn") || message.Contains("ồn") || message.Contains("kêu"))
                {
                    return "Tiếng ồn từ động cơ có thể do:\n" +
                           "• Dây đai bị mòn hoặc lỏng\n" +
                           "• Bơm nước bị hỏng\n" +
                           "• Van bị lỗi\n" +
                           "• Động cơ thiếu dầu nhớt\n\n" +
                           "Khuyến nghị: Kiểm tra mức dầu nhớt và dây đai trước.";
                }
                else
                {
                    return "Vấn đề về động cơ có thể do:\n" +
                           "• Thiếu dầu nhớt\n" +
                           "• Bộ lọc gió bẩn\n" +
                           "• Bugi bị mòn\n" +
                           "• Hệ thống làm mát\n\n" +
                           "Khuyến nghị: Kiểm tra mức dầu nhớt và bộ lọc gió trước.";
                }
            }
            
            // Các từ khóa về phanh
            else if (message.Contains("phanh") || message.Contains("brake"))
            {
                if (message.Contains("mềm") || message.Contains("không ăn"))
                {
                    return "Phanh mềm có thể do:\n" +
                           "• Thiếu dầu phanh\n" +
                           "• Rò rỉ dầu phanh\n" +
                           "• Má phanh bị mòn\n" +
                           "• Không khí trong hệ thống phanh\n\n" +
                           "Khuyến nghị: Kiểm tra mức dầu phanh và rò rỉ ngay lập tức.";
                }
                else
                {
                    return "Vấn đề về phanh có thể do:\n" +
                           "• Má phanh bị mòn\n" +
                           "• Dầu phanh bẩn\n" +
                           "• Đĩa phanh bị cong\n" +
                           "• Hệ thống phanh bị lỗi\n\n" +
                           "Khuyến nghị: Kiểm tra má phanh và dầu phanh.";
                }
            }
            
            // Các từ khóa về lốp xe
            else if (message.Contains("lốp") || message.Contains("vỏ") || message.Contains("tire"))
            {
                if (message.Contains("mòn") || message.Contains("phẳng"))
                {
                    return "Lốp xe bị mòn có thể do:\n" +
                           "• Áp suất lốp không đều\n" +
                           "• Căn chỉnh bánh xe sai\n" +
                           "• Chạy quá tốc độ\n" +
                           "• Tải trọng quá nặng\n\n" +
                           "Khuyến nghị: Thay lốp mới và kiểm tra căn chỉnh bánh xe.";
                }
                else
                {
                    return "Vấn đề về lốp xe có thể do:\n" +
                           "• Áp suất lốp không đúng\n" +
                           "• Lốp bị thủng\n" +
                           "• Lốp bị mòn không đều\n" +
                           "• Cân bằng bánh xe\n\n" +
                           "Khuyến nghị: Kiểm tra áp suất và tình trạng lốp.";
                }
            }
            
            // Các từ khóa về điện
            else if (message.Contains("điện") || message.Contains("đèn") || message.Contains("light"))
            {
                return "Vấn đề về điện có thể do:\n" +
                       "• Ắc quy yếu\n" +
                       "• Cầu chì bị cháy\n" +
                       "• Dây điện bị đứt\n" +
                       "• Công tắc bị hỏng\n\n" +
                       "Khuyến nghị: Kiểm tra ắc quy và cầu chì trước.";
            }
            
            // Các từ khóa về bảo dưỡng
            else if (message.Contains("bảo dưỡng") || message.Contains("maintenance"))
            {
                return "Bảo dưỡng xe định kỳ bao gồm:\n" +
                       "• Thay dầu nhớt động cơ (5,000-10,000 km)\n" +
                       "• Thay bộ lọc gió (20,000 km)\n" +
                       "• Thay bộ lọc nhiên liệu (40,000 km)\n" +
                       "• Kiểm tra phanh (10,000 km)\n" +
                       "• Căn chỉnh bánh xe (20,000 km)\n\n" +
                       "Khuyến nghị: Tuân thủ lịch bảo dưỡng để xe hoạt động tốt.";
            }
            
            // Các từ khóa về chi phí
            else if (message.Contains("giá") || message.Contains("tiền") || message.Contains("chi phí") || message.Contains("cost"))
            {
                return "Chi phí sửa chữa phụ thuộc vào:\n" +
                       "• Loại xe và năm sản xuất\n" +
                       "• Mức độ hư hỏng\n" +
                       "• Phụ tùng cần thay\n" +
                       "• Thời gian lao động\n\n" +
                       "Khuyến nghị: Đưa xe đến garage để được báo giá chính xác.";
            }
            
            // Câu trả lời mặc định
            else
            {
                return "Tôi hiểu bạn đang gặp vấn đề với xe. Để tôi có thể giúp bạn tốt hơn, hãy mô tả chi tiết:\n" +
                       "• Vấn đề gì đang xảy ra?\n" +
                       "• Có tiếng ồn lạ không?\n" +
                       "• Đèn báo lỗi có sáng không?\n" +
                       "• Vấn đề xảy ra khi nào?\n\n" +
                       "Hoặc bạn có thể hỏi về: động cơ, phanh, lốp xe, điện, bảo dưỡng, hoặc chi phí sửa chữa.";
            }
        }
    }

    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
} 