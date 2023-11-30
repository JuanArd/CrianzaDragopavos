/* MONTURAS NO REPRODUCIBLES */
SELECT *
FROM crianza_monturas.dbo.Montura
WHERE Esteril = 0
 AND Reproducible = 0
ORDER BY Nombre;

--UPDATE crianza_monturas.dbo.Montura SET Esteril = 1 WHERE Esteril = 0 AND Reproducible = 0

--UPDATE crianza_monturas.dbo.Montura SET Esteril = 0 WHERE Nombre IN ('DORPE-1', 'PURPE-4',
--'PURPE-5-CAMS', 'PURPE-6', 'ORQAL-4-CAM', 'PURAL-3', 'ESMPE-36', 'ESMPE-39')

--SELECT * FROM crianza_monturas.dbo.Montura WHERE Esteril = 1 ORDER BY Nombre

--UPDATE crianza_monturas.dbo.Montura SET Reproducible = 1 WHERE Id IN (542);


/* SCROLL DOFUS QUERY */
SELECT T.Nombre, M.Nombre, M.Sexo, M.Reproducciones, M.CantPureza
FROM crianza_monturas.dbo.Montura M
 INNER JOIN crianza_monturas.dbo.Tipo T ON T.Id = M.TipoId
WHERE M.Esteril = 0 
 AND M.Fecundada = 0
 AND M.Reproducible = 1
ORDER BY T.Id, M.Sexo, M.Nombre



/* ACTUALIZAR CANT PUREZA */
SELECT Nombre
FROM crianza_monturas.dbo.Montura
WHERE (Esteril = 0 
 OR Fecundada = 1)
 AND CantPureza IS NULL
ORDER BY Nombre;

--UPDATE Montura SET CantPureza = 32 WHERE Nombre = 'DORAD-20-PUR';


/* MONTURAS INTERCAMBIADAS */
SELECT * 
FROM crianza_monturas.dbo.Montura
WHERE Reproducciones != MaxReproducciones
AND Esteril = 0;

--UPDATE crianza_monturas.dbo.Montura SET Esteril = 1 WHERE Nombre IN ('PELIR-87','PELIR-88','PELIR-89');

/* MONTURAS PURAS */
SELECT *
FROM crianza_monturas.dbo.Montura
WHERE Nombre LIKE '%-PUR%'
 AND Esteril = 0

/* ACTUALIZACION PUREZA
UPDATE crianza_monturas.dbo.Montura
SET CantPureza = 6
WHERE Id = 569
*/