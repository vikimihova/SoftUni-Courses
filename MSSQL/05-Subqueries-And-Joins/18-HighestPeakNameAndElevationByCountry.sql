--18.Higest peak name and elevation by country

SELECT TOP(5)  [Country]
             , [PeakName] AS [Highest Peak Name]
             , [Elevation] AS [Highest Peak Elevation]
             , [Mountain]
        FROM 
             (
              SELECT [c].[CountryName] AS [Country]
                   , CASE WHEN [mc].[MountainId] IS NULL
                          THEN '(no highest peak)'
                          ELSE [p].[PeakName]
                     END AS [PeakName]
                   , CASE WHEN [mc].[MountainId] IS NULL
                          THEN 0
                          ELSE [p].[Elevation]
                     END AS [Elevation]
                   , CASE WHEN [mc].[MountainId] IS NULL
                          THEN '(no mountain)'
                          ELSE [m].[MountainRange]
                     END AS [Mountain]
                   , DENSE_RANK() OVER
                     (PARTITION BY [c].[CountryName]
                      ORDER BY [p].[Elevation] DESC, [p].[PeakName]) AS [RowRank]
                FROM [Countries] AS [c]
                LEFT JOIN [MountainsCountries] AS [mc]
                  ON [c].[CountryCode] = [mc].[CountryCode]
                LEFT JOIN [Mountains] AS [m]
                  ON [mc].[MountainId] = [m].[Id]
                LEFT JOIN [Peaks] AS [p]
                  ON [mc].[MountainId] = [p].[MountainId]
             ) 
          AS [AllPeaksPerCountrySubquery]
       WHERE [RowRank] = 1
       ORDER BY [Country]
              , [PeakName]

