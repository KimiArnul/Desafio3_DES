/*====================================================================================*/
/*Consulta de Tablas*/
SELECT * FROM [Recetas_Cocina].[dbo].[Ingredientes]
SELECT * FROM [Recetas_Cocina].[dbo].[PasosPreparacion]
SELECT * FROM [Recetas_Cocina].[dbo].[Recetas]

/*====================================================================================*/
/*Consulta de Recetas y sus ingredientes*/
SELECT * FROM Recetas INNER JOIN Ingredientes on 
Recetas.IdReceta = Ingredientes.RecetaId 
Order By Recetas.NombreReceta ASC

/*Consulta de Recetas y sus pasos de preparación*/
SELECT * FROM Recetas INNER JOIN PasosPreparacion on 
Recetas.IdReceta = PasosPreparacion.RecetaId 
Order By Recetas.NombreReceta , PasosPreparacion.IdPaso ASC

/*====================================================================================*/
/*Consulta de Recetas, el total de ingredientes, y el total de pasos de preparación*/
SELECT
    r.IdReceta,
    r.NombreReceta,
    r.TiempoPreparacion,
    COUNT(DISTINCT i.IdIngrediente) AS TotalIngredientes,
    COUNT(DISTINCT p.IdPaso) AS TotalPasos
FROM dbo.Recetas r
LEFT JOIN dbo.Ingredientes i
    ON r.IdReceta = i.RecetaId
LEFT JOIN dbo.PasosPreparacion p
    ON r.IdReceta = p.RecetaId
GROUP BY
    r.IdReceta,
    r.NombreReceta,
    r.TiempoPreparacion
ORDER BY
    r.IdReceta;
	


