CREATE PROCEDURE [dbo].[InsertarCria]
	@Nombre varchar(50),
	@Sexo varchar(1),
	@TipoMontura int,
	@TipoCria int,
	@Predispuesto int,
	@Padre int,
	@Madre int
AS
	INSERT INTO Montura
	OUTPUT Inserted.Id
	VALUES (@Nombre, 0, @Sexo, @TipoMontura, @TipoCria, @Predispuesto, @Padre, @Madre, 0, 5, 0, 0, 0, null);