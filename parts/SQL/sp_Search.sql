USE [parts]
GO
/****** Object:  StoredProcedure [dbo].[sp_Search]    Script Date: 10/17/2017 12:55:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Search]
      @category AS INT,
      @brand AS    INT,
      @model AS    VARCHAR(50),
	  @year AS		INT,
      @text AS     VARCHAR(200)
AS
    BEGIN
        IF @text = ''
            BEGIN
                SELECT i.Id,
                       I.Name,
                       I.Description,
                       I.PartNo,
                       I.Year,
                       M.ModelNo AS modelNo,
                       I.QuotedPrice,
				   IM.OriginalName AS image
                FROM Items I
                     INNER JOIN Models M ON I.ModelId = M.Id
                     LEFT JOIN ItemImages IM ON IM.ItemId = I.Id AND IM.IsPrimary = 1
                WHERE( @category = -1
                    OR I.CategoryId = @category
                     )
                 AND ( @brand = -1
                    OR I.BrandId = @brand
                     )

                 AND ( @model = ''
                    OR M.ModelNo LIKE '%' + @model + '%'
                    OR M.Name LIKE '%' + @model + '%'
                     )
					AND (@year = -1 OR I.Year = @year)
                 -- OR  IM.IsPrimary = 1;
            END;
        ELSE
            BEGIN
                SELECT i.Id,
                       I.Name,
                       I.Description,
                       I.PartNo,
                       I.Year,
                       M.ModelNo AS modelNo,
                       I.QuotedPrice,
                       1 AS 'Rnk',
				   (SELECT IM.OriginalName FROM ItemImages IM WHERE IM.ItemId = I.Id AND IM.IsPrimary = 1) AS image
                FROM Items I
                     INNER JOIN Models M ON I.ModelId = M.Id
                WHERE( @category = -1
                    OR I.CategoryId = @category
                     )
                 AND ( @brand = -1
                    OR I.BrandId = @brand
                     )
                 AND ( @model = ''
                    OR M.ModelNo LIKE '%' + @model + '%'
                     )
                 AND ( @text = ''
                    OR I.PartNo LIKE '%' + @text + '%'
                     )
				AND (@year = -1 OR I.Year = @year)
                
                UNION
                SELECT i.Id,
                       I.Name,
                       I.Description,
                       I.PartNo,
                       I.Year,
                       M.ModelNo AS modelNo,
                       I.QuotedPrice,
                       2 AS 'Rnk',
				  (SELECT IM.OriginalName FROM ItemImages IM WHERE IM.ItemId = I.Id AND IM.IsPrimary = 1) 
                FROM Items I
                     INNER JOIN Models M ON I.ModelId = M.Id
                WHERE( @category = -1
                    OR I.CategoryId = @category
                     )
                 AND ( @brand = -1
                    OR I.BrandId = @brand
                     )
                 AND ( @model = ''
                    OR M.ModelNo LIKE '%' + @model + '%'
                     )
                 AND ( @text = ''
                    OR I.Name LIKE '%' + @text + '%'
                     )
					 AND (@year = -1 OR I.Year = @year)
                 
                UNION
                SELECT i.Id,
                       I.Name,
                       I.Description,
                       I.PartNo,
                       I.Year,
                       M.ModelNo AS modelNo,
                       I.QuotedPrice,
                       3 AS 'Rnk',
				   (SELECT IM.OriginalName FROM ItemImages IM WHERE IM.ItemId = I.Id AND IM.IsPrimary = 1) 
                FROM Items I
                     INNER JOIN Models M ON I.ModelId = M.Id
                WHERE( @category = -1
                    OR I.CategoryId = @category
                     )
                 AND ( @brand = -1
                    OR I.BrandId = @brand
                     )
                 AND ( @model = ''
                    OR M.ModelNo LIKE '%' + @model + '%'
                     )
                 AND ( @text = ''
                    OR I.Description LIKE '%' + @text + '%'
                     )
					 AND (@year = -1 OR I.Year = @year)
                 
                ORDER BY Rnk;
            END;
    END;