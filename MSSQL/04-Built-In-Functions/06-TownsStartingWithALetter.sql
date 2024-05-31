--06.Find towns starting with a letter

  SELECT [TownID],
         [Name]
    FROM [Towns]
   WHERE [Name] LIKE 'M%' OR 
         [Name] LIKE 'K%' OR
         [Name] LIKE 'B%' OR
         [Name] LIKE 'E%'
ORDER BY [Name]

--or

  SELECT [TownID],
         [Name]
    FROM [Towns]
   WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]