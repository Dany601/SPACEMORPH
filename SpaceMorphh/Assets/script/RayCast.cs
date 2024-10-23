using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class RayCast : MonoBehaviour
{
    public int rango;
    public GameObject camara;
    public UnityEngine.UI.Image IndicadorCentral;

    private void Update()
    {
        IndicadorCentral.color = Color.white;

        RaycastHit hit;
        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, rango))
        {
           if (hit.collider ==true)
            {
              IndicadorCentral.color =Color.white;
            }
            if(hit.collider.GetComponent<DatosRecursos>()==true)
            {
               IndicadorCentral.color = Color.red;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<DatosRecursos>().obtiene = true;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(camara.transform.position, camara.transform.forward * rango);
    }
}
