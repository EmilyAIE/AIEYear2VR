using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Pixelplacement;

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
    public Spline inGreen, outGreen;
    

    [Header("Purple Recipes")]
    public Cauldron PurpleCauldron;
    [SerializeField]
    GameObject m_purpleRecipeSpawnPos;
    public List<GameObject> PurpleRecipePrefabs;
    private GameObject m_activePurpleRecipe;
    public Spline inPurple, outPurple;


    [Header("Amber Recipes")]
    public Cauldron AmberCauldron;
    [SerializeField]
    GameObject m_amberRecipeSpawnPos;
    public List<GameObject> AmberRecipePrefabs;
    private GameObject m_activeAmberRecipe;
    public Spline inAmber, outAmber;

    private AudioSource m_audio;
    public AudioClip Bell;
    public AudioClip OpenDoor;
    public AudioClip Success;
    public AudioClip Fail;

    public Animator inDoorAnim;
    public Animator outDoorAnim;

    public Spline BoxSpline;

    private bool m_allColorsActive = false;
    private List<string> m_activeColors = new List<string> { };
    private List<string> m_inactiveColors = new List<string> { "Green", "Purple", "Amber" };

    public void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    public void Update()
    {         
        if(!m_allColorsActive)
        {
            m_timer += Time.deltaTime;           
            if(m_timer > m_recipeSpawnDelay)
            {
                m_timer = 0;
                GenerateRecipe(SelectRecipeColor());
                if (m_inactiveColors.Count == 0)
                    m_allColorsActive = true;
            }
        }
    }

    public void GenerateRecipe(string color)
    {
        m_audio.PlayOneShot(Bell);
        OpenInDoor();
        Invoke("CloseInDoor", 2);
        switch(color)
        {
            default:
                break;
            case "Green":
                int randomSelectG = Random.Range(0, GreenRecipePrefabs.Count);
                m_activeGreenRecipe = Instantiate(GreenRecipePrefabs[randomSelectG], m_greenRecipeSpawnPos.transform.position, Quaternion.Euler(RecipeFaceDirection));
                Recipe recipeG = m_activeGreenRecipe.GetComponentInChildren<RecipeDisplay>().RecipeData;
                GreenCauldron.GetRecipe(recipeG);
                m_activeGreenRecipe.GetComponent<Scroll>().SetSplines(inGreen, outGreen);
                break;
            case "Purple":
                int randomSelectP = Random.Range(0, PurpleRecipePrefabs.Count);
                m_activePurpleRecipe = Instantiate(PurpleRecipePrefabs[randomSelectP], m_purpleRecipeSpawnPos.transform.position, Quaternion.Euler(RecipeFaceDirection));
                Recipe recipeP = m_activePurpleRecipe.GetComponentInChildren<RecipeDisplay>().RecipeData;
                m_activePurpleRecipe.GetComponent<Scroll>().SetSplines(inPurple, outPurple);
                PurpleCauldron.GetRecipe(recipeP);
                break;
            case "Amber":
                int randomSelectA = Random.Range(0, AmberRecipePrefabs.Count);
                m_activeAmberRecipe = Instantiate(AmberRecipePrefabs[randomSelectA], m_amberRecipeSpawnPos.transform.position, Quaternion.Euler(RecipeFaceDirection));
                Recipe recipeA = m_activeAmberRecipe.GetComponentInChildren<RecipeDisplay>().RecipeData;
                m_activeAmberRecipe.GetComponent<Scroll>().SetSplines(inAmber, outAmber);
                AmberCauldron.GetRecipe(recipeA);  
                break;
        }
    }

    public void RemoveCurrentRecipe(string color)
    {
        if (m_allColorsActive)
            m_allColorsActive = false;
        OpenOutDoor();
        Invoke("CloseOutDoor", 1);
        switch (color)
        {
            default:
                return;
            case "Green":
                Scroll gScroll = m_activeGreenRecipe.GetComponentInParent<Scroll>();
                gScroll.ExitHutt();
                m_activeColors.Remove(color);
                m_inactiveColors.Add(color);                
                break;
            case "Purple":
                Scroll pScroll = m_activePurpleRecipe.GetComponentInParent<Scroll>();
                pScroll.ExitHutt();
                m_activeColors.Remove(color);
                m_inactiveColors.Add(color);                
                break;
            case "Amber":
                Scroll aScroll = m_activeAmberRecipe.GetComponentInParent<Scroll>();
                aScroll.ExitHutt();                
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

    public void OpenInDoor()
    {
        inDoorAnim.SetTrigger("OpenDoor");
    }

    public void CloseInDoor()
    {
        inDoorAnim.SetTrigger("CloseDoor");
    }

    public void OpenOutDoor()
    {
        outDoorAnim.SetTrigger("OpenDoor");
    }

    public void CloseOutDoor()
    {
        outDoorAnim.SetTrigger("CloseDoor");
    }
}
