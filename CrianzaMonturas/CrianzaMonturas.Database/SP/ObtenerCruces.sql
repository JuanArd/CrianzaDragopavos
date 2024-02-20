CREATE PROCEDURE [dbo].[ObtenerCruces]
	@TipoMontura INT
AS
	SET NOCOUNT ON

	SELECT * 
	 FROM dbo.CruceMontura
	WHERE TipoMonturaId = @TipoMontura;