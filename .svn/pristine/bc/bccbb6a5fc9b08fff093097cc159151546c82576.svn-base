---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Category

USE [IMS]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_CategoryInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_CategoryInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_CategoryInsert] 
@company_id int,
@branch_id int,
@category_name nvarchar(50),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_category (company_id,branch_id ,category_name,status,created_by,created_date,modified_by,modified_date) values (@company_id,@branch_id,@category_name,@status,@created_by,@created_date,@modified_by,@modified_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End




----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Units
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UnitInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_UnitInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_UnitInsert] 

@company_id int,
@branch_id int,
@unit_name nvarchar(50),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_unit (company_id,branch_id ,unit_name,status,created_by,created_date,modified_by,modified_date) values (@company_id,@branch_id,@unit_name,@status,@created_by,@created_date,@modified_by,@modified_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End

   go
----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Godown



IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_godowninsert')) 
exec('CREATE PROCEDURE [dbo].[sp_godowninsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_godowninsert] 

@company_id int,
@branch_id int,
@godown_name nvarchar(50),
@godown_address nvarchar(50),
@contact_no varchar(50),
@contact_person nvarchar(50),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_godown(company_id,branch_id ,godown_name,godown_address,contact_no,contact_person,status,created_by,created_date,modified_by,modified_date) values (@company_id,@branch_id,@godown_name,@godown_address,@contact_no,@contact_person,@status,@created_by,@created_date,@modified_by,@modified_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


   go
----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Rack



IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_rackInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_rackInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_rackInsert] 
@company_id int,
@branch_id int,
@godown_id int,
@rack_name nvarchar(50),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_rack(company_id,branch_id ,rack_name,godown_id,status,created_by,created_date,modified_by,modified_date) values (@company_id,@branch_id,@rack_name,@godown_id,@status,@created_by,@created_date,@modified_by,@modified_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End
   go
----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Tax


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_taxInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_taxInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_taxInsert] 
@company_id int,
@branch_id int,
@tax_name nvarchar(50),
@tax_percentage decimal(18,0),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_tax(company_id,branch_id ,tax_name,tax_percentage,status,created_by,created_date,modified_by,modified_date) values (@company_id,@branch_id,@tax_name,@tax_percentage,@status,@created_by,@created_date,@modified_by,@modified_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End

   go


----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Batch
   
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_BatchInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_BatchInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_BatchInsert] 
@company_id int,
@branch_id int,
@batch_name nvarchar(50),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_batch (company_id,branch_id ,batch_name,status,created_by,created_date,modified_by,modified_date) values (@company_id,@branch_id,@batch_name,@status,@created_by,@created_date,@modified_by,@modified_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


   go
 ----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Expense


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_ExpenseInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_ExpenseInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_ExpenseInsert] 
@company_id int,
@branch_id int,
@expense_name nvarchar(50),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_expense(company_id,branch_id ,expense_name,status,created_by,created_date,modified_by,modified_date) values (@company_id,@branch_id,@expense_name,@status,@created_by,@created_date,@modified_by,@modified_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


go

 ----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Financial Year


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_FyInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_FyInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_FyInsert] 
@company_id int,
@branch_id int,
@start_date nvarchar(50),
@end_date nvarchar(50),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_financialyear(company_id,branch_id ,start_date,end_date,status,created_by,created_date,modified_by,modified_date) values (@company_id,@branch_id,@start_date,@end_date,@status,@created_by,@created_date,@modified_by,@modified_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


   go
 ----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert party


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_PartyInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_PartyInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_PartyInsert] 
@company_id int,
@branch_id int,
@party_name nvarchar(50),
@party_address nvarchar(500),
@contact_no varchar(50),
@gstin_no nvarchar(20),
@party_type nvarchar(20),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_party(company_id,branch_id ,party_name,party_address,contact_no,gstin_no,party_type,status,created_by,created_date)
 values (@company_id,@branch_id,@party_name,@party_address,@contact_no,@gstin_no,@party_type,@status,@created_by,@created_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


go

 ----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of insert Payment Mode


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_PaymentModeInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_PaymentModeInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_PaymentModeInsert] 
@company_id int,
@branch_id int,
@paymentmode_name nvarchar(50),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_paymentmode(company_id,branch_id ,paymentmode_name,status,created_by,created_date,modified_by,modified_date)
 values (@company_id,@branch_id,@paymentmode_name,@status,@created_by,@created_date,@modified_by,@modified_date)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End

go

 ----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of insert product


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_ProductInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_ProductInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_ProductInsert] 
@company_id int,
@branch_id int,
@category_id int,
@unit_id int,
@godown_id int,
@rack_id int,
@tax_id int,
@reorder_level int,
@product_name nvarchar(50),
@product_code nvarchar(500),
@hsn_code varchar(50),
@purchas_price decimal(18,0),
@sales_price decimal(18,0),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime,
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_product(
company_id,
branch_id ,
category_id,
unit_id,
godown_id,
rack_id,
tax_id,
product_name,
product_code,
hsn_code,
reorder_level,
purchas_price,
sales_price,
status,
created_by,
created_date,
modified_by,
modified_date
)
 values (
 @company_id,
 @branch_id,
 @category_id,
 @unit_id,
 @godown_id,
 @rack_id,
 @tax_id,
 @product_name,
 @product_code,
 @hsn_code,
 @reorder_level,
 @purchas_price,
 @sales_price,
 @status,
 @created_by,
 @created_date,
 @modified_by,
 @modified_date
 )


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


go


----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of insert Company


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_CompanyInsert')) 
exec('CREATE PROCEDURE [dbo].[sp_CompanyInsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_CompanyInsert] 
@company_name nvarchar(50),
@owner_emailid nvarchar(50),
@owner_mobileno nvarchar(50),
@country_id int,
@pincode nvarchar(50),
@created_by nvarchar(50),
@created_date smalldatetime,
@first_name nvarchar(50),
@last_name nvarchar(50)


as
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_company(company_name,owner_emailid,owner_mobileno,country_id,pincode,status,created_by,created_date,first_name,last_name)
 values (@company_name,@owner_emailid,@owner_mobileno,@country_id,@pincode,1,@created_by,@created_date,@first_name,@last_name)


     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(Error_Type,Error_Msg) values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End
   go

 ----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of insert Branch



IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_InsertBranch')) 
exec('CREATE PROCEDURE [dbo].[sp_InsertBranch] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_InsertBranch] 
 @company_id int,
 @branch_name nvarchar(50),
 @branch_address nvarchar(500),
 @pincode nvarchar(50),
 @telephone_no nvarchar(50),
 @fax_no nvarchar(50),
 @country_id int,
 @state_id int,
 @city nvarchar(200),
 @created_by  nvarchar(50),
 @created_date datetime
 as
 begin
 begin try
 begin transaction
  insert into tbl_branch(company_id,branch_name,branch_address,country_id,state_id,pincode,city,telephone_no,fax_no,status,created_by,created_date)
  values (@company_id,@branch_name,@branch_address,@country_id,@state_id,@pincode,@city,@telephone_no,@fax_no,1,@created_by,@created_date)
   
  commit transaction
  end try
  begin catch

  end catch
  end
  go


----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of insert Register


  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Register')) 
exec('CREATE PROCEDURE [dbo].[sp_Register] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_Register] 
@company_name nvarchar(50),
@first_name nvarchar(100),
@last_name nvarchar(100),
@owner_emailid nvarchar(50),
@owner_mobileno nvarchar(50),
@user_password nvarchar(50),
@country_id int,
@pincode nvarchar(50),
@created_by nvarchar(50),
@created_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction
	 Insert into tbl_company(company_name,first_name,last_name,owner_emailid,owner_mobileno,country_id,pincode,status,created_by,created_date) 
	 values (@company_name,@first_name,@last_name,@owner_emailid,@owner_mobileno,@country_id,@pincode,1,@created_by,@created_date)

	 declare @company_id int
	 Select @company_id=@@identity


	Insert into tbl_branch(branch_name,company_id,country_id,pincode,status,created_by,created_date,IsMainBranch)
	values (@company_name,@company_id,@country_id,@pincode,1,@created_by,@created_date,1)

	declare @branch_id int
	select @branch_id=@@IDENTITY

	Insert into tbl_User(user_name,user_Emai,user_mobieno,password,status,created_by,created_date)
	values (@first_name,@owner_emailid,@owner_mobileno,@user_password,1,@created_by,@created_date)
	declare @user_id int
	select @user_id=@@IDENTITY

	insert into tbl_userbranch(role_id,user_id,branch_id,status,created_by,created_date,company_id)
	values(3,@user_id,@branch_id,1,@created_by,@created_date,@company_id)

     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(Error_Type,Error_Msg) values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End



----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of insert error

   IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_saveerror')) 
exec('CREATE PROCEDURE [dbo].[sp_saveerror] AS BEGIN SET NOCOUNT ON; END') 
GO
ALter procedure[dbo].[sp_saveerror] 
@company_id int,
@branch_id int,
@error_type nvarchar(50),
@error_msg nvarchar(max),
@created_by nvarchar(50)

as
 Begin
    Begin Try
     Begin Transaction


Insert into tbl_error_log (company_id,branch_id,error_type,error_msg,created_by) values (@company_id,@branch_id,@error_type,@error_msg,@created_by)

   
     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End





