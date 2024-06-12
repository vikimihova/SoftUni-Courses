--05.Salary level function

CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
        RETURNS NVARCHAR(10)
          BEGIN
              DECLARE @SalaryLevel NVARCHAR(10)

              IF (@salary < 30000)
              BEGIN
                  SET @SalaryLevel = 'Low'
              END
              ELSE IF (@salary <= 50000)
              BEGIN
                  SET @SalaryLevel = 'Average'
              END
              ELSE IF (@salary > 50000)
              BEGIN
                  SET @SalaryLevel = 'High'
              END

              RETURN @SalaryLevel
            END

GO

SELECT dbo.ufn_GetSalaryLevel (13500)