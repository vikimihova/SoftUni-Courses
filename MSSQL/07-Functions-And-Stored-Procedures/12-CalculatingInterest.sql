--12.Calculating interest

CREATE PROC usp_CalculateFutureValueForAccount @accountId INT, @interestRate FLOAT
AS
BEGIN
    SELECT [ah].[Id] AS [Account Id]
         , [ah].[FirstName] AS [FirstName]
         , [ah].[LastName] AS [LastName]
         , [a].[TotalBalance] AS [Current Balance]
         , dbo.ufn_CalculateFutureValue([a].[TotalBalance], @interestRate, 5) AS [Balance in 5 years]
      FROM (SELECT [AccountHolderId]
                 , SUM([Balance]) AS [TotalBalance]
              FROM [Accounts]
             GROUP BY [AccountHolderId]) AS [a]
      JOIN [AccountHolders] AS [ah]
        ON [a].[AccountHolderId] = [ah].[Id]
     WHERE [a].[AccountHolderId] = @accountId

END

GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1