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
 @branch_id int,
 @category_name nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_category set category_name=@category_name,modified_by=@modified_by,modified_date=GETDATE()   where company_id=@company_id and category_id=@category_id and branch_id=@branch_id
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
    Begin Try
     Begin Transaction

update tbl_company set company_name=@company_name,company_address=@company_address,state_id=@state_id,city=@city,
telephone_no=@telephone_no,fax_no=@fax_no,website=@website,logo=@logo,logo_name=@logo_name,GSTIN=@GSTIN,modified_by=@modified_by,
modified_date=@modified_date where company_id=@company_id

     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(Error_Type,Error_Msg) values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
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
  modified_by=@modified_by,modified_date=GETDATE()   where company_id=@company_id and party_id=@party_id and branch_id=@branch_id
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
 @purchas_price decimal(18, 0),
 @sales_price decimal(18, 0),
 @product_code nvarchar(50),
 @hsn_code nvarchar(50),
 @product_name nvarchar(50),
 @modified_by nvarchar(50),
 @modified_date datetime
 as
 begin
 begin try
 begin transaction
  update tbl_product set product_name=@product_name,godown_id=@godown_id,category_id=@category_id,tax_id=@tax_id,hsn_code=@hsn_code,
  unit_id=@unit_id,modified_by=@modified_by,modified_date=GETDATE()  
   where company_id=@company_id and product_id=@product_id and branch_id=@branch_id
  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
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
@modified_date smalldatetime



as
 Begin
    Begin Try
     Begin Transaction

update tbl_user set user_name=@user_name,user_Emai=@user_emailid,user_mobieno=@user_mobileno,modified_by=@modified_by,
modified_date=@modified_date where user_id=@user_id

 update tbl_userbranch set user_id=@user_id,role_id=@role_id,branch_id=@branch_id,modified_by=@modified_by,
modified_date=@modified_date
 where userbranch_id=@userbranch_id

     Commit Transaction
End Try
Begin Catch 
Rollback Transaction
insert into tbl_error_log(Error_Type,Error_Msg) values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
End Catch 
   End


