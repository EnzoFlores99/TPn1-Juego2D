using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
     //velocidad de movimiento del personaje
    [SerializeField] private float movementSpeed = 1250f;
     //respresenta el valor de mirar a la derecha
    private bool isFacingRight = true;
     //referencia al componente Rigibody2D del personaje
    private Rigidbody2D rb;

    private void Start()
    {
         //Obtenemos la referncia al Rigibody2D del personaje 
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //obtenemos la entrada del moviemnto hoizontal (-1 a 1) y la almacenamos en movementX
        float movementX = Input.GetAxis("Horizontal");
         //normalizamos al multiplicar por deltatime
        Move(movementX * movementSpeed);
        // giro del personaje si se mueve hacia la izquierda
        if (movementX < 0 && isFacingRight)
        {
            Flip();
        }
        //giro del personaje si se mueve a la derecha
        else if (movementX >0 && !isFacingRight)
        {
            Flip();
        }
    }
    
    // establecemos la velocidad del PJ para el movimiento horizontal
    public void Move (float velocity)
    {
        rb.velocity = new Vector2(velocity * Time.deltaTime, rb.velocity.y);
    }
    // cambiamos la escala en el eje X para voltear el personaje
    private void Flip()
    {
        //la escala se invierte solo en el eje X, hace que el objeto se invierta
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //hace que valor booleano cambie, orientacion del objeto
        isFacingRight = !isFacingRight;
    }
}