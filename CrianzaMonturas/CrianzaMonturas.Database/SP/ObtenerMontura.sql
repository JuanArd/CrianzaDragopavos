CREATE PROCEDURE ObtenerMontura
	@Id INT
AS
	SELECT *
	 FROM Montura
	WHERE Id = @Id;