using UnityEngine;
using TMPro; // Importar TextMeshPro

public class BudgetManager : MonoBehaviour
{
    public int totalBudget = 1000; // Presupuesto total inicial
    public TextMeshProUGUI currentBudgetText; // Texto en UI que muestra el presupuesto actual
    public TextMeshProUGUI budgetLimitText; // Texto en UI que muestra el límite del presupuesto

    private int currentSpent = 0; // Lo que ya se ha gastado

    void Start()
    {
        UpdateBudgetUI();
    }

    // Método para añadir costo al presupuesto
    public bool AddToBudget(int cost)
    {
        if (currentSpent + cost <= totalBudget)
        {
            currentSpent += cost;
            UpdateBudgetUI();
            return true;
        }
        else
        {
            Debug.Log("No hay suficiente presupuesto");
            return false;
        }
    }

    // Método para actualizar el UI del presupuesto
    void UpdateBudgetUI()
    {
        currentBudgetText.text = "Gasto actual: $" + currentSpent;
        budgetLimitText.text = "Presupuesto total: $" + totalBudget;
    }

    // Método que se llamará al finalizar la compra
    public void FinalizePurchase()
    {
        Debug.Log("Compra finalizada. Total gastado: $" + currentSpent);
        // Aquí puedes cargar la siguiente escena
        UnityEngine.SceneManagement.SceneManager.LoadScene("NextLevelScene"); // Asegúrate de que el nombre coincida con el de la escena
    }
}

