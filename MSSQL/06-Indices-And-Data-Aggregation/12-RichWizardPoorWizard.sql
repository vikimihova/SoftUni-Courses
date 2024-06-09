--12.Rich wizard, poor wizard

SELECT SUM(Difference) AS [SumDifference]
  FROM (
        SELECT wd.FirstName
             , wd.LastName
             , gw.FirstName AS [GuestFirstName]
             , gw.LastName AS [GuestLastName]
             , (wd.DepositAmount - gw.DepositAmount) AS [Difference]
          FROM WizzardDeposits AS [wd]
          LEFT JOIN WizzardDeposits AS [gw]
            ON wd.Id + 1 = gw.Id
       ) 
    AS [WizardsSubquery]


