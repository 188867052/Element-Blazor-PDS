CREATE TRIGGER [dbo].[药品入库出库时自动修改]
   ON  [dbo].[DrugStocks]
   AFTER INSERT
AS 
BEGIN
	
	SET NOCOUNT ON;

	Declare @amount int ;
	Declare @drugid int ;
	Select @amount=Amount From inserted 
	Select @drugid=DrugId From inserted
		Begin
			Update  Drugs set Drugs.amount =Drugs.amount+@amount where id =@drugid
		End
    
END
GO
------------------------------------------------
CREATE PROCEDURE [dbo].[某段时间内各科室的就诊情况]
	@start datetime,
	@end datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select d.Name as '科室' ,count(1) as '就诊人数'  from  Departments d 
	join Doctor dc on dc.DepartmentId= p.id
	join patients p on d.doctorid= dc.id
 where p.createtime >=@start and  p.createtime <=@end
	group by  d.Name
END
GO
---------------------------------------------
CREATE VIEW [dbo].[查看各种药品的库存总数]
AS
SELECT Name as '药品名称', Amount  as '库存总数'
FROM   dbo.Drugs
GO