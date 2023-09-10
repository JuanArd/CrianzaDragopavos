/* MONTURAS NO REPRODUCIBLES */
SELECT *
FROM crianza_monturas.dbo.Montura
WHERE Esteril = 0
 AND Reproducible = 0
ORDER BY Nombre;

--SELECT * FROM Montura WHERE Esteril = 1 ORDER BY Nombre

UPDATE crianza_monturas.dbo.Montura SET Reproducible = 1 WHERE Id IN (546, 569);


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

--UPDATE Montura SET Esteril = 1 WHERE Nombre IN ();

/* MONTURAS PURAS */
SELECT *
FROM crianza_monturas.dbo.Montura
WHERE Nombre LIKE '%-PUR%'
 AND Esteril = 0