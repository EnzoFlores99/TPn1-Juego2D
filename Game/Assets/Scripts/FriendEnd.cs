using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FriendEnd : MonoBehaviour
{
    //metodo para detectar la colision entre el personaje
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si hay colision entre el Objeto con la etiqueta Player
        if(collision.tag=="Player")
        {
            //si se cumple la condicion, cambia de escena
            SceneManager.LoadScene(4);
        }
    }
}
