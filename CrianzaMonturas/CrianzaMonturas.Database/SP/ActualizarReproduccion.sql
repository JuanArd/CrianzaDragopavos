CREATE   PROCEDURE [dbo].[ActualizarReproduccion]
	@Cria INT,
	@Padre INT,
	@Madre INT
AS
	DECLARE @CantReprod INT = (SELECT COUNT(1) 
								FROM Reproducciones 
							   WHERE MonturaMachoId = @Padre
								AND MonturaHembraId = @Madre
								AND CriaId IS NULL);

	IF @CantReprod = 0
		BEGIN
			DECLARE @FechaReprod DATE = (SELECT MAX(FechaReproduccion) FROM Reproducciones
											WHERE MonturaMachoId = @Padre
												AND MonturaHembraId = @Madre);

			INSERT INTO Reproducciones 
				VALUES (@Padre, @Madre, @FechaReprod, @Cria, SYSDATETIME());
		END
	ELSE
		BEGIN
			UPDATE Reproducciones SET CriaId = @Cria, FechaNacimiento = SYSDATETIME()
				WHERE MonturaMachoId = @Padre
					AND MonturaHembraId = @Madre
					AND CriaId IS NULL;
		END;