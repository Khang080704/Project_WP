
# Tên Dự Án

Phần mềm theo theo dõi sức khỏe thông qua lượng calories tiêu hao hằng ngày.

  

## Mục lục

1. [UI/UX](#UI/UX)

2. [Design patterns/architecture](#DesignPatterns/Architecture)

3. [Advanced topics](#AdvancedTopics)

4. [Teamwork - Git flow](#Teamwork-GitFlow)

5. [Quality assurance](#QualityAssurance)
6. [Completed Features](#CompletedFeature)
7. [Product experience](#ProductExperience)
8. [Self-assessment](#SelfAssessment)

  
  

## UI/UX

### I. Giao diện chính trang Food Page
#### 1. UI
![foodpage-start.png](https://i.postimg.cc/51HR0LGz/foodpage-start.png)

Bố cục rõ ràng, có tổ chức: Giao diện được chia thành các phần rõ ràng cho từng bữa ăn trong ngày (Breakfast, Lunch, Dinner), với các tiêu đề dễ nhận biết và cách sắp xếp khoa học. Người dùng có thể nhanh chóng phân loại và quản lý các mục ăn uống một cách trực quan và dễ dàng.

Thông tin ngày, tháng, năm: Phần ngày tháng nằm ở vị trí nổi bật, giúp người dùng theo dõi quá trình nạp năng lượng hàng ngày và dễ dàng so sánh với các ngày trước đó.

Thông tin dinh dưỡng hiển thị dễ hiểu: Các chỉ số dinh dưỡng như Calories, Carbs, Fat, Protein, Sodium, và Sugar được sắp xếp thành các cột gọn gàng, dễ đọc. Các ô màu xám cho từng giá trị dinh dưỡng giúp làm nổi bật thông tin mà không gây rối mắt, trong khi thanh cuộn giúp người dùng dễ dàng theo dõi danh sách các thực phẩm đã được thêm vào.

Sử dụng màu sắc hiệu quả: Màu xanh dương nổi bật được sử dụng cho tiêu đề và các chỉ số tổng cộng, tạo sự cân bằng và giúp phân biệt thông tin quan trọng. Nút "Finish this entry" màu xanh lá cây tạo cảm giác hoàn thành và thu hút sự chú ý, nhắc nhở người dùng bấm nút này khi hoàn tất việc ghi nhật ký.

Thống kê số liệu cuối ngày: Phần tổng hợp ở cuối trang giúp người dùng có cái nhìn tổng quan về lượng dinh dưỡng đã tiêu thụ, mục tiêu hàng ngày, và lượng còn lại. Các số liệu này giúp người dùng dễ dàng đánh giá và điều chỉnh chế độ ăn uống của mình.

Tính trực quan và dễ sử dụng: Giao diện được thiết kế tối giản, tập trung vào cung cấp thông tin một cách nhanh chóng và dễ hiểu. Người dùng mới có thể làm quen và sử dụng dễ dàng mà không cần phải qua nhiều bước hướng dẫn.


### 2. UX
![foot_page_end](https://i.postimg.cc/C1rCNgc7/foodpage-end.png)
Dễ dàng nhập và chỉnh sửa thức ăn: Các tùy chọn "Add Food" và "Quick Tools" bên dưới mỗi bữa ăn cho phép người dùng linh hoạt thêm hoặc chỉnh sửa thức ăn một cách nhanh chóng. Tính năng này đặc biệt thuận tiện cho việc nhập liệu nhanh. Tính năng xóa món ăn giúp xóa món ăn ra khỏi danh sách sau khi đã hiển thị thông tin món ăn, thành phần dinh dưỡng trên trang chính.

Phản hồi tức thì về chỉ số dinh dưỡng còn lại: Phần "Remaining" ở cuối trang hiển thị các chỉ số còn lại so với mục tiêu hàng ngày (màu xanh cho đủ và màu đỏ cho thừa), giúp người dùng dễ dàng nhận biết nếu đã vượt quá hoặc chưa đạt mục tiêu. Đây là một phản hồi trực quan giúp người dùng điều chỉnh lượng ăn vào hàng ngày.

Cá nhân hóa và nhắc nhở hoàn thành: Nút "Finish this entry" hoạt động như một bước hoàn tất quy trình, giúp người dùng cảm nhận quá trình ghi chép đã hoàn tất và tạo động lực để quay lại vào ngày hôm sau.

Khả năng phản hồi và cung cấp thông tin rõ ràng: Giao diện sử dụng màu sắc khác nhau cho các chỉ số còn lại, giúp người dùng dễ dàng theo dõi và kiểm soát chế độ ăn uống của mình một cách trực quan và chính xác.

Khả năng điều hướng và truy cập dễ dàng: Thanh menu bên trái cho phép người dùng dễ dàng chuyển đổi giữa các mục khác nhau như Food, Exercise, và Proteins mà không gián đoạn quá trình nhập liệu trong mục Food Diary.

Tính năng cá nhân hóa: Việc đăng nhập bằng tài khoản email giúp người dùng lưu lại thông tin và đồng bộ hóa trên nhiều thiết bị. Người dùng có thể thay đổi ảnh đại diện theo sở thích cá nhân, ví dụ như đặt một ảnh truyền cảm hứng để làm động lực, giúp trải nghiệm trở nên thú vị và gần gũi hơn.

### II. Quick add

#### 1. UI
![quickadd_page](https://i.postimg.cc/sxnSmMd0/QuickAdd.jpg)
Giao diện tối giản, dễ nhìn: Giao diện chỉ chứa các trường nhập liệu cần thiết cho thông tin dinh dưỡng (Calories, Carbs, Fat, Protein, Sodium, Sugar), hiển thị tên bữa ăn cho người dùng biết mình đang nhập cho bữa ăn nào trong ngày và rất ít chi tiết rườm rà, giúp người dùng tập trung vào nhiệm vụ chính là nhập thông tin.

Sử dụng màu sắc hợp lý: Màu xanh lá trên nút "Add to Journal" giúp dễ nhận diện hành động quan trọng là thêm dữ liệu vào nhật ký. Nút "Cancel" màu trắng cũng tạo sự tương phản, giúp người dùng dễ dàng chọn lựa khi muốn hủy thao tác.


  #### 2. UX
  Đơn giản, dễ thao tác: Giao diện "Quick Add" được tối ưu hóa cho mục tiêu nhập liệu nhanh. Người dùng có thể nhập liệu nhanh chóng mà không cần thêm chi tiết như tên món ăn hoặc thành phần cụ thể. Điều này phù hợp cho những người dùng muốn ghi chép lượng calo tổng quát mà không cần quá chi tiết. 
  
  ### III. Add Food
  #### 1. UI
  ![AddFodd_page](https://i.postimg.cc/k5x2Yc9f/nh-ch-p-m-n-h-nh-2024-11-01-220536.png)
  Giao diện thân thiện và dễ sử dụng: Với bố cục đơn giản và rõ ràng, giao diện giúp người dùng dễ dàng thao tác mà không gặp khó khăn. Tông màu và thiết kế không gây rối mắt, tạo trải nghiệm người dùng thoải mái và dễ chịu.

Thiết kế thanh tìm kiếm rõ ràng: Thanh tìm kiếm dễ thấy và dễ sử dụng, giúp người dùng nhanh chóng nhập từ khóa để tìm thực phẩm. Sau khi tìm kiếm, các thông số về calories, carbs, fat, protein, sodium, và sugar được trình bày rõ ràng ngay bên cạnh tên thực phẩm. Điều này giúp người dùng nắm bắt thông tin nhanh chóng mà không cần nhấp thêm vào từng mục.
![SearchFood_page](https://i.postimg.cc/027ngrZK/list-addfood.png)

Nút chọn đơn vị linh hoạt: Menu lựa chọn đơn vị (grams, oz, lb, kilograms, cup,..) phù hợp với từng loại thực phẩm. Thiết kế gọn gàng và dễ thao tác, cho phép người dùng điều chỉnh đơn vị phù hợp với nhu cầu của mình.

Bố cục nút hợp lý: Các nút “Add Checked” và “Delete From The List” được đặt ngay dưới danh sách, dễ dàng truy cập và sử dụng mà không cần cuộn nhiều.

#### 2. UX
Tìm kiếm thực phẩm nhanh chóng: Với chức năng tìm kiếm, người dùng có thể nhanh chóng xác định thực phẩm cần thêm một cách nhanh chóng

Tính năng Quick Add Calories tiện lợi: Người dùng có thể thêm nhanh một lượng calories vào bữa ăn mà không phải chọn từng món, đáp ứng tốt nhu cầu nhanh chóng và đơn giản hóa quy trình theo dõi dinh dưỡng. (khi nhấn vào thì sẽ được chuyển sang tính năng quickadd với các chức năng đã được mô tả ở trên)

Thêm, Xóa món ăn dễ dàng: Bằng cách chọn các món ăn cần thêm vào và chọn số lượng và đơn vị tương ứng, nút bấm "add checked" sẽ giúp người dùng thêm vào trang food page. Tương tự với thêm, sau khi chọn, nút "delete from the list" giúp xóa món ăn khỏi danh sách nhanh chóng.

Tùy chỉnh linh hoạt số lượng và đơn vị: Người dùng có thể điều chỉnh số lượng thực phẩm theo nhu cầu và chọn đơn vị mong muốn. Điều này giúp người dùng dễ dàng theo dõi chính xác lượng dinh dưỡng mà họ tiêu thụ.

  


## Design patterns/architecture

### MVVM Design patterns

Sử dụng mẫu thiết kế MVVM, trong project có các folder:
- **Model**: Chứa các lớp
	+  **IDao**: Lớp giao diện chứa các phương thức lấy thông tin từ cơ sở dữ liệu thông qua các hàm GetAll()
	+ **MockDao**: Cài đặt chi tiết các hàm lấy thông tin, trả về 1 danh sách dữ liệu
- **ViewModel**: Chứa các lớp
	+ **Meal**: chứa thông tin 1 bữa ăn (tên bữa ăn)
	
	+ **ValueToColorConverter**: Converter có chức năng phát hiện thay đổi về giá trị số để thay đổi màu tương ứng (< 0: đỏ;  > 0: xanh; = 0:đen)
	+ **Nutritions**: Chưa thông tin của 1 chất dinh dưỡng

	+ **InputNutritionData** và **InputNutritionDataViewModel**: Class đóng vai trò như 1 bộ chuyển đổi dữ liệu từ các page khác khi chuyển đến FoodDiary thành 1 cách hiện thị thống nhất để hiển thị lên FoodDiary
		+ Dữ liệu từ các trang SearchFood, AddFood, FoodPage khi người dùng bấm các nút Add tương ứng ở các trang đó khi gửi đến FoodDiary sẽ ở nhiều dạng khác nhau (Tên bữa ăn, danh sách chất dưỡng; Tên bữa bữa ăn, tên món ăn, danh sách chất dinh dưỡng; Tên bữa ăn, danh sách món ăn, danh sách chất dinh dưỡng tương ứng).
		+ Khi đó, InputNutritionDataViewModel sẽ làm nhiệm vụ chuyển đổi các dữ liệu được chuyển đến thành 1 kiểu đối tượng chung InputNutritionData để thống nhất về cách hiển thị khi binding danh sách lên giao diện. 
		+ Các hàm như update(), updateWithFood(), updateWithListFood()  là các hàm chuyển đổi để thêm vào danh sách
	+ Các class **NutritionsViewModel**, **FoodPageViewModel**, **AddFoodViewModel**, **SearchFoodViewModel**: chịu trách nhiệm tạo và cập nhật dữ liệu bên dưới cho ứng dụng
- **View**: Chứa các file code xaml và code C# xử lí các logic cho các các page:
	+ **MainWindow.xaml**: cửa sổ chính của ứng dụng, dẫn đến các page khác 
	+ **FoodPage.xaml**, **AddFood.xaml**, **SearchFood.xaml**, **FoodDiary.xaml**: là các trang chính trong giao diện phần Food của ứng dụng, là nơi người dùng tương tác với ứng dung. Người dùng có thể chọn *QuickAdd* để nhập nhanh lượng dinh dưỡng hoặc *AddFood* để chọn các món ăn cho mình, hệ thống sẽ tính toán lượng dinh dưỡng của các món ăn đó
	+ Trong phần Food, lượng dinh dưỡng nạp vào của mỗi chất dựa trên 1 cơ thể khỏe mạnh, người dùng có thể dựa vào đó để đánh giá 1 ngày ăn uống của mình như vậy đã hợp lí chưa
 


 


  

## Advanced topics

  

## Teamwork - Git flow
+ Sử dụng **github**, 1 branch **main**
  + Thành viên 1 tạo repository ở chế độ public ,thành viên 2 clone repository về, thành viên 3 fork repository về
  + 2 thành viên sẽ có quyền push trực tiếp code lên branch **main**, 1 người tạo **pull request**, chủ repo chấp nhận code và merge vào branch **main**
+ Minh chứng commit:
![commit_history](https://i.postimg.cc/QCxQQz22/image.png)
![commit_history](https://i.postimg.cc/bvwMpgny/image.png)


  
  

## Quality assurance

## Completed Features
### Những tính năng đã hoàn thành:

 | Tên tính năng | Số giờ làm việc | 
 |---------------|-----------------|
 | Tính năng tính toán tổng lượng calories, các thành phần dinh dưỡng | 3h |  
 | Tính năng liệt kê thành phần dinh dưỡng trong từng món ăn | 3h | 
 | Tính năng chọn món | 3h | 
 |Tính năng cá nhân hóa|2h|


## Product Experience
Build và chạy Project, giao diện chính của ứng dụng sẽ như hình sau:
![HomePage](https://i.postimg.cc/qBFNnqsq/image.png)
### 1. Tính năng đổi ảnh đại diện
Ấn vào nút **Change your avatar**, chọn ảnh từ máy để thay đổi ảnh đại diện
### 2. Các tính năng ở phần Food
Chọn mục Food bên cột trái, giao diện chính của mục food:
![foodpage-start.png](https://i.postimg.cc/51HR0LGz/foodpage-start.png)
Ở mỗi phần tên bữa ăn (Breakfast, Lunch, Dinner, Snacks) đều có 2 nút là ***Add Food*** và ***Quick Tools***
+ Chọn ***Quick Tools*** để nhập nhanh số liệu của mỗi chất dinh dưỡng, giao diện của ***Quick Tools*** như sau:
![quickadd_page](https://i.postimg.cc/sxnSmMd0/QuickAdd.jpg)
+ Chọn Add to Journal để dữ liệu được cập nhật hoặc Cancel để hủy thao tác
+ Chọn ***Add Food*** để chọn các món ăn:
![AddFodd_page](https://i.postimg.cc/k5x2Yc9f/nh-ch-p-m-n-h-nh-2024-11-01-220536.png)
+ Hệ thống đề xuất 1 vài món ăn cụ thể, người dùng có thể tick vào để thêm vào danh sách hoặc tick để xóa món ăn đó ra khỏi danh sách, nếu danh sách đề xuất không chứa các món ăn người dùng cần thì có thể dùng đến thanh tìm kiếm phía trái góc trên của trang
+ Người dùng gõ vào từ khóa hoặc cả tên đầy đủ của món ăn, hệ thống sẽ tìm và cho ra các kết quả tương ứng với từ khóa vừa nhập, nếu muốn hiện 1 danh sách đầy đủ, người dùng để trống ô tìm kiếm và chọn *Search*
![SearchFood_page](https://i.postimg.cc/fTmyQqy5/image.png)
+ Chọn một món ăn bất kì, hệ thống sẽ yêu cầu 1 vài thông tin về định lượng cũng như thêm món ăn đó vào bữa ăn nào trong ngày

## Self-assessment
 | Tiêu chí | Tự đánh giá (trên thang 10) | 
 |---------------|-----------------|
 | UI/UX | 9 |  
 | Design Patter/Architecture| 9 | 
 | Advanced Topics |  | 
 |Teamwork - Git flow|9.5|
 |Quality assurance||