CREATE TABLE [dbo].[FavoriteAccount] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (25) NOT NULL,
    [AccountNumber] NVARCHAR (20) NOT NULL,
    [CustomerId]    INT           NOT NULL,
    [BankId]        INT           NOT NULL,
    CONSTRAINT [FK_FavoriteAccount_Bank] FOREIGN KEY ([BankId]) REFERENCES [dbo].[Bank] ([Id]),
    CONSTRAINT [FK_FavoriteAccount_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

