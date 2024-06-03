--16.Countries without any mountains

select count(*) as [Count]
  from (
        select CountryName
          from Countries as [c]
     left join MountainsCountries as [mc]
            on c.CountryCode = mc.CountryCode
         where mc.CountryCode IS NULL
       ) 
    as [CountriesWithNoMountains]

