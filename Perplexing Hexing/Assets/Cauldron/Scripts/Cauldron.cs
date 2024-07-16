using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class Cauldron : MonoBehaviour
{

    //CANVAS STUFF FOR DEBUGGING
    [SerializeField]
    TextMeshProUGUI m_ingredientListText;

    //Andrew's actual code
    float m_timer;
    [SerializeField]
    float m_cookStateDuration;
    AudioSource m_audioSource;    

    [SerializeField]
    GameObject m_liquid;    
    Renderer m_liquidRenderer;
    CauldronFlame m_flame;
    
    public GameObject FloatingIngredientsParent;

    public AudioClip PuffNoise;
    public AudioClip Explode;
    public AudioClip Splash;

    public enum Colours
    { 
        Green,
        Purple,
        Amber
    }
    public Colours Colour;

    [Header("Materials for Cooked State")]
    [SerializeField] Material m_default;
    [SerializeField] Material m_light;
    [SerializeField] Material m_medium;
    [SerializeField] Material m_wellDone;
           
    private CookState m_currentCookState;

    private Recipe m_activeRecipe;
    
    private List<string> m_currentIngredients = new List<string>();
    private List<string> m_targetIngredients = new List<string>();

    private bool m_isCooking;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_liquidRenderer = m_liquid.GetComponent<Renderer>();
        m_flame = GetComponentInChildren<CauldronFlame>();

        //DEBUGGING DELETE LATER
        //UpdateCookText();
    }

    private void Update()
    {
        if(m_isCooking)
        {
            m_timer += Time.deltaTime;
            if(m_timer >= m_cookStateDuration)
            {
                EnterCookState(m_currentCookState + 1);
                m_timer = 0;
            }
        }       
    }

    public void AddToMix(string ingredient)
    {
        m_currentIngredients.Add(ingredient);
        m_audioSource.PlayOneShot(Splash);
        UpdateCookText();
    }

    public void EnterCookState(CookState cookstate)
    {
        m_currentCookState = cookstate;
        switch(m_currentCookState)
        {
            default:
                break;
            case CookState.underCooked:                
                m_liquidRenderer.material = m_default;
                break;
            case CookState.light:
                m_audioSource.PlayOneShot(PuffNoise);
                m_liquidRenderer.material = m_light;
                break;
            case CookState.medium:
                m_audioSource.PlayOneShot(PuffNoise);
                m_liquidRenderer.material = m_medium;
                break;
            case CookState.wellDone:
                m_audioSource.PlayOneShot(PuffNoise);
                m_liquidRenderer.material = m_wellDone;
                break;
            case CookState.overCooked:
                m_audioSource.PlayOneShot(Explode);               
                m_liquidRenderer.material = m_default;
                StopCooking();
                
                break;
        }
        //UpdateCookText();
    }

    public void GetRecipe(Recipe recipe)
    {
        m_activeRecipe = recipe;
    }

    public bool CompareRecipe()
    {
        for(int i = 0; i < m_activeRecipe.Ingredients.Count; i++)
        {
            m_targetIngredients.Add(m_activeRecipe.Ingredients[i]);
        }        
        //if the cook state is incorrect, or if the number of ingredients is incorrect, recipe has failed
        if (m_activeRecipe.cookState != m_currentCookState)
        {
            Debug.Log("Incorrect Cook State");
            return false;
        }
        if (m_currentIngredients.Count != m_targetIngredients.Count)
        {
            Debug.Log("Incorrect Number of Ingredients");
            return false;
        }
        //Compare ingredients in cauldron to ingredients on recipe 
        for (int i = 0; i < m_currentIngredients.Count; i++)
        {
            for(int j = 0; j < m_targetIngredients.Count; j++)
            {
                if (m_currentIngredients[i] == m_targetIngredients[j])
                {
                    //if the ingredient is found in the target list, remove from target list and check next ingredient
                    m_targetIngredients.RemoveAt(j);
                    break;
                }
                //if the current ingredient cannot be found in the target ingredients list, the recipe has failed                
                else if (j == m_targetIngredients.Count - 1)
                {
                    Debug.Log("Incorrect Ingredient");
                    return false;
                }
                    
            }
        }
        //If there are ingredients left in the target ingredients list, the recipe has failed
        if(m_targetIngredients.Count > 0)
        {
            Debug.Log("Not Enough Ingredients");
            return false;
        }
        //if cauldron has not failed any checks, return true
        return true;
    }

    public void StartCooking()
    {
        m_isCooking = true;
        m_audioSource.Play();
    }

    public void StopCooking()
    {
        m_timer = 0;
        m_targetIngredients.Clear();
        m_currentIngredients.Clear();
        EnterCookState(CookState.underCooked);
        m_flame.StopCooking();
        m_isCooking = false;
        UpdateCookText();
    }

    public CookState GetCookState()
    {
        return m_currentCookState;
    }

    public void RemoveFloatIngredients()
    {
        foreach(GameObject gO in FloatingIngredientsParent.transform)
        {
            Destroy(gO);
        }
    }

    private void UpdateCookText()
    {
       //m_ingredientListText.text = "";
       //m_ingredientListText.text = "Current Cook state: " + m_currentCookState.ToString() + "\n";
       //m_ingredientListText.text += "Ingredients in pot:\n";
       //for (int i = 0; i < m_currentIngredients.Count; i++)
       //{
       //    m_ingredientListText.text += m_currentIngredients[i] + "\n";
       //}
    }
}
