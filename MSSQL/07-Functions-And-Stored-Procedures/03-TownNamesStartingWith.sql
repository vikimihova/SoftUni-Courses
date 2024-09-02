--03.Town names starting with

CREATE PROC usp_GetTownsStartingWith @NameBeginning NVARCHAR(10)
         AS
      BEGIN
          DECLARE @FullName NVARCHAR(20)
              SET @FullName = @NameBeginning + '%'
           SELECT [Name] AS [Town]
             FROM [Towns]
            WHERE [Name] LIKE @FullName
        END

        GO

        EXEC usp_GetTownsStartingWith 'B'