--03. Many-To-Many Relationship

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY IDENTITY(1,1)
  ,	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Exams]
(
	[ExamID] INT PRIMARY KEY IDENTITY(1,1)
  ,	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [StudentsExams]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
  ,	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]) NOT NULL
)

   ALTER TABLE [StudentsExams]
ADD CONSTRAINT [PK_StudentsExams]
   PRIMARY KEY([StudentID], [ExamID])
