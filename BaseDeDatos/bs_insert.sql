-- Link document with schema
USE PTE;

-- Insert data to Usuarios table
INSERT INTO Usuarios (NombreUsuario, Contraseña, PuntuaciónMáxima) VALUES 
('jugador1', 'contraseñaSegura123', 0),
('test', '123', 0);

-- Insert data to NPC table
INSERT INTO NPC (name, health, speed, attack, attackCooldown, `range`, isStructure, attackTowers, attackEnemies) VALUES 
('Knight', 400, 3, 70, 1.5, 1, 0, 0, 1),
('Archer', 150, 3, 40, 1, 3, 0, 0, 1),
('Goblin', 100, 4, 25, 0.5, 1, 0, 0, 1),
('Giant', 800, 1, 150, 2, 1, 0, 0, 1),
('Mage', 250, 2, 100, 2, 2, 0, 0, 1),
('Ghost', 200, 3, 30, 1, 1, 0, 0, 1),
('Orc', 350, 2, 60, 1.2, 1, 0, 0, 1),
('Assassin', 150, 4, 80, 1, 1, 0, 0, 1),
('Centaur', 300, 3, 70, 1.5, 2, 0, 0, 1),
('Elf', 300, 2, 60, 1.2, 3, 0, 0, 1),
('Berserker', 450, 3, 85, 0.8, 1, 0, 0, 1),
('Ice Sorceress', 250, 2, 70, 1.5, 2, 0, 0, 1),
('Stone Golem', 800, 1, 100, 2.5, 1, 0, 0, 1),
('Troll', 650, 1, 120, 2.5, 1, 0, 0, 1),
('Scout', 200, 4, 50, 1, 2, 0, 0, 1),
('Cannon', 500, 0, 80, 2, 2, 1, 0, 1),
('Catapult', 400, 0, 120, 3, 3, 1, 0, 1),
('Mortar Tower', 450, 0, 100, 2.5, 4, 1, 0, 1),
('Archer Tower', 650, 0, 45, 1, 3, 1, 0, 1),
('Inferno Tower', 550, 0, 20, 2, 2, 1, 0, 1),
('Wizard Tower', 500, 0, 80, 1.5, 2, 1, 0, 1);
/*
('Thorn Barrier', 800, 0, 30, 0, 0, 1, 0, 1),
('Bomber Tower', 600, 0, 100, 2.5, 2, 1, 0, 1);*/

-- Insert data to Cartas table
INSERT INTO Cartas (cardName, description, cost, numberOfNPCs, IDNPC) VALUES 
('Knight', 'Front-line combat', 3, 1, 1),
('Archer', 'Quick and ranged', 2, 1, 2),
('Goblin', 'Strikes and distractions', 1, 1, 3),
('Giant', 'Very resilient', 5, 1, 4),
('Mage', 'Can deal area damage', 4, 1, 5),
('Ghost', 'Sumons other ghost', 3, 1, 6),
('Orc', 'Strong and sturdy', 3, 1, 7),
('Assassin', 'High damage and speed', 4, 1, 8),
('Centaur', 'Versatile', 4, 1, 9),
('Elf', 'long-range attacks', 4, 1, 10),
('Berserker', 'Fierce warriors causing', 5, 1, 11),
('Ice Sorceress', 'tactical advantage', 6, 1, 12),
('Stone Golem', 'A living tank', 7, 1, 13),
('Troll', 'Strong and resilient', 7, 1, 14),
('Scout', 'Fast and agile', 3, 1, 15),
('Cannon', 'Ideal for defense', 4, 1, 16),
('Catapult', 'Great range', 5, 1, 17),
('Mortar Tower', 'fortified positions', 6, 1, 18),
('Archer Tower', 'Covering/ range', 5, 1, 19),
('Inferno Tower', 'Ideal bigDamage', 6, 1, 20),
('Wizard Tower', 'Casts spells', 7, 1, 21);

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
