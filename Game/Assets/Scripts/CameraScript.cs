using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
