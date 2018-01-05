USE [msdb]
GO

/****** Object:  Table [dbo].[User]    Script Date: 4.12.2017 21:48:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[First_Name] [nchar](20) NOT NULL,
	[Last_Name] [nchar](20) NOT NULL,
	[Mail_Adress] [nchar](30) NOT NULL,
	[Password] [nchar](30) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Mail_Adress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

