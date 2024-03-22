DROP DATABASE IF EXISTS protect_the_egg;
CREATE DATABASE protect_the_egg;
USE protect_the_egg;

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
    torres VARCHAR(20),
    enemigos VARCHAR(20),
    
    PRIMARY KEY (id_cartas)
);

INSERT INTO Escuderia VALUES
    ('C1', 'Caballero', 'Unidad', 'vida', 'velocidad','daño','cooldown','tipo_ataque', 'rango', 'coste', 'Si', 'Si'),
    ('C2', 'Arquero', 'Unidad', 'vida', 'velocidad','daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C3', 'Duende', 'Unidad', 'vida', 'velocidad','daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C4', 'Gigante', 'Unidad', 'vida', 'velocidad','daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C5', 'Mago', 'Unidad', 'vida', 'velocidad','daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C6', 'Fantasma', 'Unidad', 'vida', 'velocidad','daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C6', 'Orco', 'Unidad', 'vida', 'velocidad','daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C7', 'Asesino', 'Unidad', 'vida', 'velocidad','daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C8', 'Centauro', 'Unidad', 'vida', 'velocidad','daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C9', 'Cañón', 'Estructura', 'vida', 0,'daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C10', 'Catapulta', 'Estructura', 'vida', 0,'daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos'),
    ('C11', 'Mortero', 'Estructura', 'vida', 0,'daño','cooldown','tipo_ataque', 'rango', 'coste', 'torres', 'enemigos');
