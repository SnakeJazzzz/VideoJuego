DROP DATABASE IF EXISTS protect_the_egg;
CREATE DATABASE protect_the_egg;
USE protect_the_egg;

CREATE TABLE Usuarios (
	id_usuario varchar(20),
    nombre VARCHAR(20),
    id_cartas VARCHAR(20),
    
    FOREIGN KEY (id_cartas) REFERENCES Cartas(id_cartas),
    PRIMARY KEY (id_usuario)
);

INSERT INTO Usuarios VALUES
	('U1', 'Tomas'),
    ('U2', 'Michel'),
    ('U3', 'Pedro'),
    ('ID', 'Nombre');

CREATE TABLE Cartas (
    id_cartas VARCHAR(20),
	nombre VARCHAR(20),
    tipo VARCHAR(20),
    vida INT NOT NULL,
    velocidad INT,
    daño INT NOT NULL,
    cooldown INT NOT NULL,
    tipo_ataque VARCHAR(20),
    rango INT NOT NULL,
    coste INT NOT NULL,

    PRIMARY KEY (id_cartas)
);

INSERT INTO Cartas VALUES
    ('C1', 'Caballero', 'Unidad', 100, 1, 20, 1, 'single', 1, 3),
    ('C2', 'Arquero', 'Unidad', 75, 0.5, 15, 0.75, 'single', 5, 3),
    ('C3', 'Duende', 'Unidad', 50, 3, 20, 0.5, 'single', 1, 3),
    ('C4', 'Gigante', 'Unidad', 200, 0.25, 30, 2, 'single', 2, 5),
    ('C5', 'Mago', 'Unidad', 100, 88, 2, 1.5,'splash', 5, 4),
    ('C6', 'Fantasma', 'Unidad', 200, 0.8, 1, 1.5,'single', 1, 4),
    ('C6', 'Orco', 'Unidad', 225, 0.25, 25, 1.75, 'splash', 2, 7),
    ('C7', 'Asesino', 'Unidad', 100, 2, 20, 1, 'single', 1, 4),
    ('C8', 'Centauro', 'Unidad', 100, 3, 15, 1,'splash', 1.5, 4),
    ('C9', 'Cañón', 'Estructura', 200, 0, 20, 1, 'single', 7, 5),
    ('C10', 'Catapulta', 'Estructura', 250, 0, 25, 1.5, 'splash', 10, 7),
    ('C11', 'Mortero', 'Estructura', 300, 0, 35, 3, 'splash', 15, 10),
    ('C11', 'Nombre', 'Tipo de carta', 'vida', 'velocidad', 'daño', 'cooldown', 'tipo_ataque', 'rango', 'coste');
