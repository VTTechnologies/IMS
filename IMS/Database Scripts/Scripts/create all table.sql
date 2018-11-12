
------------------------------Table Country--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_country') 
begin
	print 'Create dbo.[tbl_country] table'

	create table [dbo].[tbl_country]
	(
		    [country_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[country_name] [nvarchar] (500) null		
		,	[currency_name] [nvarchar] (1000)  null 
		,	[currency_symbol] [nvarchar] (1000)  null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table State--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_state') 
begin
	print 'Create dbo.[tbl_state] table'

	create table [dbo].[tbl_state]
	(
		    [state_id] [int] identity(1,1)  not null PRIMARY KEY
		,	[country_id] [int]  null	FOREIGN KEY REFERENCES tbl_country(country_id)
		,	[state_name] [nvarchar] (500) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table User--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_User') 
begin
	print 'Create dbo.[tbl_User] table'

	create table [dbo].[tbl_User]
	(
		    [user_id] [int] identity(1,1)  not null PRIMARY KEY
		,	[user_name] [nvarchar] (50) null
		,	[user_Emai] [nvarchar] (50) null
		,	[user_mobieno] [nvarchar] (500) null
		,	[password] [nvarchar] (500) null
		,	[retry_attempts] int null
		,	[last_login] [smalldatetime]  null
		,	[islocked] [Bit] Null
		,	[locked_date] [smalldatetime] Null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Role-------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_role') 
begin
	print 'Create dbo.[tbl_role] table'

	create table [dbo].[tbl_role]
	(
		    [role_id] [int] identity(1,1)  not null PRIMARY KEY
		,	[role_name] [nvarchar] (50) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table UserRole-------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_userrole') 
begin
	print 'Create dbo.[tbl_userrole] table'

	create table [dbo].[tbl_userrole]
	(
		    [userrole_id] [int] identity(1,1)  not null PRIMARY KEY
		,	[role_id] [int] null  FOREIGN KEY REFERENCES tbl_role(role_id)
		,   [user_id] [int] null FOREIGN KEY REFERENCES tbl_user(user_id)
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Company--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_company') 
begin
	print 'Create dbo.[tbl_company] table'

	create table [dbo].[tbl_company]
	(
		    [company_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_name] [nvarchar] (500) null		
		,	[company_address] [nvarchar] (1000)  null 
		,	[country_id] [int]  null  FOREIGN KEY REFERENCES tbl_country(country_id)	
		,	[state_id] [int] null  FOREIGN KEY REFERENCES tbl_state(state_id)	
		,	[city] [nvarchar](200) null
		,	[pincode] [nvarchar](200) null 
		,	[logo] [nvarchar](500)  null 
		,	[GSTIN] [nvarchar](50) null 
		,	[telephone_no] [nvarchar] (50)  Null 
		,	[mobile_no] [nvarchar] (50)  Null 
		,	[fax_no] [nvarchar] (50) Null 
		,	[email_id] [nvarchar] (50) Null 
		,	[website] [nvarchar] (200) Null
		,	[owner_name] [nvarchar] (200) Null
		,	[owner_address] [nvarchar] (1000) Null
		,	[owner_mobileno] [nvarchar] (200) Null
		,	[owner_emailid] [nvarchar] (200) Null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table Branch--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_branch') 
begin
	print 'Create dbo.[tbl_branch] table'

	create table [dbo].[tbl_branch]
	(
		    [branch_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_id] [int]  null	 FOREIGN KEY REFERENCES tbl_company(company_id)		
		,	[branch_address] [nvarchar] (1000)  null 
		,	[country_id] [int]  null  FOREIGN KEY REFERENCES tbl_country(country_id)	
		,	[state_id] [int] null  FOREIGN KEY REFERENCES tbl_state(state_id)	 
		,	[city] [nvarchar] (200)  null
		,	[pincode] [nvarchar](200) null  
		,	[telephone_no] [nvarchar] (50)  Null 
		,	[mobile_no] [nvarchar] (50)  Null 
		,	[fax_no] [nvarchar] (50) Null 
		,	[email_id] [nvarchar] (50) Null 
		,	[manager_name] [nvarchar] (200) Null
		,	[manager_address] [nvarchar] (1000) Null
		,	[manager_mobileno] [nvarchar] (200) Null
		,	[manager_emailid] [nvarchar] (200) Null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go







------------------------------Table UserBranch-------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_userbranch') 
begin
	print 'Create dbo.[tbl_userbranch] table'

	create table [dbo].[tbl_userbranch]
	(
		    [userbranch_id] [int] identity(1,1)  not null PRIMARY KEY
		,	[role_id] [int] null  FOREIGN KEY REFERENCES tbl_role(role_id)
		,   [user_id] [int] null FOREIGN KEY REFERENCES tbl_user(user_id)
		,   [branch_id] [int] null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Category--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_category') 
begin
	print 'Create dbo.[tbl_category] table'

	create table [dbo].[tbl_category]
	(
		    [category_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)			 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[category_name] [nvarchar](50) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Unit--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_unit') 
begin
	print 'Create dbo.[tbl_unit] table'

	create table [dbo].[tbl_unit]
	(
		    [unit_id] [int] identity(1,1)  not null	 PRIMARY KEY
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[unit_name] [nvarchar](50) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table Godwon--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_godown') 
begin
	print 'Create dbo.[tbl_godown] table'

	create table [dbo].[tbl_godown]
	(
		    [godown_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[godown_name] [nvarchar](50) null
		,	[godown_address] [nvarchar](50) null
		,	[contact_no] [varchar](50) null
		,	[contact_person] [nvarchar](50) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Rack--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_rack') 
begin
	print 'Create dbo.[tbl_rack] table'

	create table [dbo].[tbl_rack]
	(
		    [rack_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[rack_name] [nvarchar](50) null
		,	[godown_id] [int] null FOREIGN KEY REFERENCES tbl_godown(godown_id)
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table Batch--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_batch') 
begin
	print 'Create dbo.[tbl_batch] table'

	create table [dbo].[tbl_batch]
	(
		    [batch_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[company_id] [int]  null  FOREIGN KEY REFERENCES tbl_company(company_id)			 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[batch_name] [nvarchar](50) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Party--------------------------------------------------------------------------


if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_party') 
begin
	print 'Create dbo.[tbl_party] table'

	create table [dbo].[tbl_party]
	(
		    [party_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[party_name] [nvarchar](50) null
		,	[party_address] [nvarchar](500) null
		,	[contact_no] [varchar](50) null
		,	[gstin_no] [nvarchar](20) null
		,	[party_type] [nvarchar](20) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Tax--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_tax') 
begin
	print 'Create dbo.[tbl_tax] table'

	create table [dbo].[tbl_tax]
	(
		    [tax_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[tax_name] [nvarchar](50) null
		,	[tax_percentage] [decimal] null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Product--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_product') 
begin
	print 'Create dbo.[tbl_product] table'

	create table [dbo].[tbl_product]
	(
		    [product_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[category_id] [int]  null FOREIGN KEY REFERENCES tbl_category(category_id) 
		,	[unit_id] [int]  null FOREIGN KEY REFERENCES tbl_unit(unit_id)
		,	[godown_id] [int]  null FOREIGN KEY REFERENCES tbl_godown(godown_id)
		,	[rack_id] [int]  null FOREIGN KEY REFERENCES tbl_rack(rack_id)
		,	[tax_id] [int]  null FOREIGN KEY REFERENCES tbl_tax(tax_id)
		,	[purchas_price] [decimal]  null 
		,	[sales_price] [decimal]  null 
		,	[reorder_level] [int]  null 
		,	[product_name] [nvarchar](50) null
		,	[product_code] [nvarchar](500) null
		,	[hsn_code] [varchar](50) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Payemnt Mode--------------------------------------------------------------------------


if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_paymentmode') 
begin
	print 'Create dbo.[tbl_paymentmode] table'

	create table [dbo].[tbl_paymentmode]
	(
		    [paymentode_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id) 
		,	[paymentmode_name] [nvarchar] (1000)  null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Financial Year--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_financialyear') 
begin
	print 'Create dbo.[tbl_financialyear] table'

	create table [dbo].[tbl_financialyear]
	(
		    [financialyear_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[company_id] [int]  null	FOREIGN KEY REFERENCES tbl_company(company_id)	 
		,	[branch_id] [int]  null  FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[start_date] [nvarchar](50) null
		,	[end_date] [nvarchar](500) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Expense--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_expense') 
begin
	print 'Create dbo.[tbl_expense] table'

	create table [dbo].[tbl_expense]
	(
		    [expense_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[expense_name] [nvarchar](50) null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table Expense Entry--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_expenseentry') 
begin
	print 'Create dbo.[tbl_expenseentry] table'

	create table [dbo].[tbl_expenseentry]
	(
		    [expenseentry_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[expense_id] [int] null	FOREIGN KEY REFERENCES tbl_expense(expense_id)	
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[spent_on] [nvarchar] (500)  null 
		,	[description] [nvarchar] (500)  null 
		,	[amount] [decimal] null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Stock--------------------------------------------------------------------------


if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_stock') 
begin
	print 'Create dbo.[tbl_stock] table'

	create table [dbo].[tbl_stock]
	(
		    [stock_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[product_id] [int]  null FOREIGN KEY REFERENCES tbl_product(product_id)
		,	[batch_id] [int]  null FOREIGN KEY REFERENCES tbl_batch(batch_id)
		,	[qty] [int]  null 
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Stock Transaction--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_stocktransaction') 
begin
	print 'Create dbo.[tbl_stocktransaction] table'

	create table [dbo].[tbl_stocktransaction]
	(
		    [stockt_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[stocktransaction_typ_id] [int]  null 
		,	[stocktransaction_typ] [varchar] (20)  null 
		,	[product_id] [int]  null FOREIGN KEY REFERENCES tbl_product(product_id) 
		,	[batch_id] [int]  null FOREIGN KEY REFERENCES tbl_batch(batch_id)
		,	[qty] [int]  null 
		,	[in_out] [varchar] (20)  null 
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go
------------------------------Table Mony--------------------------------------------------------------------------


if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_mony') 
begin
	print 'Create dbo.[tbl_mony] table'

	create table [dbo].[tbl_mony]
	(
		    [mony_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[party_id] [int] null	FOREIGN KEY REFERENCES tbl_party(party_id)	
		,	[payableamt] [decimal] (18, 0) null 
		,	[reciveableamt] [decimal] (18, 0) null 
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Mony Transaction--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_monytransaction') 
begin
	print 'Create dbo.[tbl_monytransaction] table'

	create table [dbo].[tbl_monytransaction]
	(
		    [monytransaction_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)		 
		,	[branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[transaction_typ_id] [int]  null 
		,	[transaction_typ] [varchar] (20)  null 
		,	[paymentmode_id] [int]  null FOREIGN KEY REFERENCES tbl_paymentmode(paymentode_id)
		,	[total_bil_amt] [decimal]  null 
		,	[given_amt] [decimal]  null 
		,	[balance_amt] [decimal]  null 
		,	[in_out] [varchar] (20)  null 
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table Purchase--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_purchase') 
begin
	print 'Create dbo.[tbl_purchase] table'

	create table [dbo].[tbl_purchase]
	(
		    [purchase_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[party_id] [int] null	FOREIGN KEY REFERENCES tbl_party(party_id)	
		,	[financialyear_id] [int]  null FOREIGN KEY REFERENCES tbl_financialyear(financialyear_id)
		,	[po_no] [nvarchar] (100)  null
		,	[total_tax] [decimal] null
		,	[discount] [decimal] null
		,	[actual_amount] [decimal] null
		,	[grand_total] [decimal] null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table Purchase Details--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_purchasedetails') 
begin
	print 'Create dbo.[tbl_purchasedetails] table'

	create table [dbo].[tbl_purchasedetails]
	(
		    [purchasedetails_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[purchase_id] [int] null	FOREIGN KEY REFERENCES tbl_purchase(purchase_id)	
		,	[product_id] [int]  null FOREIGN KEY REFERENCES tbl_product(product_id)
		,	[batch_id] [int]  null FOREIGN KEY REFERENCES tbl_batch(batch_id)
		,	[tax_id] [int]  null  FOREIGN KEY REFERENCES tbl_tax(tax_id)
		,	[unit_id] [int]  null FOREIGN KEY REFERENCES tbl_unit(unit_id) 
		,	[tax_amt] [decimal] null
		,	[dicount_amt] [decimal] null
		,	[quantity] [decimal] null
		,	[amount] [decimal] null
		,	[purchase_rate] [decimal] null
		,	[sale_rate] [decimal] null
		
	) on [PRIMARY]

end
go

------------------------------Table Sale--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_sale') 
begin
	print 'Create dbo.[tbl_sale] table'

	create table [dbo].[tbl_sale]
	(
		    [sale_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[party_id] [int] null	FOREIGN KEY REFERENCES tbl_party(party_id)	
		,	[financialyear_id] [int]  null FOREIGN KEY REFERENCES tbl_financialyear(financialyear_id)
		,	[invoice_no] [nvarchar] (100)  null
		,	[total_tax] [decimal] null
		,	[total_discount] [decimal] null
		,	[actual_amount] [decimal] null
		,	[grand_total] [decimal] null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table Sale Details--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_saledetails') 
begin
	print 'Create dbo.[tbl_saledetails] table'

	create table [dbo].[tbl_saledetails]
	(
		    [saledetails_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[sale_id] [int] null	FOREIGN KEY REFERENCES tbl_sale(sale_id)	
		,	[product_id] [int]  null FOREIGN KEY REFERENCES tbl_product(product_id)
		,	[batch_id] [int]  null FOREIGN KEY REFERENCES tbl_batch(batch_id)
		,	[tax_id] [int]  null  FOREIGN KEY REFERENCES tbl_tax(tax_id)
		,	[unit_id] [int]  null FOREIGN KEY REFERENCES tbl_unit(unit_id)
		,	[tax_amt] [decimal] null
		,	[dicount_amt] [decimal] null
		,	[quantity] [decimal] null
		,	[amount] [decimal] null
		
	) on [PRIMARY]

end
go

------------------------------Table Purcahse Return Main--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_purchasereturnmain') 
begin
	print 'Create dbo.[tbl_purchasereturnmain] table'

	create table [dbo].[tbl_purchasereturnmain]
	(
		    [purchasereturnmain_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_id] int null  FOREIGN KEY REFERENCES tbl_company(company_id)
		,	[branch_id] int null  FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[purchase_id] [int] null FOREIGN KEY REFERENCES tbl_purchase(purchase_id)	
		,	[financialyear_id] [int]  null FOREIGN KEY REFERENCES tbl_financialyear(financialyear_id)
		,	[total_tax] [decimal] null
		,	[total_discount] [decimal] null
		,	[actual_amount] [decimal] null
		,	[grand_total] [decimal] null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go
------------------------------Table Purchase Return--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_purchasereturn') 
begin
	print 'Create dbo.[tbl_purchasereturn] table'

	create table [dbo].[tbl_purchasereturn]
	(
		    [purchasereturn_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[purchase_id] [int] null FOREIGN KEY REFERENCES tbl_purchase(purchase_id)		
		,	[batch_id] [int]  null FOREIGN KEY REFERENCES tbl_batch(batch_id)
		,	[product_id] [int]  null FOREIGN KEY REFERENCES tbl_product(product_id)
		,	[unit_id] [int]  null FOREIGN KEY REFERENCES tbl_unit(unit_id)
		,	[tax_id] [int]  null FOREIGN KEY REFERENCES tbl_tax(tax_id)
		,	[tax_amt] [nvarchar] (100)  null
		,	[quantity] [decimal] null
		,	[amount] [decimal] null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go


------------------------------Table Sale Return Main--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_salereturnmain') 
begin
	print 'Create dbo.[tbl_salereturnmain] table'

	create table [dbo].[tbl_salereturnmain]
	(
		    [salereturnmain_id] [int] identity(1,1)  not null	PRIMARY KEY
		,	[company_id] int null  FOREIGN KEY REFERENCES tbl_company(company_id)
		,	[branch_id] int null  FOREIGN KEY REFERENCES tbl_branch(branch_id)
		,	[sale_id] [int] null	FOREIGN KEY REFERENCES tbl_sale(sale_id)	
		,	[financialyear_id] [int]  null FOREIGN KEY REFERENCES tbl_financialyear(financialyear_id)
		,	[total_tax] [decimal] null
		,	[total_discount] [decimal] null
		,	[actual_amount] [decimal] null
		,	[grand_total] [decimal] null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go
------------------------------Table Sale Return--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_salesreturn') 
begin
	print 'Create dbo.[tbl_salesreturn] table'

	create table [dbo].[tbl_salesreturn]
	(
		    [salesreturn_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[sale_id] [int] null	FOREIGN KEY REFERENCES tbl_sale(sale_id)	
		,	[batch_id] [int]  null FOREIGN KEY REFERENCES tbl_batch(batch_id)
		,	[product_id] [int]  null FOREIGN KEY REFERENCES tbl_product(product_id)
		,	[unit_id] [int]  null FOREIGN KEY REFERENCES tbl_unit(unit_id)
		,	[tax_id] [int]  null FOREIGN KEY REFERENCES tbl_tax(tax_id)
		,	[tax_amt] [decimal] null
		,	[quantity] [decimal] null
		,	[amount] [decimal] null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Tax Group--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_taxGroup') 
begin
	print 'Create dbo.[tbl_taxGroup] table'

	create table [dbo].[tbl_taxGroup]
	(
		    [taxGroup_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[product_id] [int]  null FOREIGN KEY REFERENCES tbl_product(product_id)
		,	[tax_id] [int]  null FOREIGN KEY REFERENCES tbl_tax(tax_id)
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table Error_Log--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_error_log') 
begin
 print 'Create dbo.[tbl_error_log] table'

 create table [dbo].[tbl_error_log]
 (
      [error_log_id] [int] identity(1,1)  not null PRIMARY KEY 
  , [company_id] [int]  null FOREIGN KEY REFERENCES tbl_company(company_id)    
  , [branch_id] [int]  null FOREIGN KEY REFERENCES tbl_branch(branch_id)
  , [error_type] [nvarchar] (100)
  , [error_msg] [nvarchar] (max)
  , [created_by] [nvarchar] (500) Null
  , [created_date] [smalldatetime] Null
  

 ) on [PRIMARY]

end
go
------------------------------Table Email Verify------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='Tbl_EmailVerify') 
begin
	print 'Create dbo.[Tbl_EmailVerify] table'

	create table [dbo].[Tbl_EmailVerify]
	(
		    [emailverify_ID] [int] identity(1,1) not null PRIMARY KEY	
		,	[user_id] [nvarchar] (500) null		
		,	[uniqueidentifier] [nvarchar] (max) null 
		,	[status] bit  null
		,	[created_date] [smalldatetime] Null
		
	) on [PRIMARY]

end
go

------------------------------alter tbl_branch--------------------------------------------------------------------------

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_branch]') and c.name =N'IsMainBranch' )
begin
Alter table tbl_branch add IsMainBranch bit
end
go

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_branch]') and c.name =N'IsMainBranch' )
begin
Alter table tbl_branch drop column mobile_no
end
go

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_branch]') and c.name =N'branch_name' )
begin
Alter table tbl_branch add branch_name nvarchar(250)
end
go


------------------------------alter tbl_company--------------------------------------------------------------------------

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_company]') and c.name =N'mobile_no' )
begin
alter table tbl_company drop column  mobile_no,owner_address,logo,owner_name
end
go

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_company]') and c.name =N'logo' )
begin
alter table tbl_company add logo varbinary(max)
end
go

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_company]') and c.name =N'logo_name' )
begin
alter table tbl_company add logo_name nvarchar(100)
end
go

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_company]') and c.name =N'first_name' )
begin
alter table tbl_company add first_name nvarchar(100)
end
go
if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_company]') and c.name =N'last_name' )
begin
alter table tbl_company add last_name nvarchar(100)
end
go

------------------------------alter tbl_userbranch--------------------------------------------------------------------------


if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_userbranch]') and c.name =N'company_id' )
begin
alter table tbl_userbranch add company_id int null FOREIGN KEY REFERENCES tbl_company(company_id)
end
go


------------------------------alter tbl_user--------------------------------------------------------------------------


if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_user]') and c.name =N'first_name' )
begin
Alter table tbl_user add first_name nvarchar(100)
end
go

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_user]') and c.name =N'last_name' )
begin
Alter table tbl_user add last_name nvarchar(100)
end
go


------------------------------alter tbl_purchase--------------------------------------------------------------------------
if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_purchase]') and c.name =N'Po_Date' )
begin
Alter table tbl_purchase add Po_Date smalldatetime
end
go
if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_purchase]') and c.name =N'company_id' )
begin
alter table tbl_purchase add company_id int null FOREIGN KEY REFERENCES tbl_company(company_id)
end
go

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_purchase]') and c.name =N'branch_id' )
begin
alter table tbl_purchase add branch_id int null  FOREIGN KEY REFERENCES tbl_branch(branch_id)
end
go

------------------------------alter tbl_purchase--------------------------------------------------------------------------
if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_sale]') and c.name =N'company_id' )
begin
alter table tbl_sale add company_id int null FOREIGN KEY REFERENCES tbl_company(company_id)
end
go

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_sale]') and c.name =N'price' )
begin
alter table tbl_sale drop column  price 
end
go

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_sale]') and c.name =N'branch_id' )
begin
alter table tbl_sale add branch_id int null  FOREIGN KEY REFERENCES tbl_branch(branch_id)
end
go
------------------------------alter tbl_saledetails--------------------------------------------------------------------------

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_saledetails]') and c.name =N'price' )
begin
alter table tbl_saledetails add price decimal(18, 0)
end
go
------------------------------alter tbl_stocktransaction--------------------------------------------------------------------------

if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_stocktransaction]') and c.name =N'transactio_type_id' )
begin
alter table tbl_stocktransaction add transactio_type_id int null  
end
go
------------------------------alter tbl_financialyear--------------------------------------------------------------------------


if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_financialyear]') and c.name =N'Is_new' )
begin
alter table tbl_financialyear add Is_new bit null  
end
go
------------------------------alter tbl_monytransaction--------------------------------------------------------------------------


if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_monytransaction]') and c.name =N'party_id' )
begin
alter table tbl_monytransaction add party_id int null  FOREIGN KEY REFERENCES tbl_party(party_id)
end
go
if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_monytransaction]') and c.name =N'transactio_type_id' )
begin
alter table tbl_monytransaction add transactio_type_id int null  
end
go


------------------------------alter tbl_purchaseReturn--------------------------------------------------------------------------


if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_purchasereturn]') and c.name =N'purchase_id' )
begin
alter table tbl_purchasereturn drop constraint [FK__tbl_purch__purch__03F0984C]

alter table tbl_purchasereturn drop column purchase_id
end
go
if not exists (select 1 from [sys].[columns] c where object_id = object_id(N'[dbo].[tbl_purchasereturn]') and c.name =N'purchasereturnmain_id' )
begin
alter table tbl_purchasereturn add  purchasereturnmain_id int null  FOREIGN KEY REFERENCES tbl_purchasereturnmain(purchasereturnmain_id)
end
go
------------------------------Table Plan--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_plan') 
begin
	print 'Create dbo.[tbl_plan] table'

	create table [dbo].[tbl_plan]
	(
		    [plan_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[plan_name] [nvarchar] (500) null		
		,	[price] [decimal] (18, 2)  null 
		,	[duration] [int]  null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go
------------------------------Table Subscription--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_subscription') 
begin
	print 'Create dbo.[tbl_subscription] table'

	create table [dbo].[tbl_subscription]
	(
		    [subscription_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[plan_id] [int] null FOREIGN KEY REFERENCES tbl_plan(plan_id)
		,	[user_id] [int] null FOREIGN KEY REFERENCES tbl_user(user_id)	
		,	[start_date] [smalldatetime] Null 
		,	[end_date] [smalldatetime] Null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go

------------------------------Table PaidPayment--------------------------------------------------------------------------

if not exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='dbo' and TABLE_NAME='tbl_paidpayment') 
begin
	print 'Create dbo.[tbl_paidpayment] table'

	create table [dbo].[tbl_paidpayment]
	(
		    [paidpayment_id] [int] identity(1,1)  not null PRIMARY KEY	
		,	[subscription_id] [int] null FOREIGN KEY REFERENCES tbl_subscription(subscription_id)
		,	[user_id] [int] null FOREIGN KEY REFERENCES tbl_user(user_id)	
		,	[transaction_id] [int] null 
		,	[company_id] [int] null FOREIGN KEY REFERENCES tbl_company(company_id)
		,	[transaction_date] [smalldatetime] Null
		,	[paidamount] [decimal] (18, 2)  null
		,	[status] [Bit] Null
		,	[created_by] [nvarchar] (500) Null
		,	[created_date] [smalldatetime] Null
		,	[modified_by] [nvarchar] (500) Null
		,	[modified_date] [smalldatetime] Null

	) on [PRIMARY]

end
go
--select * from tbl_country
-----------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------Date INsert------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------
declare @temp table (country_id int,country_name nvarchar(500),currency_name nvarchar(1000),
currency_symbol nvarchar(1000),status bit,created_by nvarchar(500))

INSERT INTO   @temp ( country_name, currency_name, currency_symbol, status, 
created_by) values
 ('Albania', 'Leke',  'Lek', 1,'admin'),
 ( 'America', 'Dollars',  '$',  1,'admin'),
 ( 'Afghanistan', 'Afghanis',  '؋', 1,'admin'),
 ( 'Argentina', 'Pesos',  '$', 1,'admin'),
 ( 'Aruba', 'Guilders',  'ƒ', 1,'admin'),
 ( 'Australia', 'Dollars',  '$', 1,'admin'),
 ( 'Azerbaijan', 'New Manats', 'ман', 1,'admin'),
 ( 'Bahamas', 'Dollars',  '$', 1,'admin'),
 ( 'Barbados', 'Dollars',  '$', 1,'admin'),
 ( 'Belarus', 'Rubles',  'p.',  1,'admin'),
 ( 'Belgium', 'Euro',  '€',  1,'admin'),
 ( 'Beliz', 'Dollars',  'BZ$', 1,'admin'),
 ( 'Bermuda', 'Dollars',  '$', 1,'admin'),
 ( 'Bolivia', 'Bolivianos',  '$b', 1,'admin'),
 ( 'Bosnia and Herzegovina', 'Convertible Marka',  'KM', 1,'admin'),
 ( 'Botswana', 'Pula\s',  'P', 1,'admin'),
 ( 'Bulgaria', 'Leva',  'лв',  1,'admin'),
 ( 'Brazil', 'Reais',  'R$', 1,'admin'),
 ( 'Britain (United Kingdom)', 'Pounds', '£', 1,'admin'),
 ( 'Brunei Darussalam', 'Dollars',  '$', 1,'admin'),
 ('Cambodia', 'Riels', '៛',  1,'admin'),
 ( 'Canada', 'Dollars',  '$', 1,'admin'),
 ( 'Cayman Islands', 'Dollars',  '$', 1,'admin'),
 ( 'Chile', 'Pesos', '$', 1,'admin'),
 ( 'China', 'Yuan Renminbi',  '¥', 1,'admin'),
 ( 'Colombia', 'Pesos', '$',  1,'admin'),
 ( 'Costa Rica', 'Colón',  '₡', 1,'admin'),
 ( 'Croatia', 'Kuna',  'kn',  1,'admin'),
 ( 'Cuba', 'Pesos', '₱', 1,'admin'),
 ( 'Cyprus', 'Euro', '€', 1,'admin'),
 ( 'Czech Republic',  'CZK', 'Kč', 1,'admin'),
 ('Denmark', 'Kroner',  'kr', 1,'admin'),
 ('Dominican Republic',  'DOP ', 'RD$', 1,'admin'),
 ('East Caribbean', 'Dollars',  '$', 1,'admin'),
 ('Egypt', 'Pounds', '£', 1,'admin'),
 ( 'El Salvador', 'Colones',  '$', 1,'admin'),
 ( 'England (United Kingdom)', 'Pounds',  '£', 1,'admin'),
 ( 'Euro', 'Euro',  '€', 1,'admin'),
 ('Falkland Islands', 'Pounds',  '£', 1,'admin'),
 ('Fiji', 'Dollars',  '$',  1,'admin'),
 ( 'France', 'Euro',  '€', 1,'admin'),
 ( 'Ghana', 'Cedis',  '¢',  1,'admin'),
 ('Gibraltar', 'Pounds',  '£',  1,'admin'),
 ('Greece', 'Euro', '€',  1,'admin'),
 ('Guatemala', 'Quetzales', 'Q', 1,'admin'),
 ( 'Guernsey', 'Pounds',  '£',  1,'admin'),
 ( 'Guyana', 'Dollars',  '$',  1,'admin'),
 ( 'Holland (Netherlands)', 'Euro', '€',  1,'admin'),
 ('Honduras', 'Lempiras', 'L',  1,'admin'),
 ( 'Hong Kong', 'Dollars',  '$',  1,'admin'),
 ( 'Hungary', 'Forint',  'Ft',  1,'admin'),
 ( 'Iceland', 'Kronur',  'kr',  1,'admin'),
 ( 'India', 'Rupees',  'Rp',  1,'admin'),
 ( 'Indonesia', 'Rupiahs',  'Rp',  1,'admin'),
 ( 'Iran', 'Rials',  '﷼',  1,'admin'),
 ('Ireland', 'Euro',  '€', 1,'admin'),
 ( 'Isle of Man', 'Pounds', '£',  1,'admin'),
 ( 'Israel', 'New Shekels',  '₪',  1,'admin'),
 ( 'Italy', 'Euro',  '€',  1,'admin'),
 ( 'Jamaica', 'Dollars',  'J$',  1,'admin'),
 ( 'Japan', 'Yen',  '¥',  1,'admin'),
 ( 'Jersey', 'Pounds',  '£',  1,'admin'),
 ( 'Kazakhstan', 'Tenge',  'лв',   1,'admin'),
 ( 'Korea (North)', 'Won',  '₩',  1,'admin'),
 ( 'Korea (South)', 'Won',  '₩',  1,'admin'),
 ( 'Kyrgyzstan', 'Soms',  'лв',  1,'admin'),
 ( 'Laos', 'Kips',  '₭',  1,'admin'),
 ( 'Latvia', 'Lati',  'Ls',  1,'admin'),
 ( 'Lebanon', 'Pounds',  '£',  1,'admin'),
 ( 'Liberia', 'Dollars',  '$',  1,'admin'),
 ( 'Liechtenstein', 'Switzerland Francs', 'CHF',  1,'admin'),
 ( 'Lithuania', 'Litai',  'Lt',  1,'admin'),
 ( 'Luxembourg', 'Euro',  '€',  1,'admin'),
 ( 'Macedonia', 'Denars',  'ден',  1,'admin'),
 ('Malaysia', 'Ringgits',  'RM',  1,'admin'),
 ( 'Malta', 'Euro',  '€',  1,'admin'),
 ( 'Mauritius', 'Rupees', '₨', 1,'admin'),
 ( 'Mexico', 'Pesos',  '$', 1,'admin'),
 ( 'Mongolia', 'Tugriks',  '₮', 1,'admin'),
 ( 'Mozambique', 'Meticais',  'MT', 1,'admin'),
 ( 'Namibia', 'Dollars', '$',  1,'admin'),
 ( 'Nepal', 'Rupees',  '₨', 1,'admin'),
 ( 'Netherlands Antilles', 'Guilders',  'ƒ',  1,'admin'),
 ( 'Netherlands', 'Euro',  '€',  1,'admin'),
 ( 'New Zealand', 'Dollars', '$',  1,'admin'),
 ( 'Nicaragua', 'Cordobas',  'C$',  1,'admin'),
 ( 'Nigeria', 'Nairas', '₦',  1,'admin'),
 ( 'North Korea', 'Won',  '₩',  1,'admin'),
 ( 'Norway', 'Krone',  'kr',  1,'admin'),
 ( 'Oman', 'Rials', '﷼',  1,'admin'),
 ( 'Pakistan', 'Rupees',  '₨',  1,'admin'),
 ( 'Panama', 'Balboa',  'B/.',  1,'admin'),
 ( 'Paraguay', 'Guarani',  'Gs',  1,'admin'),
 ( 'Peru', 'Nuevos Soles', 'S/.',  1,'admin'),
 ( 'Philippines', 'Pesos',  'Php',  1,'admin'),
 ( 'Poland', 'Zlotych',  'zł',  1,'admin'),
 ( 'Qatar', 'Rials',  '﷼',  1,'admin'),
 ( 'Romania', 'New Lei',  'lei',  1,'admin'),
 ( 'Russia', 'Rubles',  'руб',  1,'admin'),
 ( 'Saint Helena', 'Pounds',  '£',  1,'admin'),
 ( 'Saudi Arabia', 'Riyals',  '﷼',  1,'admin'),
 ( 'Serbia', 'Dinars',  'Дин.',  1,'admin'),
 ( 'Seychelles', 'Rupees',  '₨',  1,'admin'),
 ( 'Singapore', 'Dollars',  '$',  1,'admin'),
 ( 'Slovenia', 'Euro',  '€',  1,'admin'),
 ( 'Solomon Islands', 'Dollars',  '$',  1,'admin'),
 ( 'Somalia', 'Shillings', 'S',  1,'admin'),
 ( 'South Africa', 'Rand',  'R',  1,'admin'),
 ( 'South Korea', 'Won',  '₩',  1,'admin'),
 ( 'Spain', 'Euro',  '€',  1,'admin'),
 ( 'Sri Lanka', 'Rupees',  '₨',  1,'admin'),
 ( 'Sweden', 'Kronor', 'kr',  1,'admin'),
 ( 'Switzerland', 'Francs', 'CHF',  1,'admin'),
 ( 'Suriname', 'Dollars',  '$',  1,'admin'),
 ( 'Syria', 'Pounds', '£',  1,'admin'),
 ( 'Taiwan', 'New Dollars', 'NT$',  1,'admin'),
 ( 'Thailand', 'Baht',  '฿',  1,'admin'),
 ( 'Trinidad and Tobago', 'Dollars',  'TT$',  1,'admin'),
 ( 'Turkey', 'Lira',  'TL',  1,'admin'),
 ( 'Turkey', 'Liras',  '£',  1,'admin'),
 ( 'Tuvalu', 'Dollars',  '$',  1,'admin'),
 ( 'Ukraine', 'Hryvnia',  '₴',  1,'admin'),
 ( 'United Kingdom', 'Pounds',  '£', 1,'admin'),
 ( 'United tbl_state of America', 'Dollars', '$',  1,'admin'),
 ( 'Uruguay', 'Pesos', '$U', 1,'admin'),
 ( 'Uzbekistan', 'Sums',  'лв',  1,'admin'),
 ( 'Vatican City', 'Euro', '€',  1,'admin'),
 ( 'Venezuela', 'Bolivares Fuertes', 'Bs',  1,'admin'),
 ( 'Vietnam', 'Dong', '₫',  1,'admin'),
 ( 'Yemen', 'Rials',  '﷼',  1,'admin'),
 ('Zimbabwe', 'Zimbabwe Dollars',  'Z$',  1,'admin')

 merge into [dbo].[tbl_country] as trg
 using @temp as src
 on (trg.country_id=src.country_id)
  when not matched by target then insert
  ( country_name, currency_name, currency_symbol, status, 
created_by) values(src.country_name,src.currency_name,src.currency_symbol,src.status,src.created_by);


 go
 --select * from tbl_state

 declare @temp table (role_id int,role_name nvarchar(50),status bit,created_by nvarchar(50) )

 insert into @temp
 (role_name,status,created_by) 
 values
 ('Purchase Manager',1,'admin')
,('Sales Manager',1,'admin')
,('Manager',1,'admin')

merge into [dbo].[tbl_role] as trg
using @temp as src
on(trg.role_id=src.role_id)
when not matched by target then insert
 (role_name,status,created_by) 
 values
 (src.role_name,src.status,src.created_by);

go

declare @temp table (state_id int,country_id int,state_name nvarchar(50),status bit )

INSERT INTO @temp (country_id,state_name, status) values (53,'ANDHRA PRADESH',1),
 (53,'ASSAM',1),
 (53,'ARUNACHAL PRADESH',1),
  (53,'GUJRAT',1),
  (53,'BIHAR',1),
  (53,'HARYANA',1),
  (53,'HIMACHAL PRADESH',1),
  (53,'JAMMU & KASHMIR',1),
  (53,'KARNATAKA',1),
  (53,'KERALA',1),
  (53,'MADHYA PRADESH',1),
  (53,'MAHARASHTRA',1),
  (53,'MANIPUR',1),
  (53,'MEGHALAYA',1),
  (53,'MIZORAM',1),
  (53,'NAGALAND',1),
  (53,'ORISSA',1),
  (53,'PUNJAB',1),
  (53,'RAJASTHAN',1),
  (53,'SIKKIM',1),
  (53,'TAMIL NADU',1),
  (53,'TRIPURA',1),
  (53,'UTTAR PRADESH',1),
  (53,'WEST BENGAL',1),
 (53,'GOA',1),
 (53,'PONDICHERY',1),
  (53,'LAKSHDWEEP',1),
  (53,'DAMAN & DIU',1),
  (53,'DADRA & NAGAR',1),
  (53,'CHANDIGARH',1),
  (53,'ANDAMAN & NICOBAR',1),
  (53,'UTTARANCHAL',1),
  (53,'JHARKHAND',1),
  (53,'CHATTISGARH',1),
  (53,'ASSAM',1)

  merge into [dbo].[tbl_state] as trg
using @temp as src
on(trg.state_id=src.state_id)
when not matched by target then insert
(country_id,state_name, status)
 values
 (src.country_id,src.state_name,src.status);
  go


  declare @temp table (plan_id int,plan_name nvarchar(500),price decimal(18, 2),duration int,status bit )
  insert into @temp (plan_name,price,duration,status)
  values('Silver',49,3,1),
  ('Gold',89,6,1),
  ('Platinum',169,12,1)
   merge into [dbo].[tbl_plan] as trg
using @temp as src
on(trg.plan_name=src.plan_name)
when not matched by target then insert
(plan_name,price,duration,status)
 values
 (src.plan_name,src.price,src.duration,src.status);
  go