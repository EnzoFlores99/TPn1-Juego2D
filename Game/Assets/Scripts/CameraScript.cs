using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Para que la camara siga al jugador en el eje x
/// </summary>
public class CameraScript : MonoBehaviour
{
    public GameObject Character;
        void Update()
    {
        Vector3 position = transform.position;
        position.x = Character.transform.position.x;
        transform.position= position;
    }
}
