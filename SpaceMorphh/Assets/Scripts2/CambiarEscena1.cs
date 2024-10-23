using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena1 : MonoBehaviour
{
    public string ApartamentoNoVis;  // Nombre de la escena a cargar
    public int monedasNecesarias = 10;  // N�mero de monedas necesarias
    private Stats stats;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();  // Encuentra el componente Stats
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Aseg�rate de que el objeto con el que colisionas sea el jugador
        {
            // Verifica si el jugador tiene suficientes monedas
            if (stats.monedas >= monedasNecesarias)
            {
                // Descontar monedas
                stats.monedas -= monedasNecesarias;
                // Cargar la escena
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("No tienes suficientes monedas para entrar.");
                // Aqu� podr�as mostrar un mensaje o ventana de advertencia.
            }
        }
    }
}