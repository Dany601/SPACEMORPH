using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecursosPanel : MonoBehaviour
{
    public GameObject panelRecursos;

    [Header("Recursos")]
    public int Oro;
    public int Piedra;
    public int Documento;
    private bool panelActivo;
    [Header("TextosRecursos")]
    [SerializeField]
    private Text cantOro;
    [SerializeField]
    private Text cantPiedra;
    [SerializeField]
    private Text cantDocumento;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panelActivo = !panelActivo;
        }
        if (panelActivo == true)
        {
            panelRecursos.GetComponent<Animator>().SetBool("PanelRecursos", true);
        }
        else
        {
            panelRecursos.GetComponent<Animator>().SetBool("PanelRecursos", false);

        }
        cantOro.text = Oro.ToString();
        cantPiedra.text = Piedra.ToString();
        cantDocumento.text = Documento.ToString();
    }

}
