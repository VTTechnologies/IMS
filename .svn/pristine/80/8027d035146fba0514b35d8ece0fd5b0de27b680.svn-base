---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Category


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


   go

----------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Insert Units

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
if not EXISTS(select 1 from tbl_expense where company_id=@company_id and branch_id=@branch_id and expense_name=@expense_name)
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
@created_by nvarchar(50),
@created_date smalldatetime


as
 Begin
	 declare @e_date smalldatetime
		select @e_date=end_date  from tbl_financialyear where company_id=@company_id and status=1
			 if(GETDATE()>@e_date)
				 begin
					 Insert into tbl_financialyear(company_id,branch_id ,start_date,end_date,status,created_by,created_date,Is_new)
					 values (@company_id,@branch_id,@start_date,@end_date,1,@created_by,@created_date,0)
				 end
			 else
				 begin
					Insert into tbl_financialyear(company_id,branch_id ,start_date,end_date,Is_new,created_by,created_date,status)
					 values (@company_id,@branch_id,@start_date,@end_date,1,@created_by,@created_date,0)
				 end
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
@state_id int,
@created_by nvarchar(50),
@created_date smalldatetime


as
if not EXISTS(select 1 from tbl_party where company_id=@company_id and branch_id=@branch_id and party_name=@party_name)
 Begin
    Begin Try
     Begin Transaction

Insert into tbl_party(company_id,branch_id ,party_name,party_address,contact_no,gstin_no,party_type,status,created_by,created_date,state_id)
 values (@company_id,@branch_id,@party_name,@party_address,@contact_no,@gstin_no,@party_type,@status,@created_by,@created_date,@state_id)


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
if not EXISTS(select 1 from tbl_product where company_id=@company_id and branch_id=@branch_id and product_name=@product_name)
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
@created_date smalldatetime,
@start_date nvarchar(50),
@end_date nvarchar(50),
@uniqueidentity nvarchar(max)


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

	Insert into tbl_User(user_name,user_Emai,user_mobieno,password,status,created_by,created_date,first_name,last_name)
	values (@owner_emailid,@owner_emailid,@owner_mobileno,@user_password,1,@created_by,@created_date,@first_name,@last_name)
	declare @user_id int
	select @user_id=@@IDENTITY

	insert into tbl_userbranch(role_id,user_id,branch_id,status,created_by,created_date,company_id)
	values(4,@user_id,@branch_id,1,@created_by,@created_date,@company_id)

	Insert into tbl_financialyear(company_id,branch_id ,start_date,end_date,status,created_by,created_date) 
	values (@company_id,@branch_id,@start_date,@end_date,1,@created_by,@created_date)

	insert into tbl_emailverify([user_id],[uniqueidentifier],[status],[created_date])
	values (@user_id,@uniqueidentity,0,@created_date)

	select u.first_name +' '+ u.last_name,u.user_id,ev.uniqueidentifier from tbl_User u join Tbl_EmailVerify ev on ev.user_id=u.user_id where u.user_id = @user_id;

     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(Error_Type,Error_Msg) values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End



   go
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
@created_by nvarchar(50),
@created_date datetime
as
 Begin
    Begin Try
     Begin Transaction

	 
Insert into tbl_error_log (company_id,branch_id,error_type,error_msg,created_by,created_date) values (@company_id,@branch_id,@error_type,@error_msg,@created_by,@created_date)

   
     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End

   go


   -------------------------------------------------------Update Batch-----------------------------------------------------------------


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Updatebatch')) 
exec('CREATE PROCEDURE [dbo].[sp_Updatebatch] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_Updatebatch] 
 @company_id int,
 @batch_id int,
 @branch_id int,
 @batch_name nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_batch set batch_name=@batch_name,modified_by=@modified_by,modified_date=GETDATE()   where company_id=@company_id and batch_id=@batch_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

-------------------------------------------------------Update Baranch-----------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateBranch')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateBranch] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdateBranch] 
 
 @branch_id int,
 @company_id int,
 @branch_name nvarchar(50),
 @branch_address nvarchar(500),
 @pincode nvarchar(50),
 @telephone_no nvarchar(50),
 @fax_no nvarchar(50),
 @country_id int,
 @state_id int,
 @city nvarchar(200),
 @modified_by nvarchar(50)
 as
 begin
 begin try
 begin transaction
  update tbl_branch set branch_name=@branch_name,branch_address=@branch_address,pincode=@pincode,telephone_no=@telephone_no,fax_no=@fax_no
  ,country_id=@country_id,state_id=@state_id,city=@city,modified_by=@modified_by,modified_date=GETDATE()
     where company_id=@company_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
-------------------------------------------------------Update Category-----------------------------------------------------------------


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateCategory')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateCategory] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdateCategory] 
 @company_id int,
 @category_id int,
 @category_name nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_category set category_name=@category_name,modified_by=@modified_by,modified_date=GETDATE()  
   where company_id=@company_id and category_id=@category_id 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

-------------------------------------------------------Update Company-----------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateCompany')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateCompany] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_UpdateCompany] 
@company_id int,
@company_name nvarchar(50),
@company_address nvarchar(500),
@state_id int,
@city nvarchar(50),
@telephone_no nvarchar(50),
@fax_no  nvarchar(50),
@website nvarchar(200),
@logo  varbinary(max),
@logo_name nvarchar(100),
@GSTIN  nvarchar(50),
@modified_by nvarchar(50),
@modified_date smalldatetime


as
 Begin

update tbl_company set company_name=@company_name,company_address=@company_address,state_id=@state_id,city=@city,
telephone_no=@telephone_no,fax_no=@fax_no,website=@website,logo=@logo,logo_name=@logo_name,GSTIN=@GSTIN,modified_by=@modified_by,
modified_date=@modified_date where company_id=@company_id

   
   End


go

-------------------------------------------------------Update Expense-----------------------------------------------------------------


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateExpense')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateExpense] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdateExpense] 
 @company_id int,
 @branch_id int,
 @expense_id int,
 @expense_name nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_expense set expense_name=@expense_name,modified_by=@modified_by,modified_date=GETDATE()   where company_id=@company_id and expense_id=@expense_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
-------------------------------------------------------Update FY-----------------------------------------------------------------


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateFyear')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateFyear] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdateFyear] 
 @company_id int,
 @financialyear_id int,
 @branch_id int,
 @start_date nvarchar(50),
 @end_date nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_financialyear set start_date=@start_date,end_date=@end_date,modified_by=@modified_by,modified_date=GETDATE()   where company_id=@company_id and financialyear_id=@financialyear_id and branch_id= @branch_id 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
-------------------------------------------------------Update Godown-----------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateGodown')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateGodown] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdateGodown] 
@company_id int,
@branch_id int,
@godown_id int,
@godown_name nvarchar(50),
@godown_address nvarchar(500),
@contact_no varchar(50),
@contact_person nvarchar(50),
@modified_by nvarchar(50),
@modified_date smalldatetime
 as
 begin
 begin try
 begin transaction
  update tbl_godown set godown_name=@godown_name,godown_address=@godown_address,contact_no=@contact_no,contact_person=@contact_person,
  modified_by=@modified_by,modified_date=GETDATE()   where company_id=@company_id and godown_id=@godown_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
-------------------------------------------------------Update Party-----------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateParty')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateParty] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_UpdateParty] 
@company_id int, 
@branch_id int,
@party_id int,
@state_id int,
@party_name nvarchar(50),
@party_address nvarchar(500),
@contact_no varchar(50),
@party_type nvarchar(20),
@gstin_no nvarchar(20),
@modified_by nvarchar(50),
@modified_date smalldatetime
 as
 begin
 begin try
 begin transaction
  update tbl_party set party_name=@party_name,party_address=@party_address,contact_no=@contact_no,gstin_no=@gstin_no,party_type=@party_type,
  modified_by=@modified_by,modified_date=GETDATE(),state_id=@state_id   where company_id=@company_id and party_id=@party_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
-------------------------------------------------------Update Payment Mode-----------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdatePMode')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdatePMode] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdatePMode] 
 @company_id int,
 @branch_id int,
 @paymentode_id int,
 @paymentmode_name nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_paymentmode set paymentmode_name=@paymentmode_name,modified_by=@modified_by,modified_date=GETDATE()   
  where company_id=@company_id and paymentode_id=@paymentode_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
-------------------------------------------------------Update Product-----------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateProduct')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateProduct] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdateProduct] 
 @company_id int,
 @branch_id int,
 @product_id int,
 @category_id int,
 @rack_id int,
 @godown_id int,
 @tax_id int,
 @unit_id int,
 @reorder_level int,
 @purchas_price decimal(18, 0),
 @sales_price decimal(18, 0),
 @product_code nvarchar(50),
 @hsn_code nvarchar(50),
 @product_name nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
	
  update tbl_product set product_name=@product_name,godown_id=@godown_id,category_id=@category_id,tax_id=@tax_id,hsn_code=@hsn_code,
  unit_id=@unit_id,modified_by=@modified_by,modified_date=GETDATE(),rack_id=@rack_id,purchas_price=@purchas_price,
  sales_price=@sales_price,reorder_level=@reorder_level
   where company_id=@company_id and product_id=@product_id and branch_id=@branch_id
	end
  go
-------------------------------------------------------Update Rack-----------------------------------------------------------------


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateRack')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateRack] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdateRack] 
 @company_id int,
 @branch_id int,
 @rack_id int,
 @godown_id int,
 @rack_name nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_rack set rack_name=@rack_name,godown_id=@godown_id,modified_by=@modified_by,modified_date=GETDATE()
     where company_id=@company_id and rack_id=@rack_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
-------------------------------------------------------Update Unit-----------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateUnit')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateUnit] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdateUnit] 
 @company_id int,
 @branch_id int,
 @unit_id int,
 @unit_name nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_unit set unit_name=@unit_name,modified_by=@modified_by,modified_date=GETDATE()   
  where company_id=@company_id and unit_id=@unit_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
-------------------------------------------------------Update User-----------------------------------------------------------------


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateUser')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateUser] AS BEGIN SET NOCOUNT ON; END')
GO

