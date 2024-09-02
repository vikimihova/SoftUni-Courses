--12.Countries with 3 or more 'A's

SELECT [CountryName]
     , [IsoCode]
  FROM [Countries]
 WHERE [CountryName] LIKE '%a%a%a%'
 ORDER BY [IsoCode]