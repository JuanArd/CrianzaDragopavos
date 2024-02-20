CREATE PROCEDURE ObtenerTipo
	@TipoMontura int
as
	SELECT * 
	 FROM Tipo
	WHERE TipoMonturaId = @TipoMontura;