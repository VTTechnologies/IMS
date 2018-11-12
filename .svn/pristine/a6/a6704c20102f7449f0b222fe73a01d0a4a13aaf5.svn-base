----------------------------------------Select Category------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectCategory')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectCategory] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectCategory] 
 @company_id int
 as
 begin
  select category_id, category_name from tbl_category where company_id=@company_id and status=1
  end
  go

  ----------------------------------------Select Batch------------------------------------------------------

  
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectBatch')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectBatch] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectBatch] 
 @company_id int
 as
 begin
 begin try
 begin transaction
  select batch_id, batch_name from tbl_batch where company_id=@company_id and status=1
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

select tbl_company.company_name,tbl_company.company_address,tbl_company.country_id,tbl_company.state_id,tbl_company.city,
tbl_company.telephone_no,tbl_company.fax_no,tbl_company.pincode,tbl_company.GSTIN,tbl_company.website,tbl_company.first_name,tbl_company.last_name,
tbl_company.owner_emailid,tbl_company.owner_mobileno,tbl_country.country_name,tbl_state.state_name from ((tbl_company inner join
tbl_country on tbl_company.country_id=tbl_country.country_id) inner join tbl_state on tbl_company.state_id=tbl_state.state_id) 
where tbl_company.company_id=@company_id
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

	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectExpense')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectExpense] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectExpense] 
 @company_id int
 as
 begin
 begin try
 begin transaction
  select expense_id, expense_name from tbl_expense where company_id=@company_id and status=1
  commit transaction
  end try
  begin catch

  end catch
  end
  go
     ----------------------------------------Select FY------------------------------------------------------

	 
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_SelectFY')) 
exec('CREATE PROCEDURE [dbo].[sp_SelectFY] AS BEGIN SET NOCOUNT ON; END') 
GO
 ALTER PROCEDURE [dbo].[sp_SelectFY] 
 @company_id int
 as
 begin
 begin try
 begin transaction
  select financialyear_id, start_date,end_date from tbl_financialyear where company_id=@company_id and status=1
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
 as
 begin
 begin try
 begin transaction
  select godown_id, godown_name,godown_address,contact_no,contact_person from tbl_godown where company_id=@company_id and status=1
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
 as
 begin
 begin try
 begin transaction
  select party_id, party_name,party_address,contact_no,gstin_no,party_type from tbl_party where company_id=@company_id and status=1
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
 as
 begin
 begin try
 begin transaction
  select paymentode_id , paymentmode_name from tbl_paymentmode where company_id=@company_id and status=1
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
 as
 begin
 begin try
 begin transaction
  SELECT tbl_product.product_id,tbl_product.product_name,tbl_product.hsn_code,tbl_product.product_code,tbl_product.purchas_price,tbl_product.sales_price,tbl_product.reorder_level,
  tbl_category.category_name,tbl_unit.unit_name,tbl_godown.godown_name,tbl_rack.rack_name,tbl_tax.tax_name from((((
  ( tbl_product inner JOIN tbl_category ON tbl_product.category_id= tbl_category.category_id)
  inner JOIN tbl_unit ON tbl_product.unit_id = tbl_unit.unit_id)
   inner join tbl_godown on tbl_product.godown_id=tbl_godown.godown_id)
   inner join tbl_rack on tbl_product.rack_id=tbl_rack.rack_id)
   inner join tbl_tax on tbl_product.tax_id=tbl_tax.tax_id)
   where tbl_product.company_id=@company_id and tbl_product.status=1
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
 as
 begin
  begin try
  begin transaction

  select tbl_rack.rack_id,tbl_rack.rack_name,tbl_godown.godown_name from tbl_rack  right join tbl_godown on tbl_rack.godown_id=tbl_godown.godown_id
 
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
 as
 begin
 begin try
 begin transaction
  select tax_id, tax_name,tax_percentage from tbl_tax where company_id=@company_id and status=1
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
 as
 begin
 begin try
 begin transaction
  select unit_id, unit_name from tbl_unit where company_id=@company_id and status=1
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
	 tbl_User.user_mobieno, tbl_User.user_name,tbl_role.role_name,tbl_branch.branch_name from (((
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


 
 select tbl_userbranch.company_id,tbl_userbranch.branch_id,tbl_role.role_name from tbl_userbranch inner join tbl_role on tbl_userbranch.role_id=tbl_role.role_id where tbl_userbranch.user_id=@user_id

  commit transaction
  end try
  begin catch
  Rollback Transaction
insert into tbl_error_log(error_type,error_msg)
 values ('Sp_Error',ERROR_MESSAGE()+'ERROR_PROCEDURE()'+'ERROR_NUMBER()' )
  end catch
  end
	 ----------------------------------------ENd------------------------------------------------------