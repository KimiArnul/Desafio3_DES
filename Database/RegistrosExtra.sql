USE [Recetas_Cocina];
GO

/* ============================================================
   RECETAS
   ============================================================ */

INSERT INTO [dbo].[Recetas]
    ([NombreReceta], [Descripcion], [TiempoPreparacion])
VALUES
    (
        N'Brownies de Chocolate',
        N'Deliciosos brownies de chocolate con una textura suave y húmeda en el centro y una ligera capa crujiente en la superficie.',
        '00:45:00'
    ),
    (
        N'Galletas con Chispas de Chocolate',
        N'Galletas suaves por dentro y ligeramente crujientes por fuera, con abundantes chispas de chocolate.',
        '00:35:00'
    ),
    (
        N'Pastel de Chocolate',
        N'Pastel esponjoso de chocolate con un intenso sabor a cacao, ideal para acompañar con café o decorar con crema.',
        '01:00:00'
    ),
    (
        N'Trufas de Chocolate',
        N'Pequeñas trufas elaboradas con chocolate y crema, cubiertas con cacao en polvo para obtener un postre elegante y sencillo.',
        '00:40:00'
    ),
    (
        N'Mousse de Chocolate',
        N'Postre cremoso y ligero de chocolate con una textura suave y aireada, perfecto para servir frío.',
        '00:30:00'
    );
GO


/* ============================================================
   INGREDIENTES
   ============================================================ */

INSERT INTO [dbo].[Ingredientes]
    ([NombreIngrediente], [Cantidad], [UnidadMedida], [RecetaId])
VALUES

    -- Brownies de Chocolate - Receta 1
    (N'Harina de trigo', 150, N'gramos', 1),
    (N'Chocolate semiamargo', 200, N'gramos', 1),
    (N'Mantequilla', 120, N'gramos', 1),
    (N'Azúcar', 180, N'gramos', 1),
    (N'Huevos', 3, N'unidades', 1),
    (N'Extracto de vainilla', 5, N'mililitros', 1),
    (N'Sal', 2, N'gramos', 1),

    -- Galletas con Chispas de Chocolate - Receta 2
    (N'Harina de trigo', 250, N'gramos', 2),
    (N'Mantequilla', 120, N'gramos', 2),
    (N'Azúcar', 100, N'gramos', 2),
    (N'Azúcar morena', 80, N'gramos', 2),
    (N'Huevo', 1, N'unidad', 2),
    (N'Chispas de chocolate', 150, N'gramos', 2),
    (N'Extracto de vainilla', 5, N'mililitros', 2),

    -- Pastel de Chocolate - Receta 3
    (N'Harina de trigo', 200, N'gramos', 3),
    (N'Cacao en polvo', 50, N'gramos', 3),
    (N'Azúcar', 180, N'gramos', 3),
    (N'Huevos', 3, N'unidades', 3),
    (N'Leche', 200, N'mililitros', 3),
    (N'Aceite vegetal', 100, N'mililitros', 3),
    (N'Polvo de hornear', 10, N'gramos', 3),
    (N'Extracto de vainilla', 5, N'mililitros', 3),

    -- Trufas de Chocolate - Receta 4
    (N'Chocolate semiamargo', 250, N'gramos', 4),
    (N'Crema para batir', 120, N'mililitros', 4),
    (N'Mantequilla', 30, N'gramos', 4),
    (N'Cacao en polvo', 50, N'gramos', 4),
    (N'Extracto de vainilla', 5, N'mililitros', 4),

    -- Mousse de Chocolate - Receta 5
    (N'Chocolate semiamargo', 200, N'gramos', 5),
    (N'Crema para batir', 300, N'mililitros', 5),
    (N'Azúcar', 40, N'gramos', 5),
    (N'Huevos', 2, N'unidades', 5),
    (N'Extracto de vainilla', 5, N'mililitros', 5);
GO


/* ============================================================
   PASOS DE PREPARACIÓN
   ============================================================ */

INSERT INTO [dbo].[PasosPreparacion]
    ([DescripcionPaso], [OrdenPaso], [RecetaId])
