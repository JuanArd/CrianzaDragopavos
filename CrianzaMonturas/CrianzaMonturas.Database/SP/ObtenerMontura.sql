CREATE PROCEDURE ObtenerMontura
	@Id INT
AS
	SET NOCOUNT ON

	SELECT *
	 FROM dbo.Montura
	WHERE Id = @Id;