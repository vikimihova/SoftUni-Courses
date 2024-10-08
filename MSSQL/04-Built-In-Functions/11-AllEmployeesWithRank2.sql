--11.All employees with rank 2

 SELECT *
   FROM
(SELECT [EmployeeID]
      , [FirstName]
      , [LastName]
      , [Salary]
      , DENSE_RANK() OVER 
        (PARTITION BY [Salary] 
         ORDER BY [EmployeeID]) 
         AS [Rank]
   FROM [Employees]
  WHERE [Salary] BETWEEN 10000 AND 50000) 
     AS [Subquery]
  WHERE [Rank] = 2   
  ORDER BY [Salary] DESC