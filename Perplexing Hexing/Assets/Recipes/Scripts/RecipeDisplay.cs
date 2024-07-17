using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDisplay : MonoBehaviour
{
    public Recipe RecipeData;

    [SerializeField]
    public TextMeshProUGUI m_title, m_cookState, m_color;
    public GameObject IngredientsContainer;
    public GameObject IngredientDisplayPrefab;
    private Image m_vialStamp;
    private Scroll m_scroll;

    public Sprite[] VialStamps;


    private void Start()
    {
        RecipeData.Activate();
        m_scroll = GetComponentInParent<Scroll>();
        m_title.text = RecipeData.Title;
        m_cookState.text = RecipeData.cookState.ToString();
        m_color.text = RecipeData.Color + " Cauldron";
        m_vialStamp = GetComponentInChildren<Image>();
        SetImage();
        for(int i = 0; i < RecipeData.Ingredients.Count; i++)
        {
            GameObject ingredientText = Instantiate(IngredientDisplayPrefab, IngredientsContainer.transform);
            TextMeshProUGUI text = ingredientText.GetComponent<TextMeshProUGUI>();
            text.text = RecipeData.Ingredients[i];
            m_scroll.AddIngredient(text);
        }
    }

    private void SetImage()
    {
        
        switch(RecipeData.vialType)
        {
            default:
                break;
            case VialType.Standard:
                m_vialStamp.sprite = VialStamps[0];
                break;
            case VialType.Inverted:
                m_vialStamp.sprite = VialStamps[1];
                break;
            case VialType.Round:
                m_vialStamp.sprite = VialStamps[2];
                break;
        }
    }
}
