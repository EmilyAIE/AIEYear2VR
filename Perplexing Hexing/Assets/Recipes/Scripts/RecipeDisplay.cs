using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeDisplay : MonoBehaviour
{
    public Recipe m_recipeData;

    [SerializeField]
    public TextMeshProUGUI m_title, m_cookState, m_color;
    public GameObject IngredientsContainer;
    public GameObject IngredientDisplayPrefab; 

    private void Start()
    {        
        m_title.text = m_recipeData.Title;
        m_cookState.text = "Duration: " + m_recipeData.CookState.ToString();
        m_color.text = "Colour: " + m_recipeData.Color;

        for(int i = 0; i < m_recipeData.Ingredients.Count; i++)
        {
            GameObject ingredientText = Instantiate(IngredientDisplayPrefab, IngredientsContainer.transform);
            ingredientText.GetComponent<TextMeshProUGUI>().text = "Ingredient " + (i + 1) + ": " + m_recipeData.Ingredients[i];
        }
    }
}
