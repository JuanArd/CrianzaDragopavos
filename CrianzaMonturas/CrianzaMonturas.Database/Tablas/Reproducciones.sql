CREATE TABLE [dbo].[Reproducciones] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [MonturaMachoId]    INT      NOT NULL,
    [MonturaHembraId]   INT      NOT NULL,
    [FechaReproduccion] DATETIME NULL,
    [CriaId]            INT      NULL,
    [FechaNacimiento]   DATETIME NULL,
    CONSTRAINT [PK_Reproducciones] PRIMARY KEY CLUSTERED ([Id] ASC)
);

