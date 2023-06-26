using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    private List<DragDrop> ingredients = new List<DragDrop>();
    private PriceManager priceManager;
    private Vector3 ingredientScale;

    private void Start()
    {
        priceManager = FindObjectOfType<PriceManager>();
    }

    public void AddIngredient(DragDrop ingredient)
    {
        ingredient.transform.SetParent(transform, false); // Attach the ingredient to the plate

        // Update the ingredient's position and scale on the plate
        ingredient.transform.localPosition = Vector3.zero;
        ingredientScale = ingredient.transform.localScale;
        ingredient.transform.localScale = ingredientScale * 0.8f; // Adjust the size as desired

        ingredients.Add(ingredient); // Add the ingredient to the list

        // Update the price by +1
        if (priceManager != null)
        {
            priceManager.AddPrice(1f);
        }
    }

    public void RemoveIngredient(DragDrop ingredient)
    {
        if (ingredients.Contains(ingredient))
        {
            ingredients.Remove(ingredient); // Remove the ingredient from the list

            // Reset the ingredient's position and scale
            ingredient.transform.SetParent(ingredient.OriginalParent);
            ingredient.transform.localPosition = ingredient.StartPosition;
            ingredient.transform.localScale = ingredientScale;

            // Update the price by -1
            if (priceManager != null)
            {
                priceManager.AddPrice(-1f);
            }
        }
    }
}
