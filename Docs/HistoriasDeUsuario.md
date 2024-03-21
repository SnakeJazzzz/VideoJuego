# **Historias De Usuario**


### **1**

Yo como jugador quiero tener la opción de ver todas las cartas del juego en el menu, con su descripcion y estadisticas para poder crear mi estrategia.

Requerimiento Funcional: Crear escena de menu

Requerimiento Funcional: Agregar botones que cargen otras escenas

Requerimiento No Funcional: Hacer que la pagina de inicio se vea bonita.


### **2**

Yo como jugador quiero poder crear mazos en el menu sin tener que entrar a una partida.

Requerimiento Funcional: Crear escena de creación de mazos.

Requerimiento Funcional: Crear sistema permita insertar y/o eliminar cartas del mazo.

Requerimiento Funcional: Guardar los mazos del usuario.

Requerimiento No Funcional: Hacer que la pagina de creacion de mazos de vea bonita.


### **3**

Yo como jugador quiero que al entrar a una partida; pueda elegir mi mazo entre mis mazos prehechos, o crear uno en el momento.

Requerimiento Funcional: Mostrarle al jugador todos sus mazos disponibles.

Requerimiento Funcional: Guardar el mazo elegido para la partida.

Requerimiento Funcional: Crear el UI.

Requerimiento No Funcional: Hacer que se vea bonito el UI.


### **4**

Yo como jugador quiero tener acceso en el menu a un doc de instrucciones basicas de como se juega para poder entender si es mi primer vez jugando.

Requerimiento Funcional: Crear la escena para mostrar las instrucciones.

Requerimiento No Funcional: Que la informacion sea buena y concisa.


### **5**

Yo como jugador quiero que cada vez que coloque una carta en el mapa (tablero), la carta invoque al personaje de la carta y este pelee de mi equipo para poder ganar la partida.

Requerimiento Funcional: Crear un objeto Spawner que se encargue de instanciar a los personajes.

Requerimiento Funcional: Instancar al mismo personaje de la carta seleccioanda.


### **6**

Yo como jugador quiero recibir recursos cada cierto tiempo para poder desplegar mis cartas en el mapa.

Requerimiento Funcional: Que el recurso vaya incrementando por tiempo.

Requerimiento Funcional: Al usar cartas que disminuya el recurso.

Requerimiento No Funcional: Demostrar de forma gráfica cunatos recursos hay disponibles.


### **7**

Yo como jugador quiero tener la habilidad de tener 6 cartas "en mano", es decir disponibles para colocar y cada vez que coloque una reciba otra de mi mazo para rotar por mis distintas cartas.

Requerimiento Funcional: Sistema de admistracion de cartas.

Requerimiento Funcional: Forma de seleccionar cartas "en mano".

Requerimiento No Funcional: UI que enseña las cartas "en mano".


### **8**

Yo como jugador quiero que cada vez que coloque una carta en el mapa, esta se descarte para no spamearla.

Requerimiento Funcional: Marcar cartas como descartadas.


### **9**

Yo como jugador quiero que cuando se me acaben todas las cartas de mi mazo, todas las cartas descartas se vuelvan a revolver y me den 6 cartas "en mano" de nuevo para poder seguir jugando.

Requerimiento Funcional: Sistema que revuelva las cartas.

Requerimiento Funcional: Dar las primeras 6 cartas a mano.

Requerimiento No Funcional: Indicar visualmente que se estan revolviendo las cartas.


### **10**

Yo como jugador quiero que el proceso de revolver las cartas descartadas tarde un tiempo, en el cual no pueda poner cartas para que el oponente tenga una ventaja en esos momentos, y de esta forma se puedan crear diversas estrategias.

Requerimiento Funcional: LLevar tracking del tiempo.

Requerimiento Funcional: Que el jugador no reciba cartas hasta el final del tiempo.


### **11**

Yo como jugador quiero que el personaje invocado por mis cartas se mueva hacia su target mas cercano (tropas enemigas), para poder defender a los huevos de dragon.

Requerimiento Funcional: Implementación de IA para el movimiento de personajes.

Requerimiento Funcional: Movimiento automático de personajes hacia enemigos cercanos.

Requerimiento No Funcional: Visualización clara del objetivo y movimiento del personaje.


### **12**

Yo como jugador quiero que al principio de cada orda, se me avise que numero de orda es, para llevar registro de las ordas.

Requerimiento Funcional: Sistema de notificación para el inicio de cada horda.

Requerimiento Funcional: Visualización del número de la horda en la notificación.

Requerimiento No Funcional: Estilo y diseño coherente de las notificaciones.


### **13**

Yo como jugador quiero que al perder uno de los huevos de dragon no principal, del huevo salgo mucho fuego que mate a enemigos cercanos, para darme oportunidad de recuperame para seguir defendiendo.

Requerimiento Funcional: Activación de explosión de fuego al perder un huevo de dragón.

Requerimiento Funcional: Sistema de daño a enemigos por fuego del dragon.

Requerimiento No Funcional: Efectos visuales y de sonido impactantes para la explosión.


### **14**

Yo como jugador quiero poder acceder a un resumen de mis últimas partidas en el menú principal, para poder llevar un registro simple de mis victorias y derrotas.

Requerimiento Funcional: Función para acceder a un resumen de partidas anteriores.

Requerimiento Funcional: Visualización de victorias y derrotas en el resumen.

Requerimiento No Funcional: Interfaz de usuario intuitiva para el resumen de partidas.



### **15**

Yo como jugador quiero que cuando mis tropas esten en rango a las otras tropas enemigas, las ataquen, para derrotar esa orda.

