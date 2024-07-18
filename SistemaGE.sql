create database SistemaGE
use SistemaGE

-- Creación de tabla INV_Unidades
CREATE TABLE INV_Unidades (
    idUnidad INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255) NOT NULL,
    Estatus BIT NOT NULL
);

-- Creación de tabla INV_Ubicacion
CREATE TABLE INV_Ubicacion (
    idUbicacion INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255) NOT NULL,
    Estatus BIT NOT NULL
);

-- Creación de tabla INV_TipoDocumento
CREATE TABLE INV_TipoDocumento (
    idTipoDocumento INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255) NOT NULL,
    Estatus BIT NOT NULL,
    Efecto CHAR(1) CHECK (Efecto IN ('E', 'S', 'T', 'O', 'P'))
);

-- Creación de tabla INV_Suplidor
CREATE TABLE INV_Suplidor (
    idSuplidor INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255) NOT NULL,
    Identificacion NVARCHAR(50) NOT NULL,
    Telefono NVARCHAR(50),
    Correo NVARCHAR(255),
    Estatus BIT NOT NULL,
    PersonaContacto NVARCHAR(255),
    Comentario NVARCHAR(MAX),
    idTipoSuplidor CHAR(1) CHECK (idTipoSuplidor IN ('F', 'I')),
    idTipoIdentificacion CHAR(1) CHECK (idTipoIdentificacion IN ('C', 'R'))
);

-- Creación de tabla INV_Almacen
CREATE TABLE INV_Almacen (
    idAlmacen INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255) NOT NULL,
    Estatus BIT NOT NULL,
    idTipoAlmacen INT
);

-- Creación de tabla INV_Articulo
CREATE TABLE INV_Articulo (
    idArticulo INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255) NOT NULL,
    Estatus BIT NOT NULL,
    Imagen NVARCHAR(MAX),
    RegistroSanitario NVARCHAR(50),
    IngresoRegistroSanitario DATE,
    idCategoria INT,
    idClase INT,
    idUnidadAdquisicion INT,
    idUnidadVenta INT,
    idFabricante INT
);

-- Creación de tabla INV_ArticuloSuplidor
CREATE TABLE INV_ArticuloSuplidor (
    idArticuloSuplidor INT PRIMARY KEY IDENTITY(1,1),
    idArticulo INT NOT NULL,
    idSuplidor INT NOT NULL,
    CodigoArticulo NVARCHAR(50),
    UltimoPrecio DECIMAL(18, 2),
    PrecioCompra DECIMAL(18, 2),
    PrecioVentaMinimo DECIMAL(18, 2),
    PrecioVentaMaximo DECIMAL(18, 2),
    MargenBeneficio DECIMAL(5, 2),
    PrecioVentaMayor DECIMAL(18, 2),
    CantidadVentaMayor INT,
    CantidadOferta INT,
    CantidadUnidades INT,
    UnidadOferta NVARCHAR(50),
    FOREIGN KEY (idArticulo) REFERENCES INV_Articulo(idArticulo),
    FOREIGN KEY (idSuplidor) REFERENCES INV_Suplidor(idSuplidor)
);

-- Creación de tabla INV_ArticuloAlmacen
CREATE TABLE INV_ArticuloAlmacen (
    idArticuloAlmacen INT PRIMARY KEY IDENTITY(1,1),
    idArticulo INT NOT NULL,
    idAlmacen INT NOT NULL,
    idUbicacion INT NOT NULL,
    BalanceActual INT,
    BalanceMinimo INT,
    BalanceMaximo INT,
    BalanceReservado INT,
    FOREIGN KEY (idArticulo) REFERENCES INV_Articulo(idArticulo),
    FOREIGN KEY (idAlmacen) REFERENCES INV_Almacen(idAlmacen),
    FOREIGN KEY (idUbicacion) REFERENCES INV_Ubicacion(idUbicacion)
);
