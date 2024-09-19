using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Cauldron : MonoBehaviour
{
    private List<IngredientSO> addedIngredients = new List<IngredientSO>();
    public RecipeSO healingPotionRecipe;

    public void AddIngredient(IngredientSO ingredient)
    {
        addedIngredients.Add(ingredient);
        Debug.Log("Menambahkan " + ingredient.ingredientName + " ke dalam cauldron");

        if (CheckRecipeComplete())
        {
            Debug.Log("Resep lengkap, mulai mengaduk...");
            StartCoroutine(MixPotion());
        }
        else
        {
            Debug.Log("Resep belum lengkap, menunggu bahan lain...");
        }
    }


    private bool CheckRecipeComplete()
    {
        bool hasLifeleafPowder = addedIngredients.Exists(ing => ing.ingredientName == "Lifeleaf Powder");
        bool hasTwistingMushroom = addedIngredients.Exists(ing => ing.ingredientName == "Twisting Mushroom");
        return hasLifeleafPowder && hasTwistingMushroom;
    }

    private IEnumerator MixPotion()
    {
        Debug.Log("Mulai mengaduk potion...");
        yield return new WaitForSeconds(healingPotionRecipe.craftingTime);
        Debug.Log("Selesai mengaduk potion, membuat potion...");
        CreatePotion();
    }

    private void CreatePotion()
    {

        Debug.Log("Healing Potion Created!");
        Instantiate(healingPotionRecipe.potionPrefab, transform.position + Vector3.up, Quaternion.identity);
        addedIngredients.Clear();
    }
}
