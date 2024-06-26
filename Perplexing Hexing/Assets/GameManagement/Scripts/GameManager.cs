using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    private float m_timer = 0;
    [SerializeField]
    private float m_recipeSpawnDelay;
    public Vector3 RecipeFaceDirection;

    [Header("Green Recipes")]
    public Cauldron GreenCauldron;
    [SerializeField]
    GameObject m_greenRecipeSpawnPos;
    public List<GameObject> GreenRecipePrefabs;
    private GameObject m_activeGreenRecipe;    
    

    [Header("Purple Recipes")]
    public Cauldron PurpleCauldron;
    [SerializeField]
    GameObject m_purpleRecipeSpawnPos;
    public List<GameObject> PurpleRecipePrefabs;
    private GameObject m_activePurpleRecipe;    
    

    [Header("Amber Recipes")]
    public Cauldron AmberCauldron;
    [SerializeField]
    GameObject m_amberRecipeSpawnPos;
    public List<GameObject> AmberRecipePrefabs;
    private GameObject m_activeAmberRecipe;    
    

    private bool m_allColorsActive = false;

    private List<string> m_activeColors = new List<string> { };
    private List<string> m_inactiveColors = new List<string> { "Green", "Purple", "Amber" };

    float Timer = 0;
    public void Update()
    {         
        if(!m_allColorsActive)
        {
            m_timer += Time.deltaTime;           
            if(m_timer > m_recipeSpawnDelay)
            {
                m_timer = 0;
                GenerateRecipe(SelectRecipeColor());
                if (m_activeColors.Count == 3)
                    m_allColorsActive = true;
            }
        }
    }

    public void GenerateRecipe(string color)
    {
        switch(color)
        {
            default:
                break;
            case "Green":
                int randomSelectG = Random.Range(0, GreenRecipePrefabs.Count);
                m_activeGreenRecipe = Instantiate(GreenRecipePrefabs[randomSelectG], m_greenRecipeSpawnPos.transform.position, Quaternion.Euler(RecipeFaceDirection));
                Recipe recipeG = m_activeGreenRecipe.GetComponentInChildren<RecipeDisplay>().RecipeData;
                GreenCauldron.GetRecipe(recipeG);
                break;
            case "Purple":
                int randomSelectP = Random.Range(0, PurpleRecipePrefabs.Count);
                m_activePurpleRecipe = Instantiate(PurpleRecipePrefabs[randomSelectP], m_purpleRecipeSpawnPos.transform.position, Quaternion.Euler(RecipeFaceDirection));
                Recipe recipeP = m_activePurpleRecipe.GetComponentInChildren<RecipeDisplay>().RecipeData;
                PurpleCauldron.GetRecipe(recipeP);
                break;
            case "Amber":
                int randomSelectA = Random.Range(0, AmberRecipePrefabs.Count);
                m_activeAmberRecipe = Instantiate(AmberRecipePrefabs[randomSelectA], m_amberRecipeSpawnPos.transform.position, Quaternion.Euler(RecipeFaceDirection));
                Recipe recipeA = m_activeAmberRecipe.GetComponentInChildren<RecipeDisplay>().RecipeData;
                AmberCauldron.GetRecipe(recipeA);  
                break;
        }
    }

    public void RemoveCurrentRecipe(string color)
    {
        if (m_allColorsActive)
            m_allColorsActive = false;

        switch (color)
        {
            default:
                return;
            case "Green":
                Destroy(m_activeGreenRecipe);
                m_activeColors.Remove(color);
                m_inactiveColors.Add(color);
                break;
            case "Purple":
                Destroy(m_activePurpleRecipe);
                m_activeColors.Remove(color);
                m_inactiveColors.Add(color);
                break;
            case "Amber":
                Destroy(m_activeAmberRecipe);
                m_activeColors.Remove(color);
                m_inactiveColors.Add(color);
                break;
        }        
    }

    public string SelectRecipeColor()
    {
        string color;
        int randomInt = Random.Range(0, m_inactiveColors.Count);
        color = m_inactiveColors[randomInt];
        m_inactiveColors.RemoveAt(randomInt);
        m_activeColors.Add(color);
                
        return color;
    }
}
