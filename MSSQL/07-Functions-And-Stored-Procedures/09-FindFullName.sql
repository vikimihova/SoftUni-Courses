--09.Find full name

CREATE PROC usp_GetHoldersFullName 
AS
BEGIN
    SELECT CONCAT([FirstName], ' ', [LastName]) AS [Full Name]
    FROM [AccountHolders]
END

GO

EXEC usp_GetHoldersFullName