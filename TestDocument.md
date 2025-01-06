# Test plan

### 1. Mục tiêu kiểm thử
- Xác định được ứng dụng hoạt động được theo những yêu cầu đã được đề cập trong Proposal.
- Đảm bảo ứng dụng hoạt động tốt, không phát sinh những lỗi nghiêm trọng.
- Đảm bảo ứng dụng thân thiện với người dùng, tạo cảm giác thoải mái, không gây sự phức tạp khi sử dụng.
- Kiểm tra, phát hiện được nhiều lỗi nhất có thể để có những phương án fix lỗi trong tương lai.

### 2. Các chức năng chính kiểm thử
- Login
- Search
- Lưu trữ data food của một ngày bất kì
- Lưu trữ data exercise của một ngày bất kì
- Recent Food
- Recent Exercise
- Frequent Food
- My Food
- Create Exercise
- Change Password
- Tính năng tạo động lực
- Tính năng khảo sát sức khỏe đầu vào

### 3. Kỹ thuật kiểm thử
#### a) Kiểm thử chức năng (Functional Testing):
- **Mục tiêu**: Đảm bảo các chức năng chính của hệ thống hoạt động đúng theo yêu cầu.
- **Phương pháp**: 
    - Xác định ra những chức năng chính cần kiểm thử
    - Dựa vào *Tài liệu thiết kế* để hiểu được cách ứng dụng hoạt động. Từ đó, xác định mỗi chức năng tạo ra các test case với những mục tiêu khác nhau để bắt được lỗi của hệ thống.
    - Dựa vào *Tài liệu hướng dẫn sử dụng* xác định được *Expected Output*. Từ đó đối chiếu với *Actual Output* để xem chức năng đó có hoạt động đúng như đã dự định ban đầu.

#### b) Kiểm thử giao diện người dùng (Usability Testing):
- **Mục tiêu**: Đảm bảo giao diện của ứng dụng tạo cảm giác thoải mái cho người dùng, các thao tác với ứng dụng dễ được tiếp cận.
- **Phương pháp**: 
    - Đánh giá giao diện phản hồi. Các thông báo xuất hiện phải được thông báo rõ ràng, sạch đẹp cho người dùng có thể hiểu. Đặc biệt là các thông báo lỗi, tránh tình trạng ứng dụng bị văng ra khi lỗi, cần thông báo lỗi một cách tinh tế cho người dùng.
    - Đánh giá mức độ dễ dùng của hệ thống. 

### 4. Môi trường kiểm thử
- **Thiết bị kiểm thử**:  Laptop Ram tối thiểu 8GB, ổ cứng SSD tối thiểu 256GB, CPU 4 cores.
- **Phần mềm kiểm thử**: Microsoft Visual Studio 2022, SQL Server Management Studio 20, Docker

### 5. Lịch trình kiểm thử

| Hoạt động kiểm thử | Thời gian bắt đầu | Thời gian kết thúc |
|--------------------|-------------------|--------------------|
| Viết test case | Viết test case | 20/12/2024 | 24/12/2024 |
| Thực hiện Functional Testing | 25/12/2024 | 27/12/2024 |
| Thực hiện Usability Testing | 27/12/2024 | 29/12/2024 |
| Sửa lỗi ứng dụng dựa vào test report | 30/12/2024| 2/1/2025 |
| Thực hiện lại các Testing sau khi fix lỗi | 3/1/2025 |5/1/2024 |


# Test case