VALUES

    /* --------------------------------------------------------
       Brownies de Chocolate - Receta 1
       -------------------------------------------------------- */
    (
        N'Precalentar el horno a 180 °C y preparar un molde para hornear cubriéndolo con papel para hornear.',
        1,
        1
    ),
    (
        N'Derretir el chocolate semiamargo junto con la mantequilla a baño María o en intervalos cortos en el microondas.',
        2,
        1
    ),
    (
        N'Agregar el azúcar a la mezcla de chocolate y mantequilla y mezclar hasta integrar completamente.',
        3,
        1
    ),
    (
        N'Incorporar los huevos uno a uno, mezclando bien después de cada adición. Agregar el extracto de vainilla.',
        4,
        1
    ),
    (
        N'Añadir la harina y la sal. Mezclar suavemente hasta obtener una masa homogénea, evitando batir en exceso.',
        5,
        1
    ),
    (
        N'Verter la mezcla en el molde preparado y distribuirla uniformemente.',
        6,
        1
    ),
    (
        N'Hornear durante aproximadamente 25 a 30 minutos, hasta que la superficie esté firme y el centro ligeramente húmedo.',
        7,
        1
    ),
    (
        N'Retirar del horno, dejar enfriar y cortar los brownies en porciones antes de servir.',
        8,
        1
    ),

    /* --------------------------------------------------------
       Galletas con Chispas de Chocolate - Receta 2
       -------------------------------------------------------- */
    (
        N'Precalentar el horno a 180 °C y preparar una bandeja con papel para hornear.',
        1,
        2
    ),
    (
        N'Batir la mantequilla junto con el azúcar y el azúcar morena hasta obtener una mezcla cremosa.',
        2,
        2
    ),
    (
        N'Agregar el huevo y el extracto de vainilla y mezclar hasta integrar.',
        3,
        2
    ),
    (
        N'Incorporar poco a poco la harina hasta formar una masa homogénea.',
        4,
        2
    ),
    (
        N'Agregar las chispas de chocolate y distribuirlas uniformemente en la masa.',
        5,
        2
    ),
    (
        N'Formar pequeñas porciones de masa y colocarlas sobre la bandeja dejando espacio entre ellas.',
        6,
        2
    ),
    (
        N'Hornear durante 10 a 15 minutos hasta que los bordes estén ligeramente dorados.',
        7,
        2
    ),

    /* --------------------------------------------------------
       Pastel de Chocolate - Receta 3
       -------------------------------------------------------- */
    (
        N'Precalentar el horno a 180 °C y engrasar un molde para pastel.',
        1,
        3
    ),
    (
        N'Mezclar en un recipiente la harina, el cacao en polvo y el polvo de hornear.',
        2,
        3
    ),
    (
        N'En otro recipiente, batir los huevos junto con el azúcar hasta obtener una mezcla ligeramente espumosa.',
        3,
        3
    ),
    (
        N'Agregar la leche, el aceite vegetal y el extracto de vainilla.',
        4,
        3
    ),
    (
        N'Incorporar gradualmente los ingredientes secos y mezclar hasta obtener una masa uniforme.',
        5,
        3
    ),
    (
        N'Verter la mezcla en el molde y hornear durante 35 a 40 minutos.',
        6,
        3
    ),
    (
        N'Dejar enfriar antes de desmoldar y servir.',
        7,
        3
    ),

    /* --------------------------------------------------------
       Trufas de Chocolate - Receta 4
       -------------------------------------------------------- */
    (
        N'Picar finamente el chocolate semiamargo y colocarlo en un recipiente resistente al calor.',
        1,
        4
    ),
    (
        N'Calentar la crema para batir hasta que esté caliente, evitando que llegue a hervir.',
        2,
        4
    ),
    (
        N'Verter la crema caliente sobre el chocolate y dejar reposar durante unos minutos.',
        3,
        4
    ),
    (
        N'Mezclar hasta que el chocolate se derrita completamente y agregar la mantequilla y la vainilla.',
        4,
        4
    ),
    (
        N'Refrigerar la mezcla durante aproximadamente 2 horas hasta que esté firme.',
        5,
        4
    ),
    (
        N'Formar pequeñas bolitas con la mezcla y cubrirlas con cacao en polvo.',
        6,
        4
    ),

    /* --------------------------------------------------------
       Mousse de Chocolate - Receta 5
       -------------------------------------------------------- */
    (
        N'Derretir el chocolate semiamargo a baño María o en intervalos cortos en el microondas.',
        1,
        5
    ),
    (
        N'Separar las claras de las yemas de los huevos.',
        2,
        5
    ),
    (
        N'Incorporar las yemas y el extracto de vainilla al chocolate derretido y mezclar cuidadosamente.',
        3,
        5
    ),
    (
        N'Batir las claras de huevo con el azúcar hasta obtener una mezcla firme y aireada.',
        4,
        5
    ),
    (
        N'Batir la crema hasta obtener una consistencia ligeramente firme.',
        5,
        5
    ),
    (
        N'Incorporar suavemente la crema y las claras batidas a la mezcla de chocolate.',
        6,
        5
    ),
    (
        N'Distribuir el mousse en recipientes individuales y refrigerar durante al menos 2 horas antes de servir.',
        7,
        5
    );
GO