--05.Find towns with name length

SELECT [Name]
  FROM [Towns]
 WHERE LEN([Name]) BETWEEN 5 AND 6 
 ORDER BY [Name]