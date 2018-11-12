
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spAuthenticateUserRole')) 
exec('CREATE PROCEDURE [dbo].[spAuthenticateUserRole] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[spAuthenticateUserRole] 
@user_id int
 as
 begin
 begin try
 begin transaction


 
 select tbl_userbranch.company_id,tbl_userbranch.branch_id,tbl_role.role_name from tbl_userbranch inner join tbl_role on tbl_userbranch.role_id=tbl_role.role_id where tbl_userbranch.user_id=@user_id

  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end