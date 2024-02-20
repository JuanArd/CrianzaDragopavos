CREATE PROCEDURE [dbo].[InsertarReproduccion]
	@Padre INT,
	@Madre INT
AS

	SET QUOTED_IDENTIFIER ON;
	SET NOCOUNT ON;

	INSERT INTO dbo.Reproducciones
	VALUES (@Padre, @Madre, SYSDATETIME(), NULL, NULL);

	UPDATE dbo.Montura SET Reproducciones = (Reproducciones + 1), Fecundada = 1 WHERE Id IN (@Padre, @Madre);
	UPDATE dbo.Montura SET Esteril = 1, Reproducible = 0 WHERE Id IN (@Padre, @Madre) AND Reproducciones = MaxReproducciones;