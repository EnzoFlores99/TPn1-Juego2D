using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
     // referencia al componente Animator del Personaje
    private Animator animator;

    private void Start()
    {
         // obtenemos la referncia al componente Animator
       animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // comparamos el valor del movimiento (-1 / 0 / 1)
        if (Input.GetAxis("Horizontal") != 0) 
        {
             // activar la animacion de caminar
            animator.SetBool("isRunning", true);
        }
        else
        {
             // desactivar la animacion de caminar
            animator.SetBool("isRunning", false);
        }
    }
    // cuando el personaje colisiona con el objeto, desactiva animacion de salto
    private void OnCollisionEnter2D(Collision2D collision)
    {
         // desactiva la animacion de salto
        animator.SetBool("isJumping", false);
    }
    // cuando el personaje deja de colisionar con un objeto, activa la animacion de salto
    private void OnCollisionExit2D(Collision2D collision)
    {
         // activa la animacion de saltar
        animator.SetBool("isJumping", true);
    }
}
