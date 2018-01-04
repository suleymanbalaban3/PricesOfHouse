USE [msdb]
GO

/****** Object:  Table [dbo].[Advert]    Script Date: 4.12.2017 21:48:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Advert](
	[Advert_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[X_Coordinate] [float] NOT NULL,
	[Y_Coordinate] [float] NOT NULL,
	[Room_Number] [int] NOT NULL,
	[Living_Room_Number] [int] NOT NULL,
	[Floor_Number] [int] NOT NULL,
	[Square_Meter] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[Heating] [float] NOT NULL,
	[Proximity_Transportation] [int] NOT NULL,
	[Image] [image] NOT NULL,
	[Information] [nchar](500) NOT NULL,
	[User_Mail_Adress] [nchar](30) NOT NULL,
	[Requested_Price] [bigint] NOT NULL,
	[Estimated_Price] [bigint] NOT NULL,
	[Insert_Time] [date] NOT NULL,
 CONSTRAINT [PK_Advert] PRIMARY KEY CLUSTERED 
(
	[Advert_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Advert]  WITH CHECK ADD  CONSTRAINT [FK_Advert_User1] FOREIGN KEY([User_Mail_Adress])
REFERENCES [dbo].[User] ([Mail_Adress])
GO

ALTER TABLE [dbo].[Advert] CHECK CONSTRAINT [FK_Advert_User1]
GO

