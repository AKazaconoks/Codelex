CREATE TABLE EducationData (
    EducationId INT PRIMARY KEY IDENTITY(1,1),
    EducationName VARCHAR(50) NOT NULL,
    EducationFaculty VARCHAR(50) NOT NULL,
    EducationDirection VARCHAR(50) NOT NULL,
    EducationLevel VARCHAR(50) NOT NULL,
    EducationStatus VARCHAR(50) NOT NULL,
    PrimaryDataId INT NOT NULL,
    CONSTRAINT [FK_EducationData_PrimaryData] FOREIGN KEY ([PrimaryDataId]) REFERENCES [dbo].[PrimaryData]([Id])
    ON DELETE CASCADE
);