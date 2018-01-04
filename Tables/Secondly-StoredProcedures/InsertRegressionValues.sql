Create Procedure InsertRegressionValue
@X_Coordinate_Beta float,
@Y_Coordinate_Beta float,
@Room_Number_Beta int,
@Living_Room_Number_Beta int,
@Floor_Number_Beta int,
@Square_Meter_Beta int,
@Age_Beta int,
@Heating_Beta float,
@Proximity_Transportation_Beta float
as 
Insert Into Regression_Values(X_Coordinate_Beta, Y_Coordinate_Beta, Room_Number_Beta, Living_Room_Number_Beta, Floor_Number_Beta, 
Square_Meter_Beta, Age_Beta,Heating_Beta, Proximity_Transportation_Beta) values (@X_Coordinate_Beta, @Y_Coordinate_Beta, @Room_Number_Beta,
@Living_Room_Number_Beta, @Floor_Number_Beta, @Square_Meter_Beta, @Age_Beta, @Heating_Beta, @Proximity_Transportation_Beta)