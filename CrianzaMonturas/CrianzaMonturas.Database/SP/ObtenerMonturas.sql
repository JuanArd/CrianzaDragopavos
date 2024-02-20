CREATE PROCEDURE [dbo].[ObtenerMonturas]
	@TipoMontura INT
AS
	SET NOCOUNT ON;

	SELECT Id,
		   Nombre,
		   Salvaje,
		   Sexo,
		   TipoMonturaId,
		   TipoId,
		   Predispuesto,
		   Padre,
		   Madre,
		   Reproducciones,
		   MaxReproducciones,
		   Esteril,
		   Reproducible,
		   Fecundada,
		   CantPureza
	 FROM dbo.Montura
	WHERE TipoMonturaId = @TipoMontura
		AND (Esteril = 0
			AND Reproducible = 1)
		OR (Esteril = 1
			AND Fecundada = 1)
	ORDER BY TipoId,
			Nombre;