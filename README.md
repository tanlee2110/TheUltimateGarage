# The Ultimate Garage 2

Ứng dụng quản lý garage xe máy với tính năng trò chuyện AI để tư vấn sửa xe.

## Tính năng chính

### Quản lý garage
- Quản lý thông tin xe và chủ xe
- Quản lý phiếu sửa chữa
- Quản lý vật tư phụ tùng
- Quản lý nhân viên
- Báo cáo doanh thu và tồn kho

### 🤖 Trợ lý AI - Tư vấn sửa xe
Tính năng mới được thêm vào ứng dụng:

**Cách truy cập:**
- Vào menu "Trợ giúp" → "AI Chat"

**Chức năng:**
- Đề xuất cách sửa chữa xe dựa trên mô tả vấn đề
- Giải thích các vấn đề thường gặp
- Tư vấn về bảo dưỡng xe
- Ước tính chi phí sửa chữa

**Các chủ đề AI có thể tư vấn:**
- **Động cơ**: Không nổ, tiếng ồn, rung lắc
- **Phanh**: Mềm, không ăn, tiếng kêu
- **Lốp xe**: Mòn, phẳng, áp suất
- **Điện**: Đèn, ắc quy, cầu chì
- **Bảo dưỡng**: Lịch bảo dưỡng định kỳ
- **Chi phí**: Ước tính chi phí sửa chữa

**Cách sử dụng:**
1. Mở form AI Chat
2. Mô tả vấn đề của xe (VD: "Động cơ không nổ", "Phanh mềm")
3. AI sẽ đưa ra các nguyên nhân có thể và khuyến nghị kiểm tra
4. Có thể tiếp tục hỏi thêm để được tư vấn chi tiết hơn

## Công nghệ sử dụng
- **.NET 8.0** - Framework chính
- **WinForms** - Giao diện người dùng
- **Guna.UI2** - UI Components
- **SQL Server** - Cơ sở dữ liệu
- **Newtonsoft.Json** - Xử lý JSON
- **AI đơn giản** - Dựa trên từ khóa và logic rule-based

## Cài đặt và chạy
1. Clone repository
2. Mở solution trong Visual Studio
3. Restore NuGet packages
4. Cấu hình connection string database
5. Build và chạy ứng dụng

## Lưu ý
- AI Chat sử dụng logic đơn giản dựa trên từ khóa, không cần kết nối internet
- Các đề xuất chỉ mang tính tham khảo, cần đưa xe đến garage để kiểm tra thực tế
- Có thể mở rộng tính năng AI bằng cách tích hợp với các API AI thực tế
