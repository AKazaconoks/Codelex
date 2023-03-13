CREATE TABLE [dbo].[WorkplaceData] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [PrimaryDataId] INT NOT NULL,
    [WorkplaceName] NVARCHAR(50) NOT NULL,
    [WorkplaceTitle] NVARCHAR(50) NOT NULL,
    [WorkplaceTenure] NVARCHAR(50) NOT NULL,
    CONSTRAINT [FK_WorkplaceData_PrimaryData] FOREIGN KEY ([PrimaryDataId]) REFERENCES [dbo].[PrimaryData]([Id])
    ON DELETE CASCADE
);

