


# Tên Dự Án

Phần mềm theo theo dõi sức khỏe thông qua lượng calories tiêu hao hằng ngày.
https://drive.google.com/drive/folders/1ABBcYKWm1sasS0I0_q6ABft9E3ZnoKcf?usp=sharing

  

## Mục lục


1. [Members's information](#members-information)
2. [UI/UX](#a-uiux)
3. [Design patterns/architecture](#design-patternsarchitecture)

4. [Advanced topics](#advanced-topics)

5. [Teamwork - Git flow](#teamwork---git-flow)

6. [Quality assurance](#quality-assurance)
7. [Completed Features](#completed-features)
8. [Product experience](#product-experience)
9. [Work assignment](#work-assignment-bảng-phân-công-công-việc-từ-đầu-dự-án-cho-đến-nay)
10. [Self-assessment](#self-assessment)
11. [Database Document](#tài-liệu-cơ-sở-dữ-liệu)
12. [Test Document](#tài-liệu-kiểm-thử)
13. [Doxygen Document](#tài-liệu-doxygen)

  
  
## Members Information
| MSSV | Tên thành viên | 
 |---------------|-----------------|
 | 22120116 | Đoàn Gia Huệ |  
 | 22120152| Phạm Gia Khang | 
 | 22120236 | Nguyễn Hoàng Nguyên | 

## A. UI/UX

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

### **Bổ sung cho milestone 2:**
-- --
### IV. Trang HomePage
#### 1. UI

![HomePage_1](https://i.postimg.cc/mDHppmDs/image.png)
UI hiển thị rõ 3 chỉ số nổi trội là **Base Goal**, **Food** và **Exercise** trong đó:
+ **Base Goal**: Lượng Calo mục tiêu do người dùng thiết lập, người dùng có thể thay đổi mục Base Goal này
+ **Food**: Tổng lượng Calo nạp vào cơ thể ở mục Food, người dùng có thể theo dõi chỉ số tổng này bên page Food
+ **Exercise**: Tổng lượng Calo tiêu thụ ở mục Exercise, người dùng có thể theo dõi lượng Calo bên page Exercise ở phần *Calories Burned*, chỉ số sẽ được cập nhật ở Home Page
+ **Remaining**: Được tính bằng  **Base Goal** + **Food** - **Exercise**, mỗi khi có thay đổi bên phần kia, chỉ số này sẽ được cập nhật lại để người dùng có thể theo dõi tiến độ của mình trong ngày hôm đó
![](https://i.postimg.cc/52GYTBkB/image.png)
  _Chỉ số được cập nhật_

### V. Exercise Page
#### 1. UI
![ExPage1](./ImageForReport/exe%20page%201.png)


![ExPage2](./ImageForReport/exe%20page%202.png)
*Giao diện chính trang Exercise*

- Bố cục rõ ràng, dễ theo dõi: Giao diện được chia thành các khu vực chức năng chính, gồm:
  + **Cardiovascular**: Hiển thị số phút và lượng calories tiêu hao trong bài tập tim mạch.
  + **Strength Training**: Cung cấp các thông số về số set, số reps mỗi set và trọng lượng tập.
Today's Exercise Notes: Phần ghi chú để người dùng viết thêm các thông tin quan trọng liên quan đến bài tập.

- Cách bố trí theo dạng khối (blocks) dễ nhìn, phù hợp với thói quen theo dõi nhanh của người dùng.
- Màu sắc sử dụng nổi bật và tương phản tốt:
Màu xanh dương làm nổi bật tiêu đề và các nút nhập thông số, giúp thu hút sự chú ý 	vào các thông tin quan trọng.
Màu xanh lá cây cho nút <span style="color: green"> "View Full Report (Printable)"</span> tạo cảm giác khuyến khích 	người dùng hoàn tất quy trình hoặc kiểm tra báo cáo tổng hợp.
- Đồng nhất về font chữ và kích thước:
	Font chữ đơn giản, không rườm rà, giúp nội dung dễ đọc và truyền đạt thông tin 	nhanh chóng.
	Các tiêu đề lớn hơn (ví dụ "Cardiovascular", "Strength Training") được in đậm, làm 	rõ ràng từng phần trong giao diện.

- Sử dụng các ô nhập liệu gọn gàng:
	Ô nhập ***Minutes***, ***Calories Burned***, và các thông số tập luyện như ***Sets***, ***Reps/Set***, ***Weight/Set*** được thiết kế vừa đủ lớn, dễ dàng tương tác.

- Thanh điều hướng nhất quán:
	Thanh bên trái bao gồm các mục chính như **Home**, **Food**, **Exercise**, giúp người 	dùng dễ dàng chuyển đổi giữa các tính năng.

#### 2. UX
- Chức năng chọn ngày: Lựa chọn ngày ở đầu giao diện được thiết kế trực quan, giúp 	người dùng chuyển đổi giữa các ngày tập luyện một cách thuận tiện.

- Tích hợp nhiều thông tin trong một giao diện: Giao diện cung cấp đủ thông tin như 	tổng lượng calo đốt cháy, thời gian tập luyện, số set, số lần lặp, và ghi chú cá 	nhân, giúp người dùng dễ dàng theo dõi toàn diện.

- Dễ dàng ghi nhật ký bài tập:
	Các khu vực như Add Exercise dưới cả hai phần **"Cardiovascular"** và **"Strength Training"** cho phép người dùng nhanh chóng thêm, xóa bài tập mà không cần tìm kiếm 	phức tạp.

- Phản hồi trực tiếp từ giao diện:
	**Daily Total / Goal** và **Weekly Total / Goal** là các chỉ số tức thời, giúp người dùng 	theo dõi tiến độ tập luyện hàng ngày và cả tuần. Việc này khuyến khích người dùng 	đạt được mục tiêu đã đặt ra.

- Cá nhân hóa và tính linh hoạt:
	Người dùng có thể tự ghi chú trong phần Today's Exercise Notes, giúp họ bổ sung 	thông tin cá nhân, ví dụ như cảm giác sau bài tập hoặc các lưu ý cho lần tập tiếp 	theo.
	Giao diện hiển thị ngày tháng (Your exercise journal for 12/7/2024) hỗ trợ việc lưu 	trữ và kiểm tra lại thông tin từ những ngày trước.

- Khả năng in báo cáo: 
	Nút **"View Full Report (Printable)"** giúp người dùng dễ dàng lưu trữ báo cáo dưới 	dạng in ấn, phù hợp cho những ai muốn theo dõi tiến trình lâu dài hoặc chia sẻ với 	huấn luyện viên cá nhân.

- Khả năng điều hướng nhanh:
	Thanh menu bên trái giúp người dùng chuyển qua các tính năng khác mà không phải rời	khỏi giao diện hiện tại.

### VI. Add cardiovation
#### 1. Tìm kiếm
##### a. UI
![AddCar](./ImageForReport/add%20cardivo1.png)
*Giao diện chính*
- Thiết kế tối giản:
Giao diện không có quá nhiều chi tiết phức tạp, tập trung duy nhất vào thanh tìm kiếm và hướng dẫn, giúp người dùng dễ dàng nhận biết bước tiếp theo.

- Thanh tìm kiếm nổi bật:
Thanh tìm kiếm nằm ở vị trí trung tâm, kích thước lớn, thu hút ánh nhìn của người dùng ngay lập tức.
Nút "Search" màu xanh lá cây nổi bật trên nền trắng, tạo sự rõ ràng và khuyến khích hành động.

- Hướng dẫn bổ sung dễ hiểu:
Dòng chữ hướng dẫn **"Or, add your most recently used cardio exercises"** sử dụng font chữ đơn giản, dễ đọc, đặt ngay bên dưới thanh tìm kiếm, cung cấp thông tin rõ ràng mà không gây áp lực.
##### b. UX
- Phản hồi ngay lập tức:
Khi không có kết quả tìm kiếm phù hợp, giao diện nhanh chóng cung cấp trạng thái rõ ràng, không để người dùng bị lạc lõng.
ví dụ: 

![addcar1a](./ImageForReport/add%20cardio%201a.png)
*Hệ thống nhắc nhở người dùng nhập sai*
 
- Hỗ trợ hành động tiếp theo:
Giao diện gợi ý rõ ràng những lựa chọn tiếp theo: thử tìm kiếm lại hoặc chọn bài tập cardio gần đây nhất. Điều này đảm bảo người dùng luôn biết mình cần làm gì.Trong trường hợp trên, sau khi chỉ nhập chữ "r" thì giao diện sẽ hiển thị thông báo hướng dẫn người dùng nhập lại cho đúng ( chi tiết mô tả ở phần VI.2)
Thiết kế không chứa yếu tố dư thừa, khiến người dùng chỉ cần tập trung vào một hành động duy nhất: nhập lại từ khóa hoặc chọn bài tập khác.

#### 2. Thêm bài tập CARDIO Exercise
##### a. UI
![Cardio2](./ImageForReport/add%20cardio%202.png)
*Giao diện chính trang tìm kiếm*

- Bố cục rõ ràng và trực quan:
Giao diện được chia thành hai phần chính, giúp người dùng dễ dàng xác định các khu vực chức năng:
Khu vực danh sách bài tập: Danh sách bài tập hiển thị rõ ràng, sắp xếp theo chiều dọc, thuận tiện cho việc duyệt nhanh.
Khu vực nhập thông tin: Phần nhập liệu được đóng khung riêng, tạo sự tập trung và đảm bảo không bị nhầm lẫn khi thao tác.

- Sử dụng màu sắc hiệu quả:
<span style="color: blue">Màu xanh dương</span> cho tiêu đề và các liên kết (bài tập) tạo cảm giác thân thiện, dễ đọc, và thống nhất với phong cách ứng dụng.
<span style="color: red">Màu đỏ</span> được sử dụng làm điểm nhấn cho tên bài tập đang chọn (<span style="color: red">Canoeing, on camping trip</span>), giúp người dùng dễ nhận biết mình đang làm việc với bài tập nào.
Nút hành động ("<span style="color: green">Add Exercise</span>") có màu <span style="color: green">xanh lá cây</span> nổi bật, dễ dàng nhận diện, làm rõ bước tiếp theo mà người dùng cần thực hiện.

- Hiển thị rõ ràng thông tin cần thiết:
Font chữ to, dễ đọc cho cả danh sách bài tập và các trường nhập thông tin.
Các trường nhập liệu ("**How long**," "**Calories burned**,") được đặt trong một bố cục gọn gàng, không gây rối mắt.
Danh sách bài tập được sắp xếp hợp lý, cho phép người dùng cuộn để xem toàn bộ mà không bị cản trở.

- Tính nhất quán cao:
Các phần của giao diện tuân theo cùng một phong cách thiết kế: font chữ, màu sắc, kích thước nút bấm và bố cục đều được giữ đồng nhất, giúp trải nghiệm dễ dàng và liền mạch.

##### b. UX
- Quy trình mạch lạc và liền mạch:
Giao diện dẫn dắt người dùng một cách tự nhiên qua từng bước: tìm bài tập, chọn bài tập, nhập thông tin, và thêm vào danh sách.
Không cần chuyển qua nhiều màn hình để thực hiện một tác vụ, giảm thiểu sự gián đoạn.

- Tìm kiếm và gợi ý hiệu quả:
Thanh tìm kiếm giúp người dùng nhập từ khóa một cách nhanh chóng để tìm bài tập, ngay cả khi không nhớ chính xác tên đầy đủ.
Gợi ý danh sách bài tập phù hợp ngay khi người dùng nhập từ khóa, tiết kiệm thời gian và công sức.

- Nhập liệu dễ dàng và rõ ràng
Phần nhập liệu được chia thành các trường nhỏ gọn với nhãn rõ ràng và cụ thể.
Các trường nhập không có yếu tố dư thừa, tập trung vào các thông số quan trọng nhất .
=> Người dùng không phải suy nghĩ nhiều về cách điền thông tin, giảm áp lực trong quá trình sử dụng.

- Mở rộng chức năng, tăng tính cá nhân hóa:
Trong trường hợp người dùng muốn thêm một bài tập mà không có sẵn ở database, chương trình có hỗ trợ tính nắng đó như sau. Nhấp vào dòng chữ hướng dẫn "Can't find what you're looking for? Add an exercise to the database" Cho phép người dùng góp phần làm phong phú thêm cơ sở dữ liệu của ứng dụng. Người dùng tự thêm vào database một bài tập mới và có thể ước lượng qui định và nhập dữ liệu vào các trường ("**Exercise description**", "**How long**," "**Calories burned**"). Sau đó nhấn "add" để xác nhận thêm một bài tập mới.

![Cardio3a](./ImageForReport/add%20cardio%203b.png)
*Thêm 1 bài tập mới*

Kết quả sau khi vào mục tìm kiếm như sau

![Cardi3b](./ImageForReport/add%20cardio%204.png)
*Bài tập mới đã được thêm vào*

### VII. Add Strength Training Exercise
#### 1. Tìm kiếm
##### a. UI
![Str1](./ImageForReport/add%20streight1.png)
*Giao diện chính của trang tìm kiếm*
- Thiết kế tối giản:
Giao diện không có quá nhiều chi tiết phức tạp, tập trung duy nhất vào thanh tìm kiếm và hướng dẫn, giúp người dùng dễ dàng nhận biết bước tiếp theo.

- Thanh tìm kiếm nổi bật:
Thanh tìm kiếm nằm ở vị trí trung tâm, kích thước lớn, thu hút ánh nhìn của người dùng ngay lập tức.
Nút "**Search**" màu xanh lá cây nổi bật trên nền trắng, tạo sự rõ ràng và khuyến khích hành động.

- Hướng dẫn bổ sung dễ hiểu:
Dòng chữ hướng dẫn "**Or, add your most recently used cardio exercises**" sử dụng font chữ đơn giản, dễ đọc, đặt ngay bên dưới thanh tìm kiếm, cung cấp thông tin rõ ràng mà không gây áp lực.

##### b. UX
- Phản hồi ngay lập tức:
Khi không có kết quả tìm kiếm phù hợp, giao diện nhanh chóng cung cấp trạng thái rõ ràng, không để người dùng bị lạc lõng.
 
- Hỗ trợ hành động tiếp theo:
Giao diện gợi ý rõ ràng những lựa chọn tiếp theo: thử tìm kiếm lại hoặc chọn bài tập cardio gần đây nhất. Điều này đảm bảo người dùng luôn biết mình cần làm gì.Trong trường hợp trên, sau khi chỉ nhập chữ "r" thì giao diện sẽ hiển thị thông báo hướng dẫn người dùng nhập lại cho đúng ( chi tiết mô tả ở phần **VII.2**)
Thiết kế không chứa yếu tố dư thừa, khiến người dùng chỉ cần tập trung vào một hành động duy nhất: nhập lại từ khóa hoặc chọn bài tập khác.

#### 2. Thêm bài tập Strength Training Exercise
##### a. UI
![AddStr2](./ImageForReport/add%20streight2.png)
*Chọn bài tập*

- Bố cục rõ ràng và trực quan:
Giao diện được chia thành hai phần chính, giúp người dùng dễ dàng xác định các khu vực chức năng:
Khu vực danh sách bài tập: Danh sách bài tập hiển thị rõ ràng, sắp xếp theo chiều dọc, thuận tiện cho việc duyệt nhanh.
Khu vực nhập thông tin: Phần nhập liệu được đóng khung riêng, tạo sự tập trung và đảm bảo không bị nhầm lẫn khi thao tác.

- Sử dụng màu sắc hiệu quả:
<span style="color: blue">Màu xanh dương</span> cho tiêu đề và các liên kết (bài tập) tạo cảm giác thân thiện, dễ đọc, và thống nhất với phong cách ứng dụng.
<span style="color: red">Màu đỏ</span> được sử dụng làm điểm nhấn cho tên bài tập đang chọn (<span style="color: red">Flat Dumbbell Fly</span>), giúp người dùng dễ nhận biết mình đang làm việc với bài tập nào.
Nút hành động ("<span style="color: green">Add Exercise</span>") có màu <span style="color: green">xanh lá cây</span> nổi bật, dễ dàng nhận diện, làm rõ bước tiếp theo mà người dùng cần thực hiện.

- Hiển thị rõ ràng thông tin cần thiết:
Font chữ to, dễ đọc cho cả danh sách bài tập và các trường nhập thông tin.
Các trường nhập liệu ("**Number of sets**," "**Repetitions per set**," "**Weight per set**") được đặt trong một bố cục gọn gàng, không gây rối mắt.
Danh sách bài tập được sắp xếp hợp lý, cho phép người dùng cuộn để xem toàn bộ mà không bị cản trở.

- Tính nhất quán cao:
Các phần của giao diện tuân theo cùng một phong cách thiết kế: font chữ, màu sắc, kích thước nút bấm và bố cục đều được giữ đồng nhất, giúp trải nghiệm dễ dàng và liền mạch.

##### b. UX
- Quy trình mạch lạc và liền mạch:
Giao diện dẫn dắt người dùng một cách tự nhiên qua từng bước: tìm bài tập, chọn bài tập, nhập thông tin, và thêm vào danh sách.
Không cần chuyển qua nhiều màn hình để thực hiện một tác vụ, giảm thiểu sự gián đoạn.

- Tìm kiếm và gợi ý hiệu quả:
Thanh tìm kiếm giúp người dùng nhập từ khóa một cách nhanh chóng để tìm bài tập, ngay cả khi không nhớ chính xác tên đầy đủ.
Gợi ý danh sách bài tập phù hợp ngay khi người dùng nhập từ khóa, tiết kiệm thời gian và công sức.

- Nhập liệu dễ dàng và rõ ràng
Phần nhập liệu được chia thành các trường nhỏ gọn (**Number of sets**, **Repetitions per set**, **Weight per set**) với nhãn rõ ràng và cụ thể.
Các trường nhập không có yếu tố dư thừa, tập trung vào các thông số quan trọng nhất đối với Strength Training.
=> Người dùng không phải suy nghĩ nhiều về cách điền thông tin, giảm áp lực trong quá trình sử dụng.


- Mở rộng chức năng: Cho phép người dùng góp phần làm phong phú thêm cơ sở dữ liệu của ứng dụng. Người dùng tự thêm vào database một bài tập mới và có thể ước lượng qui định và nhập dữ liệu vào các trường (***exercise description***, ***sets***, ***repetition/sets***, ***weight/sets***). Hỗ trợ tương tự như đã mô tả ở phần mở rộng chức năng **VI.2.b**
![AddStr3](./ImageForReport/add%20streight%203.png)
*Tạo bài tập mới*
- Tập trung vào hành động chính:
Nút hành động nổi bật ("**Add Exercise**") ngay dưới phần nhập thông tin, dễ nhận biết, giúp người dùng nhanh chóng hoàn thành mục tiêu của mình.
Không có các yếu tố gây nhiễu hoặc không cần thiết trên màn hình.

- Tăng tính cá nhân hóa:
Tên bài tập đang chọn (*Flat Dumbbell Fly*) được hiển thị rõ ràng và nổi bật, tạo sự tập trung và cá nhân hóa trải nghiệm.

- Đáp ứng nhanh và đơn giản:
Người dùng chỉ cần tối đa 3 bước để hoàn thành việc thêm bài tập: tìm kiếm → chọn bài tập → nhập thông tin → bấm nút "Add Exercise."
Phần nhập liệu dễ hiểu, không có trường nào dư thừa hay không cần thiết.

- Thân thiện với cả người mới và người đã quen thuộc
Với những người mới, giao diện đơn giản và rõ ràng giúp họ nhanh chóng làm quen mà không cần phải xem hướng dẫn chi tiết.
Với người dùng đã quen thuộc, họ có thể thực hiện tác vụ nhanh chóng chỉ với vài bước.
=> Đảm bảo ứng dụng dễ dùng cho mọi cấp độ người dùng.

### **Bổ sung cho milestone 3:**
-- --
### VIII. Sign up/Sign in
#### 1. Giao diện Sign in
##### a. UI.
![AddStr3](./ImageForReport/signin.png)
*Giao diện sign in*
- Bố cục hợp lý: Logo ("KEEP IT FIT"): Được đặt ở vị trí trung tâm và nổi bật với font chữ lớn, tạo sự chú ý mạnh mẽ và nhấn mạnh thương hiệu.
- Form đăng nhập: Được căn giữa màn hình, giúp người dùng dễ tập trung và thao tác nhanh chóng.
- Sử dụng màu sắc: 
<span style="color: blue">Màu xanh đậm</span> của logo và nút <span style="color: blue">"Sign In"</span> tạo điểm nhấn, tăng sự thu hút.
Màu trắng nền giúp giao diện thoáng, sạch sẽ và dễ đọc.
- Nút hành động:
"**Sign In**": Nút lớn, màu xanh đậm, dễ nhận diện là nút chính.
"**Sign up now**": Văn bản liên kết dưới nút đăng nhập, với màu xanh lam để nhấn mạnh, hướng dẫn người dùng chưa có tài khoản.
- Kiểu chữ: Font chữ rõ ràng, kích thước hợp lý
Tiêu đề lớn "**KEEP IT FIT**" thu hút sự chú ý.
Văn bản "***Member Login***" và các nhãn trường nhập liệu dễ đọc.
Dòng "***Not a member? Sign up now***" sử dụng màu sắc khác biệt và cỡ chữ nhỏ hơn để không làm người dùng nhầm lẫn.
- Tính năng biểu tượng "hiển thị mật khẩu": Biểu tượng hình con mắt ở ô mật khẩu là một cải tiến giúp người dùng kiểm tra mật khẩu đã nhập mà không cần xóa và nhập lại.
- Liên kết: Liên kết <span style="color: blue">***Sign Up now***</span> giúp điều hướng dễ dàng cho người dùng chưa có tài khoản, với màu sắc khác biệt và dễ nhận biết.
##### b. UX.
- Hướng dẫn và dễ hiểu:
Tiêu đề và các nhãn trường nhập liệu được viết rõ ràng, giúp người dùng nhanh chóng hiểu được mục đích của trang.
Dòng hướng dẫn “*Not a member? Sign up now*” ngay dưới nút "**Sign In**" là một cách tiếp cận trực tiếp, giúp người dùng chưa có tài khoản dễ dàng tìm thấy tùy chọn đăng ký.
- Tập trung vào hành động chính:
Nút "**Sign In**" được thiết kế nổi bật để nhấn mạnh hành động chính.
Tùy chọn "**Sign up now**" sử dụng màu xanh lam nhưng có cỡ chữ nhỏ hơn để tránh gây nhầm lẫn với nút chính.
- Thân thiện với người dùng: Biểu tượng "**hiển thị/ẩn mật khẩu**" cho phép người dùng kiểm tra chính xác thông tin họ nhập, tăng tính chính xác và giảm căng thẳng.
- Trực quan và logic:
Các trường nhập liệu được sắp xếp theo thứ tự hợp lý (Email trước, Mật khẩu sau), phù hợp với thói quen của người dùng.
Dòng "**Not a member? Sign up now**" được đặt gần nút đăng nhập, giúp người dùng chưa có tài khoản không phải tìm kiếm lâu.
- Đơn giản hóa thao tác: Người dùng chỉ cần thực hiện một trong hai hành động chính: Đăng nhập hoặc Đăng ký. Điều này giúp giảm tải thông tin và tạo trải nghiệm mượt mà hơn.
- Phản hồi nhanh: Nếu đăng nhập thất bại, giao diện có thể hiện thông báo lỗi (dựa trên thiết kế UI hoàn chỉnh), giúp người dùng nhanh chóng khắc phục.
- Hỗ trợ người dùng mới: Tùy chọn "**Sign up now**" hướng dẫn rõ ràng, giúp giảm tỷ lệ người dùng rời bỏ vì không tìm thấy cách tạo tài khoản.

#### 2. Giao diện Sign up
##### a. UI.
![AddStr3](./ImageForReport/signup.png)
- Bố cục:
Form "**Sign Up**": Giao diện đăng ký được căn giữa, giúp người dùng dễ tập trung.
Các trường thông tin (***First Name, Last Name, Email, Password, Date of Birth***) được sắp xếp dọc theo thứ tự logic, phù hợp với quy trình nhập liệu.
- Sử dụng màu sắc:
Nút "**Sign Up**" có màu xanh đậm, tạo sự tương phản, dễ nhận biết và nhấn mạnh hành động chính.
Hộp thoại thông báo "**Congratulations**" có màu nền trắng và chữ đen, đơn giản và dễ đọc.
- Kiểu chữ:
Tiêu đề "**Sign Up**" có font chữ đậm, kích thước lớn vừa phải, giúp người dùng nhận diện rõ ràng mục đích.
Nội dung thông báo sử dụng font chữ dễ đọc, với thông điệp đơn giản và trực tiếp.
- Biểu tượng:
Trường **Date of Birth** có biểu tượng lịch, giúp người dùng dễ nhận biết và sử dụng.
- Hộp thoại xác nhận:
Hộp thoại hiện lên trung tâm màn hình sau khi đăng ký thành công, tạo sự nổi bật với nút "**OK**" đơn giản để đóng.

##### b. UX.
- Trực quan và dễ hiểu:
Giao diện đăng ký cung cấp các trường thông tin cơ bản, sắp xếp rõ ràng và hợp lý, giúp người dùng dễ dàng hoàn thành thao tác.
- Khuyến khích hành động:
Nút "**Sign Up**" có màu nổi bật và dễ nhìn, tạo cảm giác sẵn sàng hành động.
Sau khi hoàn tất đăng ký, thông báo "**Congratulations**" giúp người dùng cảm thấy thành công và hài lòng với trải nghiệm.
- Hỗ trợ nhập liệu chính xác:
Các trường thông tin có nhãn cụ thể (***First Name, Last Name, Email...***), giảm nguy cơ nhầm lẫn.
Biểu tượng lịch giúp chọn ngày tháng nhanh chóng, tránh sai sót khi nhập.
- Phản hồi kịp thời:
Sau khi đăng ký, hộp thoại xác nhận xuất hiện ngay lập tức với thông điệp tích cực, giúp người dùng nhận được phản hồi rõ ràng về trạng thái đăng ký.
- Tương thích và đơn giản:
Giao diện gọn gàng, phù hợp với cả màn hình lớn và nhỏ, mang lại trải nghiệm đồng nhất trên các thiết bị.
- Giảm căng thẳng:
Thông báo "**Congratulations**" với thiết kế tối giản và thông điệp rõ ràng giúp tạo cảm giác nhẹ nhàng và không gây áp lực cho người dùng.

#### 3. Form khảo sát dành cho người dùng đăng kí tài khoản mới
##### a. UI.
![AddStr3](./ImageForReport/signupa.png)
*Thông báo xác nhận được gửi đến người dùng*

![AddStr3](./ImageForReport/signupb.png)
*Form khảo sát*

![AddStr3](./ImageForReport/signupc.png)
*Chi tiết Form*
- Bố cục:
Căn giữa: Toàn bộ form được căn giữa trên nền, dễ thu hút sự chú ý của người dùng.
Cấu trúc dạng cột: Các câu hỏi và trường nhập liệu được xếp theo chiều dọc, giúp người dùng dễ dàng theo dõi và trả lời tuần tự.
Khoảng cách hợp lý: Các trường được bố trí với khoảng cách vừa đủ, không quá dày đặc hay rời rạc, tạo cảm giác thoải mái khi điền.
- Màu sắc:
Nền xanh nhạt: Nền chứa các biểu tượng y tế như dấu cộng, kính hiển vi, và trái tim. Nền này tạo cảm giác chuyên nghiệp, phù hợp với nội dung liên quan đến sức khỏe.
Màu chữ xanh đậm và xanh lá: Các câu hỏi được tô màu xanh lá để nổi bật so với nền, trong khi tiêu đề "Health Questionnaire" sử dụng màu xanh đậm để tăng tính nhận diện.
- Kiểu chữ:
Font chữ đơn giản, dễ đọc.
Cỡ chữ lớn hơn cho tiêu đề, nhỏ hơn cho các câu hỏi nhưng vẫn đảm bảo rõ ràng.
- Các trường nhập liệu và danh sách chọn:
Trường nhập liệu sử dụng placeholder để gợi ý người dùng cách nhập (ví dụ: DD/MM/YYYY, cm, kg).
Danh sách chọn (dropdown) giúp giảm tải thông tin trên màn hình và gợi ý các tùy chọn sẵn có.
- Tương tác:Nút "**Submit**" là thành phần cuối cùng của form, đặt tại vị trí dễ tìm sau khi hoàn thành các câu hỏi.

##### b. UX.
- Dễ hiểu và hướng dẫn rõ ràng:
Mỗi câu hỏi được viết rõ ràng, ngắn gọn, và trực tiếp, giúp người dùng nhanh chóng hiểu được nội dung cần cung cấp.
Các placeholder trong trường nhập liệu là hướng dẫn hiệu quả cho các thông tin đặc thù (như ngày sinh, chiều cao, cân nặng).
- Trực quan và giảm tải:
Danh sách chọn (dropdown) giúp giảm số lượng thông tin phải nhập thủ công, giảm lỗi từ phía người dùng.
Các câu hỏi được chia nhỏ thành từng mục, giúp tránh cảm giác bị "quá tải thông tin."
- Liên kết giữa các bước:
Hệ thống thông báo sau khi đăng ký và chuyển tiếp ngay tới một trang thông báo tình trạng hiện tại của người dùng.
Người dùng xác nhận bằng cách nhấn "**Got it**", form khảo sát hiện lên và dẫn dắt người dùng hiệu quả, giúp họ biết ngay cần làm gì tiếp theo.
Sau khi hoàn thành form và nhấn "**Submit**" việc chuyển tiếp sang trang chủ là một trải nghiệm mượt mà, không gây gián đoạn.
- Cá nhân hóa trải nghiệm: Việc thu thập thông tin qua form khảo sát tạo cảm giác rằng hệ thống quan tâm và sẽ cá nhân hóa nội dung cho từng người dùng (ví dụ: chế độ ăn uống, lời khuyên sức khỏe).
- Tương tác thân thiện:
Giao diện thân thiện với người mới sử dụng, không yêu cầu kỹ năng phức tạp.
Các câu hỏi liên quan đến sức khỏe đều phù hợp và không mang tính xâm phạm quyền riêng tư.
- Phù hợp với nhiều thiết bị: Cách trình bày dọc giúp giao diện dễ thích ứng với màn hình điện thoại hoặc máy tính bảng.

### IX. Báo cáo
#### 1. Biểu đồ thành phần dinh dưỡng 
![AddStr3](./ImageForReport/food.png)
*Thêm các bữa ăn*
![AddStr3](./ImageForReport/report.png)
*Biểu đồ dinh dưỡng*
##### 1.1 UI.
###### a. Bố cục và thiết kế:
- Biểu đồ tròn:
Biểu đồ tròn giúp hiển thị tỷ lệ phần trăm của các yếu tố dinh dưỡng như Calories, Sugar, Protein, Fat, v.v. Điều này trực quan và dễ hiểu với người dùng.
Mỗi phần của biểu đồ được tô màu khác nhau, giúp người dùng phân biệt nhanh chóng các thành phần dinh dưỡng.
- Thông tin bổ sung bên cạnh:
Văn bản cung cấp các thông tin hướng dẫn về dinh dưỡng như lượng calories khuyến nghị và những lưu ý về việc giảm cân an toàn. Đây là cách hữu ích để giáo dục người dùng trong khi họ xem dữ liệu cá nhân.
###### b. Hiệu ứng nổi bật khi di chuột:
- Khi di chuột vào từng phần của biểu đồ, hiệu ứng nổi bật (highlight) cùng với thông tin chi tiết (ví dụ: "Calories: 525, Sugar: 0") xuất hiện. Điều này giúp người dùng tương tác trực tiếp với biểu đồ và hiểu rõ hơn về từng thành phần.
###### c. Màu sắc và độ tương phản:
- Màu sắc trong biểu đồ được phân phối hợp lý, dễ nhận biết và không gây rối mắt.
- Màu xanh dương đậm làm nền cho biểu đồ tạo sự nổi bật, trong khi các màu sắc khác nhau cho từng thành phần giúp dễ phân biệt.
###### d. Nút "Close":
- Nút "**Close**" được đặt rõ ràng, cho phép người dùng dễ dàng thoát khỏi biểu đồ khi đã xem xong.

##### 1.2. UX.
###### a. Tính trực quan và dễ sử dụng:
- Biểu đồ tròn là công cụ trực quan giúp người dùng nhanh chóng hiểu được tỷ lệ các thành phần dinh dưỡng. Đây là cách trình bày thông tin phù hợp cho người dùng không chuyên về dinh dưỡng.
- Hiệu ứng nổi khi di chuột vào từng phần biểu đồ giúp người dùng tập trung vào chi tiết mà họ quan tâm mà không cần xem toàn bộ dữ liệu cùng lúc.
###### b. Cung cấp thông tin hữu ích và giáo dục:
- Văn bản bổ sung về khuyến nghị dinh dưỡng không chỉ giúp người dùng hiểu dữ liệu cá nhân mà còn hướng dẫn họ cách đạt được mục tiêu sức khỏe an toàn.
- Phần giải thích rõ ràng về tác hại của việc tiêu thụ quá ít calories giúp người dùng tránh sai lầm phổ biến trong quá trình giảm cân.
###### c. Tính tương tác cao:
- Hiệu ứng nổi bật và hiển thị chi tiết khi di chuột vào từng phần biểu đồ làm tăng tính tương tác, giữ sự chú ý của người dùng và giúp họ cảm thấy "tham gia" vào việc phân tích dữ liệu.
###### d. Khả năng đóng biểu đồ dễ dàng:
- Nút "**Close**" cho phép người dùng nhanh chóng quay lại giao diện chính sau khi xem biểu đồ, tạo cảm giác tiện lợi.

#### 2. Báo cáo về lượng calories nạp vào. 
![AddStr3](./ImageForReport/report2.png)
*Sơ đồ báo cáo về lượng calories nạp vào ngày 1/1/2025*
##### 2.1. UI
###### a. Bố cục và thiết kế:
- Biểu đồ dạng cột:
Hiển thị dữ liệu tổng calories tiêu thụ theo từng ngày, với trục hoành (ngày tháng) và trục tung (tổng calories). Đây là cách trình bày rõ ràng, dễ so sánh giữa các ngày.
- Màu sắc của cột thay đổi mỗi lần truy cập:
Việc thay đổi màu sắc tạo cảm giác mới mẻ, tránh nhàm chán cho người dùng. Tuy nhiên, điều này cần đảm bảo không làm mất tính nhất quán trong trải nghiệm.
###### b. Phân vùng giao diện:
- Thanh bên trái:
Bao gồm các mục điều hướng (***Home, Food, Exercise, Report***), được thiết kế gọn gàng với biểu tượng dễ nhận diện.
Hiển thị avatar và email người dùng, giúp cá nhân hóa giao diện. ( Phần này đã được mô tả ở các phần trước.)
- Phần tiêu đề:
"Charts and Report" là tiêu đề lớn, rõ ràng, giúp người dùng biết ngay mục đích của trang.
- Tùy chọn khoảng thời gian:
Các nút như "***Last 7 days," "Last 14 days," v.v.***, giúp người dùng linh hoạt chọn khoảng thời gian họ muốn xem dữ liệu.
###### c. Màu sắc và độ tương phản:
- Cột biểu đồ có màu sắc đậm, nổi bật so với nền trắng, giúp dễ dàng nhận diện dữ liệu.
- Văn bản và các đường trục có độ tương phản tốt, đảm bảo dễ đọc.
###### d. Hiệu ứng và chi tiết:
- Mỗi cột biểu đồ được làm nổi bật khi thay đổi màu sắc, tạo cảm giác tương tác và trực quan hơn.

##### 2.2. UX.
- Tính trực quan và dễ sử dụng:
Biểu đồ dạng cột rất dễ hiểu, cho phép người dùng nhanh chóng so sánh tổng calories tiêu thụ giữa các ngày.
Việc phân chia dữ liệu theo ngày giúp người dùng dễ dàng theo dõi xu hướng và điều chỉnh chế độ ăn uống.
- Tùy chọn linh hoạt:
Các nút chọn khoảng thời gian ("***Last 7 days," "Last 14 days," v.v.***) cho phép người dùng xem dữ liệu theo nhu cầu cụ thể, tăng tính tiện lợi.
- Tính cá nhân hóa:
Hiển thị avatar và email giúp tạo sự gắn kết cá nhân giữa người dùng và ứng dụng.
Giao diện chào mừng với tên hoặc email người dùng tạo cảm giác thân thiện.
- Cảm giác mới mẻ:
Việc thay đổi màu sắc của cột mỗi lần truy cập mang lại trải nghiệm mới lạ, tránh sự nhàm chán khi người dùng sử dụng ứng dụng thường xuyên.

### X. Tính năng giữ chuỗi
![AddStr3](./ImageForReport/streak.png)
#### 1. UI.
- Bố cục rõ ràng và dễ hiểu:
Hộp thông báo được căn giữa màn hình, đảm bảo người dùng nhìn thấy ngay lập tức khi đăng nhập.
Phân cấp nội dung hợp lý: Số ngày streak nổi bật nhất, biểu tượng ở giữa và câu nói truyền động lực ngay bên dưới.
- Màu sắc hài hòa:
Màu nền xanh nhạt tạo cảm giác dễ chịu, thư giãn cho mắt.
Màu xanh lá của nút "Great!" đồng bộ với thông điệp tích cực và dễ nhận diện.
- Biểu tượng trực quan:
Hình ngọn lửa là biểu tượng quen thuộc, truyền tải ý nghĩa về sự kiên trì và động lực, tạo cảm giác hứng thú cho người dùng.
- Thiết kế tối giản:
Tập trung vào thông tin quan trọng, không có chi tiết thừa, giúp người dùng dễ dàng tiếp nhận thông điệp.
- Kiểu chữ dễ đọc:
Font chữ đơn giản, kích thước lớn vừa đủ, đảm bảo nội dung dễ nhìn trên mọi kích thước màn hình.
#### 2. UX.
- Tạo động lực ngay lập tức:

Hiển thị số ngày streak giúp người dùng cảm thấy thành tựu, khuyến khích họ tiếp tục duy trì thói quen tốt.
Câu nói truyền động lực được random từ database mang lại sự mới mẻ, không gây nhàm chán.
- Cảm giác chào đón:

Hiển thị thông báo ngay sau khi đăng nhập giúp người dùng cảm thấy được ghi nhận và khích lệ.
- Tương tác đơn giản và nhanh chóng:

Nút "Great!" dễ hiểu, rõ ràng, chỉ cần một thao tác để đóng thông báo và tiếp tục sử dụng ứng dụng.
- Thân thiện với người dùng mới:
 
Thiết kế trực quan, dễ hiểu ngay từ lần đầu sử dụng, không cần hướng dẫn.
- Tăng sự gắn kết với ứng dụng:

Tính năng streak giúp người dùng hình thành thói quen sử dụng ứng dụng hàng ngày, tạo cảm giác gắn bó lâu dài.


## Design patterns/architecture

### MVVM Design patterns ( Cập nhật milestone 2)

Sử dụng mẫu thiết kế MVVM, trong project có các folder:
- **Model**: Chứa các lớp
	+  **IDao**: Lớp giao diện chứa các phương thức lấy thông tin từ cơ sở dữ liệu thông qua các hàm GetAll()
	+ **MockDao**: Cài đặt chi tiết các hàm lấy thông tin, trả về 1 danh sách dữ liệu
	
- **ViewModel**: Chứa các lớp
	+ **Meal**: chứa thông tin 1 bữa ăn (tên bữa ăn)
	
	+ **ValueToColorConverter**: Converter có chức năng phát hiện thay đổi về giá trị số để thay đổi màu tương ứng (< 0: <span style="color: red">đỏ</span> ;  > 0: <span style="color: green">xanh</span>; = 0: đen)
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
	
### **Bổ sung cho milestone 2:**
-- --
- **Model**: Chứa các lớp:
	+ **CardioExercise**: Chứa dữ liệu về các bài tập Cardio, bao gồm tên bài tập, thời gian tập và lượng calo tiêu thụ
	+ **StrengthTrainingExercise**: Chứa thông tin các bài tập thể lực
- **Service:** Chứa các lớp:
	+ **IDAO**: Lớp giao diện chứa các phương thức lấy thông tin từ cơ sở dữ liệu thông qua các hàm GetAll()
	+ **MockDao**: Cài đặt chi tiết các hàm lấy thông tin, trả về 1 danh sách dữ liệu
	+ **SqlDao**: Kết nối đến cơ sở dữ liệu để lấy thông tin từ cơ sở dữ liệu lên, dữ liệu lúc này được đưa xuống database mà không còn là dữ liệu tạm thời nữa
- **ViewModel:** Chứa các lớp:	
	 + **SearchExerciseViewModel**: Có nhiệm vụ trả về kết quả khi người dùng tra cứu tên bài tập thể dục. Lớp sẽ kết nối cơ sở dữ liệu, dựa trên từ khóa mà người dùng nhập vào để thực hiện truy vấn trả ra 1 hoặc nhiều kết quả có liên quan đến từ khóa người dùng nhập
	 +  **FoodDiaryViewModel, ExercisePageViewModel**: Các lớp giúp lưu các kết quả người dùng đã nhập theo từng ngày. *Chẳng hạn*, ngày hôm nay người dùng đã nhập các thông tin cho bữa ăn cũng như là các bài tập thể thao. Qua ngày hôm sau, các trang sẽ được làm mới và người sẽ tiếp tục cập nhật hoạt động cho ngày hôm nay của mình. Đồng thời, người dùng cũng có thể chọn lịch vào ngày cũ để xem thông tin mình đã thao tác và chỉnh sửa ngày đó (thêm/ xóa các món ăn, bài tập) 
	
- **View:** Chứa các lớp:	
	+ **CreateExercise, ExercisePage, SearchCardioExercise, SearchStrengthTrainingExercise**: Các lớp giao diện hiển thị và tương tác với người dùng ở phần chọn bài tập thể dục. Người dùng có thể tìm kiếm và chọn các bài tập thể dục ở 2 thể loại (Cardio/ Strength) để thêm các bài tập vào hoạt động hằng ngày của mình tương tự như bên phần *Food*. Đồng thời, người dùng có thể tự tạo bài thể dục riêng cho mình nếu không tìm thấy kết quả mong muốn thông qua giao diện ở của **CreateExercise**

	+ **CreateMyFood**: Giao diện giúp người dùng tự tạo riêng món ăn cho cho mình bằng cách điền các thông tin cụ thể như tên món ăn, lượng dinh dưỡng ước tính cho món ăn đó
	+ **NutrionResult**: Trang kết quả thông báo về tình trạng sức khỏe cho người dùng vào ngày hôm đó.
	+ **HomePage**: Trang chủ của ứng dụng, hiển thị các thông tin về chỉ số tổng thể bao gồm tổng lượng Calo đã nạp vào ở phần **Food** và tổng Calo đã tiêu thụ ở phần **Exercise**. Chỉ số *Remaining* được tính tự động thể hiện chỉ số Calo còn lại trong ngày hôm đó của người dùng 
## Advanced topics

 ### 1. MVVM design pattern
 - Nhóm đã tìm hiểu và triển khai mô hình MVVM. Mô hình này nhóm đã tự tìm hiểu và triển khai một cách hợp lí nhất khi phân tách ra các lớp chính là View, Model, và để đảm bảo rằng tầng giao diện chỉ phục vụ cho việc hiển thị dữ liệu lên, còn dữ liệu hiển thị đó là gì thì sẽ thông qua lớp thứ 3 là ViewModel.
 
 - Chỉ tiết về triển khai mô hình này đã thầy có thể xem ở mục Design patterns/architecture
 ### 2. WindowHandle
 - Để có thể phóng to của sổ lập tức khi người dùng chạy chương trình, nhóm đã sử dụng WindowHandle để thực hiện việc phóng to cửa sổ Phần mềm khi chạy mới chạy 
 - Ứng dụng khi chạy sẽ phóng to full màn hình 
![foodpage-start.png](https://i.postimg.cc/51HR0LGz/foodpage-start.png)

- Code behind:
![code_behind](https://i.postimg.cc/3w604NXH/image.png)
### 3. Xử lí khi dữ liệu nhập sai
- Nếu người dùng nhập dữ liệu bị sai mà bạn muốn người dùng phải Focus vào TextBox đang nhập đến khi nhập đúng? Nhóm đã tìm hiểu và sử dụng thêm 2 thuộc tính là Textchanged và LostFocus. Khi người dùng nhập sai thì hệ thống sẽ báo lỗi và ép người dùng phải nhập đúng thì mới thả Focus. Minh họa cho trường hợp này nằm ở mục Quality assurance
- Code behind:
![code_behind](https://i.postimg.cc/sgHvqx0Z/image.png)
### 4. Bất đồng bộ trong C# và dùng fileOpenPicker để tương tác với file ảnh trong window
- Tính năng chọn ảnh đại diện trong ứng dụng sử dụng bất đồng bộ,  cho phép người dùng thao tác tải ảnh từ hệ thống của máy lên mà không làm treo các tác vụ khác của ứng dụng bởi vì các thao tác đọc tệp thường mất rất nhiều thời gian

- **FileOpenPicker**: Sử dụng FileOpenPicker từ Windows Runtime API để chọn tệp từ thư viện ảnh, hỗ trợ đọc các tệp ảnh **.jpg**, **.png**, **.jpeg**


![choose_avatar](https://i.postimg.cc/5006Kfxy/image.png)
_Chọn ảnh từ hệ thống_

![update_avatar](https://i.postimg.cc/6q1vmLfY/image.png)_Ảnh được cập nhật_

## Bổ sung cho milestone 2

### 5. Áp dụng mẫu Singleton Pattern 
- Khi chương trình chạy, để đảm bảo rằng người dùng khi thay đổi Calendar của ngày chọn Food hay Exercise thì hệ thống sẽ **nhớ** được ngày của người dùng đang chọn mà không cần phải **lưu** lại xuống Database. Nhóm sử dụng Singleton Pattern để tạo một đối tượng duy nhất quản lí trạng thái Calendar trong vòng đời của ứng dụng (đến khi ứng dụng bị tắt đi).

![singleton_pattern](https://i.ibb.co/LQWbfSM/Untitled.png)




## Teamwork - Git flow
+ Sử dụng **github**, 1 branch **main**
  + Thành viên 1 tạo repository ở chế độ public ,thành viên 2 clone repository về, thành viên 3 fork repository về
  + 2 thành viên sẽ có quyền push trực tiếp code lên branch **main**, 1 người tạo **pull request**, chủ repo chấp nhận code và merge vào branch **main**
+ Minh chứng commit:
![commit_history](https://i.postimg.cc/QCxQQz22/image.png)
![commit_history](https://i.postimg.cc/bvwMpgny/image.png)

### Bổ sung cho milestone 2
-- --

+ Sử dụng **Jira** cho việc phân chia công việc và theo dõi tiến độ dự án
![Imgur](https://i.ibb.co/hmVYJ2J/Untitled.png)
  
  

## Quality assurance

### 1. Quy trình commit và kiểm duyệt code:

- Các thành viên trong nhóm làm việc trên từng chức năng hoặc nhiệm vụ được giao và commit mã nguồn lên kho lưu trữ chung.
- Trước khi bất kỳ mã nguồn nào được tích hợp vào nhánh chính (main), sẽ có một thành viên được chỉ định tiến hành kiểm duyệt mã. Người được phân sẽ xem xét mã nguồn để đảm bảo rằng chương trình tuân theo các tiêu chuẩn mã hóa và không gây ảnh hưởng đến các phần khác của hệ thống.
- Việc kiểm duyệt giúp phát hiện sớm các lỗi tiềm ẩn hoặc các phần mã có thể tối ưu hóa tốt hơn.

### 2. Chạy thử và kiểm tra mã nguồn:

- Sau khi kiểm duyệt mã nguồn, người kiểm duyệt sẽ chạy mã trên môi trường thử nghiệm để đảm bảo rằng nó hoạt động đúng chức năng như yêu cầu. Tại đây, nhóm sử dụng dụng phương pháp  kiểm tra thủ công để phát hiện các lỗi có thể xảy ra như tìm kiếm với từ khóa có trong cơ sở dữ liệu, tìm kiếm với từ khóa không có trong cơ sở dữ liệu, kiểm thử với từ khóa không hợp lệ hoặc bỏ trống,...

- Ví dụ cụ thể: Phần bắt lỗi người dùng trong chức năng AddFood và SearchFood:
	+ Trong chức năng AddFood, nhóm đã tích hợp một cơ chế kiểm tra lỗi khi người dùng nhập số lượng (FoodQuantity). Cơ chế này có chức năng kiểm tra giá trị mà người dùng nhập vào:
		+ Giá trị phải lớn hơn hoặc bằng 1: Nếu người dùng nhập số lượng nhỏ hơn 1 (ví dụ: -12 như trong ảnh), hệ thống sẽ hiển thị thông báo lỗi yêu cầu người dùng nhập một giá trị hợp lệ lớn hơn 0. Điều này giúp ngăn chặn các giá trị không phù hợp ảnh hưởng đến dữ liệu dinh dưỡng hoặc tính toán trong hệ thống.
		![addFodd_error](https://i.postimg.cc/W1y2KYZB/addfood.png)
		
		+ Chỉ chấp nhận số hợp lệ: Nếu người dùng nhập ký tự không phải là số (như chữ cái hoặc ký tự đặc biệt), hệ thống cũng sẽ hiển thị thông báo lỗi để yêu cầu người dùng nhập một giá trị hợp lệ.
		![addFood_error2](https://i.postimg.cc/y84djY8h/addfood2.png)
		+ Khi lỗi xuất hiện, hệ thống không cho phép người dùng tiếp tục thao tác cho đến khi nhập đúng giá trị. Điều này giúp đảm bảo tính chính xác của dữ liệu và ngăn ngừa sai sót có thể ảnh hưởng đến tính toán hoặc báo cáo của ứng dụng.
	+ Trong quá trình kiểm thử chức năng SearchFood, nhóm đã tích hợp một cơ chế kiểm tra lỗi và hiển thị thông báo như sau:
	
		+ Khi không tìm thấy kết quả: Nếu người dùng nhập một từ khóa mà không có thực phẩm nào trong cơ sở dữ liệu trùng khớp, hệ thống sẽ hiển thị thông báo "No result found" như trong hình 1. Thông báo này giúp người dùng dễ dàng hiểu rằng từ khóa họ vừa nhập không có trong cơ sở dữ liệu, giúp tránh sự nhầm lẫn.
		![search_error](https://i.postimg.cc/4dS7cdpg/searchfood.png)
		+ Bắt lỗi khi người dùng nhập sai định dạng hoặc ký tự đặc biệt: Để đảm bảo rằng chức năng tìm kiếm hoạt động chính xác và tránh các lỗi phát sinh do nhập liệu không đúng, thiết lập giới hạn cho phép nhập chỉ các ký tự chữ và số. Nếu người dùng nhập các ký tự không phù hợp (ví dụ: ký tự đặc biệt), hệ thống sẽ hiển thị thông báo "No result found".
		![search_error2](https://i.postimg.cc/DZpVygQB/searchfood2.png)
		
		+ Yêu cầu nhập từ khóa khi bỏ trống: Nếu người dùng bấm nút “Search” mà không nhập từ khóa, hệ thống sẽ hiển thị thông báo "No result found" như trong hình . Điều này giúp đảm bảo tính nhất quán và tránh việc người dùng vô tình thực hiện tìm kiếm mà không có từ khóa. 
- Việc kiểm thử kỹ lưỡng giúp đảm bảo rằng mã mới không gây ra lỗi và hoạt động ổn định trên các trường hợp sử dụng khác nhau.
### 3. Merge vào nhánh chính (main)
- Sau khi mã nguồn đã được kiểm thử và đạt tiêu chuẩn chất lượng, người kiểm duyệt sẽ phê duyệt cho phép merge vào nhánh chính.
- Quy trình này giúp duy trì tính ổn định và chất lượng của mã nguồn chính, giảm thiểu khả năng xảy ra lỗi khi sản phẩm được đưa vào sử dụng thực tế.

### Bổ sung cho milestone 2
-- --
### 2. Chạy thử và kiểm tra mã nguồn:
- Với việc sử dụng **Regular Expression**, trong quá trình chọn các bài tập thể dục, hoặc tạo mới các bài tập thể dục, với những chỉ cho phép nhập số, hệ thống sẽ ngăn người dùng nhập các kí tự là chữ cái và chỉ cho phép người dùng nhập số
- Đồng thời khi tạo mới 1 bài tập hoặc 1 món ăn mới, hệ thống đảm bảo người dùng đã nhập dủ các thông tin cần thiết để thêm vào cơ sở dữ liệu, và sẽ hiện cảnh báo nếu người dùng nhập sót trường thông tin nào đó

![FoodErr](./ImageForReport/FoodError.jpg)
*Kiểm tra lỗi nhập thiếu trường thông tin ở phần Food*

![ExErr](./ImageForReport/ExerciseError.jpg)
*Kiểm tra lỗi ở phần tạo mới Exercise*

## Completed Features
### Những tính năng đã hoàn thành:

 | Tên tính năng | Số giờ làm việc | 
 |---------------|-----------------|
 | Tính năng tính toán tổng lượng calories, các thành phần dinh dưỡng | 3h |  
 | Tính năng liệt kê thành phần dinh dưỡng trong từng món ăn | 3h | 
 | Tính năng chọn món | 3h | 
 |Tính năng chọn ảnh đại diện|1h|
 |Tính năng chọn bài tập thể dục|3h|
 |Tính năng lưu lại các món ăn Recent và Frequent|1.5h|
  |Tính năng lưu lại các bài tập thể dục Recent và Frequent|1h|
|Tính năng ghi lại lịch sử khi chuyển đổi ngày|1.5h|
|Tính năng ghi chú|1h|
|Tính năng hiển thị thông tin calories còn lại trong ngày trong phần Home dựa vào dữ liệu của Food và Exercise|1h|
|Tính năng tạo bài tập mới theo nhu cầu của người dùng|1.5h|
|Tính năng tạo món ăn mới theo nhu cầu của người dùng|1.5h|
|Tính năng vẽ chart thông tin các dinh dưỡng chiếm tỉ lệ bao nhiêu % trong một ngày|1h|
|Tính năng report thay đổi lượng calories theo các khung ngày khác nhau|2h|
|Tính năng Login, SigUp, Delete Account, Change Password|1.5h|
|Tính năng khảo sát sức khỏe đầu vào cho lần đầu tiên đăng kí|1.5h|
|Tính năng tạo động lực mỗi ngày|2h|
|**Tổng giờ làm việc**|**30h**|


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
### Bổ sung cho milestone 2
-- --
Hướng dẫn sử dụng.
Điều kiện: Đã cài docker và nodejs

1. Mở Terminal, nhập lệnh "npm install knex"

2. Mở terminal trong docker và nhập lệnh "docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SqlServer@123" -p 1433:1433 --name sql --hostname sql -d mcr.microsoft.com/mssql/server"
Lệnh này tạo container trong docker
- Server name: 127.0.0.1
- User : sa
- Password: SqlServer@123

3. Bật docker lên . Vào docker chọn bật tên như trong hình ![alt text](https://github.com/Khang080704/Project_WP/raw/main/Database%20Ph%E1%BA%A7n%20m%E1%BB%81m%20theo%20d%C3%B5i%20s%E1%BB%A9c%20kh%E1%BB%8Fe/image.png)

4. Trên sql server, nhập đúng thông tin như hình ![alt text](https://github.com/Khang080704/Project_WP/raw/main/Database%20Ph%E1%BA%A7n%20m%E1%BB%81m%20theo%20d%C3%B5i%20s%E1%BB%A9c%20kh%E1%BB%8Fe/image-1.png). Lưu ý, mật khẩu lấy trong file .env
4. Trong file knex.js đã khởi tạo, chỉnh sửa thông tin của file như sau: 
 ```
 require('dotenv').config();
module.exports = {

  development: {
    client: 'mssql',
    connection: {
      host: `${process.env.SQLSERVER_HOST}`,
      port: parseInt(process.env.SQLSERVER_PORT),
      user: `${process.env.SQLSERVER_USERNAME}`,
      password: `${process.env.SQLSERVER_PASSWORD}`,
      database: `${process.env.SQLSERVER_DATABASE}`,
    }
  },

  staging: {
    client: 'postgresql',
    connection: {
      database: 'my_db',
      user:     'username',
      password: 'password'
    },
    pool: {
      min: 2,
      max: 10
    },
    migrations: {
      tableName: 'knex_migrations'
    }
  },

  production: {
    client: 'postgresql',
    connection: {
      database: 'my_db',
      user:     'username',
      password: 'password'
    },
    pool: {
      min: 2,
      max: 10
    },
    migrations: {
      tableName: 'knex_migrations'
    }
  }

};

 ```
5. Mở terminal, Chạy lệnh knex migrate:latest 
6. Mở terminal, chạy lệnh knex seed:run 
7. Build project và chạy
### 2. Các tính năng ở phần Exercise
Chọn mục Exercise bên cột trái, giao diện chính của mục Exercise:

![ExercisePage](./ImageForReport/z6106076541751_5c433d97d37fe3f01d09f20b1efc8cf1.jpg)

- Tại đây người dùng có thể chọn thêm các bài tập Cardio hoặc Strength bằng cách click vào nút Add Exercise

![Cardio](./ImageForReport/Strength.jpg)
- Giao diện của trang tìm kiếm các bài tập, người dùng điền tên mong muốn, hệ thống sẽ đề xuất các kết quả phù hợp, khi chọn vào 1 bài tập bất kì, hệ thống sẽ yêu cầu người dùng điền 1 số thông tin cho bài tập đó, bao gồm:
	+ <span style="color:lightblue">Number of sets: số lần tập set tập đó </span>.
	+ <span style="color:lightblue">Repetition per set: số lần tập bài tập đó/set</span>.
	+ <span style="color:lightblue">Weight per set: Trọng lượng mỗi set tập</span>.
- Sau khi điền thông tin xong thì chọn **Add Exercise** để hệ thống thêm vào 
- Trong trường hợp không tìm thấy bài tập mong muốn, người dùng có thể tự tạo cho mình cho bài tập mới bằng cách chọn vào mục <span style="color:lightblue">*Add an exercise to database*</span> giao diện sẽ như hình bên dưới
![AddNew](./ImageForReport/AddStrength.jpg)
- Người dùng điền các thông tin cho các trường xong chọn **Add**, thông tin sẽ được tạo và người dùng có thể tìm kiếm lại tên vừa mới tạo
- Hoàn toàn tương tự cho phần Cardio Exercise, ta cũng các giao diện sau với cách điền thông tin tương tự
![CardioUI](./ImageForReport/Cardio.jpg)
![AddCCardio](./ImageForReport/AddCardio.jpg)


## Work assignment (Bảng phân công công việc từ đầu dự án cho đến nay)
|Thành viên|Công việc|
|---------------|-----------------|
|Nguyễn Hoàng Nguyên|Thiết kế tính năng tạo món ăn mới.<br>Thiết kế tính năng ghi lại lịch sử khi chuyển đổi ngày. <br> Thiết kế tính năng lưu lại các món ăn Recent và Frequent. <br> Thiết kế tính năng chọn món. <br> Thiết kế tính năng Login, SigUp, Delete Account, Change Password. <br> |
|Đoàn Gia Huệ|Thiết kế tính năng tính toán tổng lượng calories, các thành phần dinh dưỡng.<br> Thiết kế tính năng ghi chú. <br> Thiết kế tính năng hiển thị thông tin calories còn lại trong ngày trong phần Home dựa vào dữ liệu của Food và Exercise. <br> Thiết kế tính năng chọn bài tập thể dục <br> Thiết kế tính năng tạo động lực mỗi ngày|
|Phạm Gia Khang|Thiết kế tính năng liệt kê thành phần dinh dưỡng trong từng món ăn. <br> Thiết kế tính năng chọn ảnh đại diện.<br> Thiết kế tính năng tạo bài tập mới . <br> Thiết kế tính năng khảo sát sức khỏe đầu vào cho lần đầu tiên đăng kí <br> Thiết kế tính năng lưu lại các bài tập thể dục Recent và Frequent|

## Self-assessment
 | Tiêu chí | Tự đánh giá (trên thang 10) | 
 |---------------|-----------------|
 | UI/UX | 10|  
 | Design Patter/Architecture| 10 | 
 | Advanced Topics | 10 | 
 |Teamwork - Git flow|10|
 |Quality assurance|10|
 

[def]: '

# Tài liệu cơ sở dữ liệu
### Bổ sung cho milestone 3
Link Database Document: [DatabaseDocument.md](./DatabaseDocument.md)

# Tài liệu kiểm thử
### Bổ sung cho milestone 3
Link Test Document: [TestDocument.md](./TestDocument.md)

# Tài liệu Doxygen
### Bổ sung cho milestone 3
Link Doxygen Document: [doxygen.html](./Document/html/index.html)
