--15.Continents and currencies

SELECT [ContinentCode]
     , [CurrencyCode]
     , [CurrencyUsage]
  FROM (
           SELECT [ContinentCode]
                , [CurrencyCode]
	            , COUNT([CountryName]) AS [CurrencyUsage]
                , DENSE_RANK() OVER 
                  (PARTITION BY [ContinentCode] 
                   ORDER BY COUNT([CountryName]) DESC) AS [CurrencyRank]
             FROM [Countries]
            GROUP BY [ContinentCode]
                   , [CurrencyCode]
           HAVING COUNT([CountryName]) > 1
       ) 
    AS [CurrencyUsagePerContinentRankedSubquery]
 WHERE [CurrencyRank] = 1
