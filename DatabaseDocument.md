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


## 2. ExerciseDiary
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| EXERCISE_DATE     |          DATE |           |                  | YES             | PRIMARY KEY | Ngày thực hiện bài tập  |
| NOTE       | TEXT  |           |                  | YES             |   FOREIGN KEY        | Ghi chú hoặc nhận xét của người dùng về bài tập trong ngày|
| USER_EMAIL       | NVARCHAR(50) |           |                  | YES             |    PRIMARY KEY, FOREIGN KEY REFERENCES User(Email)        |Email của người dùng, liên kết đến bảng User để xác định người thực hiện bài tập hoặc ghi chú |


## 3.  CardioExerciseDiary
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Exercise_ID     |          INT |           |                  | YES             |  | Mã định danh duy nhất cho bài tập  |
| EXERCISE_DATE       | DATE  |           |                  | YES             |     FOREIGN KEY REFERENCES ExerciseDiary(EXERCISE_DATE)       | Ngày thực hiện bài tập cardio, liên kết đến bảng ExerciseDiary |
| USER_EMAIL       | NVARCHAR(50) |           |                  | YES             |    FOREIGN KEY REFERENCES ExerciseDiary(USER_EMAIL)       | Email của người dùng, liên kết đến bảng ExerciseDiary để xác định người thực hiện bài tập |
| TimeHowLong     |          INT |           |                  | YES             |  | Thời gian thực hiện bài tập  |
| CaloriesBurned      | INT  |           |                  | YES             |           | Lượng calo đã đốt cháy trong bài tập |
| CaloriesPerMinutes       | FLOAT |           |                  | YES             |            | Lượng calo trung bình đốt cháy mỗi phút |


## 4.  StrengthTrainingExerciseDiary 
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Exercise_ID     |          INT |           |                  | YES             |  | Mã định danh duy nhất cho bài tập  |
| EXERCISE_DATE       | DATE  |           |                  | YES             |      FOREIGN KEY REFERENCES ExerciseDiary(EXERCISE_DATE)         | Ngày thực hiện bài tập exercise, liên kết đến bảng ExerciseDiary. |
| USER_EMAIL       | NVARCHAR(50) |           |                  | YES             |     FOREIGN KEY REFERENCES ExerciseDiary(USER_EMAIL)          | Email của người dùng, liên kết đến bảng ExerciseDiary để xác định người thực hiện bài tập |
|  Sets     |          INT |           |                  | YES             |  | Số hiệp (sets) thực hiện trong bài tập  |
| Reps_Set      | INT  |           |                  | YES             |           | Số lần lặp (reps) trong mỗi hiệp |
|  Weight_Set       | INT |           |                  | YES             |            | Trọng lượng (tính bằng kg hoặc đơn vị khác) được sử dụng trong mỗi hiệp |



## 5.  CardioExercise 
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID      |          INT |   IDENTITY(1,1)        |                  | NO             | PRIMARY KEY | Mã định danh duy nhất cho bài tập  |
| Cardio_name       | NVARCHAR(255)  |           |                  | NO             |           | Tên của bài tập cardio |
| TimeHowLong     |          INT |           |                  | YES             |  | Thời gian thực hiện bài tập  |
| CaloriesBurned      | INT  |           |                  | YES             |           | Lượng calo đã đốt cháy trong bài tập |
| CaloriesPerMinutes       | FLOAT |           |                  | YES             |            | Lượng calo trung bình đốt cháy mỗi phút |


## 6.  StrengthTraining 
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID      |          INT |   IDENTITY(1,1)        |                  | NO             | PRIMARY KEY | Mã định danh duy nhất cho bài tập  |
| Strength_name       | NVARCHAR(255)  |           |                  | NO             |           | Tên của bài tập |
|  Sets     |          INT |           |                  | YES             |  | Số hiệp (sets) thực hiện trong bài tập  |
| Reps_Set      | INT  |           |                  | YES             |           | Số lần lặp (reps) trong mỗi hiệp |
|  Weight_Set       | INT |           |                  | YES             |            | Trọng lượng (tính bằng kg hoặc đơn vị khác) được sử dụng trong mỗi hiệp |

