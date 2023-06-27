using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    private List<DragDrop> ingredients = new List<DragDrop>();
    private PriceManager priceManager;
    private Vector3 ingredientScale;
    private SliderObjects sliderObjects; // Reference to the SliderObjects script

    private void Start()
    {
        priceManager = FindObjectOfType<PriceManager>();
        sliderObjects = FindObjectOfType<SliderObjects>(); // Assign the reference to the SliderObjects script
    }

    public void AddIngredient(DragDrop ingredient)
    {
        ingredient.transform.SetParent(transform, false); // Attach the ingredient to the plate

        // Calculate the offset based on the ingredient count
        int ingredientCount = ingredients.Count;
        float offsetX = ingredientCount * 0.3f; // Adjust the offset as desired

        // Update the ingredient's position on the plate
        ingredient.transform.localPosition = new Vector3(offsetX, 0f, 0f);

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

            // Call the method to update the ingredient visibility based on the slider value
            if (sliderObjects != null)
            {


            }
        }
    }
}