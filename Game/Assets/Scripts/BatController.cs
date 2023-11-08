using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    //velocidad a la que se movera el murcielago
    [SerializeField] private float velocityMovement;
    //arreglo de puntos a los que se movera
    [SerializeField] private Transform[] pointsMovement;
    //distancia minima para que no llegue al punto
    [SerializeField] private float distanceMinim;
    //numero aleatorio para los puntos
    private int numberAleatorio;
    //referencia al control de representacion del objeto
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        //el numero aleatorio es un numero aleatorio entre 0 y la cantidad de puntos en el arreglo
        numberAleatorio = Random.Range(0,pointsMovement.Length);
        //obtenemos la referencia al SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
        //llamamos al metodo girar
        Girar();
    }
    private void Update()
    {
        //cambia la posicion del objeto mediante el MoveTowards, usamos un punto aleatorio del arreglo y le asignamos la velocidad
        transform.position = Vector2.MoveTowards ( transform.position,pointsMovement [numberAleatorio].position, velocityMovement * Time.deltaTime);
        //si la distancia entre el punto y el objeto es menor que la distancia minima
        if(Vector2.Distance(transform.position, pointsMovement[numberAleatorio].position)<distanceMinim)
        {
            //se cambia el numero aleatorio
            numberAleatorio = Random.Range (0,pointsMovement.Length);
            //llamamos al metodo girar
            Girar();
        }
    }
    private void Girar()
    {
        //si la posicion x del objeto es menor a la posicion del punto
        if (transform.position.x< pointsMovement[numberAleatorio].position.x)
        {
            //se cambia el flip, invierte en el eje x
            spriteRenderer.flipX=true;
        }
        else
        {
            //sino, no lo hace
            spriteRenderer.flipX=false;
        }
    }
}
