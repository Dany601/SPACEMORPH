using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Script_Menu : MonoBehaviour
{
    public void EmpezarNivel(string NIVELES)
    {
        SceneManager.LoadScene(NIVELES);
    }
   public void Salir()
    {
        Application.Quit();
        Debug.Log("Cerrando sesion");
    }
}
