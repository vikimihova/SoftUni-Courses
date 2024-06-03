--17.Highest peak and longest river by country

select TOP (5) CountryName
             , HighestPeakElevation
             , LongestRiverLength
      from
          (
             select c.CountryName
                  , p.Elevation as [HighestPeakElevation]
                  , r.[Length] as [LongestRiverLength]
                  , dense_rank() over 
                    (partition by c.CountryName
                     order by p.Elevation desc 
                            , r.[Length] desc) as [RowRank]
               from Countries as [c]
               left join CountriesRivers as [cr]
                 on c.CountryCode = cr.CountryCode
               left join Rivers as [r]
                 on cr.RiverId = r.Id
               left join MountainsCountries as [mc]
                 on c.CountryCode = mc.CountryCode
               left join Peaks as [p]
                 on mc.MountainId = p.MountainId
           ) 
        as [AllCountriesMountainsRiversSubquery]
     where RowRank = 1
     order by HighestPeakElevation desc 
         , LongestRiverLength desc
         , CountryName

