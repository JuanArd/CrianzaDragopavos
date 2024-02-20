CREATE TABLE [dbo].[Montura] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (50) NOT NULL,
    [Salvaje]           BIT          NOT NULL,
    [Sexo]              VARCHAR (50) NOT NULL,
    [TipoMonturaId]     INT          NOT NULL,
    [TipoId]            INT          NOT NULL,
    [Predispuesto]      BIT          NOT NULL,
    [Padre]             INT          NOT NULL,
    [Madre]             INT          NOT NULL,
    [Reproducciones]    TINYINT      NOT NULL,
    [MaxReproducciones] TINYINT      NOT NULL,
    [Esteril]           BIT          NOT NULL,
    [Reproducible]      BIT          NULL,
    [Fecundada]         BIT          NULL,
    [CantPureza]        INT          NULL,
    CONSTRAINT [PK_Montura] PRIMARY KEY CLUSTERED ([Id] ASC)
);

