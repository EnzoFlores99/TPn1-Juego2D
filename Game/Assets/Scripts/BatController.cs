using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    [SerializeField] private float velocityMovement;
    [SerializeField] private Transform[] pointsMovement;
    [SerializeField] private float distanceMinim;
    private int numberAleatorio;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        numberAleatorio = Random.Range(0,pointsMovement.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards ( transform.position,pointsMovement [numberAleatorio].position, velocityMovement * Time.deltaTime);
        if(Vector2.Distance(transform.position, pointsMovement[numberAleatorio].position)<distanceMinim)
        {
            numberAleatorio = Random.Range (0,pointsMovement.Length);
            Girar();
        }
    }
    private void Girar()
    {
        if (transform.position.x< pointsMovement[numberAleatorio].position.x)
        {
            spriteRenderer.flipX=true;
        }
        else
        {
            spriteRenderer.flipX=false;
        }
    }
}
