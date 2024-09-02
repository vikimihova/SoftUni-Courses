--16.Countries without any mountains

SELECT COUNT(*) AS [Count]
  FROM (
        SELECT [CountryName]
          FROM [Countries] AS [c]
     LEFT JOIN [MountainsCountries] AS [mc]
            ON [c].[CountryCode] = [mc].[CountryCode]
         WHERE [mc].[CountryCode] IS NULL
       ) 
    AS [CountriesWithNoMountains]

