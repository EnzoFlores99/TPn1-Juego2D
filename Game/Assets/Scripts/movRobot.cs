using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movRobot : MonoBehaviour
{
    //representa un punto minimo en el eje X
    public float minX;
    //representa un punto maximo en el eje X
    public float maxX;
    //representa el tiempo de espera del objeto
    public float TiempoEspera=1f;
    //representa la velocidad del objeto
    public float Velocidad=2f;
    private GameObject LugarObjetivo;

    //se llama al inicio antes de la primera actualizacion de frames
    void Start()
    {
        UpdateObjetivo();
        StartCoroutine("Patrullar");
    }
    void Update()
    {

    }
    private void UpdateObjetivo()
    {
        //si es la primera vez iniciar el patrullaje para la izquierda
        if (LugarObjetivo == null)
        {
            LugarObjetivo = new GameObject("Sitio_Objetivo");
            LugarObjetivo.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1,1,1);
            return;
        }

        //Iniciar el patrullaje para la derecha
        if (LugarObjetivo.transform.position.x == minX)
        {
            LugarObjetivo.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1,1,1);
        }

        //Cambio de sentido de derecha a izquierda
        else if (LugarObjetivo.transform.position.x == maxX)
        {
            LugarObjetivo.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    private IEnumerator Patrullar()
    {
        //Corrutina para mover el enemigo
        while (Vector2.Distance(transform.position, LugarObjetivo.transform.position)>0.05f)
              //Se desplaza hasta el sitio objetivo
        {
            Vector2 direction = LugarObjetivo.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * Velocidad * Time.deltaTime);
            yield return null;
        }

        transform.position= new Vector2(LugarObjetivo.transform.position.x, transform.position.y);

        //Espera un segundo para que empiece a moverse
        yield return new WaitForSeconds(TiempoEspera);

        UpdateObjetivo();
        StartCoroutine("Patrullar");
    }

}