## 7.  UserCardio 
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID      |          INT |          |                  | NO             | PRIMARY KEY | Mã định danh duy nhất cho bài tập  |
| Email       | NVARCHAR(50)  |           |                  | YES             |           | Email của người dùng thực hiện bài tập cardio |
|  CardioName      |          NVARCHAR (255)  |           |                  | YES             |  |Tên bài tập cardio mà người dùng đã thực hiện |
| TimeHowLong     |          INT |           |                  | YES             |  | Thời gian thực hiện bài tập  |
| CaloriesBurned      | INT  |           |                  | YES             |           | Lượng calo đã đốt cháy trong bài tập |
| CaloriesPerMinutes       | FLOAT |           |                  | YES             |            | Lượng calo trung bình đốt cháy mỗi phút |


## 8.  UserStrength 
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID      |          INT |          |                  | NO             | PRIMARY KEY | Mã định danh duy nhất cho bài tập  |
| Email       | NVARCHAR(50)  |           |                  | YES             |           | Email của người dùng thực hiện bài tập  |
|  StrengthName       |          NVARCHAR (255)  |           |                  | YES             |  |Tên bài tập strength mà người dùng đã thực hiện |
|  Sets     |          INT |           |                  | YES             |  | Số hiệp (sets) thực hiện trong bài tập  |
| Reps_Set      | INT  |           |                  | YES             |           | Số lần lặp (reps) trong mỗi hiệp |
|  Weight_Set       | INT |           |                  | YES             |            | Trọng lượng (tính bằng kg hoặc đơn vị khác) được sử dụng trong mỗi hiệp |


## 9.  RECENTCARDIO 
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Cardio_ID       |          INT |          |                  | YES             | PRIMARY KEY | Mã định danh duy nhất cho bài tập  |
|  Cardio_name      |          NVARCHAR (255)  |           |                  | YES             |  |Tên bài tập cardio |
| TimeHowLong     |          INT |           |                  | YES             |  | Thời gian thực hiện bài tập  |
| CaloriesPerMinutes       | FLOAT |           |                  | YES             |            | Lượng calo trung bình đốt cháy mỗi phút |
| CaloriesBurned      | INT  |           |                  | YES             |           | Lượng calo đã đốt cháy trong bài tập |
| USER_EMAIL       | NVARCHAR(50)  |           |                  | YES             |  PRIMARY KEY, FOREIGN KEY  REFERENCES User(Email)        |  Email của người dùng thực hiện bài tập cardio, liên kết đến bảng User |


## 10.  RECENTSTRENGTH 
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Strength_ID      |          INT |          |                  | YES             | PRIMARY KEY | Mã định danh duy nhất cho bài tập  |
|  Strength_name       |          NVARCHAR (255)  |           |                  | YES             |  |Tên bài tập strength mà người dùng đã thực hiện |
|  Sets     |          INT |           |                  | YES             |  | Số hiệp (sets) thực hiện trong bài tập  |
| Reps_Set      | INT  |           |                  | YES             |           | Số lần lặp (reps) trong mỗi hiệp |
|  Weight_Set       | INT |           |                  | YES             |            | Trọng lượng (tính bằng kg hoặc đơn vị khác) được sử dụng trong mỗi hiệp |
| USER_EMAIL        | NVARCHAR(50)  |           |                 | YES             |    PRIMARY KEY,FOREIGN KEY REFERENCES User(Email)      | Email của người dùng thực hiện bài tập sức mạnh, liên kết đến bảng User  |

## 11. Các bảng BREAKFASTDIARY, LUNCHDIARY, DINNERDIARY, SNACKDIARY
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Food_ID          | int |           |                  | No             | Foreign Key Food(ID) | ID của món ăn |
| Food_Quantity       | NVARCHAR(50) |           |                  | No           |           | Định lượng món ăn |
| Food_Date       | Date |           |                  | No             |   Foreign Key FOODDIARY(FOOD_DATE)        | Ngày chọn món |
| User_Email       | nvarchar(50) |           |                  | Yes             |    Foreign Key FOODDIARY(USER_EMAIL)       | Email của người dùng |

