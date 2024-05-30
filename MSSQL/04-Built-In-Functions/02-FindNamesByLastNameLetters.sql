--02.Find names by last name letters

SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'