using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Potion/Recipe")]
public class RecipeSO : ScriptableObject
{
    public string potionName;
    public IngredientSO[] ingredients; // Bahan-bahan yang dibutuhkan
    public GameObject potionPrefab;    // Prefab hasil potion
    public float craftingTime;         // Waktu yang dibutuhkan untuk membuat potion
}
