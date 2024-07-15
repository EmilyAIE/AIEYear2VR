using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeDisplay : MonoBehaviour
{
    public Recipe RecipeData;

    [SerializeField]
    public TextMeshProUGUI m_title, m_cookState, m_color;
    public GameObject IngredientsContainer;
    public GameObject IngredientDisplayPrefab; 

    private void Start()
    {
        RecipeData.Activate();
        m_title.text = RecipeData.Title;
        m_cookState.text = RecipeData.cookState.ToString();
        m_color.text = RecipeData.Color;        

        for(int i = 0; i < RecipeData.Ingredients.Count; i++)
        {
            GameObject ingredientText = Instantiate(IngredientDisplayPrefab, IngredientsContainer.transform);
            ingredientText.GetComponent<TextMeshProUGUI>().text = RecipeData.Ingredients[i];
        }
    }
}
