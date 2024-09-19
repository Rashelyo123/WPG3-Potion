
using UnityEngine;

public class MortarAndPestle : MonoBehaviour
{
    public IngredientSO lifeleafPowder;

    public IngredientSO ProcessIngredient(IngredientSO ingredient)
    {
        if (ingredient.ingredientName == "Lifeleaf")
        {
            Debug.Log("Mengubah Lifeleaf menjadi Lifeleaf Powder");
            // Mengubah Lifeleaf menjadi Lifeleaf Powder
            return lifeleafPowder;
        }
        return ingredient;
    }
}
