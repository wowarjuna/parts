CREATE VIEW dbo.VItemSearch WITH SCHEMABINDING AS                       
SELECT     i.Id, i.Name AS ItemName, i.Description AS ItemDescription, i.Year AS YearOfManu, c.Name AS Category, mo.Name AS Model, m.Name AS Make, v.City,
i.Name + ' ' + i.Description as Meta, i.MetaModels, g.GalleryId, g.PrimaryResource as Image
FROM         dbo.Items AS i INNER JOIN
                      dbo.ItemsInCategories AS ic ON i.Id = ic.ItemId INNER JOIN
                      dbo.Categories AS c ON ic.CategoryId = c.Id INNER JOIN
                      dbo.ItemsInModels AS im ON im.ItemId = i.Id INNER JOIN
                      dbo.Models AS mo ON im.ModelId = mo.Id INNER JOIN
                      dbo.Make AS m ON i.Make = m.Id INNER JOIN
                      dbo.Vendors AS v ON i.VendorId = v.Id INNER JOIN 
                      dbo.Galleries as g on g.ItemId = i.Id
                      where g.Name = 'Default'
                      
                     
  create unique clustered  index IItemSearchView on  VItemSearch(Id)