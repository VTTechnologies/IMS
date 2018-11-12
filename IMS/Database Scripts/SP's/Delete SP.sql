
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
  @branch_id int,
 @product_id int
 as
 begin
 begin try
 begin transaction
  update tbl_product set status=0  
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