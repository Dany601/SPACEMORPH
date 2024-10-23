using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public int monedas = 0;  // Monedas acumuladas por el jugador
    public int vidas = 10;

    [Header("TextosUI")]
    public TextMeshProUGUI monedastxt;  // Texto que muestra las monedas en la UI

    private void Update()
    {
        monedastxt.text = "MONEDAS: " + monedas.ToString();
    }

    // Método para añadir monedas
    public void AddCoin(int amount)
    {
        monedas += amount;
        UpdateCoinUI();  // Actualiza el texto de monedas en la UI
    }

    // Método para restar monedas
    public void SubtractCoin(int amount)
    {
        monedas -= amount;
        UpdateCoinUI();  // Actualiza el texto de monedas en la UI
    }

    // Método para verificar si tienes suficientes monedas
    public bool HasEnoughCoins(int requiredCoins)
    {
        return monedas >= requiredCoins;
    }

    // Método para actualizar el texto de monedas en la UI
    private void UpdateCoinUI()
    {
        monedastxt.text = "MONEDAS: " + monedas.ToString();
    }
}

