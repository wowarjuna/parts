USE [parts]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_stocklot_charts]    Script Date: 2/16/2015 5:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_get_stocklot_charts]
@storeid int,
@from datetime,
@to datetime
as
select convert(nvarchar(MAX), sl.Created, 2) + ' ' + sl.Name as Name, sl.Value as QuotedVal,
(select sum(s.UnitPrice * s.Qty) from Sales s INNER JOIN Items i on s.ItemId = i.Id where i.StocklotId = sl.Id) as [Return] from Stocklots sl
where sl.Created between @from and @to