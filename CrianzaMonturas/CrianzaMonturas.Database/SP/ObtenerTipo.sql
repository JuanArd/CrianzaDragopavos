CREATE PROCEDURE ObtenerTipo
	@TipoMontura INT
AS
	SELECT * 
	 FROM Tipo
	WHERE TipoMonturaId = @TipoMontura;