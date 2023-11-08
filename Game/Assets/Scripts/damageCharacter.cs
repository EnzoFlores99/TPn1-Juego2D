using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageCharacter : MonoBehaviour
{
    
    void Start()
    {
        
    } 
    void Update()
    {
        
    }
    //metodo para detectar la colision con otro objeto, en este caso con las espinas
    private void OnTriggerEnter2D(Collider2D other)
    {
        //si el objeto con el que se ha producido la colisión tiene una etiqueta Player
        if(other.tag=="Player")
        {
            //llamamos al metodo de otra clase, se reduce la vida del jugador
            HealthCharacter.instance.DealDamage();

        }
    }
}
