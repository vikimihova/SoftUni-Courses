--04.Find all employees except engineers

SELECT [FirstNAme]
     , [LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'