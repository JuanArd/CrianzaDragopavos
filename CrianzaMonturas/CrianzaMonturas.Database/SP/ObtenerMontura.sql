CREATE PROCEDURE ObtenerMontura
	@Id INT
AS
	SET NOCOUNT ON;

	SELECT Id,
		   Nombre,
		   Salvaje,
		   Sexo,
		   TipoMonturaId,
		   TipoId,
		   Predispuesto,
		   Padre,
		   Madre,
		   Reproducciones,
		   MaxReproducciones,
		   Esteril,
		   Reproducible,
		   Fecundada,
		   CantPureza
	 FROM dbo.Montura
	WHERE Id = @Id;