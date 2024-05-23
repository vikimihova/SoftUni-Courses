--13.All employees except marketing

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [DepartmentID] NOT IN (4)