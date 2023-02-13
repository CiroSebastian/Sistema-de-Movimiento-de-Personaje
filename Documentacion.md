# Sistema de Movimiento de Personaje

-Ciro Sebastián Hernández López

# Contenidos

Este proyecto consiste en una escena reminiscente a los juegos clásicos de plataformas, en ella se encuentran el objeto jugador, una meta y varios obstáculos. El jugador cuenta con una serie de opciones de movimiento para recorrer la escena, cada una de estas estas controlada por un Script de C3#.

# Funcionamiento

El script más importante es el llamado “PlayerMovement”, este permite mover al jugador usando las teclas del teclado.

Este funciona primero aplicando una velocidad a un RigidBody2D aplicado al objeto jugador, la dirección de esta depende del Input Axis “Horizontal” asignado a las teclas “A” y “D”.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled.png)

Para permitir saltar al jugador se aplica una fuerza al mismo RigidBody2D cuando se presiona la tecla “W”, haciendo que se eleve.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled%201.png)

También se realiza un chequeo cada que toca el suelo usando una variable llamada “JumpCount”, solo permite saltar cuando sea mayor que 1, al saltar esta se reduce por uno, al tocar el suelo se suma 1. Esto evita que el jugador pueda saltar varias veces antes de tocar el suelo.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled%202.png)

Para agacharse primero se revisa si el jugador está saltando, en caso de que no se reduce a la mitad la escala del objeto jugador en caso de que la tecla “S” está siendo presionada, y se regresa a su escala normal cuando esta se suelta.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled%203.png)

En caso de que el jugador este en el aire cuando presiona la tecla “S” este realizara una caída rápida, este utiliza la misma funciona de manera similar que el salto. Aplica una fuerza al RigidBody2D, pero esta vez con un valor negativo mandándolo hacia abajo.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled%204.png)

Otro Script es encargado de las funciones de muerte y reaparición. Este funciona reiniciando la posición del jugador cada que reaparece.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled%205.png)

Para activar el método “Respawn” se tiene que llegar a la meta, tocar algo que mate al jugador o presionando el botón de reinicio.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled%206.png)

Para saber si se entra en contacto con la meta o un objeto dañino se usa una función OnTriggerEnter que verifica el Tag del objeto.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled%207.png)

Para mostrar pantallas de muerte o de victoria de utiliza una serie de métodos e “Invokes” para activar y desactivar los GameObjects correspondientes.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled%208.png)

El ultimo Script se dedica a que la cámara siga al jugador con un Offset en el eje Z para poder mostrar la escena conforme el jugador se mueve.

![Untitled](Sistema%20de%20Movimiento%20de%20Personaje%20ade471f9b8a94254bf07d088db8c48e9/Untitled%209.png)

# Usos

El sistema de movimiento en el Script “PlayerMovement” es fácilmente transferible a otros programas con movimiento lateral en 2 dimensiones.