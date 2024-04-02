INSERT INTO Cartas 
(Nombre, Descripción, Vida, Velocidad, Daño, VelocidadAtaque, Rango, CostoElixir, Tipo, NombreArchivoImagen, NombreMarco, NombreArchivoSonido) 
VALUES 
('Caballero', 'Resistente a ataques físicos, ideal para combate frontal.', 400, 1.0, 70, 1.5, 1, 3, 'Ataque', 'caballero.png', 'comun', 'caballero.mp3'),
('Arquero', 'Puede atacar desde lejos, vulnerable a ataques rápidos.', 150, 1.0, 40, 1, 3, 2, 'Ataque', 'arquero.png', 'raro', 'arquero.mp3'),
('Duende', 'Rápido y eficaz para ataques rápidos y distracciones.', 100, 1.5, 25, 0.5, 1, 1, 'Ataque', 'duende.png', 'comun', 'duende.mp3'),
('Gigante', 'Muy resistente, ideal para absorber daño.', 800, 0.5, 150, 2, 1, 5, 'Defensa', 'gigante.png', 'exotico', 'gigante.mp3'),
('Mago', 'Capaz de causar daño en área, efectivo contra grupos de enemigos.', 250, 1.0, 100, 2, 2, 4, 'Ataque', 'mago.png', 'raro', 'mago.mp3'),
('Fantasma', 'Atraviesa unidades enemigas, invisible los primeros 5 segundos.', 200, 1.0, 30, 1, 1, 3, 'Ataque', 'fantasma.png', 'exotico', 'fantasma.mp3'),
('Orco', 'Fuerte y resistente, buen balance entre ataque y defensa.', 350, 1.0, 60, 1.2, 1, 3, 'Defensa', 'orco.png', 'comun', 'orco.mp3'),
('Asesino', 'Alto daño y velocidad, perfecto para eliminar objetivos clave rápidamente.', 150, 1.5, 80, 1, 1, 4, 'Ataque', 'asesino.png', 'raro', 'asesino.mp3'),
('Centauro', 'Versátil para ataque y defensa, efectivo en múltiples situaciones.', 300, 1.0, 70, 1.5, 2, 4, 'Ataque', 'centauro.png', 'exotico', 'centauro.mp3'),
('Hechicera de Hielo', 'Puede ralentizar a los enemigos con su magia de hielo, dando ventaja táctica al jugador.', 250, 1.0, 70, 1.5, 2, 6, 'Defensa', 'hechicerahielo.png', 'legendario', 'hechicerahielo.mp3'),
('Gólem de Piedra', 'Un tanque viviente, capaz de absorber una cantidad masiva de daño antes de caer.', 800, 0.5, 100, 2.5, 1, 7, 'Defensa', 'golemdepiedra.png', 'legendario', 'golemdepiedra.mp3'),
('Troll', 'Fuertes y resistentes, los Trolls son excelentes para romper las líneas defensivas enemigas.', 650, 0.5, 120, 2.5, 1, 7, 'Ataque', 'troll.png', 'exotico', 'troll.mp3'),
('Explorador', 'Rápidos y ágiles, los Exploradores son perfectos para reconocer y atacar puntos débiles enemigos.', 200, 1.5, 50, 1, 2, 3, 'Ataque', 'explorador.png', 'comun', 'explorador.mp3'),
('Elfo', 'Excelentes para ataques a larga distancia, los Elfos pueden ablandar al enemigo antes de que se acerquen.', 300, 1.0, 60, 1.2, 3, 4, 'Ataque', 'elfo.png', 'raro', 'elfo.mp3'),
('Berserker', 'Guerreros feroces que causan estragos en las filas enemigas con su increíble velocidad y fuerza.', 450, 1.0, 85, 0.8, 1, 5, 'Ataque', 'berserker.png', 'raro', 'berserker.mp3'),
('Torre Inferno', 'Su daño aumenta cuanto más tiempo permanece enfocado en un solo objetivo, ideal contra unidades de alta salud.', 550, 0, 20, 2, 2, 6, 'Defensa', 'torreinferno.png', 'exotico', 'torreinferno.mp3'),
('Torre de Mago', 'Lanza hechizos de área que pueden afectar a múltiples enemigos a la vez.', 500, 0, 80, 1.5, 2, 7, 'Defensa', 'torredemago.png', 'legendario', 'torredemago.mp3'),
('Barrera de Espinas', 'Daña a los enemigos que la atacan o intentan cruzarla, efectiva para ralentizar avances.', 800, 0, 30, 0, 0, 4, 'Defensa', 'barreradeespinas.png', 'raro', 'barreradeespinas.mp3'),
('Torre de Bombardero', 'Arroja bombas a un área, causando daño masivo a múltiples unidades enemigas.', 600, 0, 100, 2.5, 2, 6, 'Ataque', 'torredebombardero.png', 'exotico', 'torredebombardero.mp3'),
('Cañón', 'Ideal para defensa contra unidades terrestres, el Cañón proporciona un sólido punto de control.', 500, 0, 80, 2, 2, 4, 'Defensa', 'canon.png', 'comun', 'canon.mp3'),
('Catapulta', 'Con su gran alcance y daño en área, la Catapulta es perfecta contra grupos de enemigos.', 400, 0, 120, 3, 3, 5, 'Ataque', 'catapulta.png', 'raro', 'catapulta.mp3'),
('Mortero', 'El Mortero puede alcanzar y dañar a enemigos desde una distancia segura, ideal para posiciones fortificadas.', 450, 0, 100, 2.5, 4, 6, 'Ataque', 'mortero.png', 'exotico', 'mortero.mp3'),
('Torre de Arqueras', 'Alberga a tres arqueras que atacan independientemente a los enemigos en su rango.', 650, 0, 45, 1, 3, 5, 'Defensa', 'torredearqueras.png', 'raro', 'torredearqueras.mp3');

-- Insertar un usuario dummy
INSERT INTO Usuarios (NombreUsuario, CorreoElectronico, Contraseña, PuntuaciónMáxima) VALUES 
('jugador1', 'jugador1@example.com', 'contraseñaSegura123', 0);

-- Insertar un mazo para el usuario dummy
INSERT INTO Mazos (IDUsuario, NombreMazo) VALUES 
(1, 'Mazo Inicial');

-- Insertar detalles del mazo (asumiendo que los IDs de las cartas van del 1 al 10)
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
(1, 10, 2);

-- Insertar una partida dummy
INSERT INTO Partidas (IDUsuario, FechaHoraInicio, FechaHoraFin, Puntuación, OrdasSuperadas) VALUES 
(1, '2023-01-01 10:00:00', '2023-01-01 10:30:00', 500, 5);

-- Insertar acciones de partida (ejemplo)
INSERT INTO AccionesPartida (IDPartida, Momento, IDCarta, DescripciónAcción) VALUES 
(1, '2023-01-01 10:05:00', 1, 'Invocar'),
(1, '2023-01-01 10:06:00', 2, 'Invocar'),
(1, '2023-01-01 10:07:00', 3, 'Mover');