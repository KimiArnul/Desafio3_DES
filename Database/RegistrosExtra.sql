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
    (N'Harina de trigo', 150, N'gramos', 4),
    (N'Chocolate semiamargo', 200, N'gramos', 4),
    (N'Mantequilla', 120, N'gramos', 4),
    (N'Azúcar', 180, N'gramos', 4),
    (N'Huevos', 3, N'unidades', 4),
    (N'Extracto de vainilla', 5, N'mililitros', 4),
    (N'Sal', 2, N'gramos', 4),

    -- Galletas con Chispas de Chocolate - Receta 2
    (N'Harina de trigo', 250, N'gramos', 5),
    (N'Mantequilla', 120, N'gramos', 5),
    (N'Azúcar', 100, N'gramos', 5),
    (N'Azúcar morena', 80, N'gramos', 5),
    (N'Huevo', 1, N'unidad', 5),
    (N'Chispas de chocolate', 150, N'gramos', 5),
    (N'Extracto de vainilla', 5, N'mililitros', 5),

    -- Pastel de Chocolate - Receta 3
    (N'Harina de trigo', 200, N'gramos', 6),
    (N'Cacao en polvo', 50, N'gramos', 6),
    (N'Azúcar', 180, N'gramos', 6),
    (N'Huevos', 3, N'unidades', 6),
    (N'Leche', 200, N'mililitros', 6),
    (N'Aceite vegetal', 100, N'mililitros', 6),
    (N'Polvo de hornear', 10, N'gramos', 6),
    (N'Extracto de vainilla', 5, N'mililitros', 6),

    -- Trufas de Chocolate - Receta 4
    (N'Chocolate semiamargo', 250, N'gramos', 7),
    (N'Crema para batir', 120, N'mililitros', 7),
    (N'Mantequilla', 30, N'gramos', 7),
    (N'Cacao en polvo', 50, N'gramos', 7),
    (N'Extracto de vainilla', 5, N'mililitros', 7),

    -- Mousse de Chocolate - Receta 5
    (N'Chocolate semiamargo', 200, N'gramos', 8),
    (N'Crema para batir', 300, N'mililitros', 8),
    (N'Azúcar', 40, N'gramos', 8),
    (N'Huevos', 2, N'unidades', 8),
    (N'Extracto de vainilla', 5, N'mililitros', 8);
GO


/* ============================================================
   PASOS DE PREPARACIÓN
   ============================================================ */

INSERT INTO [dbo].[PasosPreparacion]
    ([DescripcionPaso], [OrdenPaso], [RecetaId])
