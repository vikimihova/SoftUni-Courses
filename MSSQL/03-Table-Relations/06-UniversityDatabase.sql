--06.University Database

CREATE TABLE [Subjects]
(
	[SubjectID] INT PRIMARY KEY IDENTITY(1,1)
  ,	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Majors]
(
	[MajorID] INT PRIMARY KEY IDENTITY(1,1)
  ,	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY IDENTITY(1,1)
  ,	[StudentNumber] INT NOT NULL
  ,	[StudentName] VARCHAR(50) NOT NULL
  ,	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
)

CREATE TABLE [Payments]
(
	[PaymentID] INT PRIMARY KEY IDENTITY(1,1)
  ,	[PaymentDate] DATETIME2 NOT NULL
  ,	[PaymentAmount] DECIMAL(8,2) NOT NULL
  ,	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
)

CREATE TABLE [Agenda]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
  ,	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]) NOT NULL
  ,	PRIMARY KEY ([StudentID], [SubjectID])
)