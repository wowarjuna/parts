USE [parts]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_sales_charts]    Script Date: 2/16/2015 5:14:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_get_sales_charts]
@storeid int,
@from datetime,
@to datetime
as
select CONVERT(NVARCHAR(7),Created,120) as [Month], sum(s.UnitPrice * s.Qty) as Val  from Sales s inner join Invoices i
on s.InvoiceId = i.Id
where s.StoreId = @storeid
group by CONVERT(NVARCHAR(7),Created,120)