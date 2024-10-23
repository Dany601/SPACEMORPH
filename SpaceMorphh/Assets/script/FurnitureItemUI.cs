using UnityEngine;
using UnityEngine.UI;

public class FurnitureItemUI : MonoBehaviour
{
    public int furnitureCost; // Costo del mueble
    public Button furnitureButton; // El botón asociado al mueble
    private BudgetManager budgetManager;

    void Start()
    {
        // Obtener el BudgetManager en la escena
        budgetManager = FindObjectOfType<BudgetManager>();

        // Asignar el evento al botón
        furnitureButton.onClick.AddListener(AddFurniture);
    }

    void AddFurniture()
    {
        // Verificar si se puede añadir el mueble al presupuesto
        if (budgetManager.AddToBudget(furnitureCost))
        {
            Debug.Log("Mueble añadido. Costo: $" + furnitureCost);
            // Aquí puedes añadir la lógica para colocar el mueble en la escena
        }
        else
        {
            Debug.Log("No hay suficiente presupuesto para este mueble.");
        }
    }
}

