using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DatosRecursos : MonoBehaviour
{
    public GameObject panelRecursos;

    [SerializeField]
    private bool oro;
    [SerializeField]
    private bool piedra;
    [SerializeField]
    private bool documento;

    public bool obtiene;

    private void Update()
    {
        if(oro == true && obtiene == true)
        {
            panelRecursos.GetComponent<RecursosPanel>().Oro += 1;
            Destroy(gameObject);
        }
        if (piedra == true && obtiene == true)
        {
            panelRecursos.GetComponent<RecursosPanel>().Piedra += 1;
            Destroy(gameObject);
        }
        if (documento == true && obtiene == true)
        {
            panelRecursos.GetComponent<RecursosPanel>().Documento += 1;
            Destroy(gameObject);
        }
    }
}
