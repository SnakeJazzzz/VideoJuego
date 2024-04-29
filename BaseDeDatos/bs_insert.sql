-- Link document with schema
USE PTE;

-- Insert data to Usuarios table
INSERT INTO Usuarios (NombreUsuario, Contraseña) VALUES 
('jugador1', 'contraseñaSegura123'),
('test', '123');

-- Insert data to NPC table
INSERT INTO NPC (name, health, speed, attack, attackCooldown, `range`, isStructure, attackTowers, attackEnemies) VALUES 
('Knight', 400, 1, 70, 1.5, 1, 0, 1, 1),
('Archer', 150, 1, 40, 0.8, 10, 0, 1, 1),
('Goblin', 50, 2, 35, 0.5, 1, 0, 1, 1),
('Giant', 1000, 1, 450, 1.5, 1, 0, 1, 1),
('Mage', 250, 1, 30, 1.5, 10, 0, 1, 1),
('Ghost', 200, 1, 55, 0.8, 1, 0, 1, 1),
('Orc', 350, 1.5, 65, 1, 1, 0, 1, 1),
('Assassin', 250, 2, 150, 0.5, 1, 0, 1, 1),
('Centaur', 450, 1, 100, 1.5, 2, 0, 1, 1),
('Elf', 200, 1.5, 70, 1.5, 15, 0, 1, 1),
('Berserker', 450, 1, 100, 0.8, 1, 0, 1, 1),
('Ice Sorceress', 500, 1, 50, 0.8, 5, 0, 1, 1),
('Stone Golem', 1250, 1, 150, 3, 1, 0, 1, 1),
('Troll', 650, 1, 120, 2, 1, 0, 1, 1),
('Scout', 200, 3, 50, 1, 2, 0, 1, 1),
('Cannon', 500, 0, 80, 1.5, 8, 1, 0, 1),
('Catapult', 400, 0, 50, 3, 17, 1, 0, 1),
('Mortar Tower', 450, 0, 100, 2, 13, 1, 0, 1),
('Archer Tower', 650, 0, 45, 1, 8, 1, 0, 1),
('Inferno Tower', 1500, 0, 800, 2.5, 10, 1, 0, 1),
('Wizard Tower', 700, 0, 60, 1.5, 10, 1, 0, 1);
/*
('Thorn Barrier', 800, 0, 30, 0, 0, 1, 0, 1),
('Bomber Tower', 600, 0, 100, 2.5, 2, 1, 0, 1);*/

-- Insert data to Cartas table
INSERT INTO Cartas (cardName, description, cost, numberOfNPCs, IDNPC) VALUES 
('Knight', 'Front-line combat', 5, 1, 1),
('Archer', 'Quick and ranged', 10, 2, 2),
('Goblin', 'Strikes and distractions', 5, 3, 3),
('Giant', 'Very resilient', 30, 1, 4),
('Mage', 'Can deal area damage', 15, 1, 5),
('Ghost', 'Sumons other ghost', 12, 4, 6),
('Orc', 'Strong and sturdy', 8, 1, 7),
('Assassin', 'High damage and speed', 12, 1, 8),
('Centaur', 'Versatile', 8, 1, 9),
('Elf', 'long-range attacks', 25, 1, 10),
('Berserker', 'Fierce warriors causing', 10, 1, 11),
('Ice Sorceress', 'tactical advantage', 12, 1, 12),
('Stone Golem', 'A living tank', 20, 1, 13),
('Troll', 'Strong and resilient', 7, 1, 14),
('Scout', 'Fast and agile', 6, 2, 15),
('Cannon', 'Ideal for defense', 25, 1, 16),
('Catapult', 'Great range', 40, 1, 17),
('Mortar Tower', 'fortified positions', 35, 1, 18),
('Archer Tower', 'Covering/ range', 35, 1, 19),
('Inferno Tower', 'Ideal bigDamage', 40, 1, 20),
('Wizard Tower', 'Casts spells', 40, 1, 21);

-- Insert data to Mazos table for Usuarios
INSERT INTO Mazos (IDUsuario, NombreMazo) VALUES 
(1, 'Mazo Inicial'),
(1, 'Mazo 2');

-- Insert Mazo data (asumiendo que los IDs de las cartas van del 1 al 10)
INSERT INTO DetallesMazo (IDMazo, IDCarta, Cantidad) VALUES 
(1, 1, 2),
(1, 2, 2),
(1, 3, 2),
(1, 4, 2),
(1, 5, 2),
(1, 6, 2),
(1, 7, 2),
(1, 8, 2),
(1, 9, 2),
(1, 10, 2),
(2, 1 ,5);

-- Insert data to Mapas table
INSERT INTO Mapas (NombreMapa) VALUES
("SeaSide"),
("Village"),
("EnchantedForest");


-- Insert data to Partidas table
INSERT INTO Partidas (IDUsuario, MaxOrda, IDMapa) VALUES 
(1, 500, 1),
(2, 200, 1),
(2, 150, 1),
(2, 300, 1),
(2, 300, 2),
(2, 100, 2),
(2, 50, 2),
(2, 10, 2),
(2, 300, 3),
(2, 100, 3),
(2, 50, 3);
