--17.Highest peak and longest river by country

SELECT TOP (5) [CountryName]
             , [HighestPeakElevation]
             , [LongestRiverLength]
      FROM
          (
             SELECT [c].[CountryName]
                  , [p].[Elevation] AS [HighestPeakElevation]
                  , [r].[Length] AS [LongestRiverLength]
                  , DENSE_RANK() OVER 
                    (PARTITION BY [c].[CountryName]
                     ORDER BY [p].[Elevation] DESC 
                            , [r].[Length] DESC) AS [RowRank]
               FROM [Countries] AS [c]
               LEFT JOIN [CountriesRivers] AS [cr]
                 ON [c].[CountryCode] = [cr].[CountryCode]
               LEFT JOIN [Rivers] AS [r]
                 ON [cr].[RiverId] = [r].[Id]
               LEFT JOIN [MountainsCountries] AS [mc]
                 ON [c].[CountryCode] = [mc].[CountryCode]
               LEFT JOIN [Peaks] AS [p]
                 ON [mc].[MountainId] = [p].[MountainId]
           ) 
        AS [AllCountriesMountainsRiversSubquery]
     WHERE [RowRank] = 1
     ORDER BY [HighestPeakElevation] DESC 
            , [LongestRiverLength] DESC
            , [CountryName]

