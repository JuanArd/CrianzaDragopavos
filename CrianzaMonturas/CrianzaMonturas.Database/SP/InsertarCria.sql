CREATE PROCEDURE [dbo].[InsertarCria]
	@Nombre VARCHAR(50),
	@Sexo VARCHAR(1),
	@TipoMontura INT,
	@TipoCria INT,
	@Predispuesto INT,
	@Padre INT,
	@Madre INT
AS
	SET QUOTED_IDENTIFIER ON;
	SET NOCOUNT ON;

	INSERT INTO dbo.Montura
	OUTPUT Inserted.Id
	VALUES (@Nombre, 0, @Sexo, @TipoMontura, @TipoCria, @Predispuesto, @Padre, @Madre, 0, 5, 0, 0, 0, NULL);