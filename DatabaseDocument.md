# Database: Phần mềm theo dõi sức khỏe

## I. Sơ đồ dữ liệu
![Digram](./ImageForReport/Database%20Diagram%20KeepItFit.png)

## Đặc tả cơ sở dữ liệu
## 1. User
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Email          | nvarchar(50) |           |                  | No             | Primary Key | Email của người dùng |
| Password       | Text |           |                  | No             |           | Mật khẩu của người dùng |
| FirstName       | nvarchar(50) |           |                  | No             |           | Tên chính |
| LastName       | nvarchar(50) |           |                  | No             |           | Tên |
| DateOfBirth       | Date |           |                  | No             |           | Ngày sinh |
| DailyCaloriesGoal       | int |           |                  | No             |           | Mục tiêu Calories đạt được mỗi ngày |
| Calo, Carbs, Fat, Sodium, Sugar, Protein| int |     0      |                  | Yes             |           | Chỉ số dinh dưỡng khi khảo sát đầu vào|
| Avartar       | VARBINARY(max) |           |                  | yes             |           | Ảnh đại diện của người dùng |
| Streak       | int |           |            1      | Yes             |           | Chuỗi vào app hằng ngày |
| StreakDate       | Date |           |        Ngày hiện tại         | Yes             |           | Ngày ghi nhận chuỗi |

## 2. Các bảng BREAKFASTDIARY, LUNCHDIARY, DINNERDIARY, SNACKDIARY
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Food_ID          | int |           |                  | No             | Foreign Key Food(ID) | ID của món ăn |
| Food_Quantity       | NVARCHAR(50) |           |                  | No           |           | Định lượng món ăn |
| Food_Date       | Date |           |                  | No             |   Foreign Key FOODDIARY(FOOD_DATE)        | Ngày chọn món |
| User_Email       | nvarchar(50) |           |                  | Yes             |    Foreign Key FOODDIARY(USER_EMAIL)       | Email của người dùng |

## 3. Bảng Food
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | No             | Primary Key | ID của món ăn |
| Food_name       | nvarchar(255) |           |                  | No           |           | Tên món ăn |
| Food_Calories, Food_Carbs, Food_Fat, Food_Sodium, Food_Protein, Food_sugar | float |          |                  | No             |           | Thông tin dinh dưỡng của món ăn |
| Food_Quantity       | nvarchar(50) |           |                  | No             |           | Định lượng món ăn |
| Selected_Food_Unit       | NVARCHAR(50) |           |                  | No             |           | Đơn vị tính |
| FOOD_UNIT       | NVARCHAR(MAX) |           |                  | No             |           | Lưu đơn vị tính của món ăn |

## 4. Bảng FrequentFood
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | No             | Primary Key | ID của danh sách |
| Food_id       | int |           |                  | No           |    FOREIGN KEY REFERENCES FOOD(ID)       | ID của món ăn |
| Number_eat       | int |           |                  | No           |           | Số lượng |
| User_Email       | nvarchar(50) |           |                  | Yes           |    Primary Key, FOREIGN KEY REFERENCES User(Email),    | Email của người dùng |

## 5. Bảng RecentFood
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | No             | Primary Key | ID của danh sách |
| Food_id       | int |           |                  | No           |    FOREIGN KEY  FOOD(ID)       | ID của món ăn |
| User_Email       | nvarchar(50) |           |                  | Yes  |    Primary Key, FOREIGN KEY User(Email),    | Email của người dùng |

## 6. Bảng MyFood
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID          | int |           |                  | No             | Primary Key | ID của món ăn |
| Food_name       | nvarchar(255) |           |                  | No             |           | Tên món ăn |
| Food_Quantity       | NVARCHAR(50) |           |                  | No             |           | Định lượng món ăn |
| Selected_Food_Unit       | NVARCHAR(50) |           |                  | No             |           | Đơn vị tính |
| Selected_Food_Unit       | NVARCHAR(50) |           |                  | No             |           | Đơn vị tính |
| Food_Calories, Food_Carbs, Food_Fat, Food_Sodium, Food_Protein, Food_sugar| float |         |                  | No             |           | Chỉ số dinh dưỡng của món ăn
| FOOD_UNIT       | NVARCHAR(MAX) |           |                  | No             |           | Lưu đơn vị tính của món ăn |
| User_Email       | nvarchar(50) |           |                  | No             |    Primary Key, FOREIGN KEY REFERENCES User(Email)  | Email của người dùng |

## 7. Các bảng MyFoodBreakFast, MyFoodLunch, MyFoodDinner, MyFoodSnack
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Food_ID         | int |           |                  | Yes             | Foreign Key REFERENCES MyFood(ID) | ID của món ăn |
| Food_Quantity       | NVARCHAR(50) |           |                  | No          |           | Định lượng của món ăn |
| Food_Date       | Date |           |                  | Yes          |      Foreign Key REFERENCES FOODDIARY(FOOD_DATE)     | Ngày chọn món |
| User_Email       | nvarchar(50) |           |                  | No           |    Foreign Key REFERENCES MyFood(USER_EMAIL),  Foreign Key REFERENCES FOODDIARY(USER_EMAIL), | Email của người dùng |

## 8. Bảng FoodDiary
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Food_Date         | Date |           |                  | Yes            |  Primary Key   | ID của món ăn |
| TotalCalo       | int |           |                  | Yes          |           | Tổng lượng Calo trong 1 ngày |
| User_Email       | nvarchar(50) |           |                  | No           |    Primary Key, FOREIGN KEY User(Email)   | Email của người dùng |

## 9. Các bảng QuickAddBreakFast, QuickAddLunch, QuickAddDinner, QuickAddSnack
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | Yes             | PRIMARY KEY | ID của phần tử trong bảng |
| Food_Date       | Date |           |                  | Yes         |  PRIMARY KEY   | Ngày chọn món |
| Food_Calories, Food_Carbs, Food_Fat, Food_Sodium, Food_Protein, Food_sugar| float |          |                  | No             |           | Chỉ số dinh dưỡng của món ăn
| User_Email       | nvarchar(50) |           |                  | No           | PRIMARY KEY, Foreign Key  REFERENCES User(Email) | Email của người dùng |

## 10. Bảng Meal
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | No             | PRIMARY KEY | ID của bữa ăn |
| MEAL_NAME         | NVARCHAR(255) |           |                  | No           |  |Tên bữa ăn |