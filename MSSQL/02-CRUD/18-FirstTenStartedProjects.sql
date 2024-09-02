--18.Find first ten started projects

SELECT TOP(10) *
          FROM [Projects]
         ORDER BY [StartDate]
                , [Name] 