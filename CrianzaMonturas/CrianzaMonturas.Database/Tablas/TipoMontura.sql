CREATE TABLE [dbo].[TipoMontura] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Nombre] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TipoMontura] PRIMARY KEY CLUSTERED ([Id] ASC)
)
WITH (DATA_COMPRESSION = ROW);

