/* REPRODUCCIONES */
SELECT r.MonturaMachoId, mm.Nombre, r.MonturaHembraId, mh.Nombre
	, /*CAST(r.FechaReproduccion AS date) as */FechaReproduccion, r.CriaId
	, /*CAST(r.FechaNacimiento AS date) as */FechaNacimiento
 FROM crianza_monturas.dbo.Reproducciones r
  INNER JOIN crianza_monturas.dbo.Montura mm ON r.MonturaMachoId = mm.Id
  INNER JOIN crianza_monturas.dbo.Montura mh ON r.MonturaHembraId = mh.Id
  INNER JOIN crianza_monturas.dbo.Tipo th ON th.Id = mh.TipoId
WHERE r.CriaId IS NULL
	--AND th.Generacion in (10)
ORDER BY r.Id;

/* NOMBRE MONTURAS */
SELECT TOP 1 m.Id, m.Nombre, m.Sexo,M.Padre, m.Madre 
 FROM crianza_monturas.dbo.Montura m
	INNER JOIN crianza_monturas.dbo.Tipo t ON m.TipoId = t.Id
WHERE t.Sigla = 'marfi'
ORDER BY m.Id DESC;

--UPDATE Montura SET Reproducible = 0, Esteril = 1 WHERE Nombre = 'CIRUE-3'

--CANT DRAGOPAVOS POR FECHA REPRODUCCION

/*
SELECT CAST(FechaReproduccion AS date) as FechaReproduccion
	, CAST(FechaNacimiento AS date) as FechaNacimiento
	--,CASE  WHEN FechaNacimiento IS NOT NULL THEN CAST(SYSDATETIME() AS DATE) END
	,COUNT(1) 
FROM crianza_monturas.dbo.Reproducciones
GROUP BY CAST(FechaReproduccion AS date), CAST(FechaNacimiento AS date)
	--,CASE  WHEN FechaNacimiento IS NOT NULL THEN CAST(SYSDATETIME() AS DATE) END
ORDER BY CAST(FechaReproduccion AS date) DESC
	, CAST(FechaNacimiento AS date) DESC
*/



-- DRAGOPAVOS POR CANT REPRODUCCIONES

/*
SELECT Sexo, Reproducciones, count(1)
 FROM crianza_monturas.dbo.Montura
WHERE Reproducible = 1
	AND Esteril = 0
GROUP BY Sexo,
	Reproducciones
ORDER BY Reproducciones,
	Sexo;
*/


/*
SELECT * FROM crianza_monturas.dbo.Montura WHERE /*Reproducciones IN (0,1,2,3,4) AND*/ Sexo = 'M' AND (Esteril = 0 OR Fecundada = 1)
UNION
SELECT * FROM crianza_monturas.dbo.Montura WHERE /*Reproducciones IN (0,1,2,3,4) AND*/ Sexo = 'F' AND (Esteril = 0 OR Fecundada = 1)
ORDER BY Sexo Desc, Nombre;
*/

-- CANT DRAGOPAVOS EN CERCADO
/*
SELECT *
FROM crianza_monturas.dbo.Montura
WHERE (Esteril = 0 
 OR Fecundada = 1)
 AND Reproducible = 1
ORDER BY Nombre
*/