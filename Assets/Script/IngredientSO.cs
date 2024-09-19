using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Potion Crafting/Ingredient")]
public class IngredientSO : ScriptableObject
{
    public string ingredientName;
    public Sprite icon; // Untuk menampilkan gambar bahan di UI jika diperlukan
}
