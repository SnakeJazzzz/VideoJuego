# **Tower Siege**

## _GDD: Documento de Diseño de Juego_

---

##### **Aviso de derechos de autor**

Pedro Mauri Mtz - A01029143

Michael Andrew Devlyn - A01781041

Tomás Molina Pérez Diez - A01784116

---

## _Índice_

---

1. [Índice](#índice)
2. [Diseño de Juego](#diseño-de-juego)
    1. [Resumen](#resumen)
    2. [Jugabilidad](#jugabilidad)
    3. [Mentalidad](#mentalidad)
3. [Técnico](#técnico)
    1. [Pantallas](#pantallas)
    2. [Controles](#controles)
    3. [Mecánicas](#mecánicas)
4. [Diseño de Niveles](#diseño-de-niveles)
    1. [Temas](#temas)
    2. [Flujo de Juego](#flujo-de-juego)
5. [Desarrollo](#desarrollo)
6. [Gráficos](#gráficos)
7. [Sonidos/Música](#sonidosmúsica)
8. [Cronograma](#cronograma)

## _Diseño de Juego_

---

### **Resumen**

En "Tower Siege", dos jugadores se enfrentan en una batalla estratégica con el objetivo de destruir la torre principal del rival, con la ayuda de  mazos de cartas las cuales representan varias unidades para atacar al oponente mientras las suyas defienden. El dominio de creación de mazo, posicionamiento de unidades y la gestión de recursos es clave para la victoria en este competitivo juego 2D para computadoras.

---

### **Jugabilidad**

#### **General**
El juego empieza al enseñarle a los jugadores en que tablero (mapa) de la la partida. Después los jugdaores seleccionan un mazo prehecho o crean uno en el momento. Al usar una carta en el tablero hará que aparezca el personaje de la carta en el lugar colocado. Cada carta tiene un costo de recursos para desplegar y un cooldown después de que haya sido usada. El juego desafía a los jugadores a gestionar estos recursos, desplegar unidades estratégicamente, y conquistar las torres centrales para obtener una ventaja para poder destruir la torre principal del rival.

#### **Creación de Mazos**
El jugador crea un mazo de 40 cartas de un pool de 20 tipos de cartas, consistiendo en que el jugador pueda tener cartas repetidas si quiere. El jugador no sabe que baraja escogió su contrincante.

#### **Torres Centrales**
Al conquistar las torres centrales, estas amplían el espacio donde el jugador dueño puede colocar sus cartas. Al inicio de la partida las torres centrales son neutras y los jugadores tiene que pelear para conquistarlas. Para conquistar una torre central tus tropas tienen que hacer cierto daño, lo cual se vera reflejado en una barra de vida arriba de la torre. El jugador dueño de la unidad que le de el ultimo golpe de dicha barra a la torre central y haga que la barra se llene de nuevo; se vuelve dueño de la torre y obtiene sus ventajas.

#### **Mano, Mazos y Cooldown de cartas**
Los jugadores empiezan la partida con 6 cartas "en mano" o disponibles para colocar en campo de batalla. Al despegar una de estas se les dara otra carta proveniente de su mazo revuelto. El jugador puede colocar muchas cartas si es que tiene los recursos para hacerlo pero solo podra tener un maximo de 6 cartas en mano. Las cartas colocadas se descartan, y cuando todo el mazo del jugador sea descartado. Las cartas descartas se revolveran tras realizar su cooldown y podra volver a obtener 6 cartas en mano. Este proceso va durar 7s dandole al oponente una ventana de oportunidad al oponente donde podra atacar sin que el otro jugador pueda colocar cartas.

#### **Victoria**
La victoria se alcanza destruyendo las torres principales del oponente, en el caso de haberse acabado el tiempo de partida; el jugador que haya hecho más daño al oponente gana, por otra parte, en caso de que el daño realizado sean iguales, comenzará el "sudden death" donde gana el primero en hacer al menos un punto de daño a una torre principal.

---

### **Mentalidad**

El juego busca invocar una mentalidad de planificación estratégica y adaptabilidad. Los jugadores deberían sentir la tensión de la gestión de recursos, la emoción de romper las defensas exitosamente, y la necesidad de adaptarse constantemente al campo de batalla en evolución.

La estarategia del juego tiene muchas facetas, desde la creación de mazo, administración de recursos, el posicionamiento y control del tiempo para la colocación de cartas, la estarategia para llegar a las torres, etc.

---

## _Técnico_

---

### **Pantallas**

- Pantalla de Título
    - Iniciar Partida
        - Mapa de partida
        - Elegir mazo
            - Listas de mazos disponibles
            - Crear mazo
        - Partida
            - Mano (Cartas Disponibles)
            - Menu de pausa
                - Reanudar
                - Salir
            Pantalla de Victoria/Derrota
    - Selección de Mazo
        - Crear mazo
        - Listas de mazos
        - Todas las cartas
            - Descripción y estadísticas (de cada carta)
    - ¿Como Jugar?
        - Documento de instrucciones
    - Opciones
        - Volumen
        - Teclas personalizables
    - Créditos
    - Salir

---

### **Controles**

- **Ratón**: Navegar por los menús, seleccionar cartas y mazos, colocar unidades.
- **Teclado**: Atajos para la selección de cartas, manejo de tropas, menu de pausa, etc.

---

### **Mecánicas**

- **Generación de Recursos**: Los jugadores reciben recursos con el tiempo, utilizados para jugar cartas.
- **Despliegue de Unidades**: Interfaz de arrastrar y soltar para colocar unidades en el campo de batalla.
- **Interacción con el Terreno**: Las unidades interactúan con el terreno, afectando el movimiento y la estrategia.
-**Manejo de unidades desplegadas**: Las unidades toman la dirección que los jugadores indiquen.

---

## _Diseño de Niveles_

---

### **Temas**

#### **Campo de Batalla**
- **Ambiente**: Campo de batalla medieval; muy forestal, con caminos, arboles, lagos, ríos, torres de piedra, etc.
- **Objetos**
    - _Interactivos_:  
        - Obtaculos:
            - Lagos
            - Rios
            - Rocas
            - Arboles
        - Objetivos:
            - Torre principal
            - Torres centrales
            - Torre principal enemiga
    -  _No interactivos_:
        - Decoración
            - Rocas
            - Lagos
            - Rios
            - Arboles

---

### **Flujo de Juego**

1. Cada jugador selecciona su mazo de batalla.
2. Comienza la batalla, los jugadores generan recursos.
3. Los jugadores despliegan unidades, con el objetivo principal de destruir las torres del oponente.
4. La victoria se alcanza cuando la toprre principal de un jugador sea destruida.

---

## _Desarrollo_

---

### **Clases Abstractas / Componentes**

1. **Carta**
    - Atributos: Descripción, Vida, velocidad, daño, velocidad de ataque, rango, costo, enemigos, cooldown, tipo (Ataque/Defensa)
2. **Unidad**
    - Derivado de Carta: Soldado, Caballero, Arquero
3. **Torre**
    - Vida

---

### **Clases Derivadas / Composiciones de Componentes**

- **Unidades**
    - **Soldado**: Bajo costo, unidad básica
    - **Caballero**: Alta salud, rapido
    - **Arquero**: Largo alcance, baja salud
- **Obstáculos**
    - **Árbol**: Proporciona cobertura a ciertas tropas.
    - **lago**: No cruzable por la mayoría, potencia ciertas las unidades.

---

## _Gráficos_

---

### **Atributos de Estilo**

- **Colores**: Vibrantes, colores de equipo distintos para claridad
- **Estilo**: Semi-realista con elementos estilizados, asegurando que las unidades y el terreno sean fácilmente distinguibles.
- **Retroalimentación**: Explosiones para unidades destruidas, contornos brillantes para unidades seleccionables.

### **Gráficos Necesarios**

1. **Unidades**: Sprites animados para cada tipo de unidad.
2. **Terreno**: Texturas variadas para diferentes terrenos (césped, agua, arbol).
3. **Efectos**: Efectos visuales para ataques, recolección de recursos.

## _Sonidos/Música_

---

### **Atributos de Estilo**

- **Instrumentos**: Partituras orquestales con un ritmo dinámico que refleja la intensidad del juego.
- **Efectos de Sonido**: Choque de espadas, pasos de marcha y ruidos de construcción para una jugabilidad inmersiva.

---

### **Sonidos Necesarios**

1. **Movimientos de Unidades**: Cada tipo de unidad tiene sonidos de pasos distintos.
2. **Combate**: Diferentes sonidos para ataques cuerpo a cuerpo, a distancia y de asedio.
3. **Ambientales**: Ambiente de fondo que refleja el terreno actual.

---

### **Música Necesaria**

1. **Tema Principal**: Una pieza orquestal heroica que establece el tono épico del juego.
2. **Música de Batalla**: Música rápida e intensa que se reproduce durante el combate, con variaciones dependiendo de la etapa de la batalla.
3. **Temas de Victoria/Derrota**: Temas distintos que se reproducen al ganar o perder una partida, capturando el ambiente de triunfo o pérdida.
4. **Música de Menú**: Música de fondo sutil y atmosférica para los menús del juego y la pantalla de selección de mazo.

---

## _Cronograma_

---

1. **Fase de Concepto y Diseño** (sem 1-2)
    - Finalizar concepto de juego, mecánicas y documento de diseño.
    - Comenzar arte preliminar y bocetos conceptuales.

2. **Fase de Desarrollo** (sem  3-5)
    - Desarrollar mecánicas de juego principales e implementar jugabilidad básica.
    - Crear niveles iniciales y probar equilibrio.
    - Implementar elementos básicos de UI y controles.

3. **Producción de Arte y Sonido** (sem 6-8)
    - Finalizar todos los activos gráficos incluyendo personajes, entornos y UI.
    - Grabar e integrar efectos de sonido y pistas musicales.

4. **Pruebas y Refinamiento** (sem 9-10)
    - Realizar sesiones de prueba para recopilar comentarios.
    - Refinar jugabilidad, equilibrar unidades y pulir gráficos/sonido.

5. **Preparación para el Lanzamiento** (sem 11)
    - Lanzar el juego.

6. **Soporte Post-Lanzamiento** (Continuo)
    - Monitorear comentarios de los jugadores y abordar cualquier problema con actualizaciones.
    - Lanzar contenido adicional (p.ej., nuevas unidades, mapas) basado en la demanda de los jugadores.

---
