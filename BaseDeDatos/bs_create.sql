DROP SCHEMA IF EXISTS PTE;
CREATE SCHEMA PTE;
USE PTE;


-- Creación de la tabla Usuarios
CREATE TABLE Usuarios (
    IDUsuario INTEGER PRIMARY KEY AUTO_INCREMENT,
    NombreUsuario TEXT NOT NULL,
    Contraseña TEXT NOT NULL,
    PuntuaciónMáxima INTEGER DEFAULT 0
);

-- Creación de la tabla Cartas
CREATE TABLE Cartas (
    IDCarta INTEGER PRIMARY KEY AUTO_INCREMENT,
    Nombre TEXT NOT NULL,
    Descripción TEXT,
    Vida INTEGER,
    Velocidad REAL,
    Daño INTEGER,
    VelocidadAtaque REAL,
    Rango REAL,
    CostoElixir INTEGER,
    Tipo TEXT CHECK(Tipo IN ('Ataque', 'Defensa')),
    NombreArchivoImagen TEXT,
    NombreMarco TEXT CHECK(NombreMarco IN ('comun', 'raro', 'exotico', 'legendario')),
    NombreArchivoSonido TEXT
);
-- Creación de la tabla Mazos
CREATE TABLE Mazos (
    IDMazo INTEGER PRIMARY KEY AUTO_INCREMENT,
    IDUsuario INTEGER,
    NombreMazo TEXT NOT NULL,
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario)
);

-- Creación de la tabla DetallesMazo
CREATE TABLE DetallesMazo (
    IDDetalle INTEGER PRIMARY KEY AUTO_INCREMENT,
    IDMazo INTEGER,
    IDCarta INTEGER,
    Cantidad INTEGER,
    FOREIGN KEY (IDMazo) REFERENCES Mazos(IDMazo),
    FOREIGN KEY (IDCarta) REFERENCES Cartas(IDCarta)
);

-- Creación de la tabla Partidas
CREATE TABLE Partidas (
    IDPartida INTEGER PRIMARY KEY AUTO_INCREMENT,
    IDUsuario INTEGER,
    FechaHoraInicio DATETIME,
    FechaHoraFin DATETIME,
    Puntuación INTEGER,
    OrdasSuperadas INTEGER,
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario)
);

-- Creación de la tabla AccionesPartida
CREATE TABLE AccionesPartida (
    IDAcción INTEGER PRIMARY KEY AUTO_INCREMENT,
    IDPartida INTEGER,
    Momento DATETIME,
    IDCarta INTEGER,
    DescripciónAcción TEXT,
    FOREIGN KEY (IDPartida) REFERENCES Partidas(IDPartida),
    FOREIGN KEY (IDCarta) REFERENCES Cartas(IDCarta)
);
