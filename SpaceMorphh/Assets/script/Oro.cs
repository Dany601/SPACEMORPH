using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oro : MonoBehaviour
{
    public GameObject ObjPuntos;
    public float puntosQueDa;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            ObjPuntos.GetComponent<Puntos>().puntos += puntosQueDa;
            Destroy(gameObject);
        }
    }
}
