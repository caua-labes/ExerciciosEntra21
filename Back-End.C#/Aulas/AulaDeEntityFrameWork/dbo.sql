CREATE TABLE [dbo].[Contato] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Nome]  NVARCHAR (MAX) NOT NULL,
    [Email] NVARCHAR (MAX) NOT NULL,
    [Fone]  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Contato] PRIMARY KEY CLUSTERED ([Id] ASC)
);
