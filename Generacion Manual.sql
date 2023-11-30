SELECT * FROM Montura WHERE Nombre IN ('PELIR-37', 'PELIR-12')

-- Apareamiento
EXEC [InsertarReproduccion]
-- Generacion de crias
EXEC [InsertarCria] 'PELIR-87', 'M', '1', '2', '0', 230, 26;
EXEC [ActualizarReproduccion] 597, 20, 26;
EXEC [InsertarCria] 'PELIR-88', 'F', '1', '2', '0', 230, 26;
EXEC [ActualizarReproduccion] 598, 230, 26;
EXEC [InsertarCria] 'PELIR-89', 'F', '1', '2', '0', 230, 26;
EXEC [ActualizarReproduccion] 599, 230, 26;
-- Cerrar
EXEC [CerrarReproduccion] 230, 26

