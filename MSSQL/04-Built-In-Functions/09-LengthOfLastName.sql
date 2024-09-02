--09.Length of last name

SELECT [FirstName]
     , [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5