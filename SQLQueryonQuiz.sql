CREATE TABLE [Question] (
    [QuestionId] int NOT NULL IDENTITY,
    [QuizId] int NOT NULL,
    [Question_statement] nvarchar(max),
    [Time] datetime,
	[CorrectAnswer] nvarchar(max),
	[Options] nvarchar(max),
	[QuestionType] nvarchar(max),
    CONSTRAINT [PK_Question] PRIMARY KEY ([QuestionId]),
    CONSTRAINT [FK_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [Quiz] ([QuizId]) ON DELETE CASCADE ON UPDATE CASCADE
);