create procedure UpdateMetaModels
as
DECLARE @Names VARCHAR(8000)
declare @Id int 
DECLARE item_cursor CURSOR FOR select Id from Items where MetaModels is null
open item_cursor

FETCH NEXT FROM item_cursor into @Id
WHILE @@FETCH_STATUS = 0
BEGIN
set @Names = ''
select @Names = COALESCE(@Names + ', ','') + m.Name from Items i inner join ItemsInModels im on i.Id = im.ItemId
 inner join Models m on im.ModelId = m.Id
 where i.Id = @Id
 update Items set MetaModels = @Names where Id = @Id
FETCH NEXT FROM item_cursor 
    INTO @Id
END 
CLOSE item_cursor
DEALLOCATE item_cursor
