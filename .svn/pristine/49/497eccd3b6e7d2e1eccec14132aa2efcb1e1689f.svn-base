
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_Purchaseinsert')) 
exec('CREATE PROCEDURE [dbo].[sp_Purchaseinsert] AS BEGIN SET NOCOUNT ON; END') 
GO

ALTER procedure[dbo].[sp_Purchaseinsert] 
@company_id int,
@branch_id int,
@party_id int,
@po_no nvarchar(100),
@Po_Date nvarchar(100),
@product_id int,
@batch_id int,
@total_tax decimal(18,0),
@actual_amount decimal(18, 0),
@grand_total decimal(18, 0),
@discount decimal(18, 0),
@status bit,
@created_by nvarchar(50),
@created_date smalldatetime


as
 Begin
    Begin Try
     Begin Transaction
	 declare @financialyear_id int
	  select @financialyear_id=financialyear_id from tbl_financialyear where company_id=2 and branch_id=3 and status=1 
	 insert into tbl_purchase (company_id,branch_id,party_id,po_no,financialyear_id,Po_Date,total_tax,discount,actual_amount,grand_total,status,created_by,created_date) 
	 values(@company_id,@branch_id,@party_id,@po_no,@financialyear_id,@Po_Date,@total_tax,@discount,@actual_amount,@grand_total,1,@created_by,@created_date)
     Commit Transaction
End Try
Begin Catch 


End Catch 
   End


