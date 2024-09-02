--07.Find towns not starting with a letter

SELECT [TownID]
     , [Name]
  FROM [Towns]
 WHERE [Name] NOT LIKE 'R%' 
   AND [Name] NOT LIKE 'B%' 
   AND [Name] NOT LIKE 'D%'
 ORDER BY [Name]

-- or

SELECT [TownID]
     , [Name]
  FROM [Towns]
 WHERE [Name] LIKE '[^RBD]%'
 ORDER BY [Name]

