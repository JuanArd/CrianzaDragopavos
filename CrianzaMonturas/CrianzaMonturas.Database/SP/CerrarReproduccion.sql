CREATE PROCEDURE CerrarReproduccion
	@Padre INT,
	@Madre INT
AS
	UPDATE Montura SET Fecundada = 0 WHERE Id IN (@Padre, @Madre);