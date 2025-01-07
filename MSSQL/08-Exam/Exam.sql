CREATE DATABASE [LibraryDb]

GO

USE [LibraryDb]

GO

--01.DDL

CREATE TABLE [Genres]
(
    [Id] INT PRIMARY KEY IDENTITY
  , [Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [Contacts]
(
    [Id] INT PRIMARY KEY IDENTITY
  , [Email] NVARCHAR(100)
  , [PhoneNumber] NVARCHAR(20)
  , [PostAddress] NVARCHAR(200)
  , [Website] NVARCHAR(50)
)

CREATE TABLE [Authors]
(
    [Id] INT PRIMARY KEY IDENTITY
  , [Name] NVARCHAR(100) NOT NULL
  , [ContactId] INT FOREIGN KEY REFERENCES [Contacts]([Id]) NOT NULL
)

CREATE TABLE [Libraries]
(
    [Id] INT PRIMARY KEY IDENTITY
  , [Name] NVARCHAR(50) NOT NULL
  , [ContactId] INT FOREIGN KEY REFERENCES [Contacts]([Id]) NOT NULL
)

CREATE TABLE [Books]
(
    [Id] INT PRIMARY KEY IDENTITY
  , [Title] NVARCHAR(100) NOT NULL
  , [YearPublished] INT NOT NULL
  , [ISBN] NVARCHAR(13) UNIQUE NOT NULL
  , [AuthorId] INT FOREIGN KEY REFERENCES [Authors]([Id]) NOT NULL
  , [GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL
)

CREATE TABLE [LibrariesBooks]
(
    [LibraryId] INT FOREIGN KEY REFERENCES [Libraries]([Id])
  , [BookId] INT FOREIGN KEY REFERENCES [Books]([Id])
  , PRIMARY KEY([LibraryId], [BookId])
)

GO

--02.Insert

INSERT INTO [Contacts] ([Email], [PhoneNumber], [PostAddress], [Website])
VALUES (NULL, NULL, NULL, NULL)
     , (NULL, NULL, NULL, NULL)
     , ('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com')
     , ('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

INSERT INTO [Authors] ([Name], [ContactId])
VALUES ('George Orwell', 21)
     , ('Aldous Huxley', 22)
     , ('Stephen King', 23)
     , ('Suzanne Collins', 24)

INSERT INTO [Books] ([Title], [YearPublished], [ISBN], [AuthorId], [GenreId])
VALUES ('1984', 1949, '9780451524935', 16, 2)
     , ('Animal Farm', 1945, '9780451526342', 16, 2)
     , ('Brave New World', 1932, '9780060850524', 17, 2)
     , ('The Doors of Perception', 1954, '9780060850531', 17, 2)
     , ('The Shining', 1977, '9780307743657', 18, 9)
     , ('It', 1986, '9781501142970', 18, 9)
     , ('The Hunger Games', 2008, '9780439023481', 19, 7)
     , ('Catching Fire', 2009, '9780439023498', 19, 7)
     , ('Mockingjay', 2010, '9780439023511', 19, 7)

INSERT INTO [LibrariesBooks] ([LibraryId], [BookId])
VALUES (1, 36)
     , (1, 37)
     , (2, 38)
     , (2, 39)
     , (3, 40)
     , (3, 41)
     , (4, 42)
     , (4, 43)
     , (5, 44)

--03.Update

UPDATE [Contacts]
   SET [Website] = [sub].[NewWebsite]
  FROM [Contacts] AS [c]
  JOIN (SELECT [a].[Name]
             , [a].[ContactId]
             , CONCAT('www.', REPLACE(LOWER([a].[Name]), ' ' , ''), '.com') AS [NewWebsite]
          FROM [Authors] AS [a]
          JOIN [Contacts] AS [c]
            ON [a].[ContactId] = [c].[Id]
         WHERE [c].[Website] IS NULL) 
    AS [sub]
    ON [c].[Id] = [sub].[ContactId]
 WHERE [c].[Website] IS NULL

SELECT * FROM [Contacts]

GO


--04. Delete

DELETE FROM [LibrariesBooks]
      WHERE [BookId] = (SELECT [b].[Id]
                          FROM [Books] AS [b]
                          JOIN [Authors] AS [a]
                            ON [b].[AuthorId] = [a].[Id]
                         WHERE [a].[Name] = 'Alex Michaelides')

DELETE FROM [Books]
      WHERE [Id] = (SELECT [b].[Id]
                      FROM [Books] AS [b]
                      JOIN [Authors] AS [a]
                        ON [b].[AuthorId] = [a].[Id]
                     WHERE [a].[Name] = 'Alex Michaelides')

DELETE FROM [Authors]
      WHERE [Name] = 'Alex Michaelides' 

--05.Books by year of publication

SELECT [Title] AS [Book Title]
     , [ISBN] 
     , [YearPublished] AS [YearReleased]
  FROM [Books]
 ORDER BY [YearPublished] DESC
        , [Title]

--06.Books by genre

SELECT [b].[Id]
     , [b].[Title]
     , [b].[ISBN] 
     , [g].[Name] AS [Genre]
  FROM [Books] AS [b]
  JOIN [Genres] AS [g]
    ON [b].[GenreId] = [g].[Id]
 WHERE [g].[Name] IN ('Biography', 'Historical Fiction')
 ORDER BY [Genre]
        , [Title]


--07.Missing genre

SELECT [l].[Name] AS [Library]
     , [c].[Email]
  FROM [Libraries] AS [l]
  JOIN [Contacts] AS [c]
    ON [l].[ContactId] = [c].[Id]
 WHERE [l].[Id] NOT IN (SELECT [lb].[LibraryId]
                          FROM [LibrariesBooks] AS [lb]
                          JOIN [Books] AS [b]
                            ON [lb].[BookId] = [b].[Id]
                         WHERE [lb].[BookId] = (SELECT [b].[Id]
                                                  FROM [Books] AS [b]
                                                  JOIN [Genres] AS [g]
                                                    ON [b].[GenreId] = [g].[Id]
                                                 WHERE [g].[Name] = 'Mystery'))
 ORDER BY [l].[Name]


--08. First 3 books

SELECT TOP(3) [b].[Title]
            , [b].[YearPublished] AS [Year]
            , [g].[Name] AS [Genre]
         FROM [Books] AS [b]
         JOIN [Genres] AS [g]
           ON [b].[GenreId] = [g].[Id]
        WHERE ([YearPublished] > 2000 AND CHARINDEX('a', [b].[Title], 1) <> 0)
           OR ([YearPublished] < 1950 AND [g].[Name] LIKE '%Fantasy%')
        ORDER BY [b].[Title]
               , [YearPublished] DESC

--09. Authors from UK

SELECT [a].[Name] AS [Author]
     , [c].[Email]
     , [c].[PostAddress] AS [Address]
  FROM [Authors] AS [a]
  JOIN [Contacts] AS [c]
    ON [a].[ContactId] = [c].[Id]
 WHERE [c].[PostAddress] LIKE '%UK%'
 ORDER BY [a].[Name]

 --10.Fictions in Denver
 
SELECT [a].[Name] AS [Author]
     , [b].[Title]
     , [l].[Name] AS [Library]
     , [c].[PostAddress] AS [Library Address]
  FROM [Books] AS [b]
  JOIN [Genres] AS [g]
    ON [b].[GenreId] = [g].[Id]
  JOIN [Authors] AS [a]
    ON [b].[AuthorId] = [a].[Id]
  JOIN [LibrariesBooks] AS [lb]
    ON [b].[Id] = [lb].[BookId] 
  JOIN [Libraries] AS [l]
    ON [lb].[LibraryId] = [l].[Id]
  JOIN [Contacts] AS [c]
    ON [l].[ContactId] = [c].[Id]
 WHERE [g].[Name] = 'Fiction'
   AND [lb].[LibraryId] = (SELECT [l].[Id]
                             FROM [Libraries] AS [l]
                             JOIN [Contacts] AS [c]
                               ON [l].[ContactId] = [c].[Id]
                            WHERE [c].[PostAddress] LIKE '%Denver%')
 ORDER BY [b].[Title]

--11. Authors with books

GO

CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100))
RETURNS INT
BEGIN 
     DECLARE @countOfBooks INT = (     
                                  SELECT COUNT(*)
                                    FROM [Books] AS [b]
                                    JOIN [Authors] AS [a]
                                      ON [b].[AuthorId] = [a].[Id]
                                   WHERE [a].[Name] = @name  
                                   )
     RETURN @countOfBooks
END

GO

SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling')

--12. Search by genre
GO

CREATE PROC usp_SearchByGenre(@genreName NVARCHAR(30))
AS
BEGIN 
        SELECT [b].[Title]
             , [b].[YearPublished] AS [Year]
             , [b].[ISBN]
             , [a].[Name] AS [Author]
             , @genreName AS [Genre]
          FROM [Books] AS [b]
          JOIN [Genres] AS [g]
            ON [b].[GenreId] = [g].[Id]
          JOIN [Authors] AS [a]
            ON [b].[AuthorId] = [a].[Id]
         WHERE [g].[Name] = @genreName
         ORDER BY [b].[Title]
END

 GO

 EXEC usp_SearchByGenre 'Fantasy'