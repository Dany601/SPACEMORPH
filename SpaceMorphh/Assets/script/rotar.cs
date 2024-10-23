using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour
{

    public float velocidadRotacion = 45f;
    public KeyCode teclaRotacion = KeyCode.R;
    public Vector3 puntoDeRotacion;
    public float anguloMaximoRotacion = 45f; // �ngulo m�ximo de rotaci�n en grados

    private float rotacionActual = 0;

    void Start()
    {
        puntoDeRotacion = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(teclaRotacion))
        {
            rotacionActual += velocidadRotacion;

            // Verificar si se excede el �ngulo m�ximo
            if (Mathf.Abs(rotacionActual) > anguloMaximoRotacion)
            {
                rotacionActual = Mathf.Clamp(rotacionActual, -anguloMaximoRotacion, anguloMaximoRotacion);
            }

            transform.RotateAround(puntoDeRotacion, Vector3.up, velocidadRotacion);
        }
    }
}
