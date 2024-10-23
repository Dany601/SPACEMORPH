using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelAccess : MonoBehaviour
{
    public int requiredCoins;  // Monedas necesarias para acceder al nivel
    public string Ciudad;   // Nombre de la escena a cargar
    public TextMeshProUGUI messageText;  // Texto de mensaje en la UI

    private Stats playerStats;  // Referencia al script de Stats

    private void Start()
    {
        // Buscar el script Stats en la escena (puede estar en un objeto "Jugador")
        playerStats = FindObjectOfType<Stats>();
    }

    // Este método debe estar asignado al botón "Canjear"
    public void TryEnterLevel()
    {
        // Verificamos si el jugador tiene suficientes monedas
        if (playerStats.HasEnoughCoins(requiredCoins))
        {
            // Resta las monedas necesarias
            playerStats.SubtractCoin(requiredCoins);

            // Cargar la escena del nivel
            SceneManager.LoadScene(Ciudad);
        }
        else
        {
            // Mostrar mensaje de que no hay suficientes monedas
            messageText.text = "No tienes suficientes monedas para entrar. ¡Sigue recogiendo!";
        }
    }
}
