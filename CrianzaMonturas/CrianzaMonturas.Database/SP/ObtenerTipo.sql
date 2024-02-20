CREATE PROCEDURE ObtenerTipo
	@TipoMontura INT
AS
	SET NOCOUNT ON;

	SELECT TipoMonturaId,
		   Id,
		   Alias,
		   Imagen,
		   Sigla,
		   Generacion
	 FROM dbo.Tipo
	WHERE TipoMonturaId = @TipoMontura;