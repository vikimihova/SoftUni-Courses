--07.Create Table People
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
			CHECK(Gender in('m', 'f')),
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)

--ALTER TABLE People
--ADD CONSTRAINT PK_People
--PRIMARY KEY(Id)

INSERT INTO People ([Name], Gender, Birthdate)
VALUES	('Shterion', 'm', '1989-07-18'),
		('Angelina', 'f', '1989-05-18'),
		('Lazar', 'm', '1989-07-10'),
		('Vladimir', 'm', '1989-03-18'),
		('Veronika', 'f', '1989-02-11')

SELECT * FROM People