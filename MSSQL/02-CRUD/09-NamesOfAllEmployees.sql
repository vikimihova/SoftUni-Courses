--09.Find names of all employees

SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName]
	AS [Full Name]
  FROM [Employees]
 WHERE [Salary] IN (25000, 14000, 12500, 23600)

