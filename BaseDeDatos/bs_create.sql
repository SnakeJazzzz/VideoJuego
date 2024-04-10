-- Drop the existing schema if it exists to start fresh
DROP SCHEMA IF EXISTS PTE;

-- Create the new schema
CREATE SCHEMA PTE;
USE PTE;

-- Create the Usuarios table
CREATE TABLE Usuarios (
    IDUsuario INTEGER PRIMARY KEY AUTO_INCREMENT,
    NombreUsuario VARCHAR(40) NOT NULL,
    Contraseña VARCHAR(40) NOT NULL,
    PuntuaciónMáxima INTEGER DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Create the NPC table
CREATE TABLE NPC (
    IDNPC INTEGER PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(40) NOT NULL,
    health INTEGER NOT NULL,
    speed FLOAT NOT NULL,
    attack INTEGER NOT NULL,
    attackCooldown FLOAT NOT NULL,
    `range` FLOAT NOT NULL,
    isStructure BOOL NOT NULL,
    attackTowers BOOL NOT NULL,
    attackEnemies BOOL NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Create the Cartas table with a foreign key to NPC
CREATE TABLE Cartas (
    IDCarta INTEGER PRIMARY KEY AUTO_INCREMENT,
    cardName VARCHAR(40) NOT NULL,
    description VARCHAR(100) NOT NULL, -- Increased size for description to allow more detailed texts
    cost INTEGER NOT NULL,
    numberOfNPCs INTEGER NOT NULL,
    IDNPC INTEGER NOT NULL,
    FOREIGN KEY (IDNPC) REFERENCES NPC(IDNPC)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Create the Mazos table with a foreign key to Usuarios
CREATE TABLE Mazos (
    IDMazo INTEGER PRIMARY KEY AUTO_INCREMENT,
    IDUsuario INTEGER NOT NULL, -- Ensure NOT NULL for IDUsuario to enforce relationship integrity
    NombreMazo VARCHAR(40) NOT NULL,
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Create the DetallesMazo table with foreign keys to Mazos and Cartas
CREATE TABLE DetallesMazo (
    IDDetalle INTEGER PRIMARY KEY AUTO_INCREMENT,
    IDMazo INTEGER NOT NULL, -- Ensure NOT NULL for IDMazo to enforce relationship integrity
    IDCarta INTEGER NOT NULL, -- Ensure NOT NULL for IDCarta to enforce relationship integrity
    Cantidad INTEGER,
    FOREIGN KEY (IDMazo) REFERENCES Mazos(IDMazo),
    FOREIGN KEY (IDCarta) REFERENCES Cartas(IDCarta)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Create the Partidas table with a foreign key to Usuarios
CREATE TABLE Partidas (
    IDPartida INTEGER PRIMARY KEY AUTO_INCREMENT,
    IDUsuario INTEGER NOT NULL, -- Ensure NOT NULL for IDUsuario to enforce relationship integrity
    FechaHoraInicio DATETIME,
    FechaHoraFin DATETIME,
    Puntuación INTEGER,
    OrdasSuperadas INTEGER,
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;