## 12. Bảng Food
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | No             | Primary Key | ID của món ăn |
| Food_name       | nvarchar(255) |           |                  | No           |           | Tên món ăn |
| Food_Calories, Food_Carbs, Food_Fat, Food_Sodium, Food_Protein, Food_sugar | float |          |                  | No             |           | Thông tin dinh dưỡng của món ăn |
| Food_Quantity       | nvarchar(50) |           |                  | No             |           | Định lượng món ăn |
| Selected_Food_Unit       | NVARCHAR(50) |           |                  | No             |           | Đơn vị tính |
| FOOD_UNIT       | NVARCHAR(MAX) |           |                  | No             |           | Lưu đơn vị tính của món ăn |

## 13. Bảng FrequentFood
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | No             | Primary Key | ID của danh sách |
| Food_id       | int |           |                  | No           |    FOREIGN KEY REFERENCES FOOD(ID)       | ID của món ăn |
| Number_eat       | int |           |                  | No           |           | Số lượng |
| User_Email       | nvarchar(50) |           |                  | Yes           |    Primary Key, FOREIGN KEY REFERENCES User(Email),    | Email của người dùng |

## 14. Bảng RecentFood
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | No             | Primary Key | ID của danh sách |
| Food_id       | int |           |                  | No           |    FOREIGN KEY  FOOD(ID)       | ID của món ăn |
| User_Email       | nvarchar(50) |           |                  | Yes  |    Primary Key, FOREIGN KEY User(Email),    | Email của người dùng |

## 15. Bảng MyFood
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

## 16. Các bảng MyFoodBreakFast, MyFoodLunch, MyFoodDinner, MyFoodSnack
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Food_ID         | int |           |                  | Yes             | Foreign Key REFERENCES MyFood(ID) | ID của món ăn |
| Food_Quantity       | NVARCHAR(50) |           |                  | No          |           | Định lượng của món ăn |
| Food_Date       | Date |           |                  | Yes          |      Foreign Key REFERENCES FOODDIARY(FOOD_DATE)     | Ngày chọn món |
| User_Email       | nvarchar(50) |           |                  | No           |    Foreign Key REFERENCES MyFood(USER_EMAIL),  Foreign Key REFERENCES FOODDIARY(USER_EMAIL), | Email của người dùng |

## 17. Bảng FoodDiary
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| Food_Date         | Date |           |                  | Yes            |  Primary Key   | ID của món ăn |
| TotalCalo       | int |           |                  | Yes          |           | Tổng lượng Calo trong 1 ngày |
| User_Email       | nvarchar(50) |           |                  | No           |    Primary Key, FOREIGN KEY User(Email)   | Email của người dùng |

## 18. Các bảng QuickAddBreakFast, QuickAddLunch, QuickAddDinner, QuickAddSnack
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | Yes             | PRIMARY KEY | ID của phần tử trong bảng |
| Food_Date       | Date |           |                  | Yes         |  PRIMARY KEY   | Ngày chọn món |
| Food_Calories, Food_Carbs, Food_Fat, Food_Sodium, Food_Protein, Food_sugar| float |          |                  | No             |           | Chỉ số dinh dưỡng của món ăn
| User_Email       | nvarchar(50) |           |                  | No           | PRIMARY KEY, Foreign Key  REFERENCES User(Email) | Email của người dùng |

## 19. Bảng Meal
| Tên Thuộc Tính | Kiểu Dữ Liệu | Ràng Buộc | Giá Trị Mặc Định | Chấp Nhận NULL | Kiểu Khóa | Diễn Giải |
|----------------|--------------|-----------|------------------|----------------|-----------|-----------|
| ID         | int |           |                  | No             | PRIMARY KEY | ID của bữa ăn |
| MEAL_NAME         | NVARCHAR(255) |           |                  | No           |  |Tên bữa ăn |