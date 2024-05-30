--01.FindNamesByFirstName

SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'