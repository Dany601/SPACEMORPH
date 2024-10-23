using UnityEngine;
using UnityEngine.UI;

public class FurnitureItemUI : MonoBehaviour
{
    public int furnitureCost; // Costo del mueble
    public Button furnitureButton; // El bot�n asociado al mueble
    private BudgetManager budgetManager;

    void Start()
    {
        // Obtener el BudgetManager en la escena
        budgetManager = FindObjectOfType<BudgetManager>();

        // Asignar el evento al bot�n
        furnitureButton.onClick.AddListener(AddFurniture);
    }

    void AddFurniture()
    {
        // Verificar si se puede a�adir el mueble al presupuesto
        if (budgetManager.AddToBudget(furnitureCost))
        {
            Debug.Log("Mueble a�adido. Costo: $" + furnitureCost);
            // Aqu� puedes a�adir la l�gica para colocar el mueble en la escena
        }
        else
        {
            Debug.Log("No hay suficiente presupuesto para este mueble.");
        }
    }
}

