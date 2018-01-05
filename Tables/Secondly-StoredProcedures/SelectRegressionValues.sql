Create Procedure SelectRegressionValues
AS
BEGIN
Select X_Coordinate_Beta, Y_Coordinate_Beta, Room_Number_Beta, Living_Room_Number_Beta, 
Floor_Number_Beta, Square_Meter_Beta, Age_Beta, Heating_Beta, Proximity_Transportation_Beta from [msdb].[dbo].[Regression_Values]
END