| STT | Tên test case | Đối tượng test | Ý nghĩa |
|-----|--------------|----------------|---------|
|1|Login với correct username và correct password| Login | Kiểm tra hệ thống có phản hồi lại đúng nếu người dùng nhớ chính xác username và password |
|2|Login in với username hoặc password để trống| Login |  Kiểm tra hệ thống có phản hồi lại đúng nếu người dùng quên nhập password hoặc username|
|3| Login với invalid username| Login| Kiểm tra hệ thống có phản hồi lại đúng nếu người dùng nhập sai username hoặc password |
|4| Search với từ khóa trống | Search | Kiểm tra hệ thống có phản hồi lại đúng nếu người dùng quên nhập cố ý bỏ quên từ khóa trống|
|5| Search với từ khóa không tồn tại | Search | Người dùng lần đầu vào phần mềm, search một cú pháp bất kì để xem phần mềm có gì?|
|6| Search với từ khóa không đầy đủ	| Search | Người dùng không nhớ rõ tên món ăn hay bài tập|
|7| Phần Food, thêm số lượng là một chuỗi của món ăn sau khi đã Search | Search | Người dùng nhập định dạng không hợp lệ|
|8| Phần Exercise, thêm thời gian là chuỗi của bài tập sau khi Search | Search | 	Người dùng nhập định dạng không hợp lệ|
|9| Lưu data food từ database của hệ thống thông qua search cho ngày 30/12/2024 | Lưu trữ data Food | Đảm bảo người dùng có thể lưu các món ăn mình chọn trong ngày|
|10| Lưu data food từ database của hệ thống thông qua search cho nhiều ngày	| Lưu trữ data Food | Đảm bảo người dùng có thể lưu các món ăn mình chọn trong nhiều ngày|
|11| Xóa dữ liệu data food và thêm mới dữ liệu data food khác vào các bữa ăn của ngày bất kì |Lưu trữ data Food| Người dùng có thể cập nhật các Food theo các ngày|
|12| Lưu data exercise từ database của hệ thống thông qua search cho ngày 30/12/2024| Lưu trữ data Exercise | Đảm bảo người dùng có thể lưu các bài tập mình chọn trong ngày|
|13| Lưu data exercise từ database của hệ thống thông qua search cho nhiều ngày	| Lưu trữ data Exercise | Đảm bảo người dùng có thể lưu các bài tập mình chọn trong nhiều ngày|
|14| Xóa dữ liệu data exercise và thêm mới dữ liệu data exercise khác vào các ngày bất kì | Lưu trữ data Exercise | Người dùng có thể cập nhật các Exercise theo các ngày|
|15| Cập nhật Recent Food đúng | Recent Food | Người dùng có thể chọn lại các món ăn mình chọn trong những lần gần đây |
|16 | Add Recent Food vào data Food của ngày hiện tại với dữ liệu là invalid| Recent Food | Người dùng nhập định dạng không hợp lệ|
|17| Cập nhật Recent Exercise đúng| Recent Exercise| Người dùng có thể chọn lại các bài tập mình chọn trong những lần gần đây |
|18| Add Recent Exercise vào data Exercise của ngày hiện tại với dữ liệu là invalid	| Recent Exercise| Người dùng nhập định dạng không hợp lệ|
|19| Cập nhật Frequent Food đúng | Frequent Food | Người dùng có thể chọn lại các món ăn mình chọn nhiều nhất | 
|20| Add Frequent Food vào data Food của ngày hiện tại với dữ liệu là invalid| Frequent Food| Người dùng nhập định dạng không hợp lệ|
|21| Cập nhật My Food đúng | My Food | Người dùng có thể tự tạo món ăn theo sở thích của mình|
|22| Tạo My Food với dữ liệu Invalid | My Food |  Người dùng nhập định dạng không hợp lệ|
|23| Cập nhật Create Exercise đúng	| Create Exercise | Người dùng có thể tự tạo bài tập theo sở thích của mình|
|24| Create Exercise với dữ liệu Invalid | Create Exercise | Người dùng nhập định dạng không hợp lệ|
|25| Change password với current password wrong | Change Password | Người dùng muốn đổi password nhưng password hiện tại nhập sai|
|26| Change password với new password trống	| Change Password | Người dùng muốn đổi password nhưng password hiện tại không nhớ nên để trống|
|27| Change password với new password khác với confirm password	| Change Password | Người dùng muốn đổi password nhưng nhập sai dữ liệu giữa new password và confirm password|
|28| Sign In lần đầu trong 1 ngày | Tính năng tạo động lực | Hệ thống sẽ hiện lên một câu động lực sau khi người dùng Sign In lần đầu trong 1 ngày |
|29| Sign In lần thứ 2,3,4,…. trong 1 ngày (Không phải lần đầu)	| Tính năng tạo động lực | Hệ thống sẽ **không** hiện lên một câu động lực sau khi người dùng Sign In các lần 2,3,... trong 1 ngày |	
|30| Sign in lần đầu tiên sau khi Sign Up | Tính năng khảo sát sức khỏe đầu vào | Hệ thống sẽ đưa người dùng đến trang khảo sát sức khỏe, tính toán lượng calories cần thiết vì đây là lần đầu người dùng Sign in vào hệ thống|
|31| Sign in lần thứ 2, 3,….| Tính năng khảo sát sức khỏe đầu vào | Hệ thống sẽ vào trang Home mà **không** đưa người dùng đến trang khảo sát sức khỏe, tính toán lượng calories cần thiết vì đây là các lần 2,3.... người dùng Sign in vào hệ thống|

# Test Report

Link Test Report: [TestReport.xlsx](./TestReport.xlsx)
