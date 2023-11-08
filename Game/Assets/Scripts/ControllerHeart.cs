using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Controlamos los Corazones
public class ControllerHeart : MonoBehaviour
{
    //instanciamos la clase para acceder a los metodos
    public static ControllerHeart instance;
    //hacemos referncia a las imagenes que usaremos
    public Image Heart1, Heart2, Heart3;
    //referncia a los corazones llenos y vacios
    public Sprite heartFull, heartEmpty;
    private void Awake()
    {
        //instanciamos la clase para utilizarla
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //metodo para la actualizacion de los corazones
    public void UpdateHealthDisplay()
    {
        //de acuerdo a la vida del jugador sucede
        switch(HealthCharacter.instance.currentHealth)
        {
            //en caso de que la vida sea 3, se muestra los corazones llenos
            case 3:
            Heart1.sprite=heartFull;
            Heart2.sprite=heartFull;
            Heart3.sprite=heartFull;
            break;

            //en caso de que la vida sea 2, se muestran 2 llenos y uno vacio
            case 2:
            Heart1.sprite=heartFull;
            Heart2.sprite=heartFull;
            Heart3.sprite=heartEmpty;
            break;

            //en caso de que la vida sea 1, se muestran 1 lleno y 2 vacios
            case 1:
            Heart1.sprite=heartFull;
            Heart2.sprite=heartEmpty;
            Heart3.sprite=heartEmpty;
            break;

            //en caso de que la vida sea 0, se muestran 3 vacios
            case 0:
            Heart1.sprite=heartEmpty;
            Heart2.sprite=heartEmpty;
            Heart3.sprite=heartEmpty;
            break;

        }
    }
}
