--12.Highest peaks in Bulgaria

  select mc.CountryCode
	   , m.MountainRange
	   , p.PeakName
	   , p.Elevation
	from MountainsCountries as [mc]
	join Mountains as [m]
	  on mc.MountainId = m.Id
	join Peaks as [p] 
	  on m.Id = p.MountainId	
   where mc.CountryCode = 'BG'
     and p.Elevation > 2835
   order by p.Elevation desc








  SELECT mc.CountryCode,
		 m.MountainRange,
		 p.PeakName,
		 p.Elevation
	FROM MountainsCountries AS [mc]
	JOIN Mountains AS [m] 
      ON mc.MountainId = m.Id
	JOIN Peaks AS [p]
	  ON m.Id = p.MountainId	
   WHERE mc.CountryCode = 'BG'
     AND p.Elevation > 2835
   ORDER BY p.Elevation DESC





