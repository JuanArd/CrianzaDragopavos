CREATE PROCEDURE [dbo].[ObtenerMonturas]
	@TipoMontura INT
AS
	SET NOCOUNT ON

	SELECT * 
	 FROM dbo.Montura
	WHERE TipoMonturaId = @TipoMontura
		AND (Esteril = 0
			AND Reproducible = 1)
		OR (Esteril = 1
			AND Fecundada = 1)
	ORDER BY TipoId,
			Nombre;