--22.Biggest countries by population

SELECT TOP(30) [CountryName], [Population]
	      FROM [Countries]
		 WHERE [ContinentCode] = 'EU'
	  ORDER BY [Population] DESC