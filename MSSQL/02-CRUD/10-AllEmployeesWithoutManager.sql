--10.Find all employees without manager

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [ManagerID] IS NULL