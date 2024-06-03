--18.Higest peak name and elevation by country

select top(5)  Country
             , PeakName as [Highest Peak Name]
             , Elevation as [Highest Peak Elevation]
             , Mountain
        from 
             (
              select c.CountryName as [Country]
                   , case when mc.MountainId is null
                          then '(no highest peak)'
                          else p.PeakName
                     end as [PeakName]
                   , case when mc.MountainId is null
                          then 0
                          else p.Elevation
                     end as [Elevation]
                   , case when mc.MountainId is null
                          then '(no mountain)'
                          else m.MountainRange
                     end as [Mountain]
                   , dense_rank() over
                     (partition by c.CountryName
                      order by p.Elevation desc, p.PeakName) as [RowRank]
                from Countries as [c]
                left join MountainsCountries as [mc]
                  on c.CountryCode = mc.CountryCode
                left join Mountains as [m]
                  on mc.MountainId = m.Id
                left join Peaks as [p]
                  on mc.MountainId = p.MountainId
             ) 
          as [AllPeaksPerCountrySubquery]
       where RowRank = 1
       order by Country, PeakName

