using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChallengeWindowManager : MonoBehaviour
{
    public int requiredCoins;  // Monedas necesarias para entrar al nivel (configurables en el Inspector)
    public string GridPlace;   // Nombre del nivel a cargar si tiene suficientes monedas
    public TextMeshProUGUI messageText;  // Texto para mostrar mensajes de error o �xito

    private Stats playerStats;  // Referencia al script Stats del jugador

    private void Start()
    {
        // Buscar el script Stats en el jugador (aseg�rate de que est� en la escena)
        playerStats = FindObjectOfType<Stats>();
    }

    // M�todo que se llama cuando se presiona el bot�n "Canjear"
    public void OnRedeemButtonPressed()
    {
        // Verifica si el jugador tiene suficientes monedas
        if (playerStats.HasEnoughCoins(requiredCoins))
        {
            // Restar las monedas necesarias
            playerStats.SubtractCoin(requiredCoins);

            // Cargar la siguiente escena (nivel)
            SceneManager.LoadScene(GridPlace);
        }
        else
        {
            // Mostrar un mensaje de advertencia
            messageText.text = "No tienes suficientes monedas para este nivel. �Sigue recogiendo!";
        }
    }

    // M�todo que se llama cuando se presiona el bot�n "Salir"
    public void OnExitButtonPressed()
    {
        // Cierra la ventana o vuelve al mapa
        SceneManager.LoadScene("Ciudad");  // Cambia "Mapa" por el nombre de tu escena principal
    }
}
