using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SALIR : MonoBehaviour
{
    public void Salir(string Ciudad)
    {
        SceneManager.LoadScene(1);
    }
}
