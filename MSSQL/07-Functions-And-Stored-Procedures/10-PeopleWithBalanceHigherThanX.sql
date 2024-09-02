--10.People with balance higher than x

CREATE PROC usp_GetHoldersWithBalanceHigherThan @threshold DECIMAL(18,4)
AS
BEGIN
    SELECT [FirstName] AS [First Name]
         , [LastName] AS [Last Name]
      FROM [AccountHolders]
     WHERE [Id] IN (SELECT [AccountHolderId]
                      FROM [Accounts]
                     GROUP BY [AccountHolderId]
                    HAVING SUM([Balance]) > @threshold)
     ORDER BY [FirstName]
            , [LastName]
END

GO

EXEC usp_GetHoldersWithBalanceHigherThan 20000

