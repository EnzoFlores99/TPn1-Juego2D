using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    // fuerza que aplicamos al saltar
    private float jumpForce = 1400f;
     //banadera que indica si el personaje esta en la plataforma
    private bool isGrounded;
     // referencia al componente rigidbody2d del personaje
    private Rigidbody2D rb;
    //referencia al componente AudioSource del personaje
    private AudioSource JumpSound;

    private void Start()
    {
        // obtenemos la referencia al rigidbody2d del personaje
        rb = GetComponent<Rigidbody2D>(); 
        //referencia del sonido del salto perteneciente al personaje
        JumpSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // llamamos a la funcion Jump () si el personaje esta en una plataforma y se presiona el boton de saltar
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
    }
    // cuando el personaje colisiona con un objeto, se establece isGrounded como verdadero
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    // cuando el personaje deja de colisionar con un objeto, se establece isGrounded como falso
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    // funcion que aplica una fuerza vertical para ejecutar el salto. Normalizamos el salto con deltaTime
    public void Jump()
    {
       rb.AddForce(Vector2.up*jumpForce);
       // se llama a la uncion que reproduce un sonido
        PlayJumpSound();
    }
    private void PlayJumpSound()
    {//se reproduce un sonido
        if(JumpSound!= null)
        {
            JumpSound.Play();
        }
    }
}