Requerimiento Funcional: Implementación de sistema de detección de rango para el ataque.

Requerimiento Funcional: Ataque automático a enemigos dentro del rango.

Requerimiento No Funcional: Precisión en la detección de rango y en el sistema de ataque.


### **16**

Yo como jugador qyuero que cuando mi huevo de dragon principal se rompa, se acabe el juego y un cartel diga quien a que orda gane y mi score, para que el juego acabe y quede claro el marcador.

Requerimiento Funcional: Finalización del juego al romperse el huevo de dragón principal.

Requerimiento Funcional: Mostrar cartel con información de la horda alcanzada y el score final.

Requerimiento No Funcional: Transición suave hacia la pantalla de finalización del juego.


### **17**

Yo como jugador quiero poder ordenar y filtrar mis cartas por atributos como tipo, costo, daño y vida, para facilitar la construcción de mi mazo.

Requerimiento Funcional: Funcionalidad para ordenar cartas por atributos (tipo, costo, daño, vida).

Requerimiento No Funcional: Interfaz intuitiva para la organización y filtrado de cartas.


### **18**

Yo como jugador quiero ver de manera visual la zona donde me es permitido poner cartas, para poder planear mi estrategia.

Requerimiento Funcional: Visualización de la zona permitida para colocar cartas en el campo de juego.

Requerimiento Funcional: Actualización dinámica de la zona visual según el estado del juego.

Requerimiento No Funcional: Claridad visual para distinguir la zona permitida.


### **19**

Yo como jugador quiero un contador visible durante el juego que muestre cuántas cartas me quedan en mi mazo, para poder planear mejor mi estrategia a largo plazo.

Requerimiento Funcional: Mostrar un contador de cartas restantes en el mazo durante el juego.

Requerimiento Funcional: Actualización en tiempo real del contador conforme se usan las cartas.

Requerimiento No Funcional: Precisión en la actualización y visualización del contador de cartas.


### **20**

Yo como jugador quiero tener un limite de recurso de desplegar cartas, para que no pueda ahorrar demasiado.

Requerimiento Funcional: Establecimiento de un límite de recursos para el despliegue de cartas.

Requerimiento Funcional: Sistema de gestión de recursos que se actualiza con el uso de cartas.

Requerimiento No Funcional: Claridad en la representación visual del límite de recursos y su consumo.


### **21**

Yo como jugador quiero que los distintos personajes de cartas tengan diferentes tipos de ataques, como; ataque en área, ataque a distancia, etc.

Requerimiento Funcional: Crear diferentes tipos de ataques para personajes de cartas (splash damage, ataque a distancia).

Requerimiento Funcional: Balance adecuado entre los diferentes tipos de ataques.

Requerimiento No Funcional: Animaciones y efectos para cada tipo de ataque.

Requerimiento No Funcional: Claridad y distinción de efectos de ataques.


### **22**

Yo como jugador quiero que el juego tenga un timer que me deje ver visualmente cuanto tiempo lleva la partida.

Requerimiento Funcional: Crear cronómetro para contar el tiempo de partida.

Requerimiento Funcional: Crear espacio en base de datos para guardar el tiempo de partida.

Requerimiento No Funcional: Hacer que el cronometro se vea durante la partida.


### **23**

Yo como jugador quiero tener un sistema simple de recompensas para convencerme de jugar más.

Requerimiento Funcional: Desarrollar sistema de puntajes y puntajes maximos.

Requerimiento Funcional: Hacer espacio en la base de datos para guardar puntajes de diversos perfiles.

Requerimiento Funcional: Crear escena donde se vean los puntajes.

Requerimiento No Funcional: Hacer diseño visual para que se vean los mejores puntajes.


### **24**

Yo como jugador quiero que el juego tenga musica de fondo para ambientar el juego.

Requerimiento Funcional: Crear espacio en la base de datos dedicado a musica para cada escena.


### **25**

Yo como jugador quiero que al poner una carta, esta haga un sonido carcteristo para que el juego sea mas inmersivo.

Requerimiento Funcional: Crear espacio en la base de datos dedicado a sonidos para cada carta.


### **26**

Yo como jugador quiero que haya una torre alado de el huevo de dragon que hagan daño a los enemigos cercanos, para que se puedan defender.

Requerimiento Funcional: Crear sistema completo de las torres.

Requerimiento No Funcional: Hacer diseño de las torres.


### **27**

Yo como jugador quiero que al solo quedar el huevo de dragon principal se duplique el generamiento de recursos para poner cartas, asi el final es mas movido y entretenido.

Requerimiento Funcional: Crear segundo sistema de generación de recursos para esta condición.

Requerimiento No Funcional: Realizar diseño para fase de x2 de recursos.


### **28**

Yo como jugador quiero que las ordas de enemigos se vayan haciendo progresivamente mas dificiles.

Requerimiento Funcional: Crear sistema con formula exponensial para que las ordas de montruos sean cada vez más dificiles.

Requerimiento No Funcional: Diseñar monstruos.

Requerimiento No Funcional: Diseñar contador de ordas.


### **29**

Yo como jugador quiero que las ordas de enemigos no sean siempre iguales y alla variacion entre ellas.

Requerimiento Funcional: Crear sistema de generación de ordas para que haya distintas variaciones balanceadas.


### **30**

Yo como jugador quiero que el jeugo tenga animaciones basicas para que el juego se vea bien.

Requerimiento Funcional: Crear sistema para indentificar los eventos para presentar sus animaciones.


### **31**

Yo como jugador quiero que los personajes tengan profundidad y no este "plano" el juego, para que se vea mas bonito.

Requerimiento No Funcional: Crear diseños de personajes con profundidad y animaciones.
