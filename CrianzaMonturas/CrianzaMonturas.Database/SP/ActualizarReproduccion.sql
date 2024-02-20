CREATE PROCEDURE [dbo].[ActualizarReproduccion]
	@Cria INT,
	@Padre INT,
	@Madre INT
AS
	
	SET QUOTED_IDENTIFIER ON
	SET NOCOUNT ON

	DECLARE @CantReprod INT = (SELECT COUNT(1) 
								FROM dbo.Reproducciones 
							   WHERE MonturaMachoId = @Padre
								AND MonturaHembraId = @Madre
								AND CriaId IS NULL);

	IF @CantReprod = 0
		BEGIN
			DECLARE @FechaReprod DATE = (SELECT MAX(FechaReproduccion) FROM dbo.Reproducciones
											WHERE MonturaMachoId = @Padre
												AND MonturaHembraId = @Madre);

			INSERT INTO dbo.Reproducciones 
				VALUES (@Padre, @Madre, @FechaReprod, @Cria, SYSDATETIME());
		END
	ELSE
		BEGIN
			UPDATE dbo.Reproducciones SET CriaId = @Cria, FechaNacimiento = SYSDATETIME()
				WHERE MonturaMachoId = @Padre
					AND MonturaHembraId = @Madre
					AND CriaId IS NULL;
		END;