ALTER procedure[dbo].[sp_UpdateUser]
@userbranch_id int,
@user_id int,
@user_name nvarchar(50),
@user_emailid nvarchar(50),
@user_mobileno nvarchar(50),
@role_id int,
@branch_id int,
@company_id int,
@status bit,
@modified_by nvarchar(50),
@modified_date smalldatetime,
@first_name nvarchar(50),
@last_name	nvarchar(50)


as
 Begin
    Begin Try
     Begin Transaction

update tbl_user set first_name=@first_name,last_name=@last_name, user_name=@user_name,user_Emai=@user_emailid,
user_mobieno=@user_mobileno,modified_by=@modified_by,
modified_date=@modified_date where user_id=@user_id

 update tbl_userbranch set role_id=@role_id,branch_id=@branch_id,modified_by=@modified_by,
modified_date=@modified_date
 where userbranch_id=@userbranch_id and user_id=@user_id 

     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(Error_Type,Error_Msg) values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End
go

---------------------------------------Update tax-----------------------------------------------------------



IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateTax')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateTax] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_UpdateTax] 
 @company_id int,
  @branch_id int,
 @tax_id int,
 @tax_name nvarchar(50),
 @tax_percentage decimal(18, 0),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_tax set tax_name=@tax_name,tax_percentage=@tax_percentage,modified_by=@modified_by,modified_date=GETDATE() 
    where company_id=@company_id and tax_id=@tax_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end

  go
  ----------------------------------------Authentication-----------------------------------------------------

  
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
  go

  ----------------------------------------------------------------user role-------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spAuthenticateUserRole')) 
exec('CREATE PROCEDURE [dbo].[spAuthenticateUserRole] AS BEGIN SET NOCOUNT ON; END') 
GO
 Alter PROCEDURE [dbo].[spAuthenticateUserRole] 
 @user_id int
 as
 begin
 begin try
 begin transaction

 select tbl_userbranch.company_id,tbl_userbranch.branch_id,tbl_role.role_name , u.first_name + ' ' + u.last_name as [Name]
 from tbl_userbranch 
 inner join tbl_role on tbl_userbranch.role_id=tbl_role.role_id 
 join tbl_User u on u.user_id = tbl_userbranch.user_id
 where tbl_userbranch.user_id=@user_id

  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  ----------------------------------------------------------------

  ----------------------------------------Select Category------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectCategory')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectCategory] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectCategory] 
 @company_id int,
 @branch_id int
 as
 begin
  select category_id, category_name from tbl_category where company_id=@company_id and status=1 and branch_id=@branch_id
  end
  go

  ----------------------------------------Select Batch------------------------------------------------------

  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectBatch')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectBatch] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectBatch] 
 @company_id int
 ,@branch_id int
 as
 begin
 begin try
 begin transaction
  select batch_id, batch_name from tbl_batch where company_id=@company_id and status=1 and branch_id=@branch_id
  commit transaction
  end try
  begin catch

  end catch
  end
  go

    ----------------------------------------Select Branch------------------------------------------------------

	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectBranch')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectBranch] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectBranch] 
 @company_id int
 as
 begin
 begin try
 begin transaction
  select tbl_branch.branch_id,tbl_branch.branch_name,tbl_branch.branch_address,tbl_branch.pincode,tbl_branch.city,
  tbl_branch.state_id,tbl_branch.fax_no,tbl_branch.telephone_no,tbl_branch.country_id,tbl_country.country_name,tbl_state.state_name
  from((tbl_branch inner join tbl_country on tbl_branch.country_id=tbl_country.country_id)
  inner join tbl_state on tbl_branch.state_id=tbl_state.state_id) 
  where tbl_branch.company_id=@company_id and tbl_branch.status=1
  commit transaction
  end try
  begin catch

  end catch
  end
  go

  
    ----------------------------------------Select Company------------------------------------------------------

	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectCompany')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectCompany] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_SelectCompany] 
@company_id int


as
 Begin
    Begin Try
     Begin Transaction

select c.company_name,c.company_address,c.country_id,c.state_id,c.city,c.telephone_no,c.fax_no,c.pincode
,c.GSTIN,c.website,c.first_name,c.last_name,c.owner_emailid,c.owner_mobileno,cy.country_name,s.state_name
  from ((tbl_company as c left join tbl_country as cy on c.country_id=cy.country_id)
 left join tbl_state as s on c.state_id=s.state_id) where c.company_id=@company_id
     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(Error_Type,Error_Msg) values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


go

  ----------------------------------------Select Country------------------------------------------------------

  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectCountry')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectCountry] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectCountry] 
 as
 begin
 begin try
 begin transaction
  select country_id,country_name from tbl_country where status=1
  commit transaction
  end try
  begin catch

  end catch
  end

  go

    ----------------------------------------Select Expense------------------------------------------------------

 Alter PROCEDURE [dbo].[sp_SelectExpense] 
 @company_id int,
 @branch_id int
 as
 begin
 begin try
 begin transaction
  select expense_id, expense_name from tbl_expense where company_id=@company_id and status=1 and branch_id=@branch_id
  commit transaction
  end try
  begin catch

  end catch
  end

     ----------------------------------------Select FY------------------------------------------------------

	 
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectFY')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectFY] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectFY] 
 @company_id int
  ,@branch_id int
 as
 begin
 begin try
 begin transaction
  select financialyear_id, start_date,end_date from tbl_financialyear where company_id=@company_id and status=1 and branch_id=@branch_id
  commit transaction
  end try
  begin catch

  end catch
  end
  go

      ----------------------------------------Select Godown------------------------------------------------------

	  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Selectgodown')) 
exec('CREATE PROCEDURE [dbo].[sp_Selectgodown] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_Selectgodown] 
 @company_id int
  ,@branch_id int
 as
 begin
 begin try
 begin transaction
  select godown_id, godown_name,godown_address,contact_no,contact_person from tbl_godown where company_id=@company_id and status=1 and branch_id=@branch_id
  commit transaction
  end try
  begin catch

  end catch
  end
  go

       ----------------------------------------Select Party------------------------------------------------------

	   
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectParty')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectParty] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectParty] 
 @company_id int
  ,@branch_id int
 as
 begin
 begin try
 begin transaction
   select tbl_party.party_id,tbl_party.party_name,tbl_party.party_address,tbl_party.contact_no,tbl_party.gstin_no,tbl_party.party_type,
  tbl_party.state_id,tbl_state.state_name from tbl_party left join tbl_state on tbl_state.state_id=tbl_party.state_id
   where tbl_party.company_id=@company_id and tbl_party.status=1 and tbl_party.branch_id=@branch_id

  commit transaction
  end try
  begin catch

  end catch
  end

  go

  ----------------------------------------Select PM------------------------------------------------------

  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectPM')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectPM] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectPM] 
 @company_id int
  ,@branch_id int
 as
 begin
 begin try
 begin transaction
  select paymentode_id , paymentmode_name from tbl_paymentmode where company_id=@company_id and status=1 and
  branch_id=@branch_id
  commit transaction
  end try
  begin catch

  end catch
  end

  go
   ----------------------------------------Select Product------------------------------------------------------

   
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectProduct')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectProduct] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectProduct] 
 @company_id int
  ,@branch_id int
 as
 begin
 begin try
 begin transaction
  SELECT tbl_product.product_id,tbl_product.product_name,tbl_product.hsn_code,tbl_product.product_code,tbl_product.purchas_price,tbl_product.sales_price,tbl_product.reorder_level,
 tbl_product.category_id,tbl_product.godown_id,tbl_product.rack_id,tbl_product.tax_id,tbl_product.unit_id,tbl_category.category_name,tbl_unit.unit_name,tbl_godown.godown_name,tbl_rack.rack_name,tbl_tax.tax_name from((((
  ( tbl_product inner JOIN tbl_category ON tbl_product.category_id= tbl_category.category_id)
  inner JOIN tbl_unit ON tbl_product.unit_id = tbl_unit.unit_id)
   inner join tbl_godown on tbl_product.godown_id=tbl_godown.godown_id)
   inner join tbl_rack on tbl_product.rack_id=tbl_rack.rack_id)
   inner join tbl_tax on tbl_product.tax_id=tbl_tax.tax_id)
   where tbl_product.company_id=@company_id and tbl_product.status=1 and tbl_product.branch_id=@branch_id
  commit transaction
  end try
  begin catch

  end catch
  end

  go


  ----------------------------------------Select Rack------------------------------------------------------


  IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectRack')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectRack] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectRack] 
 @company_id int
  ,@branch_id int
 as
 begin
  begin try
  begin transaction

 
  select tbl_rack.rack_id,tbl_rack.rack_name,tbl_godown.godown_name,tbl_rack.godown_id 
  from tbl_rack  right join tbl_godown on tbl_rack.godown_id=tbl_godown.godown_id
   where tbl_rack.company_id=@company_id and tbl_rack.status=1 and tbl_rack.branch_id=@branch_id
  commit transaction
  end try
  begin catch

  end catch
  end


  go

  ----------------------------------------Select Tax------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectTax')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectTax] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectTax] 
 @company_id int
 ,@branch_id int
 as
 begin
 begin try
 begin transaction
  select tax_id, tax_name,tax_percentage from tbl_tax where company_id=@company_id and status=1 and branch_id=@branch_id
  commit transaction
  end try
  begin catch

  end catch
  end
  go


  ----------------------------------------Select Unit------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectUnit')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectUnit] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectUnit] 
 @company_id int
 ,@branch_id int
 as
 begin
 begin try
 begin transaction
  select unit_id, unit_name from tbl_unit where company_id=@company_id and status=1 and branch_id=@branch_id
  commit transaction
  end try
  begin catch

  end catch
  end
  go
   ----------------------------------------Select UserRole------------------------------------------------------

   
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectUserRole')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectUserRole] AS BEGIN SET NOCOUNT ON; END')
GO

