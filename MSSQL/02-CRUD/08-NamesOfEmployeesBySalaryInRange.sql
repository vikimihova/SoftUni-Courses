--08.Find names of all employees by salary in range

SELECT [FirstName]
     , [LastName]
     , [JobTitle]
  FROM [Employees]
 WHERE [Salary] BETWEEN 20000 AND 30000