CREATE TABLE [dbo].[LanguageData] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Language] VARCHAR(50) NOT NULL,
    [PrimaryDataId] INT NOT NULL,
    CONSTRAINT [FK_LanguageData_PrimaryData] FOREIGN KEY ([PrimaryDataId]) REFERENCES [dbo].[PrimaryData]([Id])
    ON DELETE CASCADE
);