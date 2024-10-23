using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts_Niveles : MonoBehaviour
{
    // Start is called before the first frame update
    public void RemodelarApartaestudio(string Apartaestudio)
    {
        SceneManager.LoadScene(Apartaestudio);
    }

    public void RemodelarApartamentoVis(string ApartamentoVis)
    {
        SceneManager.LoadScene(ApartamentoVis);
    }
    public void RemodelarApartamentoNoVis(string ApartamentoNoVis)
    {
        SceneManager.LoadScene(ApartamentoNoVis);
    }
    public void RemodelarCasa(string Casa)
    {
        SceneManager.LoadScene(Casa);
    }
    public void jugar(string Ciudad)
    {
        SceneManager.LoadScene(Ciudad);
    }
    public void Salir(string MENU)
    {
        SceneManager.LoadScene(MENU);
    }
}
