
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_AddUser2')) 
exec('CREATE PROCEDURE [dbo].[sp_AddUser2] AS BEGIN SET NOCOUNT ON; END')
GO

ALTER procedure[dbo].[sp_AddUser2]
@user_name nvarchar(50),
@user_emailid nvarchar(50),
@user_mobileno nvarchar(50),
@password nvarchar(50),
@role_id int,
@branch_id int,
@company_id int,
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime



as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_User(user_name,user_Emai,user_mobieno,password,status,created_by,created_date)
 values (@user_name,@user_emailid,@user_mobileno,@password,@status,@created_by,@created_date)

 declare @user_id int 
Select @user_id = @@identity

 insert into tbl_userbranch(role_id,user_id,branch_id,status,created_by,created_date,company_id) 
 values(@role_id,@user_id,@branch_id,@status,@created_by,@created_date,@company_id)

     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(Error_Type,Error_Msg) values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