VALUES

    /* --------------------------------------------------------
       Brownies de Chocolate - Receta 4
       -------------------------------------------------------- */
    (
        N'Precalentar el horno a 180 °C y preparar un molde para hornear cubriéndolo con papel para hornear.',
        1,
        4
    ),
    (
        N'Derretir el chocolate semiamargo junto con la mantequilla a baño María o en intervalos cortos en el microondas.',
        2,
        4
    ),
    (
        N'Agregar el azúcar a la mezcla de chocolate y mantequilla y mezclar hasta integrar completamente.',
        3,
        4
    ),
    (
        N'Incorporar los huevos uno a uno, mezclando bien después de cada adición. Agregar el extracto de vainilla.',
        4,
        4
    ),
    (
        N'Añadir la harina y la sal. Mezclar suavemente hasta obtener una masa homogénea, evitando batir en exceso.',
        5,
        4
    ),
    (
        N'Verter la mezcla en el molde preparado y distribuirla uniformemente.',
        6,
        4
    ),
    (
        N'Hornear durante aproximadamente 25 a 30 minutos, hasta que la superficie esté firme y el centro ligeramente húmedo.',
        7,
        4
    ),
    (
        N'Retirar del horno, dejar enfriar y cortar los brownies en porciones antes de servir.',
        8,
        4
    ),

    /* --------------------------------------------------------
       Galletas con Chispas de Chocolate - Receta 5
       -------------------------------------------------------- */
    (
        N'Precalentar el horno a 180 °C y preparar una bandeja con papel para hornear.',
        1,
        5
    ),
    (
        N'Batir la mantequilla junto con el azúcar y el azúcar morena hasta obtener una mezcla cremosa.',
        2,
        5
    ),
    (
        N'Agregar el huevo y el extracto de vainilla y mezclar hasta integrar.',
        3,
        5
    ),
    (
        N'Incorporar poco a poco la harina hasta formar una masa homogénea.',
        4,
        5
    ),
    (
        N'Agregar las chispas de chocolate y distribuirlas uniformemente en la masa.',
        5,
        5
    ),
    (
        N'Formar pequeñas porciones de masa y colocarlas sobre la bandeja dejando espacio entre ellas.',
        6,
        5
    ),
    (
        N'Hornear durante 10 a 15 minutos hasta que los bordes estén ligeramente dorados.',
        7,
        5
    ),

    /* --------------------------------------------------------
       Pastel de Chocolate - Receta 6
       -------------------------------------------------------- */
    (
        N'Precalentar el horno a 180 °C y engrasar un molde para pastel.',
        1,
        6
    ),
    (
        N'Mezclar en un recipiente la harina, el cacao en polvo y el polvo de hornear.',
        2,
        6
    ),
    (
        N'En otro recipiente, batir los huevos junto con el azúcar hasta obtener una mezcla ligeramente espumosa.',
        3,
        6
    ),
    (
        N'Agregar la leche, el aceite vegetal y el extracto de vainilla.',
        4,
        6
    ),
    (
        N'Incorporar gradualmente los ingredientes secos y mezclar hasta obtener una masa uniforme.',
        5,
        6
    ),
    (
        N'Verter la mezcla en el molde y hornear durante 35 a 40 minutos.',
        6,
        6
    ),
    (
        N'Dejar enfriar antes de desmoldar y servir.',
        7,
        6
    ),

    /* --------------------------------------------------------
       Trufas de Chocolate - Receta 7
       -------------------------------------------------------- */
    (
        N'Picar finamente el chocolate semiamargo y colocarlo en un recipiente resistente al calor.',
        1,
        7
    ),
    (
        N'Calentar la crema para batir hasta que esté caliente, evitando que llegue a hervir.',
        2,
        7
    ),
    (
        N'Verter la crema caliente sobre el chocolate y dejar reposar durante unos minutos.',
        3,
        7
    ),
    (
        N'Mezclar hasta que el chocolate se derrita completamente y agregar la mantequilla y la vainilla.',
        4,
        7
    ),
    (
        N'Refrigerar la mezcla durante aproximadamente 2 horas hasta que esté firme.',
        5,
        7
    ),
    (
        N'Formar pequeñas bolitas con la mezcla y cubrirlas con cacao en polvo.',
        6,
        7
    ),

    /* --------------------------------------------------------
       Mousse de Chocolate - Receta 8
       -------------------------------------------------------- */
    (
        N'Derretir el chocolate semiamargo a baño María o en intervalos cortos en el microondas.',
        1,
        8
    ),
    (
        N'Separar las claras de las yemas de los huevos.',
        2,
        8
    ),
    (
        N'Incorporar las yemas y el extracto de vainilla al chocolate derretido y mezclar cuidadosamente.',
        3,
        8
    ),
    (
        N'Batir las claras de huevo con el azúcar hasta obtener una mezcla firme y aireada.',
        4,
        8
    ),
    (
        N'Batir la crema hasta obtener una consistencia ligeramente firme.',
        5,
        8
    ),
    (
        N'Incorporar suavemente la crema y las claras batidas a la mezcla de chocolate.',
        6,
        8
    ),
    (
        N'Distribuir el mousse en recipientes individuales y refrigerar durante al menos 2 horas antes de servir.',
        7,
        8
    );
GO