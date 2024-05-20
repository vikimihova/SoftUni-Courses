--13.Movies Database
CREATE DATABASE Movies
USE Movies;
GO;

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT,
	[Length] INT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating DECIMAL(2,1),
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName)
VALUES 
('Denis Villenueve'),
('Martin Scorcese'),
('Quentin Tarantino'),
('Steven Spielberg'),
('Wes Anderson')

INSERT INTO Genres (GenreName)
VALUES
('horror'),
('comedy'),
('science-fiction'),
('action'),
('drama')

INSERT INTO Categories (CategoryName)
VALUES
('trilogy'),
('stand-alone'),
('series'),
('short-film'),
('trailer')

INSERT INTO Movies (Title, DirectorId, GenreId, CategoryId)
VALUES
('Dune', 1, 3, 1),
('Jurassic Park', 4, 3, 3),
('The Irishman', 2, 5, 2),
('Once Upon a Time in Hollywood', 3, 1, 2),
('Hotel Budapest', 5, 2, 2)