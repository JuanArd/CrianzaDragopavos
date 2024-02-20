CREATE PROCEDURE [dbo].[ObtenerCruces]
	@TipoMontura INT
AS
	SET NOCOUNT ON;

	SELECT Id,
	       TipoMonturaId,
		   TipoId_Masculino,
		   TipoId_Femenino,
		   TipoIdResultado
	 FROM dbo.CruceMontura
	WHERE TipoMonturaId = @TipoMontura;