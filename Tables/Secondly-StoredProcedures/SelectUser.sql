Create Proc SelectUser
@Mail_Adress nchar (30) ,
@Password nvarchar (30) 
AS
BEGIN
Select Mail_Adress, Password from [msdb].[dbo].[User] where @Password = Password AND @Mail_Adress = Mail_Adress
END