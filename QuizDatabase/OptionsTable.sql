/*
The database must have a MEMORY_OPTIMIZED_DATA filegroup
before the memory optimized object can be created.

The bucket count should be set to about two times the 
maximum expected number of distinct values in the 
index key, rounded up to the nearest power of two.
*/

CREATE TABLE [dbo].[OptionsTable]
(
	[Id] INT NOT NULL PRIMARY KEY NONCLUSTERED HASH WITH (BUCKET_COUNT = 131072), 
    [Question_statement] NCHAR(10) NULL, 
    [Time] DATETIME NULL, 
    [CorrectAnswer] NCHAR(10) NULL, 
    [Options] NCHAR(10) NULL, 
    [Question_type] NCHAR(10) NULL
) WITH (MEMORY_OPTIMIZED = ON)