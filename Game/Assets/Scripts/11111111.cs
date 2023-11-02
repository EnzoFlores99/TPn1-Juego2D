using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotScript : MonoBehaviour
{
  [SerializeField] private float velocidad;
  [SerializeField] private Transform controlSuelo;
  [SerializeField] private float distancia;
  [SerializeField] private bool moviendoDerecha;
  private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpadet()
    {
       RaycastHit2D InformacionSuelo = Physics2D.Raycast(controlSuelo.position,Vector2.down,distancia);
       rb.velocity = new Vector2(velocidad, rb.velocity.y);

       if (InformacionSuelo == false)
       {

       }
    }
    void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 100,0);
        velocidad *=-1;
    }
    void Update()
    {
        
    }
}
