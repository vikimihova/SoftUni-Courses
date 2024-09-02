--07.Define function

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(10), @word NVARCHAR(20)) 
        RETURNS BIT
             AS
          BEGIN
                DECLARE @isComprised BIT
                    SET @isComprised = 1
          
                DECLARE @currentIndex INT
                    SET @currentIndex = 1
          
                WHILE (@currentIndex <= LEN(@word))
                BEGIN
                       DECLARE @pattern NVARCHAR(5)
                           SET @pattern = '%' + SUBSTRING(LOWER(@word), @currentIndex, 1) + '%'
                
                            IF (@setOfLetters NOT LIKE @pattern)
                            BEGIN
                                    RETURN 0 
                            END
                            
                           SET @currentIndex = @currentIndex + 1
                  END
          
                RETURN @isComprised
            END

GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
     , dbo.ufn_IsWordComprised('oistmiahf', 'halves')

     