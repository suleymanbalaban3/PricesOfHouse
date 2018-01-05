USE [msdb]
GO

/****** Object:  Table [dbo].[Regression_Values]    Script Date: 4.12.2017 21:49:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Regression_Values](
	[X_Coordinate_Beta] [float] NOT NULL,
	[Y_Coordinate_Beta] [float] NOT NULL,
	[Room_Number_Beta] [float] NOT NULL,
	[Living_Room_Number_Beta] [float] NOT NULL,
	[Floor_Number_Beta] [float] NOT NULL,
	[Square_Meter_Beta] [float] NOT NULL,
	[Age_Beta] [float] NOT NULL,
	[Heating_Beta] [float] NOT NULL,
	[Proximity_Transportation_Beta] [float] NOT NULL
) ON [PRIMARY]

GO

