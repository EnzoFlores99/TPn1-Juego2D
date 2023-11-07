using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movRobot : MonoBehaviour
{
    /*
  [SerializeField] private float velocidad;
  [SerializeField] private Transform controlSuelo;
  [SerializeField] private float distancia;
  [SerializeField] private bool moviendoDerecha;
  private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       RaycastHit2D InformacionSuelo = Physics2D.Raycast(controlSuelo.position,Vector2.down,distancia);
       rb.velocity = new Vector2(velocidad, rb.velocity.y);

       if (InformacionSuelo == false)
       {

       }
    }
    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 100,0);
        velocidad *=-1;
    }
    private void OnDrawGizmos()
    {

    }*/
    public float minX;
    public float maxX;
    public float TiempoEspera=1f;
    public float Velocidad=2f;
    private GameObject _LugarObjectivo;

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
        if (_LugarObjectivo == null)
        {
            _LugarObjectivo = new GameObject("Sitio_Objetivo");
            _LugarObjectivo.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1,1,1);
            return;
        }

        //Iniciar el patrullaje para la derecha
        if (_LugarObjectivo.transform.position.x == minX)
        {
            _LugarObjectivo.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1,1,1);
        }

        //Cambio de sentido de derecha a izquierda
        else if (_LugarObjectivo.transform.position.x == maxX)
        {
            _LugarObjectivo.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    private IEnumerator Patrullar()
    {
        //Corrutina para mover el enemigo
        while (Vector2.Distance(transform.position, _LugarObjectivo.transform.position)>0.05f)
              //Se desplaza hasta el sitio objetivo
        {
            Vector2 direction = _LugarObjectivo.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * Velocidad * Time.deltaTime);
            yield return null;
        }

        transform.position= new Vector2(_LugarObjectivo.transform.position.x, transform.position.y);

        //Espera un segundo para que empiece a moverse
        yield return new WaitForSeconds(TiempoEspera);

        UpdateObjetivo();
        StartCoroutine("Patrullar");
    }

}
