CREATE TABLE [dbo].[CruceMontura] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [TipoMonturaId]    INT NOT NULL,
    [TipoId_Masculino] INT NOT NULL,
    [TipoId_Femenino]  INT NOT NULL,
    [TipoIdResultado]  INT NOT NULL,
    CONSTRAINT [PK_CruceMontura] PRIMARY KEY CLUSTERED ([Id] ASC)
)
WITH (DATA_COMPRESSION = ROW);

