--15.Continents and currencies

select ContinentCode
     , CurrencyCode
     , CurrencyUsage
  from (
           select ContinentCode
                , CurrencyCode
	            , count(CountryName) as [CurrencyUsage]
                , dense_rank() over 
                  (partition by ContinentCode 
                   order by count(CountryName) desc) as [CurrencyRank]
             from Countries
            group by ContinentCode, CurrencyCode
           having count(CountryName) > 1
       ) 
    as [CurrencyUsagePerContinentRankedSubquery]
 where CurrencyRank = 1
