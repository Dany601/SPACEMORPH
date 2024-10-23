using UnityEngine;
using TMPro; // Importar TextMeshPro

public class BudgetManager : MonoBehaviour
{
    public int totalBudget = 1000; // Presupuesto total inicial
    public TextMeshProUGUI currentBudgetText; // Texto en UI que muestra el presupuesto actual
    public TextMeshProUGUI budgetLimitText; // Texto en UI que muestra el l�mite del presupuesto

    private int currentSpent = 0; // Lo que ya se ha gastado

    void Start()
    {
        UpdateBudgetUI();
    }

    // M�todo para a�adir costo al presupuesto
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

    // M�todo para actualizar el UI del presupuesto
    void UpdateBudgetUI()
    {
        currentBudgetText.text = "Gasto actual: $" + currentSpent;
        budgetLimitText.text = "Presupuesto total: $" + totalBudget;
    }

    // M�todo que se llamar� al finalizar la compra
    public void FinalizePurchase()
    {
        Debug.Log("Compra finalizada. Total gastado: $" + currentSpent);
        // Aqu� puedes cargar la siguiente escena
        UnityEngine.SceneManagement.SceneManager.LoadScene("NextLevelScene"); // Aseg�rate de que el nombre coincida con el de la escena
    }
}

