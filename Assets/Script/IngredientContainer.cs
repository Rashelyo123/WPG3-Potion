
using UnityEngine;

public class IngredientContainer : MonoBehaviour
{
    public IngredientSO ingredient;

    public IngredientSO TakeIngredient()
    {
        IngredientSO takenIngredient = ingredient;
        ingredient = null; // Kosongkan setelah bahan diambil
        Debug.Log("Mengambil " + takenIngredient.ingredientName);
        return takenIngredient;
    }
}
