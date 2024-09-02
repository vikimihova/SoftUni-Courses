--19.Salary challenge

--(1. Solution with a subquery in the WHERE clause)

SELECT TOP(10) [e].[FirstName]
             , [e].[LastName]
             , [e].[DepartmentID]
  FROM [Employees] AS [e]
 WHERE [e].[Salary] > 
       (
            SELECT AVG([emp].[Salary]) AS [AverageSalary]
              FROM [Employees] AS [emp]
             GROUP BY [emp].[DepartmentID]
            HAVING [emp].[DepartmentID] = [e].[DepartmentID]
       )
 ORDER BY [e].[DepartmentID]

--(2. Solution with a subquery in the JOIN clause)

SELECT TOP(10) [e].[FirstName]
             , [e].[LastName]
             , [e].[DepartmentID]
  FROM [Employees] AS [e]
  JOIN (
            SELECT [DepartmentID]
                 , AVG([Salary]) AS [AverageSalary]
              FROM [Employees]
             GROUP BY [DepartmentID]
       ) 
    AS [AverageSalaryPerDepartment]
    ON [e].[DepartmentID] = [AverageSalaryPerDepartment].[DepartmentID]
 WHERE [e].[Salary] > [AverageSalaryPerDepartment].[AverageSalary]
 ORDER BY [e].[DepartmentID]

 --(3. Solution with a AVG() OVER (PARTITION BY))

 SELECT TOP(10) [FirstName]
              , [LastName]
              , [DepartmentID]
  FROM (
            SELECT [FirstName]
                 , [LastName]
                 , [DepartmentID]
                 , [Salary]
                 , AVG([Salary]) OVER 
                  (PARTITION BY [DepartmentID]) 
                   AS [AverageSalary]
              FROM [Employees]
       ) AS [SubqueryWithAverageSalary]
 WHERE [Salary] > [AverageSalary]       
 ORDER BY [DepartmentID]



