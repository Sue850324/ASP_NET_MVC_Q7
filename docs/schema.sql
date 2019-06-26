CREATE TABLE [dbo].[ToDoListModels] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Subject] NVARCHAR (MAX) NULL,
    [Status]  BIT            NOT NULL,
    CONSTRAINT [PK_dbo.ToDoListModels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

