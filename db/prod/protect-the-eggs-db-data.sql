-- Set the database context
USE `protect-the-eggs-db`;

-- Insert users
INSERT INTO Usuarios (NombreUsuario, Contraseña) VALUES 
('jugador1', 'contraseñaSegura123'),
('test', '123');

-- Insert NPC entities
INSERT INTO NPC (name, health, speed, attack, attackCooldown, `range`, isStructure, attackTowers, attackEnemies) VALUES 
('Knight', 400, 1, 70, 1.5, 1, FALSE, TRUE, TRUE),
('Archer', 150, 1, 40, 0.8, 10, FALSE, TRUE, TRUE),
('Goblin', 50, 2, 35, 0.5, 1, FALSE, TRUE, TRUE),
-- Repeat with appropriate values for other NPCs

-- Insert maps
INSERT INTO Mapas (NombreMapa) VALUES
('SeaSide'),
('Village'),
('EnchantedForest');

-- Insert card data linking it to NPCs
INSERT INTO Cartas (cardName, description, cost, numberOfNPCs, IDNPC) VALUES 
('Knight Card', 'Front-line combat', 5, 1, (SELECT IDNPC FROM NPC WHERE name = 'Knight')),
-- Repeat for other cards with proper links

-- Insert decks for users
INSERT INTO Mazos (IDUsuario, NombreMazo) VALUES 
((SELECT IDUsuario FROM Usuarios WHERE NombreUsuario = 'jugador1'), 'Mazo Inicial'),
-- Additional entries for other users and decks

-- Insert deck details for cards
INSERT INTO DetallesMazo (IDMazo, IDCarta, Cantidad) VALUES 
((SELECT IDMazo FROM Mazos WHERE NombreMazo = 'Mazo Inicial'), (SELECT IDCarta FROM Cartas WHERE cardName = 'Knight Card'), 2),
-- Additional entries for other cards in other decks

-- Insert game matches ensuring valid map and user references
INSERT INTO Partidas (IDUsuario, MaxOrda, IDMapa) VALUES 
((SELECT IDUsuario FROM Usuarios WHERE NombreUsuario = 'jugador1'), 500, (SELECT IDMapa FROM Mapas WHERE NombreMapa = 'SeaSide')),
-- Additional matches with different maps and users
;