ALTER procedure[dbo].[sp_SelectUserRole]
@company_id int

as
 Begin
    Begin Try
     Begin Transaction
	 Select tbl_userbranch.userbranch_id,tbl_role.role_id,tbl_userbranch.branch_id,tbl_User.user_id,tbl_User.user_Emai,tbl_User.password,
	 tbl_User.user_mobieno, tbl_User.first_name,tbl_User.last_name,tbl_role.role_name,tbl_branch.branch_name from (((
	 tbl_userbranch inner join tbl_User on tbl_userbranch.user_id=tbl_User.user_id)
	 inner join tbl_role on tbl_userbranch.role_id=tbl_role.role_id)
	 inner join tbl_branch on tbl_userbranch.branch_id=tbl_branch.branch_id)
	 where tbl_userbranch.company_id=@company_id and tbl_userbranch.status=1 and tbl_User.status=1
     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(Error_Type,Error_Msg) values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End



go
    ----------------------------------------Select Role------------------------------------------------------

	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spAuthenticateUserRole')) 
exec('CREATE PROCEDURE [dbo].[spAuthenticateUserRole] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[spAuthenticateUserRole] 
@user_id int
 as
 begin
 begin try
 begin transaction


 
 select tbl_userbranch.company_id,tbl_userbranch.branch_id,tbl_role.role_name,(u.first_name + ' ' + u.last_name) as [Name] from tbl_userbranch 
  join tbl_User u on u.user_id = tbl_userbranch.user_id
 inner join tbl_role on tbl_userbranch.role_id=tbl_role.role_id where tbl_userbranch.user_id=@user_id

  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
	 ----------------------------------------ADD User------------------------------------------------------------


	 
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
@created_date smalldatetime,
@first_name nvarchar(50),
@last_name nvarchar(50)

as
begin   
	 IF not EXISTS(select 1 from tbl_User where user_Emai = @user_emailid and user_mobieno = @user_mobileno)
	 begin 
	   Begin Try
			Begin Transaction
				Insert into tbl_User(user_name,user_Emai,user_mobieno,password,status,created_by,created_date,first_name,last_name)
				values (@user_name,@user_emailid,@user_mobileno,@password,@status,@created_by,@created_date,@first_name,@last_name)

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
	end
End

go

-------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Batch
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Deletebatch')) 
exec('CREATE PROCEDURE [dbo].[sp_Deletebatch] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_Deletebatch] 
 @company_id int,
 @batch_id int,
 @branch_id int
 as
 begin
 begin try
 begin transaction
  update tbl_batch set status=0  where company_id=@company_id and batch_id=@batch_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end

  go


 ---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Category
 
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteCategory')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteCategory] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteCategory] 
 @company_id int,
 @category_id int,
 @branch_id int
 as
 begin
 begin try
 begin transaction
  update tbl_category set status=0  where company_id=@company_id and category_id=@category_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

  ---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Expense


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteExpense')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteExpense] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteExpense] 
 @company_id int,
 @branch_id int,
 @expense_id int
 as
 begin
 begin try
 begin transaction
  update tbl_expense set status=0  where company_id=@company_id and expense_id=@expense_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Financial Year


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteFyear')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteFyear] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteFyear] 
 @company_id int,
 @branch_id int,
 @financialyear_id int
 as
 begin
 begin try
 begin transaction
  update tbl_financialyear set status=0  where company_id=@company_id and financialyear_id=@financialyear_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end

  go

 ---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Godown


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteGodown')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteGodown] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteGodown] 
@company_id int,
@branch_id int,
@godown_id int
 as
 begin
 begin try
 begin transaction
  update tbl_godown set status=0
    where company_id=@company_id and godown_id=@godown_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Party

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteParty')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteParty] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_DeleteParty] 
@company_id int, 
@branch_id int,
@party_id int
 as
 begin
 begin try
 begin transaction
  update tbl_party set status=0
   where company_id=@company_id and party_id=@party_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end

  go

---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Payment Mode


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeletePMode')) 
exec('CREATE PROCEDURE [dbo].[sp_DeletePMode] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeletePMode] 
 @company_id int,
 @branch_id int,
 @paymentode_id int
 as
 begin
 begin try
 begin transaction
  update tbl_paymentmode set status=0
  where company_id=@company_id and paymentode_id=@paymentode_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Product

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteProduct')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteProduct] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteProduct] 
 @company_id int,
 @product_id int
 as
 begin
 begin try
 begin transaction
  update tbl_product set status=0  
   where company_id=@company_id and product_id=@product_id 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Rack


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteRack')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteRack] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteRack] 
 @company_id int,
 @branch_id int,
 @rack_id int
 as
 begin
 begin try
 begin transaction
  update tbl_rack set status=0
     where company_id=@company_id and rack_id=@rack_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Tax


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteTax')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteTax] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteTax] 
 @company_id int,
  @branch_id int,
 @tax_id int
 as
 begin
 begin try
 begin transaction
  update tbl_tax set status=0
    where company_id=@company_id and tax_id=@tax_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Unit


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteUnit')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteUnit] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteUnit] 
 @company_id int,
 @branch_id int,
 @unit_id int
 as
 begin
 begin try
 begin transaction
  update tbl_unit set status=0  
  where company_id=@company_id and unit_id=@unit_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

  ---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete Branch

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteBranch')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteBranch] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteBranch] 
 
 @branch_id int,
 @company_id int
 as
 begin
 begin try
 begin transaction
  update tbl_branch set status=0
     where company_id=@company_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

  
---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Delete User

  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteUser')) 
exec('CREATE PROCEDURE [dbo].[sp_DeleteUser] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_DeleteUser] 
 @company_id int,
 @userbranch_id int,
 @user_id int,
 @branch_id int
 as
 begin
 begin try
 begin transaction
  update tbl_userbranch set status=0  where company_id=@company_id and userbranch_id=@userbranch_id and branch_id=@branch_id

  
  update tbl_user set status=0  where user_id=@user_id 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end

  go




  ---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Select Company_Name



IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectCompany_name')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectCompany_name] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_SelectCompany_name] 

@user_id int


as
 Begin
    Begin Try
     Begin Transaction

	 select company_name from tbl_company where company_id=(select company_id from tbl_userbranch where user_id=@user_id)

     Commit Transaction
End Try
Begin Catch 

 Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End

go

  ---------------------------------------------------------------------------------------------------------------------------------------------
-- SP of Select sp_SelectTaxpercent

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectTaxpercent')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectTaxpercent] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectTaxpercent] 
 @company_id int,
 @product_id int
 as
 begin
 begin try
 begin transaction

 select tbl_product.tax_id,tbl_product.unit_id,tbl_tax.tax_percentage,
 tbl_unit.unit_name,tbl_purchasedetails.batch_id,tbl_batch.batch_name from((((
 tbl_product inner join tbl_tax on tbl_tax.tax_id=tbl_product.tax_id)inner join
 tbl_unit on tbl_unit.unit_id=tbl_product.unit_id) 
 left join tbl_purchasedetails on tbl_purchasedetails.product_id=tbl_product.product_id )
 left join tbl_batch on tbl_batch.batch_id=tbl_purchasedetails.batch_id) 
 where tbl_product.product_id=@product_id and tbl_product.company_id=@company_id 

  commit transaction
  end try
  begin catch
   Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end

go

 ----------------------------------------Select Exists Email------------------------------------------------------
-- Created By :- AL hamed Mohammed
--Created Date :- 22/01/2018
--Perpose :- For get exists emails
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.SpGetExistsEmail')) 
exec('CREATE PROCEDURE [dbo].[SpGetExistsEmail] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[SpGetExistsEmail] 
 @email varchar(50)
 as
begin
begin try
begin transaction
	 Select @email from tbl_User where user_Emai = @email;
commit transaction
end try
begin catch
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
end catch
end
go

----------------------------------------Select Exists mobile------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.Sp_GetExistsMobile')) 
exec('CREATE PROCEDURE [dbo].[Sp_GetExistsMobile] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[Sp_GetExistsMobile] 
 @user_mobieno varchar(50)
 as
begin
begin try
begin transaction
	 Select @user_mobieno from tbl_User where user_mobieno = @user_mobieno;
commit transaction
end try
begin catch
Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
end catch
end
go


----------------------------------------Select Purchase insert------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Purchaseinsert')) 
exec('CREATE PROCEDURE [dbo].[sp_Purchaseinsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_Purchaseinsert] 
@company_id int,
@branch_id int,
@party_id int,
@po_no nvarchar(100),
@Po_Date nvarchar(100),
@total_tax decimal(18,0),
@actual_amount decimal(18, 0),
@grand_total decimal(18, 0),
@discount decimal(18, 0),
@created_by nvarchar(50),
@created_date smalldatetime,
@purchase_id int out


as
 Begin
	 declare @financialyear_id int
	  select @financialyear_id=financialyear_id from tbl_financialyear where company_id=@company_id  and status=1 
	 insert into tbl_purchase (company_id,branch_id,party_id,po_no,financialyear_id,Po_Date,total_tax,discount,actual_amount,grand_total,status,created_by,created_date) 
	 values(@company_id,@branch_id,@party_id,@po_no,@financialyear_id,@Po_Date,@total_tax,@discount,@actual_amount,@grand_total,1,@created_by,@created_date)

	  
	 select @purchase_id=@@IDENTITY
   
   End


go



----------------------------------------Select Purchase Detail insert------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_PurchaseDetailinsert')) 
exec('CREATE PROCEDURE [dbo].[sp_PurchaseDetailinsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_PurchaseDetailinsert] 
@product_id int,
@purchase_id int,
@batch_id int,
@user_id int,
@created_date nvarchar(500),
@tax_amt decimal(18,0),
@dicount_amt decimal(18, 0),
@quantity decimal(18, 0),
@amount decimal(18, 0),
@purchase_rate decimal(18, 0),
@sale_rate decimal(18, 0),
@purchasedetails_id int out


as
 Begin
	 declare 
@tax_id int,
@unit_id int
select @tax_id=tax_id,@unit_id=unit_id from tbl_product where product_id=@product_id 

insert into 
tbl_purchasedetails(purchase_id,product_id,batch_id,tax_id,unit_id,tax_amt,dicount_amt,quantity,amount,purchase_rate,sale_rate,created_by,created_date,status)
              values(@purchase_id,@product_id,@batch_id,@tax_id,@unit_id,@tax_amt,@dicount_amt,@quantity,@amount,@purchase_rate,@sale_rate,@user_id,@created_date,1)
			  select @purchasedetails_id=@@IDENTITY

End
   go

   ----------------------------------------Sales insert------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Salesinsert')) 
exec('CREATE PROCEDURE [dbo].[sp_Salesinsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_Salesinsert] 
@company_id int,
@branch_id int,
@party_id int,
@invoice_no nvarchar(100),
@total_tax decimal(18,0),
@actual_amount decimal(18, 0),
@grand_total decimal(18, 0),
@total_discount decimal(18, 0),
@created_by nvarchar(50),
@created_date smalldatetime,
@sale_id int out

as
 Begin
    Begin Try
     Begin Transaction
	 declare @financialyear_id int
	  select @financialyear_id=financialyear_id from tbl_financialyear where company_id=@company_id and branch_id=@branch_id and status=1 
	 insert into tbl_sale(company_id,branch_id,party_id,invoice_no,financialyear_id,total_tax,total_discount,actual_amount,grand_total,status,created_by,created_date) 
	 values(@company_id,@branch_id,@party_id,@invoice_no,@financialyear_id,@total_tax,@total_discount,@actual_amount,@grand_total,1,@created_by,@created_date)

	 
	 set @sale_id=@@IDENTITY
     Commit Transaction
End Try
Begin Catch 

Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


go



----------------------------------------Sales Detail insert------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SalesDetailinsert')) 
exec('CREATE PROCEDURE [dbo].[sp_SalesDetailinsert] AS BEGIN SET NOCOUNT ON; END') 
GO


Alter procedure[dbo].[sp_SalesDetailinsert] 
@product_id int,
@sale_id int,
@batch_id int,
@user_id int,
@created_date nvarchar(500),
@tax_amt decimal(18,0),
@dicount_amt decimal(18, 0),
@quantity decimal(18, 0),
@amount decimal(18, 0),
@price decimal(18, 0),
@saledetails_id int out


as
 Begin
    
	 declare 
@tax_id int,
@unit_id int
select @tax_id=tax_id,@unit_id=unit_id from tbl_product where product_id=@product_id 

insert into 
tbl_saledetails(sale_id,product_id,batch_id,tax_id,unit_id,tax_amt,dicount_amt,quantity,amount,price,created_by,created_date,status)
              values(@sale_id,@product_id,@batch_id,@tax_id,@unit_id,@tax_amt,@dicount_amt,@quantity,@amount,@price,@user_id,@created_date,1)
    set @saledetails_id=@@IDENTITY
   End


   go

   ----------------------------------------Transaction insert------------------------------------------------------

   
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_InsertTransaction')) 
exec('CREATE PROCEDURE [dbo].[sp_InsertTransaction] AS BEGIN SET NOCOUNT ON; END') 
GO


ALTER procedure[dbo].[sp_InsertTransaction] 
@company_id int,
@branch_id int,
@product_id int,
@bacth_id int,
@in_out varchar(20),
@qty decimal(18, 0),
@transactio_type_id int,
@stocktransaction_typ nvarchar(100),
@created_by nvarchar(50),
@created_date smalldatetime
as
 Begin  
 

		
 ------ For Purchase Stock & Stock Transaction Logic
	
		begin
			IF EXISTS (select * from tbl_stock where product_id=@product_id and company_id=@company_id )
				Begin
				declare @qty1 int
               select @qty1=qty from tbl_stock where product_id=@product_id and company_id=@company_id
			   
				    if(@qty1 is not null)
						begin
							Update tbl_stock set qty= (@qty+@qty1) where product_id=@product_id and company_id=@company_id 
						end

					else
					  begin 
					  set @qty1=0
					  Update tbl_stock set qty=@qty+@qty1 where product_id=@product_id and company_id=@company_id 
					  end
				end
			ELSE 
				 Begin
				insert into tbl_stock(
					company_id,
					 branch_id,
					product_id,
					 batch_id,
					qty,
					status,
					created_by,
					created_date)
				 values 
					(@company_id,
					 @branch_id,
					 @product_id,
					 @bacth_id,
					 @qty,
					 1,
					 @created_by,
					 @created_date)
	 
				
				 end
				 insert into tbl_stocktransaction
						(company_id,
						branch_id,
						stocktransaction_typ,
						product_id,
						batch_id,
						qty,
						in_out,
						status,
						created_by,
						created_date,
						transactio_type_id)
				values (@company_id,
						@branch_id,
						@stocktransaction_typ,
						@product_id,
						@bacth_id,
						@qty,
						@in_out,
						1,
						@created_by,
						@created_date,
						@transactio_type_id)
	
		End
	

 End



   go


    ----------------------------------------Select MonyTransaction insert------------------------------------------------------

	IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_InsertMonyTransaction')) 
exec('CREATE PROCEDURE [dbo].[sp_InsertMonyTransaction] AS BEGIN SET NOCOUNT ON; END') 
GO


ALTER procedure[dbo].[sp_InsertMonyTransaction] 
@company_id int,
@branch_id int,
@party_id int,
@given_amt decimal(18, 0),
@grand_total decimal(18, 0),
@balance_amt decimal(18, 0),
@in_out varchar(20),
@paymentmode_id int,
@transaction_typ nvarchar(100),
@transactio_type_id int,
@created_by nvarchar(50),
@created_date smalldatetime
as
 Begin   
			insert into tbl_monytransaction(
						company_id,
						branch_id,
						transaction_typ,
						paymentmode_id,
						total_bil_amt,
						given_amt,
						balance_amt,
						in_out,
						status,
						party_id,
						transactio_type_id,
						created_by,
						created_date)
				values(
						@company_id,
						@branch_id,
						@transaction_typ,
						@paymentmode_id,
						@grand_total,
						@given_amt,
						@balance_amt,
						@in_out
						,1,
						@party_id,
						@transactio_type_id,
						@created_by,
						@created_date)

						---Mony Logic-----
						 declare @reciveableamt decimal(18, 0)= 0
											,@payableamt decimal(18, 0)= 0
								 	IF NOT EXISTS (SELECT * FROM tbl_mony where party_id=@party_id and company_id=@company_id)
										   begin
										     	if(@in_out='in')
													 begin 
														set @reciveableamt=@balance_amt
													 end
												else
													  begin
														set @payableamt=@balance_amt
													  end
										            
												 insert into tbl_mony(company_id,branch_id,party_id,payableamt,reciveableamt,status,created_by,created_date)
												 values(@company_id,@branch_id,@party_id,@payableamt,@reciveableamt,1,@created_by,@created_date)
											 end
									else
										   begin

										   if(@balance_amt>0)
												 begin
														select @reciveableamt=reciveableamt,@payableamt=payableamt from tbl_mony 
														where company_id=@company_id and party_id=@party_id

													if(@in_out='in')
														 	 	 begin 
												set	@reciveableamt=@balance_amt+@reciveableamt
													 end
													else
														  	  	  begin
												set	  @payableamt=@balance_amt+@payableamt
													  end
													IF(@payableamt>@reciveableamt)
														 begin
														set	@payableamt=@payableamt-@reciveableamt
													set		@reciveableamt=0
														 end
													else
													     begin
													set	   @reciveableamt=@reciveableamt-@payableamt
												set		   @payableamt=0
														 end
														update tbl_mony set payableamt=@payableamt,reciveableamt=@reciveableamt,
														modified_by=@created_by,modified_date=@created_date
													    where party_id=@party_id and company_id=@company_id
												  end
											end
						

					
    end

 

   go

      ----------------------------------------Select Sales Transaction insert------------------------------------------------------

   IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_InsertSaleTransaction')) 
exec('CREATE PROCEDURE [dbo].[sp_InsertSaleTransaction] AS BEGIN SET NOCOUNT ON; END') 
GO


ALTER procedure[dbo].[sp_InsertSaleTransaction] 
@company_id int,
@branch_id int,
@product_id int,
@bacth_id int,
@in_out varchar(20),
@qty decimal(18, 0),
@transactio_type_id int,
@stocktransaction_typ nvarchar(100),
@created_by nvarchar(50),
@created_date smalldatetime
as
 Begin  
 ------ For Sale Stock & Stock Transaction Logic
   
       
         IF EXISTS (select * from tbl_stock where product_id=@product_id and company_id=@company_id and branch_id=@branch_id )
           Begin
             declare @qty1 int
               select @qty1=qty from tbl_stock where product_id=@product_id and company_id=@company_id and branch_id=@branch_id 
               Update tbl_stock set qty=@qty1-@qty where product_id=@product_id and company_id=@company_id and branch_id=@branch_id
           end
         ELSE 

          Begin
	         insert into tbl_stock(
	           company_id,
	           branch_id,
	           product_id,
	           batch_id,
	           qty,
	           status,
	           created_by,
			   created_date)
			 values 
			   (@company_id,
			    @branch_id,
				@product_id,
				@bacth_id,
				@qty,
				1,
				@created_by,
				 @created_date)
	
			
		End
		insert into tbl_stocktransaction
				(company_id,
				branch_id,
				stocktransaction_typ,
				product_id,
				batch_id,
				qty,
				in_out,
				status,
				created_by,
				created_date,
				transactio_type_id)
			values (@company_id,
				@branch_id,
				@stocktransaction_typ,
				@product_id,
				@bacth_id,
				@qty,
				@in_out,
				1,
				@created_by,
				@created_date,
				@transactio_type_id)
End

	GO
	
	----------------------------------------Select PRICE------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectPrice')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectPrice] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_SelectPrice]
@company_id int,
@product_id int
 as
 begin
 begin try
 begin transaction

 Select purchas_price,sales_price  from tbl_product where product_id=@product_id and company_id=@company_id 
 
 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	

  	----------------------------------------Check User------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_checkuser')) 
exec('CREATE PROCEDURE [dbo].[sp_checkuser] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_checkuser] 
  @user_Emai nvarchar(50)
 as
 begin
 begin try
 begin transaction

 Select user_Emai from tbl_User where user_Emai=@user_Emai
 
 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

    	----------------------------------------Check User Mobile No------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_checkusermobil')) 
exec('CREATE PROCEDURE [dbo].[sp_checkusermobil] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_checkusermobil] 
  @user_mobieno nvarchar(50)
 as
 begin
 begin try
 begin transaction

 Select user_mobieno from tbl_User where user_mobieno=@user_mobieno
 
 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

  ------------------------------------------------Purchase report-----------------------------------------


  IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectPurchase')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectPurchase] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectPurchase] 
 @company_id int
 as
 begin
 begin try
 begin transaction
   select tbl_purchase.purchase_id,tbl_purchase.party_id,tbl_purchase.po_no,tbl_purchase.grand_total,(CONVERT(nvarchar,tbl_purchase.created_date, 101)) as Date,
tbl_party.party_name from tbl_purchase left join tbl_party on tbl_party.party_id=tbl_purchase.party_id
where tbl_purchase.company_id=@company_id and tbl_purchase.status=1 order by tbl_purchase.purchase_id DESC  
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go

   ------------------------------------------------ sp_SelectSalesReport-----------------------------------------


  IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectSalesReport')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectSalesReport] AS BEGIN SET NOCOUNT ON; END') 
GO

   Alter PROCEDURE [dbo].[sp_SelectSalesReport] 

 @company_id int,
 @partyid int,
 @invoiceno varchar(100),
 @fromdate smalldatetime,
 @enddate smalldatetime
 as
 begin
  DECLARE @bothdateflag int  
if (@partyid = 0 OR @partyid = null)
begin
 set @partyid = null
end	
if (@invoiceno = '' OR @invoiceno = null)
begin
 set @invoiceno = null
end	
if (@fromdate = '' OR @fromdate = null)
begin
 set @fromdate = null
end	
if (@enddate = '' OR @enddate = null)
begin
 set @enddate = null
end	
if((@fromdate != '' OR @fromdate != null) and (@enddate != '' OR @enddate != null))
begin
 set @bothdateflag = 0
end	
  else
    begin
	set @bothdateflag =1
	end
	if(@bothdateflag=0)
	begin
		  SELECT s.sale_id,p.party_id,p.party_name as [customerName],s.invoice_no,s.grand_total,CONVERT(varchar(20), s.created_date,101) as [date]
		  FROM tbl_sale s 
		  JOIN tbl_party p on s.party_id = p.party_id 
		  where s.company_id=@company_id and s.status=1
		  And (@partyid is Null or s.party_id=@partyid)
		  And (@invoiceno is Null or s.invoice_no = @invoiceno)
		  And (@bothdateflag =1  or s.created_date >= @fromdate and s.created_date <= @enddate)
		 
	end
	else
	  begin 
			SELECT s.sale_id,p.party_id,p.party_name as [customerName],s.invoice_no,s.grand_total,CONVERT(varchar(20), s.created_date,101) as [date]
			  FROM tbl_sale s 
			  JOIN tbl_party p on s.party_id = p.party_id 
			  where s.company_id=@company_id and s.status=1
			  And (@partyid is Null or s.party_id=@partyid)
			  And (@invoiceno is Null or s.invoice_no = @invoiceno)
			  And (@fromdate is Null or s.created_date >= @fromdate)
			  And (@enddate is Null or s.created_date <= @enddate)
	  end
  end
go
    ------------------------------------------------ Select Purchase Invoice-----------------------------------------


  IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectPurchaseinvoice')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectPurchaseinvoice] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectPurchaseinvoice] 
 @company_id int,
 @party_id int ,
 @purchase_id int,
 @start_date datetime ,
 @end_date datetime 
AS
 BEGIN
  Begin try
    begin transaction
			 DECLARE @start_dateFLAG int                
			 DECLARE @end_dateFLAG int
			 DECLARE @party_idFLAG int                
			 DECLARE @purchaseFLAG int   
			 DECLARE @bothdateflag int   
  
					if (@party_id is null or @party_id = 0)                 
						BEGIN                
							set @party_idFLAG = 1                
						END                
					else                
						BEGIN                
							set @party_idFLAG = 0                
						END  
			  
					if (@purchase_id is null or @purchase_id = 0)                 
						BEGIN                
							set @purchaseFLAG = 1                
						END                
					else                
						BEGIN                
							set @purchaseFLAG = 0                
						END              
                        
					if (@start_date is null or @start_date = '')                
						BEGIN                
							set @start_dateFLAG =1                 
						END                
					else                
						BEGIN                
							set @start_dateFLAG =0                
						END                
                            
					if (@end_date is null or @end_date = '' )                
						BEGIN                
							set @end_dateFLAG =1                 
						END                
					else                
						BEGIN                
							set @end_dateFLAG =0                
						END 
                    
				    if (@start_dateFLAG = 0 and @end_dateFLAG = 0)
						begin
							set @bothdateflag = 0
						end
						else
						begin
							set @bothdateflag = 1
						end
        
		if (@bothdateflag = 0)
		Begin
					select tbl_purchase.purchase_id,tbl_purchase.party_id,tbl_purchase.po_no,tbl_purchase.grand_total,(CONVERT(nvarchar,tbl_purchase.created_date, 101)) as Date,
								tbl_party.party_name from tbl_purchase left join tbl_party on tbl_party.party_id=tbl_purchase.party_id
								where
								 (tbl_purchase.company_id=@company_id and tbl_purchase.status=1) 
								 and (@purchaseFLAG=1 or tbl_purchase.purchase_id=@purchase_id) 
								 and(@party_idFLAG=1 or tbl_purchase.party_id=@party_id)
								 and(@bothdateflag=1 or tbl_purchase.created_date > = @start_date and tbl_purchase.created_date <= @end_date)
								 --and(@end_dateFLAG=1 or (CONVERT(nvarchar,tbl_purchase.created_date, 101))=@end_date))
								 order by tbl_purchase.purchase_id DESC
	    end
		else
		Begin
				select tbl_purchase.purchase_id,tbl_purchase.party_id,tbl_purchase.po_no,tbl_purchase.grand_total,(CONVERT(nvarchar,tbl_purchase.created_date, 101)) as Date,
								tbl_party.party_name from tbl_purchase left join tbl_party on tbl_party.party_id=tbl_purchase.party_id
								where
								 ((tbl_purchase.company_id=@company_id and tbl_purchase.status=1) 
								 and (@purchaseFLAG=1 or tbl_purchase.purchase_id=@purchase_id) 
								 and(@party_idFLAG=1 or tbl_purchase.party_id=@party_id)
								 and(@start_dateFLAG=1 or (CONVERT(nvarchar,tbl_purchase.created_date, 101))=@start_date)
								 and(@end_dateFLAG=1 or (CONVERT(nvarchar,tbl_purchase.created_date, 101))=@end_date))
								  order by tbl_purchase.purchase_id DESC			
		End
          commit transaction
	 end try
	 begin catch
		  Rollback Transaction
				insert into tbl_error_log(error_type,error_msg)
				 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
	end catch
  end

  	----------------------------------------Select sp_SelectPurchaseinvoicebyid------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectPurchaseinvoicebyid')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectPurchaseinvoicebyid] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_SelectPurchaseinvoicebyid] 
@purchsae_id int,
@company_id int

 as
 begin
 begin try
 begin transaction

 select p.party_id,p.actual_amount, (CONVERT(nvarchar,p.created_date, 101)) as Date,p.discount,
p.po_no,p.grand_total,p.total_tax,
py.party_name,mony.balance_amt,mony.given_amt
 from (( tbl_purchase as p
inner  join tbl_party as py on py.party_id=p.party_id)inner join tbl_monytransaction as mony on mony.transactio_type_id=p.purchase_id )
where  p.purchase_id=@purchsae_id and  p.company_id=@company_id and p.status=1
 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	
  	----------------------------------------Select Purchase products by purchase_id------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectProductbyid')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectProductbyid] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_SelectProductbyid] 

@purchsae_id int

 as
 begin
 begin try
 begin transaction

 select
 pd.purchasedetails_id,
pd.product_id,pd.batch_id,pd.unit_id,pd.tax_id,
pd.amount,pd.dicount_amt,pd.tax_amt,pd.purchase_rate,
pd.sale_rate,pd.quantity,
pt.product_name,
u.unit_name,
b.batch_name,
t.tax_percentage from (((( tbl_purchasedetails as pd
inner join tbl_product as pt on pt.product_id=pd.product_id)
inner join tbl_unit as u  on u.unit_id=pd.unit_id)
inner  join tbl_batch as b on b.batch_id=pd.batch_id)
inner  join tbl_tax as t on t.tax_id=pd.tax_id)
where pd.purchase_id=@purchsae_id and pd.status=1
 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	
   

     	----------------------------------------Select sp_SelectFinicialyeardate------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectFinicialyeardate')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectFinicialyeardate] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_SelectFinicialyeardate] 


@company_id int

 as
 begin
 begin try
 begin transaction

select start_date,end_date from tbl_financialyear where company_id=@company_id and status=1
 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	

  	----------------------------------------Select sp_Selectquantity------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Selectquantity')) 
exec('CREATE PROCEDURE [dbo].[sp_Selectquantity] AS BEGIN SET NOCOUNT ON; END') 
GO
<<<<<<< .mine
  ALTER PROCEDURE [dbo].[sp_Selectquantity]
=======
  ALTER PROCEDURE [dbo].[sp_Selectquantity] 


>>>>>>> .r157
@company_id int,
@product_id int

 as
 begin
 begin try
 begin transaction

select qty from tbl_stock where company_id=@company_id and product_id= @product_id

  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
  
  ----------------------------------------Select sp_Selectsaleid------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Selectsaleid')) 
exec('CREATE PROCEDURE [dbo].[sp_Selectsaleid] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_Selectsaleid] 




 as
 begin
 begin try
 begin transaction

 SELECT max(sale_id) as order_id FROM tbl_sale

 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
  
  
  	----------------------------------------Select sp_DeletePurchasedetailbyreutrn------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeletePurchasedetailbyreutrn')) 
exec('CREATE PROCEDURE [dbo].[sp_DeletePurchasedetailbyreutrn] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_DeletePurchasedetailbyreutrn] 



@purchase_id int,
@purchasedetails_id int
 as
 begin
 begin try
 begin transaction

update tbl_purchasedetails set status=0 where purchase_id=@purchase_id and purchasedetails_id=@purchasedetails_id 


 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	
  
   ----------------------------------------Select sp_insert into purchase_return------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_insert_purchase_return')) 
exec('CREATE PROCEDURE [dbo].[sp_insert_purchase_return] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_insert_purchase_return] 

@purchase_id int,
@purchasedetails_id int,
@batch_id int,
@product_id int,
@tax_amt decimal(18, 0),
@quantity decimal(18, 0),
@amount	decimal(18, 0),
@created_by nvarchar(50),
@created_date nvarchar(50)


 as
 begin
 begin try
 begin transaction

 declare 
 
@unit_id int,
@tax_id int,
@transactio_type_id int,
@qty1 decimal(18, 0),
@company_id int,
@branch_id int ,
@quanty decimal(18, 0),
@quanty1 decimal(18, 0)
			select      @unit_id=unit_id,@tax_id=tax_id from tbl_product where product_id=@product_id 
			select      @quanty1=quantity from tbl_purchasedetails where purchasedetails_id=@purchasedetails_id and product_id=@product_id 
			insert into tbl_purchasereturn (purchase_id,batch_id,product_id,unit_id,tax_id,tax_amt,quantity,amount,status,created_by,created_date)
            values		(@purchase_id,@batch_id,@product_id,@unit_id,@tax_id,@tax_amt,(@quanty1-@quantity),@amount,1,@created_by,@created_date)
		
			select		@transactio_type_id=@@IDENTITY
		
			select		@qty1=qty from tbl_stock where product_id=@product_id 
			update		 tbl_stock set qty=@qty1-(@quanty1-@quantity) 
			where		 product_id=@product_id 
			select      @quanty=quantity from tbl_purchasereturn where purchasereturn_id=@transactio_type_id
			select		@company_id=company_id, @branch_id=branch_id from tbl_product where product_id=@product_id
		    insert into tbl_stocktransaction
													(company_id,
													branch_id,
													stocktransaction_typ,
													product_id,
													batch_id,
													qty,
													in_out,
													status,
													created_by,
													created_date,
													transactio_type_id
													) 
											values (@company_id,
													@branch_id,
													'Purchase Return',
													@product_id,
													@batch_id,
													(@quanty-@quantity),
													'out',
													1,
													@created_by,
													@created_date,
													@transactio_type_id)

 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	

     ----------------------------------------Select sp_UpdatePurchase------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdatePurchase')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdatePurchase] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_UpdatePurchase] 

@purchase_id int,
@count int,
@company_id int,
@party_id int,
@po_no nvarchar(100),
@total_tax decimal(18,0),
@actual_amount decimal(18, 0),
@grand_total decimal(18, 0),
@discount decimal(18, 0),
@modified_by nvarchar(50),
@modifie_date nvarchar(50)


 as
 begin
 begin try
 begin transaction
 IF(@count!=0)
	begin
		 update tbl_purchase set po_no=@po_no,total_tax=@total_tax,actual_amount=@actual_amount
		 ,discount=@discount,grand_total=@grand_total,modified_by=@modified_by,modified_date=@modifie_date
		 where purchase_id=@purchase_id and company_id=@company_id
    end
 else
    begin
      update tbl_purchase set status=0 where purchase_id=@purchase_id and company_id=@company_id
     end
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	

       ----------------------------------------Select sp_UpdatePurchasedetails------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdatePurchasedetails')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdatePurchasedetails] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_UpdatePurchasedetails]
   
@purchasedetails_id int,
@product_id int,
@purchase_id int,
@batch_id int,
@tax_amt decimal(18,0),
@dicount_amt decimal(18, 0),
@quantity decimal(18, 0),
@amount decimal(18, 0),
@purchase_rate decimal(18, 0),
@sale_rate decimal(18, 0),
@modified_by nvarchar(50),
@modifie_date nvarchar(50)


 as
 begin
 begin try
 begin transaction
			
		 update tbl_purchasedetails set product_id=@product_id,batch_id=@batch_id,tax_amt=@tax_amt,dicount_amt=@dicount_amt,
		 quantity=@quantity,amount=@amount,purchase_rate=@purchase_rate,sale_rate=@sale_rate ,modified_by=@modified_by
		 ,modified_date=@modifie_date where purchase_id=@purchase_id and purchasedetails_id=@purchasedetails_id

		 
   
    commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end

  go	

   ----------------------------------------Select sp_product_relorderlevel_report_companybranch------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_product_relorderlevel_report_companybranch')) 
exec('CREATE PROCEDURE [dbo].[sp_product_relorderlevel_report_companybranch] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER PROCEDURE [dbo].[sp_product_relorderlevel_report_companybranch]  
@company_id int,
@branch_id int 
as
begin
	Select s.stock_id, s.batch_id, p.product_id,p.product_name,p.hsn_code,p.product_code,p.reorder_level as [Reorderlevel], s.qty as [quantity] from tbl_product p
	join tbl_stock s on s.product_id = p.product_id
	where p.company_id = @company_id and p.branch_id = @branch_id and p.status = 1 and s.status = 1
	and s.qty < p.reorder_level
end

go
----------------------------------------Select sp_product_relorderlevel_report_forcompany_only------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_product_relorderlevel_report_forcompany_only')) 
exec('CREATE PROCEDURE [dbo].[sp_product_relorderlevel_report_forcompany_only] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER PROCEDURE [dbo].[sp_product_relorderlevel_report_forcompany_only]  
@company_id int
as
begin
	Select s.stock_id, s.batch_id, p.product_id,p.product_name,p.hsn_code,p.product_code,p.reorder_level as [Reorderlevel], s.qty as [quantity] from tbl_product p
	join tbl_stock s on s.product_id = p.product_id
	where p.company_id = @company_id and p.status = 1 and s.status = 1
	and s.qty < p.reorder_level
end


  go	

    ----------------------------------------Select sp_Updatestockquantity------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Updatestockquantity')) 
exec('CREATE PROCEDURE [dbo].[sp_Updatestockquantity] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_Updatestockquantity] 

@product_id int,
@quantity int,
@company_id int


 as
 begin
 begin try
 begin transaction
 update tbl_stock set qty=qty-@quantity where company_id=@company_id and product_id=@product_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	



  ---------------------------------------- sp_SelectSaleinvoice------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectSaleinvoice')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectSaleinvoice] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_SelectSaleinvoice] 

@sale_id int,
@company_id int

 as
 begin
 begin try
 begin transaction

 select p.party_id,p.actual_amount, (CONVERT(nvarchar,p.created_date, 101)) as Date,p.total_discount,
p.invoice_no,p.grand_total,p.total_tax,
py.party_name,mony.balance_amt,mony.given_amt
 from (( tbl_sale as p
inner  join tbl_party as py on py.party_id=p.party_id)inner join tbl_monytransaction as mony on mony.transactio_type_id=p.sale_id )
where  p.sale_id=@sale_id and  p.company_id=@company_id and p.status=1
 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	
  	----------------------------------------sp_Selectsaleproduct-----------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Selectsaleproduct')) 
exec('CREATE PROCEDURE [dbo].[sp_Selectsaleproduct] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_Selectsaleproduct] 

@sale_id int

 as
 begin
 begin try
 begin transaction

 select
 pd.saledetails_id,
pd.product_id,pd.batch_id,pd.unit_id,pd.tax_id,
pd.amount,pd.dicount_amt,pd.tax_amt,
pd.price,pd.quantity,
pt.product_name,
u.unit_name,
b.batch_name,
t.tax_percentage from (((( tbl_saledetails as pd
inner join tbl_product as pt on pt.product_id=pd.product_id)
inner join tbl_unit as u  on u.unit_id=pd.unit_id)
inner  join tbl_batch as b on b.batch_id=pd.batch_id)
inner  join tbl_tax as t on t.tax_id=pd.tax_id)
where pd.sale_id=@sale_id and pd.status=1
 
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go
  
     ----------------------------------------sp_salereturn ------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_salereturn')) 
exec('CREATE PROCEDURE [dbo].[sp_salereturn] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_salereturn] 

@sale_id int,
@saledetails_id int,
@product_id int,
@batch_id int,
@tax_amt decimal(18,0),
@dicount_amt decimal(18, 0),
@quantity int,
@amount decimal(18, 0),
@price decimal(18, 0),
@created_by nvarchar(50),
@created_date nvarchar(50)


 as
 begin
 begin try
 begin transaction
 declare @unit_id int,@tax_id int,@qty1 decimal(18,0)
 

        select       @unit_id=unit_id , @tax_id=tax_id  
		from         tbl_product
		where        product_id=@product_id
		select      @qty1=quantity from tbl_saledetails where saledetails_id=@saledetails_id and product_id=@product_id 
		insert into  tbl_salesreturn(sale_id,batch_id,product_id,unit_id,tax_id,tax_amt,quantity,amount,status,created_by,created_date)
		values		 (@sale_id,@batch_id,@product_id,@unit_id,@tax_id,@tax_amt,(@qty1-@quantity),@amount,1,@created_by,@created_date)
		
		declare		 @transactio_type_id int,@qty12 decimal(18,0), @company_id int,@branch_id int 
		
		select		 @transactio_type_id=@@IDENTITY
		
		select	     @qty12=qty from tbl_stock where product_id=@product_id 
		
		update		 tbl_stock set qty=@qty12+@quantity
		where		 product_id=@product_id 
		
		select		 @company_id=company_id, @branch_id=branch_id from tbl_product where product_id=@product_id
		
		insert into  tbl_stocktransaction
					 (company_id,
					 branch_id,
					 stocktransaction_typ,
					 product_id,
					 batch_id,
					 qty,
					 in_out,
					 status,
					 created_by,
					created_date,
					transactio_type_id
					) 
		values	    (@company_id,
					 @branch_id,
					 'Sale Return',
					 @product_id,
					 @batch_id,
					(@qty1-@quantity),
					 'IN',
					 1,
					 @created_by,
					 @created_date,
					 @transactio_type_id
					)

  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	
	
	   ----------------------------------------Select sp_UpdateSale------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateSale')) 
exec('CREATE PROCEDURE [dbo].[sp_UpdateSale] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_UpdateSale] 

@sale_id int,
@count int,
@company_id int,
@party_id int,
@invoice_no nvarchar(100),
@total_tax decimal(18,0),
@actual_amount decimal(18, 0),
@grand_total decimal(18, 0),
@discount decimal(18, 0),
@modified_by nvarchar(50),
@modifie_date nvarchar(50)


 as
 begin
 begin try
 begin transaction
 IF(@count!=0)
	begin
		 update tbl_sale set invoice_no=@invoice_no,total_tax=@total_tax,actual_amount=@actual_amount
		 ,total_discount=@discount,grand_total=@grand_total,modified_by=@modified_by,modified_date=@modifie_date
		 where sale_id=@sale_id and company_id=@company_id
    end
 else
    begin
      update tbl_sale set status=0 where sale_id=@sale_id and company_id=@company_id
     end
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go	

       ----------------------------------------Select sp_Updatesaledetail------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Updatesaledetail')) 
exec('CREATE PROCEDURE [dbo].[sp_Updatesaledetail] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_Updatesaledetail] 
   
@saledetails_id int,
@product_id int,
@sale_id int,
@batch_id int,
@tax_amt decimal(18,0),
@dicount_amt decimal(18, 0),
@quantity decimal(18, 0),
@amount decimal(18, 0),
@price decimal(18, 0),
@modified_by nvarchar(50),
@modifie_date nvarchar(50)


 as
 begin
	 
	update      tbl_saledetails
	 set        batch_id=@batch_id,product_id=@product_id,tax_amt=@tax_amt,dicount_amt=@dicount_amt,
		        quantity=@quantity,amount=@amount,price=@price,modified_by=@modified_by,modified_date=@modifie_date
    where       sale_id=@sale_id and saledetails_id=@saledetails_id
		
  end
  
  go	

   ----------------------------------------Select Branchname------------------------------------------------------

	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectBranchName')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectBranchName] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectBranchName] 
 @company_id int,
 @value nvarchar(50)
 as
 begin
 begin try
 begin transaction
  select branch_name from tbl_branch where company_id=@company_id and branch_name=@value
  commit transaction
  end try
  begin catch

  end catch
  end
  go

  
       ----------------------------------------Select sp_deleteSladetail------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_deleteSladetail')) 
exec('CREATE PROCEDURE [dbo].[sp_deleteSladetail] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_deleteSladetail]
   
@sale_id int,
@saledetails_id int


 as
 begin
 begin try
 begin transaction

		update tbl_saledetails set status=0 where sale_id=@sale_id and saledetails_id=@saledetails_id

		 
   
    commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
  go


-- this sp is get all information related to dashboard
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_dashboarddata')) 
exec('CREATE PROCEDURE [dbo].[sp_dashboarddata] AS BEGIN SET NOCOUNT ON; END') 
GO
ALter Procedure [sp_dashboarddata]
@conpanyid int
as
begin

	select count(purchase_id) as [TotalPurchaseOrder], sum(grand_total) as [TotalAmountofPurchase] 
	from tbl_purchase 
	where created_date between Getdate() - 30 and Getdate() and status = 1
	and company_id = @conpanyid
	
	select count(sale_id) as [TotalSalesOrder], sum(grand_total) as [TotalAmountofSale] 
	from tbl_sale 
	where created_date between Getdate() - 30 and Getdate() and status = 1
	and company_id = @conpanyid

	select top 10 p.product_name, count(sd.product_id) as [ProductCount], sd.product_id as [ProductID], sum(sd.amount) as [TotalSaleAmount] 
	from tbl_saledetails sd
	join tbl_product p on p.product_id = sd.product_id  
	where sd.created_date between DATEADD(day,-30, getdate()) and getdate()
	and company_id = @conpanyid
	group by sd.product_id, p.product_name
	order by count(sd.product_id) desc

	select COUNT(party_id) as [Total Count], party_type from tbl_party
	where company_id = @conpanyid and party_type in ('Vendor','Customer')
	group by party_type

end
  go	

-------------------------------- [sp_ActiveUser] ------------------------------------------------------


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_ActiveUser')) 
exec('CREATE PROCEDURE [dbo].[sp_ActiveUser] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_ActiveUser]
@userid int,
@uniqueid nvarchar(max)

as
 Begin
    Begin Try
     Begin Transaction

		UPDATE Tbl_EmailVerify set status=1 where user_id=@userid and uniqueidentifier = @uniqueid

		SELECT user_id,USER_NAME,first_name,last_name FROM tbl_User WHERE user_id=@userid
Commit Transaction
	End Try
	Begin Catch 
	Rollback Transaction
		insert into tbl_error_log(error_type,error_msg)
		values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
	End Catch 
End


go
 ----------------------------------------Select Party------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_partyprint')) 
exec('CREATE PROCEDURE [dbo].[sp_partyprint] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_partyprint] 
 @company_id int
 ,@branch_id int,
 @party_id int,
 @party_type nvarchar(50)
 as
 begin
  select party_name,party_address,contact_no from tbl_party where company_id=@company_id 
  and party_id=@party_id and party_type=@party_type
 
  end
  go

   ----------------------------------------Select batch by product------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_selectbatchbyproduct')) 
exec('CREATE PROCEDURE [dbo].[sp_selectbatchbyproduct] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_selectbatchbyproduct] 
 @company_id int
 ,@branch_id int,
 @product_id int
 as
 begin
 select distinct p.batch_id,b.batch_name from tbl_purchasedetails p
join tbl_batch b on p.batch_id = b.batch_id
where p.product_id = @product_id and b.company_id=@company_id and b.branch_id=@branch_id order by batch_id
 
  end

  go
----------------------------------------Reset Password Request------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.Sp_InsertResetPass')) 
exec('CREATE PROCEDURE [dbo].[Sp_InsertResetPass] AS BEGIN SET NOCOUNT ON; END') 
GO
-- Created By :- AL hamed Mohammed
--Created Date :- 28/03/2018
--Perpose :- For Insert in Tbl_VerifyResetPass and get details of User by UserEmail

Alter PROCEDURE [dbo].[Sp_InsertResetPass] 
 @email varchar(50),
 @uniqueid varchar(max),
 @created_date smalldatetime
as
 Begin
    Begin Try
     Begin Transaction

		declare @userid int
		if Exists (Select user_Emai from tbl_User where user_Emai = @email)
		Begin
			 Select @userid = user_id from tbl_User where user_Emai = @email;
	
			Insert Into Tbl_VerifyResetPass ([user_id],[uniqueidentifier],[created_date],[status])
			Values (@userid,@uniqueid,@created_date,1)

				select top 1 u.first_name +' '+ u.last_name AS [username],u.user_id,vr.uniqueidentifier,vr.status,vr.Passverify_ID from tbl_User u join Tbl_VerifyResetPass vr on vr.user_id=u.user_id
				 where u.user_id = @userid order by Passverify_ID desc;
		END
		Else
		Begin
			Select 'This Email is not register with IMSbizz' 
		End
Commit Transaction
	End Try
	Begin Catch 
	Rollback Transaction
		insert into tbl_error_log(error_type,error_msg)
		values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
	End Catch 
End
GO
----------------------------------------Update Password------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.Sp_UpdatePassword')) 
exec('CREATE PROCEDURE [dbo].[Sp_UpdatePassword] AS BEGIN SET NOCOUNT ON; END') 
GO
-- Created By :- AL hamed Mohammed
--Created Date :- 04/04/2018
--Perpose :- For Updating new password

Alter PROCEDURE [dbo].[Sp_UpdatePassword] 
 @userid int ,
 @uniqueid varchar(max),
 @modify_date smalldatetime,
 @newpwd varchar(max),
 @pid int
as
 Begin
  

		
			UPDATE Tbl_VerifyResetPass SET status=0 WHERE user_id=@userid And Passverify_ID=@pid And uniqueidentifier = @uniqueid 
	
			UPDATE tbl_User SET password=@newpwd,modified_by=@userid,modified_date=@modify_date WHERE user_id=@userid 
			

	
End
go
 ----------------------------------------Select Exists Mobile------------------------------------------------------
 IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.SpGetExistsMobile')) 
exec('CREATE PROCEDURE [dbo].[SpGetExistsMobile] AS BEGIN SET NOCOUNT ON; END') 
GO
-- Created By :- AL hamed Mohammed
--Created Date :- 22/03/2018
--Perpose :- For get exists Mobile
Alter PROCEDURE [dbo].[SpGetExistsMobile] 
 @mobileno varchar(50)
 as
begin
	 Select  user_mobieno from tbl_User where user_mobieno = @mobileno;
end

GO
----------------------------------------Check reset password link------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.Sp_checkResetPwdlink')) 
exec('CREATE PROCEDURE [dbo].[Sp_checkResetPwdlink] AS BEGIN SET NOCOUNT ON; END') 
GO
-- Created By :- AL hamed Mohammed
--Created Date :- 04/04/2018
--Perpose :- For Updating new password

Alter PROCEDURE [dbo].[Sp_checkResetPwdlink] 
@userid int,
 @uniqueid varchar(max),
 @pid int
as
 Begin
    Begin Try
     Begin Transaction
		
			select * from Tbl_VerifyResetPass where user_id=@userid And Passverify_ID = @pid And uniqueidentifier=@uniqueid 
			
Commit Transaction
	End Try
	Begin Catch 
	Rollback Transaction
		insert into tbl_error_log(error_type,error_msg)
		values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
	End Catch 
End


  go

   ----------------------------------------sp_insertpurchasereturnmain------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_insertpurchasereturnmain')) 
exec('CREATE PROCEDURE [dbo].[sp_insertpurchasereturnmain] AS BEGIN SET NOCOUNT ON; END') 
GO

 ALTER procedure[dbo].[sp_insertpurchasereturnmain] 
@company_id int,
@branch_id int,
@purchase_id int,
@total_tax decimal(18,0),
@actual_amount decimal(18, 0),
@grand_total decimal(18, 0),
@total_discount decimal(18, 0),
@created_by nvarchar(50),
@created_date smalldatetime,
@purchasereturnmain_id int out

as
 Begin
 
	 declare @financialyear_id int
	  select @financialyear_id=financialyear_id from tbl_financialyear where company_id=@company_id and status=1 
	 insert into tbl_purchasereturnmain(company_id,branch_id,purchase_id,financialyear_id,total_tax,total_discount,actual_amount,grand_total,status,created_by,created_date) 
	 values(@company_id,@branch_id,@purchase_id,@financialyear_id,@total_tax,@total_discount,@actual_amount,@grand_total,1,@created_by,@created_date)

	 
	 set @purchasereturnmain_id=@@IDENTITY
   
   End


go

   ----------------------------------------sp_insertsalreturnmain------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_insertsalreturnmain')) 
exec('CREATE PROCEDURE [dbo].[sp_insertsalreturnmain] AS BEGIN SET NOCOUNT ON; END') 
GO

 ALTER procedure[dbo].[sp_insertsalreturnmain] 
@company_id int,
@branch_id int,
@sale_id int,
@total_tax decimal(18,0),
@actual_amount decimal(18, 0),
@grand_total decimal(18, 0),
@total_discount decimal(18, 0),
@created_by nvarchar(50),
@created_date smalldatetime,
@salereturnmain_id int out

as
 Begin
 
	 declare @financialyear_id int
	  select @financialyear_id=financialyear_id from tbl_financialyear where company_id=@company_id and branch_id=@branch_id and status=1 
	 insert into tbl_salereturnmain(company_id,branch_id,sale_id,financialyear_id,total_tax,total_discount,actual_amount,grand_total,status,created_by,created_date) 
	 values(@company_id,@branch_id,@sale_id,@financialyear_id,@total_tax,@total_discount,@actual_amount,@grand_total,1,@created_by,@created_date)

	 
	 set @salereturnmain_id=@@IDENTITY
   
   End


go

   ----------------------------------------sp_selectspurchaseproduct------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_selectspurchaseproduct')) 
exec('CREATE PROCEDURE [dbo].[sp_selectspurchaseproduct] AS BEGIN SET NOCOUNT ON; END') 
GO

 ALTER procedure[dbo].[sp_selectspurchaseproduct] 
@purchase_id int

as
 Begin
 
	select ps.product_id,p.product_name from tbl_purchasedetails as ps
	 inner join tbl_product as p on p.product_id=ps.product_id where purchase_id=@purchase_id
   
   End


go

 ----------------------------------------sp_selectpurchasebatch------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_selectpurchasebatch')) 
exec('CREATE PROCEDURE [dbo].[sp_selectpurchasebatch] AS BEGIN SET NOCOUNT ON; END') 
GO

 ALTER procedure[dbo].[sp_selectpurchasebatch] 
@purchase_id int,
@product_id int

as
 Begin
 
	select ps.batch_id,b.batch_name from tbl_purchasedetails as ps 
	inner join tbl_batch as b on b.batch_id=ps.batch_id where purchase_id=@purchase_id and product_id=@product_id

   
   End


go

 ----------------------------------------sp_selectbatchwisequantity------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_selectbatchwisequantity')) 
exec('CREATE PROCEDURE [dbo].[sp_selectbatchwisequantity] AS BEGIN SET NOCOUNT ON; END') 
GO

 ALTER procedure[dbo].[sp_selectbatchwisequantity] 
@batch_id int,
@product_id int

as
 Begin
 
	;with result as (
						select batch_id, 
						  case when in_out = 'in' then sum(qty) 
						   else 0
						  end as inTot
						  ,case when in_out = 'out' then sum(qty) 
						   else 0
						  end as outTot
						from tbl_stocktransaction where product_id = @product_id and batch_id = @batch_id
						group by batch_id, in_out
					) 
					select batch_id,(sum(inTot) - sum(outTot)) as StockAvl from result
					group by batch_id

   
   End


go

 ----------------------------------------sp_selectcompanylogo------------------------------------------------------
  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_selectcompanylogo')) 
exec('CREATE PROCEDURE [dbo].[sp_selectcompanylogo] AS BEGIN SET NOCOUNT ON; END') 
GO

 ALTER procedure[dbo].[sp_selectcompanylogo] 
@company_id int

as
 Begin
 
	select logo from tbl_company where company_id=@company_id

   
   End


go

----------------------------------------Check rack in godown------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_checkrackingodown')) 
exec('CREATE PROCEDURE [dbo].[sp_checkrackingodown] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_checkrackingodown] 
  @company_id int,
  @godown_id int,
  @value nvarchar(50)
 as
 begin

 Select rack_name from tbl_rack where company_id=@company_id and godown_id=@godown_id and rack_name=@value
 
 
  end

  go
  
----------------------------------------Check last 15-days of the F-Year------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_last15daysf_year')) 
exec('CREATE PROCEDURE [dbo].[sp_last15daysf_year] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_last15daysf_year] 
  @company_id int,
  @days_flag int out,
  @enddays_flag int out,
  @s_date smalldatetime,
  @days_left int out
 as
 begin

declare @e_date smalldatetime
select @e_date=end_date  from tbl_financialyear where company_id=@company_id and status=1
set  @days_left=DATEDIFF(day, @s_date, @e_date) 

		 if(@days_left<=15 AND @days_left>=1 )
			 begin
			set	@days_flag=1
			 end
		  else if(@days_left<=0)
				begin 
				--logic for Popup
						--set end days flag to 0
						set @enddays_flag=1

				-- update previous fy to non-active
					update tbl_financialyear set status=0 where company_id=@company_id and status=1
				end
		IF  EXISTS (select * from tbl_financialyear where company_id=@company_id and Is_new=1)
					begin
					--logic for notification
						--set flag to 1
						set @enddays_flag=0
						set @days_flag=0
						-- update new fy to active
						 if(@days_left<=0)
							begin 
							--logic for Popup
									--set end days flag to 0
								update tbl_financialyear set is_new=0 ,status=1 where company_id=@company_id and status=0 and  Is_new=1
							end
						
					end
				
  end
  go

  ----------------------------------------Check license------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_checklicense')) 
exec('CREATE PROCEDURE [dbo].[sp_checklicense] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_checklicense] 
  @company_id int,
  @user_id int,
  @Subscription_count int out
 as
 begin
	 declare @e_date smalldatetime,
			 @s_date smalldatetime,
			 @daydiff int

			 select @s_date=start_date,@e_date =end_date from tbl_paidpayment as p inner join tbl_subscription as s
			 on s.subscription_id=p.subscription_id  where p.company_id=@company_id and p.user_id=@user_id
			 and s.status=1

			 SET @daydiff= DATEDIFF(day, GETDATE(), @e_date)  
 
			 if (@daydiff>=1)
					  begin
						set @Subscription_count=1
					  end
			 else
					  begin
						set @Subscription_count=0
					  end
  end

  go

    ----------------------------------------sp_planall------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_planall')) 
exec('CREATE PROCEDURE [dbo].[sp_planall] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_planall] 

 as
 begin
	 select * from tbl_plan
  end

  go

    ----------------------------------------sp_updatesubscription------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_updatesubscription')) 
exec('CREATE PROCEDURE [dbo].[sp_updatesubscription] AS BEGIN SET NOCOUNT ON; END') 
GO
  ALTER PROCEDURE [dbo].[sp_updatesubscription] 
  @company_id int,
  @user_id int,
  @plan_id int, 
  @transaction_id int,
  @paidamount decimal(18,2),
  @start_date smalldatetime
 as
 begin
	update tbl_subscription set status=0,modified_by=@user_id,modified_date=@start_date where user_id=@user_id and status=1
		declare @duration int, @end_date smalldatetime,@subscription_id int
			select @duration=duration from tbl_plan where plan_id=@plan_id
				set @end_date= DATEADD(month, @duration, @start_date) 
				 insert into tbl_subscription(plan_id,user_id,start_date,end_date,status,created_by,created_date)
				 values (@plan_id,@user_id,@start_date,@end_date,1,@user_id,@start_date)

					set @subscription_id=@@identity

						 insert into tbl_paidpayment(subscription_id,transaction_id,transaction_date,user_id,company_id,paidamount,status,created_by,created_date)
						 values(@subscription_id,@transaction_id,@start_date,@user_id,@company_id,@paidamount,1,@user_id,@start_date)
  end

  go