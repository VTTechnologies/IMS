
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spAuthenticateUser')) 
exec('CREATE PROCEDURE [dbo].[spAuthenticateUser] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[spAuthenticateUser] 
@user_name nvarchar(100),
@password nvarchar(500)
 as
 begin
 begin try
 begin transaction
 select user_id from tbl_User where user_name=@user_name and password=@password
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end