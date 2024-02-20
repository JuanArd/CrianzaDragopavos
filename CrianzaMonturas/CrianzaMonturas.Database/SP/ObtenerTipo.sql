CREATE PROCEDURE ObtenerTipo
	@TipoMontura INT
AS
	SET NOCOUNT ON

	SELECT * 
	 FROM dbo.Tipo
	WHERE TipoMonturaId = @TipoMontura;