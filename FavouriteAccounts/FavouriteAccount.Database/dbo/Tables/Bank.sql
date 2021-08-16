CREATE TABLE [dbo].[Bank] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Code] NVARCHAR (4)  NOT NULL,
    [Name] NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED ([Id] ASC)
);

