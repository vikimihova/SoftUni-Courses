--12.Five best paid employees

  SELECT TOP(5) [FirstName], [LastName]
		   FROM [Employees]
	   ORDER BY [Salary] DESC