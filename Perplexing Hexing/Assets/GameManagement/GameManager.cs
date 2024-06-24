using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    private float m_timer;
    [SerializeField]
    public float m_recipeSpawnDelay;
    public Vector3 RecipeFaceDirection;

    [Header("Green Recipes")]
    public Cauldron GreenCauldron;
    public List<GameObject> GreenRecipePrefabs;
    private GameObject m_activeGreenRecipe;    
    [SerializeField]
    Vector3 m_greenRecipeSpawnPos;

    [Header("Purple Recipes")]
    public Cauldron PurpleCauldron;
    public List<GameObject> PurpleRecipePrefabs;
    private GameObject m_activePurpleRecipe;    
    [SerializeField]
    Vector3 m_purpleRecipeSpawnPos;

    [Header("Amber Recipes")]
    public Cauldron AmberCauldron;
    public List<GameObject> AmberRecipePrefabs;
    private GameObject m_activeAmberRecipe;    
    [SerializeField]
    Vector3 m_amberRecipeSpawnPos;

    private bool m_allColorsActive = false;

    private List<string> m_activeColors = new List<string> { };
    private List<string> m_inactiveColors = new List<string> { "Green", "Purple", "Amber" };


    public void Update()
    {
        while(!m_allColorsActive)
        {
            m_timer += Time.deltaTime;
            if(m_timer >= m_recipeSpawnDelay)
            {
                GenerateRecipe(SelectRecipeColor());
                m_timer = 0;
                if(m_inactiveColors.Count == 0)
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
                m_activeGreenRecipe = Instantiate(GreenRecipePrefabs[randomSelectG], m_greenRecipeSpawnPos, Quaternion.Euler(RecipeFaceDirection));
                Recipe recipeG = m_activeGreenRecipe.GetComponent<Recipe>();
                GreenCauldron.GetRecipe(recipeG);
                break;
            case "Purple":
                int randomSelectP = Random.Range(0, PurpleRecipePrefabs.Count);
                m_activePurpleRecipe = Instantiate(PurpleRecipePrefabs[randomSelectP], m_purpleRecipeSpawnPos, Quaternion.Euler(RecipeFaceDirection));
                Recipe recipeP = m_activePurpleRecipe.GetComponent<Recipe>();
                PurpleCauldron.GetRecipe(recipeP);
                break;
            case "Amber":
                int randomSelectA = Random.Range(0, AmberRecipePrefabs.Count);
                m_activeAmberRecipe = Instantiate(AmberRecipePrefabs[randomSelectA], m_amberRecipeSpawnPos, Quaternion.Euler(RecipeFaceDirection));
                Recipe recipeA = m_activeAmberRecipe.GetComponent<Recipe>();
                AmberCauldron.GetRecipe(recipeA);  
                break;
        }
    }

    public void RemoveCurrentRecipe(string color)
    {
        if(m_allColorsActive)

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
        m_activeColors.Add(color);
        m_inactiveColors.Remove(color);
        return color;
    }
}
