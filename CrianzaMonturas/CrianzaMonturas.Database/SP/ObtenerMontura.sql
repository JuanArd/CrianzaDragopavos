CREATE PROCEDURE ObtenerMontura
	@Id int
AS
	SELECT *
	 FROM Montura
	WHERE Id = @Id;