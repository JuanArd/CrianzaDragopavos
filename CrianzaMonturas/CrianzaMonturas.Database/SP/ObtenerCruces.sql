CREATE PROCEDURE [dbo].[ObtenerCruces]
	@TipoMontura INT
AS
	SELECT * 
	 FROM CruceMontura
	WHERE TipoMonturaId = @TipoMontura;