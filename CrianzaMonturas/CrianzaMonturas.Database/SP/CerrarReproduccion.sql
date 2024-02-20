CREATE PROCEDURE CerrarReproduccion
	@Padre int,
	@Madre int
AS
	UPDATE Montura SET Fecundada = 0 WHERE Id IN (@Padre, @Madre);