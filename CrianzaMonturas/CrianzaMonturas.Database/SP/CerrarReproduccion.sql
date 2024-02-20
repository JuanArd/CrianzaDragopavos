CREATE PROCEDURE CerrarReproduccion
	@Padre INT,
	@Madre INT
AS
	SET QUOTED_IDENTIFIER ON
	SET NOCOUNT ON

	UPDATE dbo.Montura SET Fecundada = 0 WHERE Id IN (@Padre, @Madre);