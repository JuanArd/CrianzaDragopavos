CREATE PROCEDURE [dbo].[ObtenerMonturas]
	@TipoMontura int
as
	SELECT * 
	 FROM Montura
	WHERE TipoMonturaId = @TipoMontura
		AND (Esteril = 0
			AND Reproducible = 1)
		OR (Esteril = 1
			AND Fecundada = 1)
	ORDER BY TipoId,
			Nombre