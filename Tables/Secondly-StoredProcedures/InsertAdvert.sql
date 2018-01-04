Create Procedure InsertAdvertLast 
@X_Coordinate float,
@Y_Coordinate float,
@Room_Number int,
@Living_Room_Number int,
@Floor_Number int,
@Square_Meter int,
@Age int,
@Heating float,
@Proximity_Transportation float,
@Image image,
@Information nchar(500),
@User_Mail_Adress nchar(30),
@Requested_Price bigint,
@Estimated_Price bigint,
@Insert_Time date,
@City nchar(50) 
as 
Insert Into Advert(X_Coordinate, Y_Coordinate, Room_Number, Living_Room_Number, Floor_Number, Square_Meter, Age,
Heating, Proximity_Transportation, Image, Information, User_Mail_Adress, Requested_Price, Estimated_Price, Insert_Time, City) values (@X_Coordinate, @Y_Coordinate, @Room_Number,
@Living_Room_Number, @Floor_Number, @Square_Meter, @Age, @Heating, @Proximity_Transportation, @Image, 
@Information, @User_Mail_Adress, @Requested_Price, @Estimated_Price, @Insert_Time, @City)