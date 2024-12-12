# THAO TÁC VỚI TỪNG USER KHÁC NHAU

**Lưu ý**: Chạy lại migration Database để lấy Database mới nhất (Chạy seeder ít nhất 2 lần)

Lớp UserSessionService trong folder Services lưu giữ tài khoản mail user hiện tại sau khi đã đăng nhập thành công. Nếu muốn truy xuất mail thì hãy gọi lệnh UserSessionService.Instance.UserEmail

Trong Database, bảng User có cột DailyCaloriesGoal chứa Calories cho từng user (**cần cập nhật lại HOMEPAGE lấy dữ liệu CaloriesGoal cho từng User từ đây**)

Hiện tại trong hầu hết tất cả các bảng đều cập nhật thêm cột USER_EMAIL nhằm xác định dữ liệu nào trong bảng sẽ thuộc về user nào (Ngoài trừ các bảng FOOD, CARDIOEXERCISE, STRENGTHEXERCISE vì đây là các bảng dữ liệu của hệ thống, user không đụng đến)