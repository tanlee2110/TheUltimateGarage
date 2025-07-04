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
            try
            {
                // Tạo prompt chuyên về sửa xe bằng tiếng Việt
                string systemPrompt = @"Bạn là chuyên gia sửa xe máy tại Việt Nam với 15 năm kinh nghiệm. 
                Hãy trả lời bằng tiếng Việt, ngắn gọn, dễ hiểu và đưa ra các bước kiểm tra cụ thể.
                Nếu không chắc chắn, hãy khuyên đưa xe đến garage để kiểm tra chuyên nghiệp.
                Luôn đưa ra lời khuyên an toàn và thực tế.";

                string fullPrompt = $"{systemPrompt}\n\nKhách hàng hỏi: {userMessage}";

                // Gọi Ollama API với Gemma:2b
                var httpClient = new HttpClient();
                var requestBody = new
                {
                    model = "gemma3",
                    messages = new[]
                    {
                        new { role = "user", content = fullPrompt }
                    },
                    stream = false,
                    options = new
                    {
                        temperature = 0.5,
                        top_p = 0.9,
                        num_predict = 500
                    }
                };

                var content = new StringContent(
                    JsonConvert.SerializeObject(requestBody), 
                    Encoding.UTF8, 
                    "application/json"
                );

                var response = await httpClient.PostAsync(
                    "http://localhost:11434/api/chat", 
                    content
                );

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseString);
                    return result.message.content.ToString();
                }
                else
                {
                    return "Xin lỗi, có lỗi kết nối với AI. Vui lòng kiểm tra:\n" +
                           "• Ollama đã được cài đặt và chạy chưa?\n" +
                           "• Model gemma3 đã được tải chưa?\n" +
                           "• Thử chạy lệnh 'ollama run gemma3' trong terminal.";
                }
            }
            catch (Exception ex)
            {
                return "Xin lỗi, có lỗi xảy ra khi kết nối với AI. Vui lòng thử lại sau.\n" +
                       "Lỗi chi tiết: " + ex.Message;
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