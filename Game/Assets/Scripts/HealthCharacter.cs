using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCharacter : MonoBehaviour
{
    //instanciamos la clase para acceder a los metodos
    public static HealthCharacter instance;
    //vaariables para llevar el conteo de las vidas
    public int currentHealth, maxHealth;
    //variable para el tiempo de inmunidad
    public float invincibleLenght;
    //variable para el conteo de la inmunidad
    private float invincibleCounter;
    //referncia al sprite del personaje para hacerlo intermitente
    private SpriteRenderer theSr;
    //metodo para inicializar variables o estados antes de que comience el juego
    private void Awake()
    {
        //instanciamos la clase para utilizarla
        instance = this;
    }
   
    void Start()
    {
        //comienza con las vidas al maximo
        currentHealth = maxHealth;
        //referncia al spriterenderer del personaje
        theSr= GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //si el conteo es mayor que 0
        if(invincibleCounter>0)
        {
            //empieza el conteo para llegar a 0
            invincibleCounter -= Time.deltaTime;
            //si el personaje recibio daño
            if(invincibleCounter<= 0)
            {
                //modificamos el valor de alfa en su tabla de colores, para hacerlo transparente
                theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b,1f);
            }
        }
    }

//metodo para que jugador sufra daño
    public void DealDamage()
    {
        //si el conteo es menor a 0, se hace daño
        if(invincibleCounter<=0)
        {
            //se reduce la vida en una unidad
            currentHealth--;
            //si tenemos 0 vidas
        if (currentHealth<=0)
        {
            currentHealth=0;
            //se desactiva el personaje
            gameObject.SetActive(false);
            //y llama al metodo
            GameOver();
            

        }
        //si perdemos vidas pero no llegamos a 0
        else
        {
            //hacemos que el conteo se completa
            invincibleCounter = invincibleLenght;
            //modificamos la transperencia del personaje
            theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b,0.5f);
        }
        //Llamamos a la funcion de la actualizacion de los corazones
        ControllerHeart.instance.UpdateHealthDisplay();
        }
        
    }
    //metodo para finalizar el juego y pasar a la escena GameOver
    public void GameOver()
    {
           SceneManager.LoadScene(3);
    }
}
