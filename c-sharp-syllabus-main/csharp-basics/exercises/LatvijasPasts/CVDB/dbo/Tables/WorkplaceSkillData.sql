CREATE TABLE WorkplaceSkillData (
    SkillId INT PRIMARY KEY IDENTITY(1,1),
    SkillDescription VARCHAR(50) NOT NULL,
    SkillType VARCHAR(50) NOT NULL,
    WorkplaceId INT NOT NULL,
    CONSTRAINT [FK_WorkplaceSkillData_WorkplaceData] FOREIGN KEY ([WorkplaceId]) REFERENCES [dbo].[WorkplaceData]([Id])
    ON DELETE CASCADE
);
