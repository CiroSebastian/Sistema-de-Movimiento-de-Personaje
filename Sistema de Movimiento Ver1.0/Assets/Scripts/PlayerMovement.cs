using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public float fall;

    private float Move;

    int JumpCount = 1;

    public Rigidbody2D rb;

    public bool isJumping;

    public GameObject Death;
    public GameObject Win;

    // Start is called before the first frame update
    void Start()
    {
        StopDeathScreen();
        StopWinScreen();
    }

    // Update is called once per frame
    void Update()
    {
        // Encargada de movimientos de izquierda a derecha
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y); 

        // Encargada del Salto
        if (Input.GetKeyDown(KeyCode.W) && isJumping == false && JumpCount > 1)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
            JumpCount--;
        }

        //Controla la funcion de "Agacharse"
        if (Input.GetKeyDown(KeyCode.S) && isJumping == false)
        {
            transform.localScale = new Vector2(1f, .5f);
        }

        if (Input.GetKeyUp(KeyCode.S) && isJumping == false)
        {
            transform.localScale = new Vector2(1f, 1f);
        }

        //Permite realizar una "Caida Rapida"
        if (Input.GetKeyDown(KeyCode.S) && isJumping == true)
        {
            rb.AddForce(new Vector2(rb.velocity.x, fall));
        }

        //Permite reinicar el nivel en cualquier momento
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    //Determina si el Jugador esta saltando o no
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            JumpCount++;
        }
    }
    
    //Determina si el jugador entra en contacto con algo dañino o la meta
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            Respawn();
            WinScreen();
        }
        if (other.gameObject.CompareTag("KillBox"))
        {
            Respawn();
            DeathScreen();
        }
    }

    //Metodos encargados de mostrar y dejar de mostrar la pantalla de Muerte
    private void DeathScreen ()
    {
        Death.SetActive(true);
        Invoke("StopDeathScreen", 2f);
    }

    private void StopDeathScreen()
    {
        Death.SetActive(false);
    }

    //Metodos encargados de mostrar y dejar de mostrar la pantalla de Victoria
    private void WinScreen()
    {
        Win.SetActive(true);
        Invoke("StopWinScreen", 2f);
    }

    private void StopWinScreen()
    {
        Win.SetActive(false);
    }

    //Metodo encargado de la reaparición del jugador cuando muere o se reinicia el nivel
    private void Respawn()
    {
        transform.position = new Vector2(0, 0);
    }
}
