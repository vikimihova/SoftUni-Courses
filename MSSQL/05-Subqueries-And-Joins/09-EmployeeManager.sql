--09.Employee manager

SELECT [e].EmployeeID,
	   [e].[FirstName],
	   [e].[ManagerID],
	   [m].[FirstName]
FROM [Employees] AS [e]
JOIN [Employees] AS [m] ON [e].ManagerID = [m].[ManagerID]
WHERE [m].[ManagerID] IN (3, 7)