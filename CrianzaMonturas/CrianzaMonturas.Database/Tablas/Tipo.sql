CREATE TABLE [dbo].[Tipo] (
    [TipoMonturaId] INT          NOT NULL,
    [Id]            INT          NOT NULL,
    [Alias]         VARCHAR (50) NOT NULL,
    [Nombre]        VARCHAR (50) NOT NULL,
    [Imagen]        IMAGE        NULL,
    [Sigla]         VARCHAR (10) NULL,
    [Generacion]    INT          NULL,
    CONSTRAINT [PK_Tipo_Id_TipoMonturaId] PRIMARY KEY CLUSTERED ([TipoMonturaId] ASC, [Id] ASC)
)
WITH (DATA_COMPRESSION = ROW);

