Create Procedure SelectIndependentFromAdvert
AS
BEGIN
Select X_Coordinate, Y_Coordinate, Room_Number, Living_Room_Number, 
Floor_Number, Square_Meter, Age, Heating, Proximity_Transportation, Requested_Price from [msdb].[dbo].[Advert]
END