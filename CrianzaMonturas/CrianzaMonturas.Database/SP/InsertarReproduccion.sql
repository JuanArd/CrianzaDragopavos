CREATE PROCEDURE [dbo].[InsertarReproduccion]
	@Padre int,
	@Madre int
AS
	INSERT INTO Reproducciones
	VALUES (@Padre, @Madre, SYSDATETIME(), NULL, NULL);

	UPDATE Montura SET Reproducciones = (Reproducciones + 1), Fecundada = 1 WHERE Id IN (@Padre, @Madre);
	UPDATE Montura SET Esteril = 1, Reproducible = 0 WHERE Id IN (@Padre, @Madre) AND Reproducciones = MaxReproducciones;